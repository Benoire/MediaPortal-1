#region Copyright (C) 2005-2011 Team MediaPortal

// Copyright (C) 2005-2011 Team MediaPortal
// http://www.team-mediaportal.com
// 
// MediaPortal is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// MediaPortal is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with MediaPortal. If not, see <http://www.gnu.org/licenses/>.

#endregion

using System;
using System.Runtime.InteropServices;
using DirectShowLib;
using TvLibrary.Channels;
using TvLibrary.Interfaces;
using TvLibrary.Interfaces.Analyzer;
using TvLibrary.Interfaces.Device;

namespace TvLibrary.Implementations.DVB
{
  /// <summary>
  /// Implementation of <see cref="T:TvLibrary.Interfaces.ITVCard"/> which handles MediaPortal DVB-IP sources.
  /// </summary>
  public class TvCardDVBIP : TvCardDvbBase, ITVCard
  {
    #region variables

    private IBaseFilter _filterStreamSource = null;
    private int _sequenceNumber = -1;

    /// <summary>
    /// The source filter's default URL.
    /// </summary>
    protected string _defaultUrl;

    /// <summary>
    /// The CLSID/UUID for the source filter.
    /// </summary>
    protected Guid _sourceFilterGuid = Guid.Empty;

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="TvCardDVBIP"/> class.
    /// </summary>
    /// <param name="epgEvents">The EPG events interface.</param>
    /// <param name="device">The device.</param>
    /// <param name="sequenceNumber">A sequence number or index for this instance.</param>
    public TvCardDVBIP(IEpgEvents epgEvents, DsDevice device, int sequenceNumber)
      : base(epgEvents, device)
    {
      _tunerType = CardType.DvbIP;
      _defaultUrl = "udp://@0.0.0.0:1234";
      _sourceFilterGuid = new Guid(0xd3dd4c59, 0xd3a7, 0x4b82, 0x97, 0x27, 0x7b, 0x92, 0x03, 0xeb, 0x67, 0xc0);
      _idleMode = DeviceIdleMode.Stop;  // Pause graph not supported.

      _sequenceNumber = sequenceNumber;
      if (_sequenceNumber > 0)
      {
        _name += "_" + _sequenceNumber;
      }
    }

    #region graphbuilding

    /// <summary>
    /// Build the BDA filter graph.
    /// </summary>
    public override void BuildGraph()
    {
      Log.Log.Debug("TvCardDvbIp: BuildGraph()");
      try
      {
        if (_isDeviceInitialised)
        {
          Log.Log.Error("TvCardDvbIp: the graph is already built");
          throw new TvException("The graph is already built.");
        }

        _graphBuilder = (IFilterGraph2)new FilterGraph();
        _capBuilder = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
        _capBuilder.SetFiltergraph(_graphBuilder);
        _rotEntry = new DsROTEntry(_graphBuilder);

        _infTee = (IBaseFilter)new InfTee();
        int hr = _graphBuilder.AddFilter(_infTee, "Inf Tee");
        if (hr != 0)
        {
          Log.Log.Error("TvCardDvbIp: failed to add infinite tee, hr = 0x{0:x} ({1})", hr, HResult.GetDXErrorString(hr));
          throw new TvException("Failed to add infinite tee.");
        }

        AddTsWriterFilterToGraph();
        AddStreamSourceFilter(_defaultUrl);
        IBaseFilter lastFilter = _filterStreamSource;

        // Check for and load plugins, adding any additional device filters to the graph.
        LoadPlugins(_filterStreamSource, ref lastFilter);

        if (!ConnectTsWriter(lastFilter))
        {
          throw new TvExceptionGraphBuildingFailed("Failed to connect TS writer filter.");
        }

        // Open any plugins we found. This is separated from loading because some plugins can't be opened
        // until the graph has finished being built.
        OpenPlugins();

        _isDeviceInitialised = true;

        // Plugins can request to pause or start the device - other actions don't make sense here. The running
        // state is considered more compatible than the paused state, so start takes precedence.
        DeviceAction actualAction = DeviceAction.Default;
        foreach (ICustomDevice deviceInterface in _customDeviceInterfaces)
        {
          DeviceAction action;
          deviceInterface.OnInitialised(this, out action);
          if (action == DeviceAction.Pause)
          {
            if (actualAction == DeviceAction.Default)
            {
              Log.Log.Debug("TvCardDvbBase: plugin \"{0}\" will cause device pause", deviceInterface.Name);
              actualAction = DeviceAction.Pause;
            }
            else
            {
              Log.Log.Debug("TvCardDvbBase: plugin \"{0}\" wants to pause the device, overriden", deviceInterface.Name);
            }
          }
          else if (action == DeviceAction.Start)
          {
            Log.Log.Debug("TvCardDvbBase: plugin \"{0}\" will cause device start", deviceInterface.Name);
            actualAction = action;
          }
          else if (action != DeviceAction.Default)
          {
            Log.Log.Debug("TvCardDvbBase: plugin \"{0}\" wants unsupported action {1}", deviceInterface.Name, action);
          }
        }
        if (actualAction == DeviceAction.Start)
        {
          SetGraphState(FilterState.Running);
        }
        else if (actualAction == DeviceAction.Pause)
        {
          SetGraphState(FilterState.Paused);
        }
      }
      catch (Exception ex)
      {
        Log.Log.Write(ex);
        Dispose();
        _isDeviceInitialised = false;
        throw new TvExceptionGraphBuildingFailed("Graph building failed.", ex);
      }
    }

    /// <summary>
    /// Add the DVB-IP stream source filter to the BDA graph.
    /// </summary>
    /// <param name="url">url</param>
    protected virtual void AddStreamSourceFilter(string url)
    {
      Log.Log.WriteFile("TvCardDvbIp: add source filter");
      _filterStreamSource = FilterGraphTools.AddFilterFromClsid(_graphBuilder, _sourceFilterGuid,
                                                                "DVB-IP Source Filter");
      AMMediaType mpeg2ProgramStream = new AMMediaType();
      mpeg2ProgramStream.majorType = MediaType.Stream;
      mpeg2ProgramStream.subType = MediaSubType.Mpeg2Transport;
      mpeg2ProgramStream.unkPtr = IntPtr.Zero;
      mpeg2ProgramStream.sampleSize = 0;
      mpeg2ProgramStream.temporalCompression = false;
      mpeg2ProgramStream.fixedSizeSamples = true;
      mpeg2ProgramStream.formatType = FormatType.None;
      mpeg2ProgramStream.formatSize = 0;
      mpeg2ProgramStream.formatPtr = IntPtr.Zero;
      ((IFileSourceFilter)_filterStreamSource).Load(url, mpeg2ProgramStream);

      // Connect the source filter to the infinite tee.
      Log.Log.WriteFile("TvCardDvbIp: render [source]->[inf tee]");
      int hr = _capBuilder.RenderStream(null, null, _filterStreamSource, null, _infTee);
      if (hr != 0)
      {
        Log.Log.Error("TvCardDvbIp: failed to render stream, hr = 0x{0:x} ({1})", hr, HResult.GetDXErrorString(hr));
        throw new TvException("Failed to render stream.");
      }
    }

    /// <summary>
    /// Remove the DVB-IP stream source filter from the BDA graph.
    /// </summary>
    protected virtual void RemoveStreamSourceFilter()
    {
      Log.Log.WriteFile("TvCardDvbIp: remove source filter");
      if (_filterStreamSource != null)
      {
        if (_graphBuilder != null)
        {
          _graphBuilder.RemoveFilter(_filterStreamSource);
        }
        Release.ComObject("DVB-IP Source Filter", _filterStreamSource);
        _filterStreamSource = null;
      }
    }

    #endregion

    #region tuning & scanning

    /// <summary>
    /// Actually tune to a channel.
    /// </summary>
    /// <param name="channel">The channel to tune to.</param>
    protected override void PerformTuning(IChannel channel)
    {
      DVBIPChannel dvbipChannel = channel as DVBIPChannel;
      if (dvbipChannel == null)
      {
        throw new TvException("TvCardDvbIp: channel is not a DVB-IP channel!!! " + channel.GetType().ToString());
      }

      if (_useCustomTuning)
      {
        foreach (ICustomDevice deviceInterface in _customDeviceInterfaces)
        {
          ICustomTuner customTuner = deviceInterface as ICustomTuner;
          if (customTuner != null && customTuner.CanTuneChannel(channel))
          {
            Log.Log.Debug("TvCardDvbIp: using custom tuning");
            if (!customTuner.Tune(channel))
            {
              throw new TvException("TvCardDvbIp: failed to tune to channel");
            }
            break;
          }
        }
      }

      // DVB-IP "tuning" (if there is such a thing) occurs during this stage of the process. We stop the
      // graph, then replace the stream source filter with a new filter that is configured to stream from
      // the appropriate URL.
      Log.Log.Debug("TvCardDvbIp: using default tuning");
      SetGraphState(FilterState.Stopped);
      RemoveStreamSourceFilter();
      AddStreamSourceFilter(dvbipChannel.Url);
    }

    /// <summary>
    /// Check if the tuner can tune to a specific channel.
    /// </summary>
    /// <param name="channel">The channel to check.</param>
    /// <returns><c>true</c> if the tuner can tune to the channel, otherwise <c>false</c></returns>
    public override bool CanTune(IChannel channel)
    {
      if (channel is DVBIPChannel)
      {
        return true;
      }
      return false;
    }

    /// <summary>
    /// Get the device's channel scanning interface.
    /// </summary>
    public override ITVScanning ScanningInterface
    {
      get
      {
        if (!CheckThreadId())
        {
          return null;
        }
        return new DVBIPScanning(this);
      }
    }

    #endregion

    /// <summary>
    /// Dispose resources
    /// </summary>
    public override void Dispose()
    {
      base.Dispose();
      RemoveStreamSourceFilter();
    }

    /// <summary>
    /// Stop the device. The actual result of this function depends on device configuration:
    /// - graph stop
    /// - graph pause
    /// TODO graph destroy
    /// </summary>
    public override void Stop()
    {
      base.Stop();
      // TODO: fix me. This logic should be checked (removing and adding filters in stop?) (morpheus_xx)
      if (_isDeviceInitialised)
      {
        RemoveStreamSourceFilter();
        AddStreamSourceFilter(_defaultUrl);
      }
    }

    /// <summary>
    /// Update the tuner signal status statistics.
    /// </summary>
    protected override void UpdateSignalStatus()
    {
      if (GraphRunning() == false ||
        CurrentChannel == null ||
        _filterStreamSource == null ||
        !CheckThreadId())
      {
        _tunerLocked = false;
        _signalLevel = 0;
        _signalPresent = false;
        _signalQuality = 0;
        return;
      }
      _tunerLocked = true;
      _signalLevel = 100;
      _signalPresent = true;
      _signalQuality = 100;
    }

    /// <summary>
    /// return the DevicePath
    /// </summary>
    public override string DevicePath
    {
      get
      {
        if (_sequenceNumber == 0)
        {
          return base.DevicePath;
        }
        return base.DevicePath + "(" + _sequenceNumber + ")";
      }
    }
  }
}
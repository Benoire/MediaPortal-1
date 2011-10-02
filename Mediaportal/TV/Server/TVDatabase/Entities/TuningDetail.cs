//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Mediaportal.TV.Server.TVDatabase.Entities
{
    public partial class TuningDetail
    {
        #region Primitive Properties
    
        public virtual int idTuning
        {
            get;
            set;
        }
    
        public virtual int idChannel
        {
            get { return _idChannel; }
            set
            {
                if (_idChannel != value)
                {
                    if (Channel != null && Channel.idChannel != value)
                    {
                        Channel = null;
                    }
                    _idChannel = value;
                }
            }
        }
        private int _idChannel;
    
        public virtual string name
        {
            get;
            set;
        }
    
        public virtual string provider
        {
            get;
            set;
        }
    
        public virtual int channelType
        {
            get;
            set;
        }
    
        public virtual int channelNumber
        {
            get;
            set;
        }
    
        public virtual int frequency
        {
            get;
            set;
        }
    
        public virtual int countryId
        {
            get;
            set;
        }
    
        public virtual bool isRadio
        {
            get;
            set;
        }
    
        public virtual bool isTv
        {
            get;
            set;
        }
    
        public virtual int networkId
        {
            get;
            set;
        }
    
        public virtual int transportId
        {
            get;
            set;
        }
    
        public virtual int serviceId
        {
            get;
            set;
        }
    
        public virtual int pmtPid
        {
            get;
            set;
        }
    
        public virtual bool freeToAir
        {
            get;
            set;
        }
    
        public virtual int modulation
        {
            get;
            set;
        }
    
        public virtual int polarisation
        {
            get;
            set;
        }
    
        public virtual int symbolrate
        {
            get;
            set;
        }
    
        public virtual int diseqc
        {
            get;
            set;
        }
    
        public virtual int switchingFrequency
        {
            get;
            set;
        }
    
        public virtual int bandwidth
        {
            get;
            set;
        }
    
        public virtual int majorChannel
        {
            get;
            set;
        }
    
        public virtual int minorChannel
        {
            get;
            set;
        }
    
        public virtual int videoSource
        {
            get;
            set;
        }
    
        public virtual int tuningSource
        {
            get;
            set;
        }
    
        public virtual int band
        {
            get;
            set;
        }
    
        public virtual int satIndex
        {
            get;
            set;
        }
    
        public virtual int innerFecRate
        {
            get;
            set;
        }
    
        public virtual int pilot
        {
            get;
            set;
        }
    
        public virtual int rollOff
        {
            get;
            set;
        }
    
        public virtual string url
        {
            get;
            set;
        }
    
        public virtual int bitrate
        {
            get;
            set;
        }
    
        public virtual int audioSource
        {
            get;
            set;
        }
    
        public virtual bool isVCRSignal
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual Channel Channel
        {
            get { return _channel; }
            set
            {
                if (!ReferenceEquals(_channel, value))
                {
                    var previousValue = _channel;
                    _channel = value;
                    FixupChannel(previousValue);
                }
            }
        }
        private Channel _channel;

        #endregion
        #region Association Fixup
    
        private void FixupChannel(Channel previousValue)
        {
            if (previousValue != null && previousValue.TuningDetails.Contains(this))
            {
                previousValue.TuningDetails.Remove(this);
            }
    
            if (Channel != null)
            {
                if (!Channel.TuningDetails.Contains(this))
                {
                    Channel.TuningDetails.Add(this);
                }
                if (idChannel != Channel.idChannel)
                {
                    idChannel = Channel.idChannel;
                }
            }
        }

        #endregion
    }
}

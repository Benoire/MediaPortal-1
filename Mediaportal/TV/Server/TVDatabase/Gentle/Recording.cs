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
using System.Collections.Generic;
using Gentle.Framework;
using Mediaportal.TV.Server.TVDatabase.Gentle.Enums;
using Mediaportal.TV.Server.TVLibrary.Interfaces.Logging;

namespace Mediaportal.TV.Server.TVDatabase.Gentle
{
  /// <summary>
  /// Instances of this class represent the properties and methods of a row in the table <b>Recording</b>.
  /// </summary>
  [TableName("Recording")]
  [Serializable]
  public class Recording : Persistent
  {
    #region Members

    private bool isChanged;
    [TableColumn("idRecording", NotNull = true), PrimaryKey(AutoGenerated = true)] private int idRecording;
    [TableColumn("idChannel", NotNull = true), ForeignKey("Channel", "idChannel")] private int idChannel;
    [TableColumn("idSchedule", NotNull = true), ForeignKey("Schedule", "idSchedule")] private int idSchedule;

    [TableColumn("mediaType", NotNull = true)] private int mediaType;

    [TableColumn("isRecording", NotNull = false)] private bool isRecording;
    [TableColumn("startTime", NotNull = true)] private DateTime startTime;
    [TableColumn("endTime", NotNull = true)] private DateTime endTime;
    [TableColumn("title", NotNull = true)] private string title;
    [TableColumn("description", NotNull = true)] private string description;
    [TableColumn("genre", NotNull = true)] private string genre;
    [TableColumn("fileName", NotNull = true)] private string fileName;
    [TableColumn("keepUntil", NotNull = true)] private int keepUntil;
    [TableColumn("keepUntilDate", NotNull = true)] private DateTime keepUntilDate;
    [TableColumn("timesWatched", NotNull = true)] private int timesWatched;
    [TableColumn("idServer", NotNull = true), ForeignKey("Server", "idServer")] private int idServer;
    // stores the last position - to make resume possible
    [TableColumn("stopTime", NotNull = true)] private int stopTime;
    [TableColumn("episodeName", NotNull = true)] private string episodeName;
    [TableColumn("seriesNum", NotNull = true)] private string seriesNum;
    [TableColumn("episodeNum", NotNull = true)] private string episodeNum;
    [TableColumn("episodePart", NotNull = true)] private string episodePart;

    #endregion

    #region Constructors

    /// <summary> 
    /// Create a new object by specifying all fields (except the auto-generated primary key field). 
    /// </summary> 
    public Recording(int idChannel, int idSchedule, bool isRecording, DateTime startTime, DateTime endTime, string title,
                     string description, string genre,
                     string fileName, int keepUntil, DateTime keepUntilDate, int timesWatched, int idServer,
                     string episodeName,
                     string seriesNum, string episodeNum, string episodePart, int mediaType)
    {
      this.mediaType = mediaType;
      isChanged = true;
      this.idChannel = idChannel;
      this.isRecording = isRecording;
      this.idSchedule = idSchedule;
      this.startTime = startTime;
      this.endTime = endTime;
      this.title = title;
      this.description = description;
      this.genre = genre;
      this.fileName = fileName;
      this.keepUntil = keepUntil;
      this.keepUntilDate = keepUntilDate;
      this.timesWatched = timesWatched;
      this.idServer = idServer;
      stopTime = 0;
      this.episodeName = episodeName;
      this.seriesNum = seriesNum;
      this.episodeNum = episodeNum;
      this.episodePart = episodePart;
    }
    
    /// <summary> 
    /// Create a new object by specifying all fields (except the auto-generated primary key field). 
    /// </summary> 
    public Recording(int idChannel, int idSchedule, bool isRecording, DateTime startTime, DateTime endTime, string title,
                     string description, string genre,
                     string fileName, int keepUntil, DateTime keepUntilDate, int timesWatched, int idServer,
                     string episodeName,
                     string seriesNum, string episodeNum, string episodePart)
    {
      isChanged = true;
      this.idChannel = idChannel;
      this.isRecording = isRecording;
      this.idSchedule = idSchedule;
      this.startTime = startTime;
      this.endTime = endTime;
      this.title = title;
      this.description = description;
      this.genre = genre;
      this.fileName = fileName;
      this.keepUntil = keepUntil;
      this.keepUntilDate = keepUntilDate;
      this.timesWatched = timesWatched;
      this.idServer = idServer;
      stopTime = 0;
      this.episodeName = episodeName;
      this.seriesNum = seriesNum;
      this.episodeNum = episodeNum;
      this.episodePart = episodePart;
    }

    /// <summary> 
    /// Create an object from an existing row of data. This will be used by Gentle to 
    /// construct objects from retrieved rows. 
    /// </summary> 
    public Recording(int idRecording, bool isRecording, int idSchedule, int idChannel, DateTime startTime,
                     DateTime endTime, string title,
                     string description, string genre, string fileName, int keepUntil, DateTime keepUntilDate,
                     int timesWatched, int idServer, int stopTime, string episodeName,
                     string seriesNum, string episodeNum, string episodePart)
    {
      this.idSchedule = idSchedule;
      this.idRecording = idRecording;
      this.isRecording = isRecording;
      this.idChannel = idChannel;
      this.startTime = startTime;
      this.endTime = endTime;
      this.title = title;
      this.description = description;
      this.genre = genre;
      this.fileName = fileName;
      this.keepUntil = keepUntil;
      this.keepUntilDate = keepUntilDate;
      this.timesWatched = timesWatched;
      this.idServer = idServer;
      this.stopTime = stopTime;
      this.episodeName = episodeName;
      this.seriesNum = seriesNum;
      this.episodeNum = episodeNum;
      this.episodePart = episodePart;
    }

    #endregion

    #region Public Properties

    public bool IsTV
    {
      get
      {
        return (mediaType == (int)MediaTypeEnum.TV);        
      }      
    }

    public bool IsRadio
    {
      get
      {
        return (mediaType == (int)MediaTypeEnum.Radio);        
      }
    }

    /// <summary>
    /// Is recording a manual one
    /// </summary>
    public bool IsManual
    {
      get { return (Title.Equals("manual")); }
    }

    /// <summary>
    /// Indicates whether the entity is changed and requires saving or not.
    /// </summary>
    public bool IsChanged
    {
      get { return isChanged; }
    }

    /// <summary>
    /// Property relating to database column idRecording
    /// </summary>
    public int IdRecording
    {
      get { return idRecording; }
    }

    /// <summary>
    /// Property relating to database column idChannel
    /// </summary>
    public int IdChannel
    {
      get { return idChannel; }
      set
      {
        isChanged |= idChannel != value;
        idChannel = value;
      }
    }

    /// <summary>
    /// Property relating to database column idSchedule
    /// </summary>
    public int Idschedule
    {
      get { return idSchedule; }
      set
      {
        isChanged |= idSchedule != value;
        idSchedule = value;
      }
    }

    /// <summary>
    /// Property relating to database column startTime
    /// </summary>
    public DateTime StartTime
    {
      get { return startTime; }
      set
      {
        isChanged |= startTime != value;
        startTime = value;
      }
    }

    /// <summary>
    /// Property relating to database column endTime
    /// </summary>
    public DateTime EndTime
    {
      get { return endTime; }
      set
      {
        isChanged |= endTime != value;
        endTime = value;
      }
    }

    /// <summary>
    /// Property relating to database column title
    /// </summary>
    public string Title
    {
      get { return title; }
      set
      {
        isChanged |= title != value;
        title = value;
      }
    }

    /// <summary>
    /// Property relating to database column description
    /// </summary>
    public string Description
    {
      get { return description; }
      set
      {
        isChanged |= description != value;
        description = value;
      }
    }

    /// <summary>
    /// Property relating to database column genre
    /// </summary>
    public string Genre
    {
      get { return genre; }
      set
      {
        isChanged |= genre != value;
        genre = value;
      }
    }

    /// <summary>
    /// Property relating to database column fileName
    /// </summary>
    public string FileName
    {
      get { return fileName; }
      set
      {
        isChanged |= fileName != value;
        fileName = value;
      }
    }

    /// <summary>
    /// Property relating to database column keepUntil
    /// </summary>
    public int KeepUntil
    {
      get { return keepUntil; }
      set
      {
        isChanged |= keepUntil != value;
        keepUntil = value;
      }
    }

    /// <summary>
    /// Property relating to database column keepUntilDate
    /// </summary>
    public DateTime KeepUntilDate
    {
      get { return keepUntilDate; }
      set
      {
        isChanged |= keepUntilDate != value;
        keepUntilDate = value;
      }
    }

    /// <summary>
    /// Property relating to database column timesWatched
    /// </summary>
    public int TimesWatched
    {
      get { return timesWatched; }
      set
      {
        isChanged |= timesWatched != value;
        timesWatched = value;
      }
    }

    /// <summary>
    /// Property relating to database column idServer
    /// </summary>
    public int IdServer
    {
      get { return idServer; }
      set
      {
        isChanged |= idServer != value;
        idServer = value;
      }
    }

    /// <summary>
    /// Property relating to database column stopTime
    /// </summary>
    public int StopTime
    {
      get { return stopTime; }
      set
      {
        isChanged |= stopTime != value;
        stopTime = value;
      }
    }

    /// <summary>
    /// Property relating to database column episodeName
    /// </summary>
    public string EpisodeName
    {
      get { return episodeName; }
      set
      {
        isChanged |= episodeName != value;
        episodeName = value;
      }
    }

    /// <summary>
    /// Property relating to database column serieNum
    /// </summary>
    public string SeriesNum
    {
      get { return seriesNum; }
      set
      {
        isChanged |= seriesNum != value;
        seriesNum = value;
      }
    }

    /// <summary>
    /// Property relating to database column episodeNum
    /// </summary>
    public string EpisodeNum
    {
      get { return episodeNum; }
      set
      {
        isChanged |= episodeNum != value;
        episodeNum = value;
      }
    }

    /// <summary>
    /// Property relating to database column episodePart
    /// </summary>
    public string EpisodePart
    {
      get { return episodePart; }
      set
      {
        isChanged |= episodePart != value;
        episodePart = value;
      }
    }

    /// <summary>
    /// Property relating to database column seriesNum, episodeNum and episodePart (readonly)
    /// </summary>
    public string EpisodeNumber
    {
      get { return EpisodeFormatter.GetEpisodeNumber(seriesNum, episodeNum, episodePart); }
    }


    /// <summary>
    /// Property relating to database column isRecording
    /// </summary>
    public bool IsRecording
    {
      get
      {
        //this.Refresh(); //slow
        return isRecording;
      }
      set
      {
        isChanged |= isRecording != value;
        isRecording = value;
      }
    }

    #endregion

    #region Storage and Retrieval
    /// <summary>
    /// Static method to retrieve all instances that are stored in the database in one call
    /// </summary>
    public static IList<Recording> ListAllRadio()
    {
      SqlBuilder sb = new SqlBuilder(StatementType.Select, typeof(Recording));
      sb.AddConstraint(Operator.Equals, "mediaType", (int)MediaTypeEnum.Radio);

      SqlStatement stmt = sb.GetStatement(true);

      // execute the statement/query and create a collection of User instances from the result set
      return ObjectFactory.GetCollection<Recording>(stmt.Execute());
    }

    /// <summary>
    /// Static method to retrieve all instances that are stored in the database in one call
    /// </summary>
    public static IList<Recording> ListAll()
    {
      return (List<Recording>)(Broker.RetrieveList<Recording>());
    }

    /// <summary>
    /// Static method to retrieve all instances that are stored in the database in one call
    /// </summary>
    public static IList<Recording> ListAllTv()
    {
      SqlBuilder sb = new SqlBuilder(StatementType.Select, typeof(Recording));
      sb.AddConstraint(Operator.Equals, "mediaType", (int)MediaTypeEnum.TV);

      SqlStatement stmt = sb.GetStatement(true);

      // execute the statement/query and create a collection of User instances from the result set
      return ObjectFactory.GetCollection<Recording>(stmt.Execute());

    }

    /// <summary>
    /// Static method to retrieve all instances that are stored in the database in one call
    /// </summary>
    public static void ResetActiveRecordings()
    {
      /*SqlBuilder sb = new SqlBuilder(StatementType.Update, typeof(Recording));
      sb.AddConstraint(Operator.Equals, "isRecording", false);

      SqlStatement stmt = sb.GetStatement(true);

      // execute the statement/query and create a collection of User instances from the result set
      return ObjectFactory.GetCollection<Recording>(stmt.Execute());
      */

      IList<Recording> activeRecordings = Recording.ListAllActive();

      foreach (Recording rec in activeRecordings)
      {
        rec.IsRecording = false;
        rec.Persist();
      }
    }

    public static Recording ActiveRecording(int idSchedule)
    {
      SqlBuilder sb = new SqlBuilder(StatementType.Select, typeof (Recording));
      sb.AddConstraint(Operator.Equals, "isRecording", true);
      sb.AddConstraint(Operator.Equals, "idSchedule", idSchedule);

      SqlStatement stmt = sb.GetStatement(true);

      // execute the statement/query and create a collection of User instances from the result set
      IList<Recording> getList = ObjectFactory.GetCollection<Recording>(stmt.Execute());
      if (getList.Count != 0)
      {
        return getList[0];
      }
      return null;
    }

    public static Recording ActiveRecording(string title, int idChannel)
    {
      SqlBuilder sb = new SqlBuilder(StatementType.Select, typeof (Recording));
      sb.AddConstraint(Operator.Equals, "isRecording", true);
      sb.AddConstraint(Operator.Equals, "title", title);
      sb.AddConstraint(Operator.Equals, "idChannel", idChannel);

      SqlStatement stmt = sb.GetStatement(true);

      // execute the statement/query and create a collection of User instances from the result set
      IList<Recording> getList = ObjectFactory.GetCollection<Recording>(stmt.Execute());
      if (getList.Count != 0)
      {
        return getList[0];
      }
      return null;
    }

    /// <summary>
    /// Static method to retrieve all instances that are stored in the database in one call
    /// </summary>
    public static IList<Recording> ListAllActive()
    {
      SqlBuilder sb = new SqlBuilder(StatementType.Select, typeof (Recording));
      sb.AddConstraint(Operator.Equals, "isRecording", true);

      SqlStatement stmt = sb.GetStatement(true);

      // execute the statement/query and create a collection of User instances from the result set
      return ObjectFactory.GetCollection<Recording>(stmt.Execute());
    }


    /// <summary>
    /// Refresh the recording
    /// </summary>
    public static Recording Refresh(int id)
    {
      // Return null if id is smaller than seed and/or increment for autokey
      if (id < 1)
      {
        return null;
      }
      Key key = new Key(typeof (Recording), true, "idRecording", id);

      Recording rec = Broker.TryRetrieveInstance<Recording>(key);

      if (rec != null)
      {
        Broker.Refresh(rec);
      }
      return rec;
    }

    /// <summary>
    /// Retrieves an entity given it's id.
    /// </summary>
    public static Recording Retrieve(int id)
    {
      // Return null if id is smaller than seed and/or increment for autokey
      if (id < 1)
      {
        return null;
      }
      Key key = new Key(typeof (Recording), true, "idRecording", id);

      return Broker.RetrieveInstance<Recording>(key);
    }

    /// <summary>
    /// Retrieves an entity given it's filename.
    /// </summary>
    public static Recording Retrieve(string fileName)
    {
      // Return null if id is smaller than seed and/or increment for autokey
      if (string.IsNullOrEmpty(fileName))
      {
        return null;
      }

      SqlBuilder sb = new SqlBuilder(StatementType.Select, typeof (Recording));
      sb.AddConstraint(Operator.Equals, "fileName", fileName);

      SqlStatement stmt = sb.GetStatement(true);

      // execute the statement/query and create a collection of User instances from the result set
      IList<Recording> getList = ObjectFactory.GetCollection<Recording>(stmt.Execute());
      if (getList.Count != 0)
      {
        return getList[0];
      }
      return null;
    }

    /// <summary>
    /// Retrieves an entity given it's id, using Gentle.Framework.Key class.
    /// This allows retrieval based on multi-column keys.
    /// </summary>
    public static Recording Retrieve(Key key)
    {
      return Broker.RetrieveInstance<Recording>(key);
    }

    /// <summary>
    /// Persists the entity if it was never persisted or was changed.
    /// </summary>
    public override void Persist()
    {
      if (IsChanged || !IsPersisted)
      {
        try
        {
          PersistMediaType();

          base.Persist();
        }
        catch (Exception ex)
        {
          Log.Error("Exception in Recording.Persist() with Message {0}", ex.Message);
          return;
        }
        isChanged = false;
      }
    }

    private void PersistMediaType() 
    {
      Channel refChannel = ReferencedChannel();
      if (refChannel.IsRadio)
      {
        mediaType = (int)MediaTypeEnum.Radio;
      }
      else if (refChannel.IsTv)
      {
        mediaType = (int)MediaTypeEnum.TV;
      }
    }

    #endregion

    #region Relations

    /// <summary>
    ///
    /// </summary>
    public Channel ReferencedChannel()
    {
      return Channel.Retrieve(IdChannel);
    }

    /// <summary>
    ///
    /// </summary>    
    public Schedule ReferencedSchedule()
    {
      return Schedule.Retrieve(Idschedule);
    }

    /// <summary>
    ///
    /// </summary>
    public Server ReferencedServer()
    {
      return Server.Retrieve(IdServer);
    }

    #endregion

    public bool ShouldBeDeleted
    {
      get
      {
        if (KeepUntil != (int)KeepMethodType.TillDate)
        {
          return false;
        }
        if (KeepUntilDate.Date > DateTime.Now.Date)
        {
          return false;
        }
        return true;
      }
    }

    public int MediaType
    {
      get { return mediaType; }
    }

    public void Delete()
    {
      Remove();
    }
  }
}
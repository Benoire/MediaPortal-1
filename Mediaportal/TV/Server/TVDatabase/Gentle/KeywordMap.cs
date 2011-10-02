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
using Mediaportal.TV.Server.TVLibrary.Interfaces.Logging;

namespace Mediaportal.TV.Server.TVDatabase.Gentle
{
  /// <summary>
  /// Instances of this class represent the properties and methods of a row in the table <b>KeywordMap</b>.
  /// Database used by PersonalTVGuide plugin
  /// </summary>
  [TableName("KeywordMap")]
  public class KeywordMap : Persistent
  {
    #region Members

    private bool isChanged;
    [TableColumn("idKeywordMap", NotNull = true), PrimaryKey(AutoGenerated = true)] private int idKeywordMap;
    [TableColumn("idKeyword", NotNull = true), ForeignKey("Keyword", "idKeyword")] private int idKeyword;
    [TableColumn("idChannelGroup", NotNull = true), ForeignKey("ChannelGroup", "idGroup")] private int idChannelGroup;

    #endregion

    #region Constructors

    /// <summary> 
    /// Create a new object by specifying all fields (except the auto-generated primary key field). 
    /// </summary> 
    public KeywordMap(int idKeyword, int idChannelGroup)
    {
      isChanged = true;
      this.idKeyword = idKeyword;
      this.idChannelGroup = idChannelGroup;
    }

    /// <summary> 
    /// Create an object from an existing row of data. This will be used by Gentle to 
    /// construct objects from retrieved rows. 
    /// </summary> 
    public KeywordMap(int idKeywordMap, int idKeyword, int idChannelGroup)
    {
      this.idKeywordMap = idKeywordMap;
      this.idKeyword = idKeyword;
      this.idChannelGroup = idChannelGroup;
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Indicates whether the entity is changed and requires saving or not.
    /// </summary>
    public bool IsChanged
    {
      get { return isChanged; }
    }

    /// <summary>
    /// Property relating to database column idKeywordMap
    /// </summary>
    public int IdKeywordMap
    {
      get { return idKeywordMap; }
    }

    /// <summary>
    /// Property relating to database column idKeyword
    /// </summary>
    public int IdKeyword
    {
      get { return idKeyword; }
      set
      {
        isChanged |= idKeyword != value;
        idKeyword = value;
      }
    }

    /// <summary>
    /// Property relating to database column idChannelGroup
    /// </summary>
    public int IdChannelGroup
    {
      get { return idChannelGroup; }
      set
      {
        isChanged |= idChannelGroup != value;
        idChannelGroup = value;
      }
    }

    #endregion

    #region Storage and Retrieval

    /// <summary>
    /// Static method to retrieve all instances that are stored in the database in one call
    /// </summary>
    public static IList<KeywordMap> ListAll()
    {
      return Broker.RetrieveList<KeywordMap>();
    }

    /// <summary>
    /// Retrieves an entity given it's id.
    /// </summary>
    public static KeywordMap Retrieve(int id)
    {
      // Return null if id is smaller than seed and/or increment for autokey
      if (id < 1)
      {
        return null;
      }
      Key key = new Key(typeof (KeywordMap), true, "idKeywordMap", id);
      return Broker.RetrieveInstance<KeywordMap>(key);
    }

    /// <summary>
    /// Retrieves an entity given it's id, using Gentle.Framework.Key class.
    /// This allows retrieval based on multi-column keys.
    /// </summary>
    public static KeywordMap Retrieve(Key key)
    {
      return Broker.RetrieveInstance<KeywordMap>(key);
    }

    /// <summary>
    /// Retrieves a list of ChannelGroup's with the same KeywordID.
    /// </summary>
    public static List<ChannelGroup> RetrieveChannelGroups(int KeywordID)
    {
      if (KeywordID < 1)
      {
        return null;
      }
      Key key = new Key(typeof (KeywordMap), true, "idKeyword", KeywordID);
      IList<KeywordMap> list = Broker.RetrieveList<KeywordMap>(key);
      List<ChannelGroup> channelGroupList = new List<ChannelGroup>();
      foreach (KeywordMap map in list)
      {
        if (map.IdChannelGroup > 0)
        {
          ChannelGroup channelGroup = ChannelGroup.Retrieve(map.IdChannelGroup);
          if (channelGroup != null)
          {
            channelGroupList.Add(channelGroup);
          }
        }
      }
      return channelGroupList;
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
          base.Persist();
        }
        catch (Exception ex)
        {
          Log.Error("Exception in KeywordMap.Persist() with Message {0}", ex.Message);
          return;
        }
        isChanged = false;
      }
    }

    #endregion

    #region Relations

    /// <summary>
    ///
    /// </summary>
    public ChannelGroup ReferencedChannelGroup()
    {
      return ChannelGroup.Retrieve(IdChannelGroup);
    }

    /// <summary>
    ///
    /// </summary>
    public Keyword ReferencedKeyword()
    {
      return Keyword.Retrieve(IdKeyword);
    }

    #endregion

    public void Delete()
    {
      Remove();
    }
  }
}
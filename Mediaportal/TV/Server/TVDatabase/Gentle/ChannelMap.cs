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
  /// Instances of this class represent the properties and methods of a row in the table <b>ChannelMap</b>.
  /// </summary>
  [TableName("ChannelMap")]
  public class ChannelMap : Persistent
  {
    #region Members

    private bool isChanged;
    [TableColumn("idChannelMap", NotNull = true), PrimaryKey(AutoGenerated = true)] private int idChannelMap;
    [TableColumn("idChannel", NotNull = true), ForeignKey("Channel", "idChannel")] private int idChannel;
    [TableColumn("idCard", NotNull = true), ForeignKey("Card", "idCard")] private int idCard;
    [TableColumn("epgOnly")] private bool epgOnly;

    #endregion

    #region Constructors

    /// <summary> 
    /// Create a new object by specifying all fields (except the auto-generated primary key field). 
    /// </summary> 
    public ChannelMap(int idChannel, int idCard, bool epgOnly)
    {
      isChanged = true;
      this.idChannel = idChannel;
      this.idCard = idCard;
      this.epgOnly = epgOnly;
    }

    /// <summary> 
    /// Create an object from an existing row of data. This will be used by Gentle to 
    /// construct objects from retrieved rows. 
    /// </summary> 
    public ChannelMap(int idChannelMap, int idChannel, int idCard, bool epgOnly)
    {
      this.idChannelMap = idChannelMap;
      this.idChannel = idChannel;
      this.idCard = idCard;
      this.epgOnly = epgOnly;
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
    /// Property relating to database column idChannelMap
    /// </summary>
    public int IdChannelMap
    {
      get { return idChannelMap; }
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
    /// Property relating to database column idCard
    /// </summary>
    public int IdCard
    {
      get { return idCard; }
      set
      {
        isChanged |= idCard != value;
        idCard = value;
      }
    }

    /// <summary>
    /// Property relating to database column epgOnly
    /// </summary>
    public bool EpgOnly
    {
      get { return epgOnly; }
      set
      {
        isChanged |= epgOnly != value;
        epgOnly = value;
      }
    }

    #endregion

    #region Storage and Retrieval

    /// <summary>
    /// Static method to retrieve all instances that are stored in the database in one call
    /// </summary>
    public static IList<ChannelMap> ListAll()
    {
      return Broker.RetrieveList<ChannelMap>();
    }

    /// <summary>
    /// Retrieves an entity given it's id.
    /// </summary>
    public static ChannelMap Retrieve(int id)
    {
      // Return null if id is smaller than seed and/or increment for autokey
      if (id < 1)
      {
        return null;
      }
      Key key = new Key(typeof (ChannelMap), true, "idChannelMap", id);
      return Broker.RetrieveInstance<ChannelMap>(key);
    }

    /// <summary>
    /// Retrieves an entity given it's id, using Gentle.Framework.Key class.
    /// This allows retrieval based on multi-column keys.
    /// </summary>
    public static ChannelMap Retrieve(Key key)
    {
      return Broker.RetrieveInstance<ChannelMap>(key);
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
          Log.Error("Exception in ChannelMap.Persist() with Message {0}", ex.Message);
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
    public Card ReferencedCard()
    {
      return Card.Retrieve(IdCard);
    }

    /// <summary>
    ///
    /// </summary>
    public Channel ReferencedChannel()
    {
      return Channel.Retrieve(IdChannel);
    }

    #endregion

    public void Delete()
    {
      Remove();
    }
  }
}
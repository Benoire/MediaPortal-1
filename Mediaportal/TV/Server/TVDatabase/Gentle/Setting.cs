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
  /// Instances of this class represent the properties and methods of a row in the table <b>Setting</b>.
  /// </summary>
  [TableName("Setting")]
  public class Setting : Persistent
  {
    #region Members

    private bool isChanged;
    [TableColumn("idSetting", NotNull = true), PrimaryKey(AutoGenerated = true)] private int idSetting;
    [TableColumn("tag", NotNull = true)] private string tag;
    [TableColumn("value", NotNull = true)] private string value;

    #endregion

    #region Constructors

    /// <summary> 
    /// Create a new object by specifying all fields (except the auto-generated primary key field). 
    /// </summary> 
    public Setting(string tag, string value)
    {
      isChanged = true;
      this.tag = tag;
      this.value = value;
    }

    /// <summary> 
    /// Create an object from an existing row of data. This will be used by Gentle to 
    /// construct objects from retrieved rows. 
    /// </summary> 
    public Setting(int idSetting, string tag, string value)
    {
      this.idSetting = idSetting;
      this.tag = tag;
      this.value = value;
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
    /// Property relating to database column idSetting
    /// </summary>
    public int IdSetting
    {
      get { return idSetting; }
    }

    /// <summary>
    /// Property relating to database column tag
    /// </summary>
    public string Tag
    {
      get { return tag; }
      set
      {
        isChanged |= tag != value;
        tag = value;
      }
    }

    /// <summary>
    /// Property relating to database column value
    /// </summary>
    public string Value
    {
      get { return value; }
      set
      {
        isChanged |= this.value != value;
        this.value = value;
      }
    }

    #endregion

    #region Storage and Retrieval

    /// <summary>
    /// Static method to retrieve all instances that are stored in the database in one call
    /// </summary>
    public static IList<Setting> ListAll()
    {
      return Broker.RetrieveList<Setting>();
    }

    /// <summary>
    /// Retrieves an entity given it's id.
    /// </summary>
    public static Setting Retrieve(int id)
    {
      // Return null if id is smaller than seed and/or increment for autokey
      if (id < 1)
      {
        return null;
      }
      Key key = new Key(typeof (Setting), true, "idSetting", id);
      return Broker.RetrieveInstance<Setting>(key);
    }

    /// <summary>
    /// Retrieves an entity given it's id, using Gentle.Framework.Key class.
    /// This allows retrieval based on multi-column keys.
    /// </summary>
    public static Setting Retrieve(Key key)
    {
      return Broker.RetrieveInstance<Setting>(key);
    }

    /// <summary>
    /// Retrieves a setting entity based on tag
    /// </summary>
    public static Setting RetrieveByTag(string tag)
    {
      // Return null if id is smaller than seed and/or increment for autokey
      if (string.IsNullOrEmpty(tag))
      {
        return null;
      }
      var key = new Key(typeof(Setting), true, "tag", tag);
      return Broker.RetrieveInstance<Setting>(key);
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
          Log.Error("Exception in Setting.Persist() with Message {0}", ex.Message);
          return;
        }
        isChanged = false;
      }
    }

    #endregion
  }
}
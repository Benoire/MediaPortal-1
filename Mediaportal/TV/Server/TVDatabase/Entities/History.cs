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
    public partial class History
    {
        #region Primitive Properties
    
        public virtual int idHistory
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
    
        public virtual System.DateTime startTime
        {
            get;
            set;
        }
    
        public virtual System.DateTime endTime
        {
            get;
            set;
        }
    
        public virtual string title
        {
            get;
            set;
        }
    
        public virtual string description
        {
            get;
            set;
        }
    
        public virtual string genre
        {
            get;
            set;
        }
    
        public virtual bool recorded
        {
            get;
            set;
        }
    
        public virtual int watched
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
            if (previousValue != null && previousValue.Histories.Contains(this))
            {
                previousValue.Histories.Remove(this);
            }
    
            if (Channel != null)
            {
                if (!Channel.Histories.Contains(this))
                {
                    Channel.Histories.Add(this);
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

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
    public partial class ChannelLinkageMap
    {
        #region Primitive Properties
    
        public virtual int idMapping
        {
            get;
            set;
        }
    
        public virtual int idPortalChannel
        {
            get;
            set;
        }
    
        public virtual int idLinkedChannel
        {
            get;
            set;
        }
    
        public virtual string displayName
        {
            get;
            set;
        }

        #endregion
    }
}

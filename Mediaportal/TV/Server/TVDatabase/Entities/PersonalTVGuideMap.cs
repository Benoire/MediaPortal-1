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
    public partial class PersonalTVGuideMap
    {
        #region Primitive Properties
    
        public virtual int idPersonalTVGuideMap
        {
            get;
            set;
        }
    
        public virtual int idKeyword
        {
            get { return _idKeyword; }
            set
            {
                if (_idKeyword != value)
                {
                    if (Keyword != null && Keyword.idKeyword != value)
                    {
                        Keyword = null;
                    }
                    _idKeyword = value;
                }
            }
        }
        private int _idKeyword;
    
        public virtual int idProgram
        {
            get { return _idProgram; }
            set
            {
                if (_idProgram != value)
                {
                    if (Program != null && Program.idProgram != value)
                    {
                        Program = null;
                    }
                    _idProgram = value;
                }
            }
        }
        private int _idProgram;

        #endregion
        #region Navigation Properties
    
        public virtual Program Program
        {
            get { return _program; }
            set
            {
                if (!ReferenceEquals(_program, value))
                {
                    var previousValue = _program;
                    _program = value;
                    FixupProgram(previousValue);
                }
            }
        }
        private Program _program;
    
        public virtual Keyword Keyword
        {
            get { return _keyword; }
            set
            {
                if (!ReferenceEquals(_keyword, value))
                {
                    var previousValue = _keyword;
                    _keyword = value;
                    FixupKeyword(previousValue);
                }
            }
        }
        private Keyword _keyword;

        #endregion
        #region Association Fixup
    
        private void FixupProgram(Program previousValue)
        {
            if (previousValue != null && previousValue.PersonalTVGuideMaps.Contains(this))
            {
                previousValue.PersonalTVGuideMaps.Remove(this);
            }
    
            if (Program != null)
            {
                if (!Program.PersonalTVGuideMaps.Contains(this))
                {
                    Program.PersonalTVGuideMaps.Add(this);
                }
                if (idProgram != Program.idProgram)
                {
                    idProgram = Program.idProgram;
                }
            }
        }
    
        private void FixupKeyword(Keyword previousValue)
        {
            if (previousValue != null && previousValue.PersonalTVGuideMaps.Contains(this))
            {
                previousValue.PersonalTVGuideMaps.Remove(this);
            }
    
            if (Keyword != null)
            {
                if (!Keyword.PersonalTVGuideMaps.Contains(this))
                {
                    Keyword.PersonalTVGuideMaps.Add(this);
                }
                if (idKeyword != Keyword.idKeyword)
                {
                    idKeyword = Keyword.idKeyword;
                }
            }
        }

        #endregion
    }
}

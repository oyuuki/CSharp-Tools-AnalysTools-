using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib
{
    public class StringRange : Range
    {
        #region InstanceVal

        private string _spilitSeparatorStart = null;
        private string _spilitSeparatorEnd = null;
        private StringRange[] _childs = null;

        private readonly string _targetString = string.Empty;

        #endregion

        #region Constructor

        public StringRange(
            int indexStart,
            int indexEnd,
            string spilitStringStart,
            string targetString)
            : this(indexStart, indexEnd, spilitStringStart, string.Empty, targetString)
        {
            
        }

        public StringRange(
            int indexStart,
            int indexEnd,
            string spilitStringStart,
            string spilitStringEnd,
            string targetString)
            : base(indexStart, indexEnd)
        {
            this._spilitSeparatorStart = spilitStringStart;
            this._spilitSeparatorEnd = spilitStringEnd;
            this._targetString = targetString;
        }

        public StringRange(
            int indexStart,
            string spilitStringStart,
            string spilitStringEnd,
            string targetString)
            : this(indexStart, -1, spilitStringStart, spilitStringEnd, targetString)
        {
            
        }

        public StringRange(
            StringRange range)
            : this(range.IndexStart, range.IndexEnd, range.SpilitSeparatorStart, range.SpilitSeparatorEnd, range.TargetString)
        {
            
        }

        #endregion

        #region Property

        public string SpilitSeparatorStart
        {
            get { return this._spilitSeparatorStart; }
            set { this._spilitSeparatorStart = value; }
        }

        public string SpilitSeparatorEnd
        {
            get { return this._spilitSeparatorEnd; }
            set { this._spilitSeparatorEnd = value; }
        }

        public StringRange[] Childs
        {
            get { return this._childs; }
            set { this._childs = value; }
        }

        public bool HasChild
        {
            get { return this.Childs != null;}
        }

        public int CutStringCount
        {
            get { return this.IndexEnd - this.IndexStart + 1; }
        }

        public string TargetString
        {
            get { return this._targetString; }
        }

        public bool GetIsSpilitStrings(string spilitStringStart, string spilitStringEnd)
        {
            if (!this.GetIsSpilitStringStart(spilitStringStart)
                || !this.SpilitSeparatorEnd.Equals(spilitStringEnd))
            {
                return false;
            }

            return true;
        }

        public bool GetIsSpilitStringStart(string spilitStringStart)
        {
            if (!this.SpilitSeparatorStart.Equals(spilitStringStart))
            {
                return false;
            }

            return true;
        }

        public string GetStringSpilited()
        {
            return TargetString.Substring(this.IndexStart, this.CutStringCount);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib
{
    public class StringRange : Range
    {
        #region InstanceVal

        private string[] _spilitStrings = null;
        private StringRange[] _childs = null;

        private readonly string _targetString = string.Empty;

        #endregion

        #region Constructor

        public StringRange(
            int indexStart,
            int indexEnd,
            string spilitString,
            string targetString)
            : this(indexStart, indexEnd, new string[] { spilitString }, targetString)
        {
            
        }

        public StringRange(
            int indexStart,
            int indexEnd,
            string[] spilitStrings,
            string targetString)
            : base(indexStart, indexEnd)
        {
            this._spilitStrings = spilitStrings;
            this._targetString = targetString;
        }

        public StringRange(
            int indexStart,
            int indexEnd,
            string targetString)
            : this(indexStart, indexEnd, new string[]{}, targetString)
        {
        }

        public StringRange(
            int indexStart,
            string spilitString,
            string targetString)
            : this(indexStart, -1, new string[] { spilitString }, targetString)
        {
            
        }

        public StringRange(
            int indexStart,
            string targetString)
            : this(indexStart, -1, new string[] { }, targetString)            
        {
            
        }

        public StringRange(
            StringRange range)
            : this(range.IndexStart, range.IndexEnd, range.SpilitStrings, range.TargetString)
        {
            
        }

        #endregion

        #region Property

        public string[] SpilitStrings
        {
            get { return this._spilitStrings; }
            set { this._spilitStrings = value; }
        }

        public StringRange[] Childs
        {
            get { return this._childs; }
            set { this._childs = value; }
        }

        public int CutStringCount
        {
            get { return this.IndexEnd - this.IndexStart + 1; }
        }

        public string TargetString
        {
            get { return this._targetString; }
        }

        public bool GetIsSpilitStrings(string[] spilitStrings)
        {
            if (this.SpilitStrings.Length != spilitStrings.Length)
            {
                return false;
            }

            return ArrayUtil.IsIncludeAllStringsInArray(this.SpilitStrings, spilitStrings);
        }

        public bool GetIsSpilitStrings(string spilitString)
        {
            return this.GetIsSpilitStrings(new string[] {spilitString});
        }

        public string GetStringSpilited()
        {
            return TargetString.Substring(this.IndexStart, this.CutStringCount);
        }

        #endregion
    }
}

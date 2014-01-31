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

        #endregion

        #region Constructor

        public StringRange(
            int indexStart,
            int indexEnd,
            string spilitString)
            : this(indexStart, indexEnd, new string[] { spilitString })
        {
            
        }

        public StringRange(
            int indexStart,
            int indexEnd,
            string[] spilitStrings)
            : base(indexStart, indexEnd)
        {
            this._spilitStrings = spilitStrings;
        }

        public StringRange(
            int indexStart,
            int indexEnd)
            : this(indexStart, indexEnd, new string[]{})
        {
        }

        public StringRange(
            int indexStart,
            string spilitString)
            : this(indexStart, -1, new string[] { spilitString })
        {
            
        }

        public StringRange(
            int indexStart)
            : this(indexStart, -1, new string[] { })            
        {
            
        }

        public StringRange(
            StringRange range)
            : this(range.IndexStart, range.IndexEnd, range.SpilitStrings)
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

        #endregion
    }
}

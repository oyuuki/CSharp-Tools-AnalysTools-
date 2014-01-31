using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib
{
    public class StringRange
    {
        #region InstanceVal

        private int _indexStart = -1;
        private int _indexEnd = -1;
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
        {
            this._indexStart = indexStart;
            this._indexEnd = indexEnd;
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
            this._indexStart = indexStart;
        }

        public StringRange(
            StringRange range)
            : this(range.IndexStart, range.IndexEnd, range.SpilitStrings)
        {
            
        }

        #endregion

        #region Property

        public int IndexStart
        {
            get { return this._indexStart; }
            set { this._indexStart = value; }
        }

        public int IndexEnd
        {
            get { return this._indexEnd; }
            set { this._indexEnd = value; }
        }

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
            get { return this._indexEnd - this.IndexStart + 1; }
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

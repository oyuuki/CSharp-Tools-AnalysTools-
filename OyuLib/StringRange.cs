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
        private StringRange[] _childs = null;

        #endregion

        #region Constructor

        public StringRange(
            int indexStart,
            int indexEnd = -1)
        {
            this._indexStart = indexStart;
            this._indexEnd = indexEnd;
        }

        public StringRange(
            int indexStart)
        {
            this._indexStart = indexStart;
        }

        public StringRange(
            StringRange range)
            : this(range.IndexStart, range.IndexEnd)
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

        public StringRange[] Childs
        {
            get { return this._childs; }
            set { this._childs = value; }
        }

        public int CutStringCount
        {
            get { return this._indexEnd - this.IndexStart + 1; }
        }

        #endregion
    }
}

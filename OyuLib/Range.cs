using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib
{
    public class Range
    {
        #region InstanceVal

        private int _indexStart = -1;
        private int _indexEnd = -1;

        #endregion

        #region constructor

        public Range(
            int indexStart,
            int indexEnd)
        {
            this._indexStart = indexStart;
            this._indexEnd = indexEnd;
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

        #endregion
    }
}

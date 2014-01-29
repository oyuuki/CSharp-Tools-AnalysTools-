using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib
{
    public class NestingStringIndexPare
    {
        #region InstanceVal

        private int _indexStart = -1;
        private int _indexEnd = -1;
        private NestingStringIndexPare[] _childs = null;

        #endregion

        #region Constructor

        public NestingStringIndexPare(
            int indexStart,
            int indexEnd = -1)
        {
            this._indexStart = indexStart;
            this._indexEnd = indexEnd;
        }

        public NestingStringIndexPare(
            int indexStart)
        {
            this._indexStart = indexStart;
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

        public NestingStringIndexPare[] Childs
        {
            get { return this._childs; }
            set { this._childs = value; }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Collection
{
    public class NestIndex
    {   
        #region instanceVal

        private int _index = -1;

        private NestIndex[] _childIndices = null;


        #endregion

        #region Constructor

        public NestIndex(
            int index)
        {
            this._index = index;
        }


        #endregion

        #region Property

        public int Index
        {
            get { return this._index;  }
        }

        public NestIndex[] Childs
        {
            get { return this._childIndices; }
            set { this._childIndices = value; }
        }

        #endregion

        #region Method


        #endregion
    }
}

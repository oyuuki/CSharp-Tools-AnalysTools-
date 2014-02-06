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

        private int _hierarchyCount = -1;

        private int _parentIndex = -1;

        private NestIndex[] _childIndices = null;


        #endregion

        #region Constructor

        public NestIndex(
            int index,
            int hierarchyCount,
            int parentIndex)
        {
            this._index = index;
            this._hierarchyCount = hierarchyCount;
            this._parentIndex = parentIndex;
        }

        public NestIndex(
            int index)
            : this(index, 0, 0)
        {

        }


        #endregion

        #region Property

        public int Index
        {
            get { return this._index;  }
        }

        public int HierarchyCount
        {
            get { return this._hierarchyCount; }
        }

        public int ParentIndex
        {
            get { return this._parentIndex; }
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

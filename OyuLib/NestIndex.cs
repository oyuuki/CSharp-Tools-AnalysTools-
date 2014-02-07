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

        private int _groupCount = -1;

        private NestIndex[] _childIndices = null;


        #endregion

        #region Constructor

        public NestIndex(
            int index,
            int hierarchyCount,
            int groupCount)
        {
            this._index = index;
            this._hierarchyCount = hierarchyCount;
            this._groupCount = groupCount;
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

        public int GroupCount
        {
            get { return this._groupCount; }
        }

        public NestIndex[] Childs
        {
            get { return this._childIndices; }
            set { this._childIndices = value; }
        }

        public bool HasChild
        {
            get { return this._childIndices != null && this._childIndices.Length > 0; }
        }

        #endregion

        #region Method


        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Collection
{
    public class HierarchyUniqueIndex
    {   
        #region instanceVal

        private int _index = -1;

        private int _hierarchyCount = -1;

        private string _hierarchyPrefix = string.Empty;

        #endregion

        #region Constructor

        internal HierarchyUniqueIndex(
            int index,
            int hierarchyCount,
            string hierarchyPrefix)
        {
            this._index = index;
            this._hierarchyCount = hierarchyCount;
            this._hierarchyPrefix = hierarchyPrefix;
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

        public string HierarchyPrefix
        {
            get { return this._hierarchyPrefix; }
        }

        #endregion

        #region Method

        #region Public

        public string GetUniqueIndexString()
        {
            return this.HierarchyCount + this.HierarchyPrefix + this.Index;
        }

        #endregion

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib;

namespace OyuLib.Collection
{
    public class HierarchyUniqueIndexCollection : UserClassCollection<HierarchyUniqueIndex>
    {
        #region InstanceVal

        private string _hierarchyPrefix = string.Empty;

        #endregion

        #region Constructor

        public HierarchyUniqueIndexCollection(string hierarchyPrefix)
        {
            this._hierarchyPrefix = hierarchyPrefix;
        }
        public HierarchyUniqueIndexCollection()
            : this(string.Empty)
        {
            
        }

        #endregion

        #region Method

        #region Public

        public new void Add(
            int index,
            int hierarchyCount)
        {
            base.Add(new HierarchyUniqueIndex(index, hierarchyCount, this._hierarchyPrefix));
        }

        public new void Add(
            int index)
        {
            this.Add(index, 0);
        }

        #endregion

        #region New

        private new void Add(HierarchyUniqueIndex tValue)
        {
            base.Add(tValue);
        }

        #endregion

        #endregion
    }
}

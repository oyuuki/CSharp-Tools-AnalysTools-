using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Collection
{
    public class Category
    {
        #region instanceVal

        private Category[] _childCategorys = null;

        private Profile[] _childProfiles = null;

        #endregion

        #region Property

        public Category[] ChildCategorys
        {
            get { return _childCategorys; }
        }

        public Profile[] ChildProfiles
        {
            get { return _childProfiles; }
        }

        public bool IsHaveChildCategorys
        {
            get
            {
                return this.ChildCategorys == null || this.ChildCategorys.Length <= 0;
            }
        }

        public bool IsHaveProfiles
        {
            get
            {
                return this.ChildProfiles == null || this.ChildProfiles.Length <= 0;
            }
        }

        #endregion

        #region Constructor

        public Category(Profile[] childProfiles)
        {
            this._childProfiles = childProfiles;
        }

        #endregion

        #region Method

        public void SetChildCategory(Category[] childCategorys)
        {
            this._childCategorys = childCategorys;
        }

        public void ExecuteAll()
        {
            Category.ExecuteInCategorys(this.ChildCategorys);
        }

        protected static void ExecuteInCategorys(Category[] categorys)
        {
            foreach(var child in categorys)
            {
                if(child.IsHaveProfiles)
                {
                    Category.ExecuteInProfiles(child.ChildProfiles);
                }

                if(child.IsHaveChildCategorys)
                {
                    Category.ExecuteInCategorys(child.ChildCategorys);
                }
            }
        }

        protected static void ExecuteInProfiles(Profile[] profiles)
        {
            foreach (var child in profiles)
            {
                child.Execute();
            }
        }

        #endregion
    }
}

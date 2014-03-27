using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Collection
{
    public abstract class Profile : ICategoryItem
    {
        #region instanceVal

        private string _name = string.Empty;

        private string _uniquName = string.Empty;

        #endregion

        #region Constructor

        public Profile(string name)
        {
            this._name = name;
            this._uniquName = name;
        }

        #endregion

        #region InsterFace

        #region ICategoryItem

        public abstract void Execute();

        #endregion

        #endregion
    }
}

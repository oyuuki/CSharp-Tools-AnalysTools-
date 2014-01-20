using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExCast
{
    abstract class General
    {
        #region instance

        protected object _obj = null;

        #endregion

        #region constractor

        public General(object obj)
        {
            this._obj = obj;
        }

        #endregion

        #region method

        #region abstract

        #endregion

        #endregion
    }
}

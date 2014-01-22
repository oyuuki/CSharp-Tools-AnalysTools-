using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.OyuWindows.Interface.Logic
{
    class TypeUtil
    {
        #region Instance

        /// <summary>
        /// Instance obj
        /// </summary>
        private object _obj = null;

        #endregion

        #region constractor

        /// <summary>
        /// Constractor
        /// </summary>
        public TypeUtil(object obj)
        {
            this._obj = obj;
        }

        #endregion

        #region Combine Type

        public bool IsTypeof(Type type)
        {
            return _obj.GetType() == type;
        }

        #endregion
    }
}

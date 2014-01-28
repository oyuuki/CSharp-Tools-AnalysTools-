using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib
{
    public class TypeUtil
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

        #region Method

        #region Instance

        #region Combine Type

        public bool IsTypeof(Type type)
        {
            return _obj.GetType() == type;
        }

        #endregion

        #endregion

        #region Static

        public static T GetInstance<T>(object[] objArray)
        {
            return (T)typeof(T).GetConstructor(GetArrayValuesType(objArray)).Invoke(objArray);
        }

        public static Type[] GetArrayValuesType(object[] paramArray)
        {
            return paramArray.Select(obj => obj.GetType()).ToArray();
        }

        public static bool IsSameTypeObject(Type type, object obj)
        {
            return type.Equals(obj.GetType());

        }

        public static bool IsSameTypesObject(Type[] types, object obj)
        {
            return types.Any(type => TypeUtil.IsSameTypeObject(type, obj));
        }

        #endregion

        #endregion
    }
}

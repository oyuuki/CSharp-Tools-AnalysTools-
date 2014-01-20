using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib
{
    public static class Util
    {
        public static T GetInstance<T>(object[] objArray)
        {
            return (T)typeof(T).GetConstructor(GetArrayValuesType(objArray)).Invoke(objArray);
        }

        public static Type[] GetArrayValuesType(object[] paramArray)
        {
            return paramArray.Select(obj => obj.GetType()).ToArray();
        }
    }
}

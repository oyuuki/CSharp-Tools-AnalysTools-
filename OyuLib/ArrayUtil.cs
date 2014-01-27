using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib
{
    public static class ArrayUtil
    {
        #region Method

        public static bool IsNullOrNoLength(Array array)
        {
            return array == null || array.Length < 0;
        }

        public static bool IsIncludeStringEndsWith(Array array, string value)
        {
            if (array == null)
            {
                return false;
            }

            foreach (string val in array)
            {
                if (value.EndsWith(val))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsIncludeStringsInArray(Array array, string[] value)
        {
            foreach (string val in array)
            {
                if (val.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

    }
}

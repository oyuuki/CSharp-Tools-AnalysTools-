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

        public static bool IsIncludeStringInCodeAtLast(string[] arrayString, string value)
        {
            if (arrayString == null)
            {
                return false;
            }

            return arrayString[arrayString.Length - 1].Equals(value);
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

        public static bool IsIncludeString(Array array, string value)
        {
            if (array == null)
            {
                return false;
            }

            foreach (string val in array)
            {
                if (value.IndexOf(val) >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsIncludeSomeStringsInArray(Array array, string[] targetStrings)
        {
            foreach (string val in array)
            {
                foreach (var tarStr in targetStrings)
                {
                    if (val.Equals(tarStr))
                    {
                        return true;
                    }    
                }
            }

            return false;
        }

        public static bool IsIncludeAllStringsInArray(Array array, string[] targetStrings)
        {
            foreach (string val in array)
            {
                bool isFind = false;

                foreach (var tarStr in targetStrings)
                {
                    if (val.Equals(tarStr))
                    {
                        isFind = true;
                        break;
                    }
                }

                if (!isFind)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

    }
}

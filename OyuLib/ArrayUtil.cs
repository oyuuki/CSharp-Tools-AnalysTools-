using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib
{
    public static class ArrayUtil
    {
        public static bool IsNullOrNoLength(Array array)
        {
            return array == null || array.Length < 0;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.OyuChar
{
    public static class CharManager<T> 
        where T : CharCode, new()
    {
        public static string[] GetSpilitString(string text)
        {
            T code = new T();
            return text.Split(new string[]{code.GetCharCodeString()}, StringSplitOptions.None);
        }
    }
}

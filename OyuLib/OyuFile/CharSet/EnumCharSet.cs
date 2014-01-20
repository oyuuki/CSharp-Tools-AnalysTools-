using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ConstAttribute;

namespace OyuLib.OyuFile.CharSet
{
    public enum EnumCharSet
    {
        [ConstValue(EnumCharSetValue.CONST_CHARSET_NONE, EnumCharSetValue.CONST_CHARSET_NONE_NAME)]
        None,
        [ConstValue(EnumCharSetValue.CONST_CHARSET_SHIFTJIS, EnumCharSetValue.CONST_CHARSET_SHIFTJIS_NAME)]
        ShiftJis,
    }
}

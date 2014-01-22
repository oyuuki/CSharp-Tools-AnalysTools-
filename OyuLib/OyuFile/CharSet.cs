using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.OyuAttribute;

namespace OyuLib.OyuFile
{
    public enum CharSet
    {
        [ConstValue(CharSetValue.CONST_CHARSET_NONE, CharSetValue.CONST_CHARSET_NONE_NAME)]
        None,
        [ConstValue(CharSetValue.CONST_CHARSET_SHIFTJIS, CharSetValue.CONST_CHARSET_SHIFTJIS_NAME)]
        ShiftJis,
    }
}

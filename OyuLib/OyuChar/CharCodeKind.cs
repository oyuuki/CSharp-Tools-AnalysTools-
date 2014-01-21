using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConstAttribute;

namespace OyuLib.OyuChar
{
    public enum CharCodeKind
    {
        [ConstValue(LineCharCodeKindValue.CONST_LINECODE_ENRENN, LineCharCodeKindValue.CONST_LINECODE_ENRENN_NAME)]
        Tab,
        [ConstValue(LineCharCodeKindValue.CONST_LINECODE_ENN, LineCharCodeKindValue.CONST_LINECODE_ENN_NAME)]
        Khamma,
    }
}

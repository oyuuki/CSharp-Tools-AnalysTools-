using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ConstAttribute;

namespace OyuLib.OyuChar
{
    public enum LineCharCodeKind
    {
        [ConstValue(LineCharCodeKindValue.CONST_LINECODE_ENRENN, LineCharCodeKindValue.CONST_LINECODE_ENRENN_NAME)]
        EnREnN,
        [ConstValue(LineCharCodeKindValue.CONST_LINECODE_ENN, LineCharCodeKindValue.CONST_LINECODE_ENN_NAME)]
        EnN,
        [ConstValue(LineCharCodeKindValue.CONST_LINECODE_ENR, LineCharCodeKindValue.CONST_LINECODE_ENR_NAME)]
        EnR,
    }
}

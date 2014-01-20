using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ConstAttribute;

namespace AnalysSourceCode.Enum
{
    public enum EnumReadOnly
    {
        [ConstValue("1", "出")]
        On,
        [ConstValue("0", "入出")]
        Off
    }
}

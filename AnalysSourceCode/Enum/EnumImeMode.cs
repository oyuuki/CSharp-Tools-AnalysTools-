using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ConstAttribute;

namespace AnalysSourceCode.Enum
{
    public enum EnumImeMode
    {
        [ConstValue("0", "規定値")]
        Default,
        [ConstValue("1", "ON")]
        On,
        [ConstValue("2", "OFF")]
        Off
        
    }
}

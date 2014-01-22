using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.OyuAttribute;

namespace OyuLib.AnalysisSourceCode
{
    public enum ReadOnly
    {
        [ConstValue("1", "出")]
        On,
        [ConstValue("0", "入出")]
        Off
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.OyuAttribute;

namespace AnalysisSourceCode
{
    public enum KindImeMode
    {
        [ConstValue("0", "規定値")]
        Default,
        [ConstValue("1", "ON")]
        On,
        [ConstValue("2", "OFF")]
        Off
        
    }
}

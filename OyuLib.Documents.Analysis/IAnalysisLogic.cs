using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    interface IAnalysisLogic
    {
        CodeInfo GetCodeInfo();
        bool IsCodeInfo();
    }
}

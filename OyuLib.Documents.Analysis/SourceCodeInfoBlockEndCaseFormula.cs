using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockEndCaseFormula : SourceCodeInfoBlockEnd
    {
        #region Constructor

        public SourceCodeInfoBlockEndCaseFormula(
            int statement)
            : base(statement)
        {
            
        }

        public SourceCodeInfoBlockEndCaseFormula(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion

        public override NestIndex[] GetNestIndices()
        {
            throw new Exception("TODO：未実装");
        }
    }
}

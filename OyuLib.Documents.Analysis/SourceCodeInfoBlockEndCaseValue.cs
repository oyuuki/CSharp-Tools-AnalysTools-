using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockEndCaseValue : SourceCodeInfoBlockEnd
    {
        #region Constructor

        public SourceCodeInfoBlockEndCaseValue(
            int statement)
            : base(statement)
        {
            
        }

        public SourceCodeInfoBlockEndCaseValue(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion

        protected override int[] GetCodePartsIndex()
        {
            throw new Exception("TODO：未実装");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockEndIf : SourceCodeInfoBlockEnd
    {
        #region Constructor

        public SourceCodeInfoBlockEndIf(
            int statement)
            : base(statement)
        {
            
        }

        public SourceCodeInfoBlockEndIf(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        protected override int[] GetCodePartsIndex()
        {
            throw new Exception("TODO：未実装");
        }

        #endregion
    }
}

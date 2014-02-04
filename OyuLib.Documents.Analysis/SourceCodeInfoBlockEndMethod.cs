using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockEndMethod : SourceCodeInfoBlockEnd
    {
        #region Constructor

        public SourceCodeInfoBlockEndMethod(
            int statement)
            : base(statement)
        {
            
        }

        public SourceCodeInfoBlockEndMethod(
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

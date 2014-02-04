using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class CodeInfoBlockEndDoWhile :SourceCodeInfoBlockEnd
    {
        #region Constructor

        public CodeInfoBlockEndDoWhile(
            int statement)
            : base(statement)
        {
            
        }

        public CodeInfoBlockEndDoWhile(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

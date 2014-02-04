using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockEndDoWhile :SourceCodeInfoBlockEnd
    {
        #region Constructor

        public SourceCodeInfoBlockEndDoWhile(
            int statement)
            : base(statement)
        {
            
        }

        public SourceCodeInfoBlockEndDoWhile(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

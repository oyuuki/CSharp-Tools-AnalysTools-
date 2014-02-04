using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources
{
    public class SourceCodeInfoBlockFunctionEndVB : SourceCodeInfoBlockEnd
    {
        #region Constructor

        public SourceCodeInfoBlockFunctionEndVB(
            int statement)
            : base(statement)
        {
            
        }

        public SourceCodeInfoBlockFunctionEndVB(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

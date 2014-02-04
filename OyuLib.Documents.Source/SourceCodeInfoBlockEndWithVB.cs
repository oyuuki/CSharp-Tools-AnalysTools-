using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources
{
    public class SourceCodeInfoBlockEndWithVB : SourceCodeInfoBlockEnd
    {
        #region Constructor

        public SourceCodeInfoBlockEndWithVB(
            int statement)
            : base(statement)
        {
            
        }

        public SourceCodeInfoBlockEndWithVB(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

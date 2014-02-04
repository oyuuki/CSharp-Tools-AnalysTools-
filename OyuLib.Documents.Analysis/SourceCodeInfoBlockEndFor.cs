using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockEndFor : SourceCodeInfoBlockEnd
    {
        #region Constructor

        public SourceCodeInfoBlockEndFor(
            int statement)
            : base(statement)
        {
            
        }

        public SourceCodeInfoBlockEndFor(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

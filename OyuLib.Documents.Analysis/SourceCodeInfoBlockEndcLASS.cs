using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    class SourceCodeInfoBlockEndClass : SourceCodeInfoBlockEnd
    {
        #region Constructor

        public SourceCodeInfoBlockEndClass(
            int statement)
            : base(statement)
        {
            
        }

        public SourceCodeInfoBlockEndClass(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        public override NestIndex[] GetNestIndices()
        {
            throw new Exception("TODO：未実装");
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

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

        protected internal override HierarchyUniqueIndex[] GetCodePartsIndex()
        {
            throw new Exception("TODO：未実装");
        }

        #endregion
    }
}

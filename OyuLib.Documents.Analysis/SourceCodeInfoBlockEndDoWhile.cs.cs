using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

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

        protected internal override HierarchyUniqueIndex[] GetCodePartsIndex()
        {
            throw new Exception("TODO：未実装");
        }

        #endregion
    }
}

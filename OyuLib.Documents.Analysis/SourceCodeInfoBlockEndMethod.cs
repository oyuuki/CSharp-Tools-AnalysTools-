﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

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

        protected internal override HierarchyUniqueIndex[] GetCodePartsIndex()
        {
            throw new Exception("TODO：未実装");
        }

        #endregion

    }
}

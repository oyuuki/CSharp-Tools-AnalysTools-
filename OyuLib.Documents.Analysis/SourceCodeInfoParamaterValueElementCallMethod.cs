﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterValueElementCallMethod : SourceCodeInfoParamaterValueElement
    {
        #region Constructor

        public SourceCodeInfoParamaterValueElementCallMethod(
            SourceCode code,
            SourceCodePartsfactory coFac,
            StringRange range,
            int parammaterName,
            int parentIndex,
            int hierarchyCount)
            : base(code, coFac, range, parammaterName, parentIndex, hierarchyCount)
        {
                                                              
        }

        #endregion

        #region Method

        #region Public


        #endregion

        #endregion
    }
}

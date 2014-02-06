﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterFactoryVBDotNetCallMethod :
        SourceCodeInfoParamaterFactory<SourceCodeInfoParamaterValueMethod, SourceCodeInfoParamaterMethod, SourceCodePartsFactoryCommat>
    {
        #region Constructor

        public SourceCodeInfoParamaterFactoryVBDotNetCallMethod(
            int parentIndex,
            SourceCodePartsFactoryCommat factory,
            StringRange range)
            : base(parentIndex, factory, range)
        {

        }

        #endregion

        #region Method

        #region Override

        protected override SourceCodeInfoParamaterValueMethod GetSourceCodeInfoParamaterValueLogic(
            SourceCode sourceCode, 
            SourceCodePartsfactory fac,
            StringRange rangeParam,
            out string paramaterString, 
            out int paramaterStringIndex,
            out StringRange range,
            int partsStartIndex, 
            int parentIndex,
            int hierarchyCount)
        {
            paramaterString = string.Empty;   
            paramaterStringIndex = -1;   
            range = null;

            int asIndex = fac.GetIndexCodeParts("As") + partsStartIndex;
            int parammaterName = asIndex - 1 + partsStartIndex;
            int typeName = asIndex + 1 + partsStartIndex;

            var paramaterStrings = fac.GetNestedCodeParts("(", ")");

            if (paramaterStrings != null && paramaterStrings.Length > 0)
            {
                paramaterString = paramaterStrings[0];
                paramaterStringIndex = fac.GetNestedCodePartsIndex("(", ")")[0];
            }

            return new SourceCodeInfoParamaterValueMethod(sourceCode, new SourceCodePartsFactoryParamater(sourceCode),rangeParam,
                parammaterName, parentIndex, hierarchyCount, typeName);
        }

        protected override SourceCodePartsfactory GetSourceCodePartsFactoryParamaterValue(
            SourceCode sourceCode)
        {
            return new SourceCodePartsFactoryParamater(sourceCode);
        }

        protected override SourceCodeInfoParamaterMethod GetSourceCodeInfoParamater(SourceCodeInfoParamaterValueMethod[] values, StringRange range)
        {
            return new SourceCodeInfoParamaterMethod(values, range);
        }

        protected override SourceCodePartsFactoryCommat GetFactory(string paramaterString)
        {
            return new SourceCodePartsFactoryCommat(new SourceCode(paramaterString));
        }

        protected override SourceCodeInfoParamaterFactory
            <SourceCodeInfoParamaterValueMethod, SourceCodeInfoParamaterMethod, SourceCodePartsFactoryCommat> 
            GetFactory(SourceCodeInfoParamaterValueMethod[] values)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}

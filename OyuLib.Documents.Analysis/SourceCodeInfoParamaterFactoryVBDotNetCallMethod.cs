using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterFactoryVBDotNetCallMethod :
        SourceCodeInfoParamaterFactory<SourceCodeInfoParamaterValueCallMethod, SourceCodeInfoParamater, SourceCodePartsFactoryCommatIncludeParamater>
    {
        #region Constructor

        public SourceCodeInfoParamaterFactoryVBDotNetCallMethod(
            int parentIndex,
            StringRange range)
            : base(parentIndex, range)
        {

        }

        #endregion

        #region Method

        #region Override

        protected override SourceCodeInfoParamaterValueCallMethod GetSourceCodeInfoParamaterValueLogic(
            SourceCode sourceCode, 
            SourceCodePartsfactory fac,
            StringRange rangeParam,
            out string paramaterString, 
            out int paramaterStringIndex,
            out StringRange range,
            int groupCount,
            int hierarchyCount)
        {
            paramaterString = string.Empty;   
            paramaterStringIndex = -1;   
            range = null;

            int parammaterName = 0;


            var paramaterStrings = fac.GetNestedCodeParts("(", ")");

            if (paramaterStrings != null && paramaterStrings.Length > 0)
            {
                paramaterString = paramaterStrings[0];
                paramaterStringIndex = fac.GetNestedCodePartsIndex("(", ")")[0];
            }

            return new SourceCodeInfoParamaterValueCallMethod(sourceCode, new SourceCodePartsFactoryParamater(sourceCode), rangeParam,
                parammaterName, groupCount, hierarchyCount);
        }

        protected override SourceCodePartsfactory GetSourceCodePartsFactoryParamaterValue(
            SourceCode sourceCode)
        {
            return new SourceCodePartsFactoryParamater(sourceCode);
        }

        protected override SourceCodeInfoParamater GetSourceCodeInfoParamater(SourceCodeInfoParamaterValueCallMethod[] values,
            StringRange range)
        {
            return new SourceCodeInfoParamater(values, range);
        }

        protected override SourceCodePartsFactoryCommatIncludeParamater GetFactory(string paramaterString)
        {
            return new SourceCodePartsFactoryCommatIncludeParamater(new SourceCode(paramaterString));
        }

        #endregion

        #endregion
    }
}

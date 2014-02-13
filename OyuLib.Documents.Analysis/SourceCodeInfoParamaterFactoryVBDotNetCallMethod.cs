using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterFactoryVBDotNetCallMethod :
        SourceCodeInfoParamaterFactory<SourceCodeInfo, SourceCodeInfoParamater, SourceCodePartsFactoryCommatIncludeParamater>
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

        protected override SourceCodeInfo GetSourceCodeInfoParamaterValueLogic(
            SourceCode sourceCode, 
            SourceCodePartsfactory fac,
            StringRange rangeParam,
            int groupCount,
            int hierarchyCount)
        {
            int parammaterName = 0;

            var paramaterStrings = fac.GetNestedCodeParts("(", ")");

            SourceCodeInfo retValue = null;

            // Exist Paramater
            if (paramaterStrings != null && paramaterStrings.Length > 0 && !string.IsNullOrEmpty(paramaterStrings[0]) && !paramaterStrings[0].StartsWith("("))
            {
                retValue = SourceCodeInfoFactoryCallMethodVBDotNet.GetCodeInfoCallMethod(sourceCode, rangeParam);
            }
            else
            {
                retValue = new SourceCodeInfoParamaterValueCallMethod(sourceCode, new SourceCodePartsFactoryParamater(sourceCode), rangeParam,
                    parammaterName, groupCount, hierarchyCount);
            }

            return retValue;
        }

        protected override SourceCodePartsfactory GetSourceCodePartsFactoryParamaterValue(
            SourceCode sourceCode)
        {
            return new SourceCodePartsFactoryParamater(sourceCode);
        }

        protected override SourceCodeInfoParamater GetSourceCodeInfoParamater(SourceCodeInfo[] values)
        {
            return new SourceCodeInfoParamater(values);
        }

        protected override SourceCodePartsFactoryCommatIncludeParamater GetFactory(string paramaterString)
        {
            return new SourceCodePartsFactoryCommatIncludeParamater(new SourceCode(paramaterString), new string[] { ",", " & ", " + ", " * ", " - ", " / ", " = " });
        }

        #endregion

        #endregion
    }
}

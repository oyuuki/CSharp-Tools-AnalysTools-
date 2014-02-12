using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterFactoryIf :
        SourceCodeInfoParamaterFactory<SourceCodeInfo, SourceCodeInfoParamater, SourceCodePartsFactoryVBDotNetIfValue>
    {
        #region Constructor

        public SourceCodeInfoParamaterFactoryIf(
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

            if (paramaterStrings != null && paramaterStrings.Length > 0 && !string.IsNullOrEmpty(paramaterStrings[0]))
            {
                retValue = SourceCodeInfoFactoryCallMethodVBDotNet.GetCodeInfoCallMethod(sourceCode);
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

        protected override SourceCodePartsFactoryVBDotNetIfValue GetFactory(string paramaterString)
        {
            return new SourceCodePartsFactoryVBDotNetIfValue(new SourceCode(paramaterString));
        }

        #endregion

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterFactoryVBDotNetCallMethod :
        SourceCodeInfoParamaterFactory<SourceCodeInfoParamaterValueCallMethod, SourceCodeInfoParamaterMethod, SourceCodePartsFactoryCommat>
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

            int asIndex = fac.GetIndexCodeParts("As");
            int parammaterName = asIndex - 1;
            int typeName = asIndex + 1;

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

        protected override SourceCodeInfoParamaterMethod GetSourceCodeInfoParamater(SourceCodeInfoParamaterValueCallMethod[] values,
            StringRange range)
        {
            return new SourceCodeInfoParamaterMethod(values, range);
        }

        protected override SourceCodePartsFactoryCommat GetFactory(string paramaterString)
        {
            return new SourceCodePartsFactoryCommat(new SourceCode(paramaterString));
        }

        protected override SourceCodeInfoParamaterFactory
            <SourceCodeInfoParamaterValueCallMethod, SourceCodeInfoParamaterMethod, SourceCodePartsFactoryCommat>
            GetFactory(SourceCodeInfoParamaterValueCallMethod[] values)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}

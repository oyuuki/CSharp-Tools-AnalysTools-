using System;
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
            int hierarchyCount,
            SourceCodePartsFactoryCommat factory)
            : base(hierarchyCount, factory)
        {

        }

        #endregion

        #region Method

        #region Override

        protected override SourceCodeInfoParamaterValueMethod GetSourceCodeInfoParamaterValueLogic(
            SourceCode sourceCode, SourceCodePartsfactory fac, out string paramaterString)
        {
            paramaterString = string.Empty;   // this code won't using at this class

            int asIndex = fac.GetIndexCodeParts("As");
            int parammaterName = asIndex - 1;
            int hierarchyCount = this.HierarchyCount + 1;
            int typeName = asIndex + 1;

            var paramaterStrings = fac.GetNestedCodeParts("(", ")");

            if (paramaterStrings != null && paramaterStrings.Length > 0)
            {
                paramaterString = paramaterStrings[0];
            }

            return new SourceCodeInfoParamaterValueMethod(sourceCode, new SourceCodePartsFactoryParamater(sourceCode),
                parammaterName, hierarchyCount, typeName);
        }

        protected override SourceCodePartsfactory GetSourceCodePartsFactoryParamaterValue(
            SourceCode sourceCode)
        {
            return new SourceCodePartsFactoryParamater(sourceCode);
        }

        protected override SourceCodeInfoParamaterMethod GetSourceCodeInfoParamater(SourceCodeInfoParamaterValueMethod[] values)
        {
            return new SourceCodeInfoParamaterMethod(values);
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

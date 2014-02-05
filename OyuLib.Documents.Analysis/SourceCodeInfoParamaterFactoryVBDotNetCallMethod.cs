using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterFactoryVBDotNetCallMethod :
        SourceCodeInfoParamaterFactory<SourceCodeInfoParamaterValueMethod, SourceCodeInfoParamaterMethod>
    {
        #region Constructor

        public SourceCodeInfoParamaterFactoryVBDotNetCallMethod(
            int hierarchyCount,
            SourceCodePartsfactoryVBDotNet factory)
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

            return new SourceCodeInfoParamaterValueMethod(sourceCode, this.GetSourceCodePartsFactory(),
                parammaterName, hierarchyCount, typeName);
        }

        protected override SourceCodePartsfactory GetSourceCodePartsFactoryParamaterValue(
            SourceCode sourceCode)
        {
            return new SourceCodePartsFactoryVBDotNetMethod(sourceCode);
        }

        protected override SourceCodeInfoParamaterMethod GetSourceCodeInfoParamater(SourceCodeInfoParamaterValueMethod[] values)
        {
            return new SourceCodeInfoParamaterMethod(values);
        }

        #endregion

        #endregion
    }
}

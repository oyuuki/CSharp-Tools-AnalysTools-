using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterFactoryVBDotNetMethod :
        SourceCodeInfoParamaterFactory<SourceCodeInfoParamaterValueCallMethod, SourceCodeInfoParamaterMethod>
    {
        #region Constructor

        public SourceCodeInfoParamaterFactoryVBDotNetMethod(            
            int hierarchyCount,
            SourceCodePartsFactoryCommat paramfactory)
            : base(hierarchyCount, paramfactory)
        {

        }

        #endregion

        #region Method

        #region Override

        protected override SourceCodeInfoParamaterValueCallMethod GetSourceCodeInfoParamaterValueLogic(
            SourceCode sourceCode, SourceCodePartsfactory fac, out string paramaterString)
        {
            paramaterString = string.Empty;   // this code  won't  Using at this class

            int parammaterName = 0;
            int hierarchyCount = this.HierarchyCount + 1;

            var paramaterStrings = fac.GetNestedCodeParts("(", ")");

            if (paramaterStrings != null && paramaterStrings.Length > 0)
            {
                paramaterString = paramaterStrings[0];
            }

            return new SourceCodeInfoParamaterValueCallMethod(sourceCode, this.GetSourceCodePartsFactory(),
                parammaterName, hierarchyCount);
        }

        protected override SourceCodePartsfactory GetSourceCodePartsFactoryParamaterValue(
            SourceCode sourceCode)
        {
            return new SourceCodePartsFactoryParamater(sourceCode);
        }

        protected override SourceCodeInfoParamaterMethod GetSourceCodeInfoParamater(SourceCodeInfoParamaterValueCallMethod[] values)
        {
            return new SourceCodeInfoParamaterMethod(values);
        }

        #endregion

        #endregion
    }
}

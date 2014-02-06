using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterFactoryVBDotNetMethod :
        SourceCodeInfoParamaterFactory<SourceCodeInfoParamaterValueCallMethod, SourceCodeInfoParamaterMethod, SourceCodePartsFactoryCommat>
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

            return new SourceCodeInfoParamaterValueCallMethod(sourceCode, new SourceCodePartsFactoryParamater(sourceCode),
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterFactoryVBDotNetMethod :
        SourceCodeInfoParamaterFactory<SourceCodeInfoParamaterValueMethod, SourceCodeInfoParamaterMethod, SourceCodePartsFactoryCommat>
    {
        #region Constructor

        public SourceCodeInfoParamaterFactoryVBDotNetMethod(            
            int parentIndex,
            SourceCodePartsFactoryCommat paramfactory,
            StringRange range)
            : base(parentIndex, paramfactory, range)
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
            paramaterString = string.Empty;   // this code  won't  Using at this class
            paramaterStringIndex = -1;        // this code  won't  Using at this class
            range = null;                     // this code  won't  Using at this class

            int parammaterName = 1 + partsStartIndex;
            int typeName = fac.GetIndexCodeParts("As") + 1 + partsStartIndex;

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

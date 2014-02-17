using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterFactoryVBDotNetSigunature :
        SourceCodeInfoParamaterFactory<SourceCodeInfoParamaterValueMethod, SourceCodeInfoParamater, SourceCodePartsFactoryCommat>
    {
        #region Constructor

        public SourceCodeInfoParamaterFactoryVBDotNetSigunature(            
            int parentIndex,
            SourceCodePartsFactoryCommat paramfactory,
            StringRange range)
            : base(parentIndex, range)
        {

        }

        #endregion

        #region Method

        #region Override

        protected override SourceCodeInfoParamaterValueMethod[] GetSourceCodeInfoParamaterValueLogic(
            SourceCode sourceCode, 
            SourceCodePartsfactory fac, 
            StringRange rangeParam,
            int groupCount, 
            int hierarchyCount)
        {
            int parammaterName = 1;
            int typeName = fac.GetIndexCodeParts("As") + 1;

            var retList = new List<SourceCodeInfoParamaterValueMethod>();

            retList.Add(new SourceCodeInfoParamaterValueMethod(sourceCode, new SourceCodePartsFactoryParamater(sourceCode),rangeParam,
                parammaterName, groupCount, hierarchyCount, typeName));

            return retList.ToArray();

            
        }

        protected override SourceCodePartsfactory GetSourceCodePartsFactoryParamaterValue(
            SourceCode sourceCode)
        {
            return new SourceCodePartsFactoryParamater(sourceCode);
        }

        protected override SourceCodeInfoParamater GetSourceCodeInfoParamater(SourceCodeInfoParamaterValueMethod[] values)
        {
            return new SourceCodeInfoParamater(values);
        }

        protected override SourceCodePartsFactoryCommat GetFactory(string paramaterString)
        {
            return new SourceCodePartsFactoryCommat(new SourceCode(paramaterString));
        }

        #endregion

        #endregion
    }
}

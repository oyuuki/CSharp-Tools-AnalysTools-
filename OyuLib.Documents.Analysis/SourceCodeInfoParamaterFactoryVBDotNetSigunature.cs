using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterFactoryVBDotNetSigunature :
        SourceCodeInfoParamaterFactory<SourceCodeInfoParamaterValueElementMethod, SourceCodePartsFactoryCommat, SourceCodePartsFactoryCommatIncludeParamater>
    {
        #region Constructor

        public SourceCodeInfoParamaterFactoryVBDotNetSigunature(            
            int parentIndex,
            SourceCodePartsFactoryCommat paramfactory,
            StringRange range)
            : base(parentIndex, range, ",")
        {

        }

        #endregion

        #region Method

        #region Override

        // SourceCodeInfoParamaterValueElementMethod

        protected override SourceCodeInfoParamaterValueElementStrage[] GetSourceCodeInfoParamaterValueLogic(
            SourceCode sourceCode, 
            SourceCodePartsfactory fac, 
            StringRange rangeParam,
            int groupCount, 
            int hierarchyCount)
        {
            int parammaterName = 1;
            int typeName = fac.GetIndexCodeParts("As") + 1;

            var retList = new List<SourceCodeInfoParamaterValueElementStrage>();

            retList.Add(new SourceCodeInfoParamaterValueElementStrage(new SourceCodeInfoParamaterValueElementMethod(sourceCode, new SourceCodePartsFactoryParamater(sourceCode),rangeParam,
                parammaterName, groupCount, hierarchyCount, typeName)));

            return retList.ToArray();
        }

        protected override SourceCodePartsFactoryCommat GetParamaterValueFactory(string paramaterString)
        {
            return new SourceCodePartsFactoryCommat(new SourceCode(paramaterString));
        }

        protected override SourceCodePartsFactoryCommatIncludeParamater GetParamaterElementFactory(string paramaterString)
        {
            return new SourceCodePartsFactoryCommatIncludeParamater(new SourceCode(paramaterString));
        }

        #endregion

        #endregion
    }
}

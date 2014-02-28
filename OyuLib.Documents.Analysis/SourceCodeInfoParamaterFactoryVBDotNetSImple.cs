using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterFactoryVBDotNetSimple :
        SourceCodeInfoParamaterFactory<SourceCodeInfo, SourceCodePartsFactoryCommatIncludeParamater, SourceCodePartsFactoryVBDotNetFomula>
    {
        #region Constructor

        public SourceCodeInfoParamaterFactoryVBDotNetSimple(
            int parentIndex,
            StringRange range)
            : base(parentIndex, range, ",")
        {

        }

        #endregion

        #region Method

        #region Override

        protected override SourceCodeInfoParamaterValueElementStrage[] GetSourceCodeInfoParamaterValueLogic(
            SourceCode sourceCode, 
            SourceCodePartsfactory fac,
            StringRange rangeParam,
            int groupCount,
            int hierarchyCount)
        {

            var retList = new List<SourceCodeInfoParamaterValueElementStrage>();

            var codeParts = fac.GetCodeParts();
            var codeRange = fac.GetCodePartsRanges();

            for (int index = 0; index < codeParts.Length; index++)
            {
                var codepart = codeParts[index];
                var codepartRange = codeRange[index];

                var sourceCodeinner = new SourceCode(codepart);

                retList.AddRange(this.GetSourceCodeInfoParamaterValueLogicForhasReturnValue(
                    sourceCodeinner,
                    new SourceCodePartsFactoryParamater(sourceCodeinner),
                    codepartRange,
                    groupCount,
                    hierarchyCount));
            }

            return retList.ToArray();
        }


        protected override SourceCodePartsFactoryCommatIncludeParamater GetParamaterValueFactory(string paramaterString)
        {
            return new SourceCodePartsFactoryCommatIncludeParamater(new SourceCode(paramaterString));
        }

        protected override SourceCodePartsFactoryVBDotNetFomula GetParamaterElementFactory(string paramaterString)
        {
            return new SourceCodePartsFactoryVBDotNetFomula(new SourceCode(paramaterString));
        }
        

        #endregion

        #endregion
    }
}

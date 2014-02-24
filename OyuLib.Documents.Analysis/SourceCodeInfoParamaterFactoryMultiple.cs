using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterFactoryMultiple :
        SourceCodeInfoParamaterFactory<SourceCodeInfo, SourceCodeInfoParamater, SourceCodePartsFactoryVBDotNetFomula>
    {
        #region Constructor

        public SourceCodeInfoParamaterFactoryMultiple(
            int parentIndex,
            StringRange range)
            : base(parentIndex, range)
        {

        }

        #endregion

        #region Method

        #region Override

        public override SourceCodeInfoParamater GetSourceCodeInfoParamater(SourceCodePartsfactory factory, int hierarchyCount, StringRange range)
        {
            var retList = new List<SourceCodeInfo>();

            if(range.GetStringSpilited().EndsWith(")"))
            {
                retList.Add(SourceCodeInfoFactoryCallMethodVBDotNet.GetCodeInfoCallMethod(new SourceCode(range.GetStringSpilited()), range));
                return this.GetSourceCodeInfoParamater(retList.ToArray());
            }
            else
            {
                return base.GetSourceCodeInfoParamater(factory, hierarchyCount, range);
            }
        }

        protected override SourceCodeInfo[] GetSourceCodeInfoParamaterValueLogic(
            SourceCode sourceCode,
            SourceCodePartsfactory fac,
            StringRange rangeParam,
            int groupCount,
            int hierarchyCount)
        {
            return this.GetSourceCodeInfoParamaterValueLogicForhasReturnValue2(
                 sourceCode,
                 fac,
                 rangeParam,
                 groupCount,
                 hierarchyCount);
        }


        protected SourceCodeInfo[] GetSourceCodeInfoParamaterValueLogicForhasReturnValue2(
           SourceCode sourceCode,
           SourceCodePartsfactory fac,
           StringRange rangeParam,
           int groupCount,
           int hierarchyCount)
        {
            int parammaterName = 0;

            var paramaterStrings = fac.GetNestedCodeParts("(", ")");

            //var innerFacParam = new SourceCodePartsFactoryVBDotNetIfValue(sourceCode);

            //if (innerFacParam.GetCodePartsLength() >= 2)
            //{

            //}

            //var innerParamRange = new StringRange()

            var retList = new List<SourceCodeInfo>();

            // Exist Paramater
            if (paramaterStrings != null && paramaterStrings.Length > 0 && !string.IsNullOrEmpty(paramaterStrings[0]) && !paramaterStrings[0].StartsWith("("))
            {
                var startIndex = 0;
                var sourceCodeString = sourceCode.CodeString.Trim();

                foreach (var param in paramaterStrings)
                {
                    if (paramaterStrings.Length >= 2)
                    {
                        int a1 = 1;
                    }

                    var paramKakko = "(" + param + ")";

                    var paramIndex = sourceCodeString.IndexOf(paramKakko, startIndex);
                    startIndex = sourceCode.CodeString.LastIndexOf(",", paramIndex) + 1;
                    var endIndex = paramIndex + paramKakko.Length;

                    var paramSourceCode =
                        new SourceCode(sourceCodeString.Substring(startIndex, endIndex - startIndex));
                    var range = new StringRange(startIndex, endIndex, "", "", sourceCodeString);
                    startIndex = endIndex;
                    retList.Add(SourceCodeInfoFactoryCallMethodVBDotNet.GetCodeInfoCallMethod(paramSourceCode, rangeParam));
                }

                if (startIndex < sourceCodeString.Length)
                {
                    var paramValueSourceCodeString = sourceCodeString.Substring(startIndex);
                    var paramSourceCode = new SourceCode(paramValueSourceCodeString);

                    var range = new StringRange(0, paramValueSourceCodeString.Length - 1, "", "", paramValueSourceCodeString);
                    retList.Add(new SourceCodeInfoParamaterValueCallMethod(
                        paramSourceCode,
                        new SourceCodePartsFactoryParamater(paramSourceCode),
                        range,
                        0,
                        groupCount,
                        hierarchyCount));
                }
            }
            else
            {
                retList.Add(new SourceCodeInfoParamaterValueCallMethod(sourceCode, new SourceCodePartsFactoryParamater(sourceCode), rangeParam,
                    parammaterName, groupCount, hierarchyCount));
            }

            return retList.ToArray();
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

        protected override SourceCodePartsFactoryVBDotNetFomula GetFactory(string paramaterString)
        {
            return new SourceCodePartsFactoryVBDotNetFomula(new SourceCode(paramaterString));
        }

        #endregion

        #endregion
    }
}

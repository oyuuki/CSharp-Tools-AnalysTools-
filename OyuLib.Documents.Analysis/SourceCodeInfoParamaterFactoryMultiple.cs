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
                var a = range.GetStringSpilited();
                retList.Add(SourceCodeInfoFactoryCallMethodVBDotNet.GetCodeInfoCallMethod(new SourceCode(range.GetStringSpilited()), range));
                return this.GetSourceCodeInfoParamater(retList.ToArray());
            }
            else
            {
                var a = range.GetStringSpilited();
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
            return this.GetSourceCodeInfoParamaterValueLogicForhasReturnValue(
                 sourceCode,
                 fac,
                 rangeParam,
                 groupCount,
                 hierarchyCount);
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

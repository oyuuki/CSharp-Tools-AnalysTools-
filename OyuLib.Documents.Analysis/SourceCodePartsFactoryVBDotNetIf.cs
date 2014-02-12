using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsFactoryVBDotNetIf : SourceCodePartsfactoryNocomment
    {
        #region Constructor

        public SourceCodePartsFactoryVBDotNetIf(
            SourceCode code)
            : base(code, "")
        {

        }

        #endregion

        #region Method

        #region Override

        protected override StringRange[] GetCodePartsRanges(string withOutComment)
        {
            var retList = new List<StringRange>();

            var ifString = new SourceDocumentRuleVBDotNet().GetControlCodeBeginIf() + " ";
            var thenString = " " + SourceDocumentSyntaxVBDotNet.CONST_THEN;

            var ifIndexStart = withOutComment.IndexOf(ifString);
            var ifIndexEnd = ifIndexStart + ifString.Length - 2;
            var thenIndexStart = withOutComment.IndexOf(thenString) + 1;
            var thenIndexEnd = thenIndexStart + thenString.Length - 2;

            retList.Add(new StringRange(ifIndexStart, ifIndexEnd, "", " ", withOutComment));

            retList.Add(new StringRange(ifIndexEnd + 2, thenIndexStart - 2, "", " ", withOutComment));

            retList.Add(new StringRange(thenIndexStart, thenIndexEnd, "", "", withOutComment));

            return retList.ToArray();
        }


        #endregion

        #endregion
    }
}

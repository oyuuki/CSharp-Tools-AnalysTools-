using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsFactoryVBDotNetWith : SourceCodePartsfactoryNocomment
    {
        #region Constructor

        public SourceCodePartsFactoryVBDotNetWith(
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

            var withString = SourceDocumentSyntaxVBDotNet.CONST_STATEMENT_WITH;
            

            var withIndexStart = withOutComment.IndexOf(withString);
            var withIndexEnd = withIndexStart + withString.Length;

            retList.Add(new StringRange(withIndexStart, withIndexEnd, "", " ", withOutComment));

            retList.Add(new StringRange(withIndexEnd + 1, withOutComment.Length - 1, "", " ", withOutComment));

            return retList.ToArray();
        }


        #endregion

        #endregion
    }
}

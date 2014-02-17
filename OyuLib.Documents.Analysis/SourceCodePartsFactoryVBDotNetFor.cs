using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsFactoryVBDotNetFor : SourceCodePartsfactoryNocomment
    {
        #region Constructor

        public SourceCodePartsFactoryVBDotNetFor(
            SourceCode code)
            : base(code, " To ")
        {

        }

        #endregion

        #region Method

        #region Override

        protected override StringRange[] GetCodePartsRanges(string withOutComment)
        {
            var retList = new List<StringRange>();                         


            var toString = this.CodeDelimiter;
            var toStringStartIndex = withOutComment.IndexOf(toString);

            retList.Add(new StringRange(0, toStringStartIndex - 1, " ", withOutComment));

            retList.Add(new StringRange(toStringStartIndex, toStringStartIndex + toString.Length - 1, "", "", withOutComment));

            retList.Add(new StringRange(toStringStartIndex + toString.Length, withOutComment.Length - 1, "", "", withOutComment));

            return retList.ToArray();
        }


        #endregion

        #endregion
    }
}

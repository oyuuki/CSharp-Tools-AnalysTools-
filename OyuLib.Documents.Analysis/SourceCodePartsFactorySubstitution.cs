using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsFactorySubstitution : SourceCodePartsfactoryNocomment
    {
        #region Constructor

        public SourceCodePartsFactorySubstitution(
            SourceCode code)
            : base(code, " = ")
        {

        }

        #endregion

        #region Method

        #region Override

        protected override StringRange[] GetCodePartsRanges(string withOutComment)
        {
            var retList = new List<StringRange>();                         

            var equalsString = this.CodeDelimiter;

            var equalsStringStartIndex = withOutComment.IndexOf(equalsString);


            retList.Add(new StringRange(0, equalsStringStartIndex - 1, " ", withOutComment));

            retList.Add(new StringRange(equalsStringStartIndex, equalsStringStartIndex + equalsString.Length - 1, "", "", withOutComment));

            retList.Add(new StringRange(equalsStringStartIndex + equalsString.Length, withOutComment.Length - 1, "", "", withOutComment));

            return retList.ToArray();
        }


        #endregion

        #endregion
    }
}

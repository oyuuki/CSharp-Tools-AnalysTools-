using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodePartsFactoryVB : CodePartsFactory
    {
        #region Constructor

        public CodePartsFactoryVB(
            Code code,
            string codeDelimiter)
            : base(code, codeDelimiter)
        {
            
        }

        #endregion


        #region Method

        #region Override

        protected override string[] GetCodePartsWithOutComment(string withOutComment)
        {
            return new CharCodeManager(new CharCode(this.CodeDelimiter)).GetSpilitString(withOutComment);
        }

        protected override int GetCommentStartindex()
        {
            var rangeList =
                new StringSpilitter(this.TrimCodeString).GetStringRangeSpilit(new CharCode("'").GetCharCodeString(),
                    new ManagerStringNested("\"", "\""));

            var commentStringIndex = -1;

            foreach (var range in rangeList.Reverse())
            {
                if (range.GetIsSpilitStrings(new string[]{"\"", "\""}))
                {
                    break;
                }

                if (range.GetIsSpilitStrings("'"))
                {
                    commentStringIndex = range.IndexEnd;
                }
            }

            return commentStringIndex;
        }

        #endregion

        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsfactoryNocomment : SourceCodePartsfactory
    {
        #region Constructor

        public SourceCodePartsfactoryNocomment(
            SourceCode code,
            string codeDelimiter)
            : base(code, codeDelimiter)
        {
            
        }

        public SourceCodePartsfactoryNocomment(
            SourceCode code,
            string codeDelimiter,
            bool doTrim)
            : base(code, codeDelimiter, doTrim)
        {

        }

        #endregion


        #region Method

        #region Override

        protected override StringRange[] GetCodePartsRanges(string withOutComment)
        {
            return
                new StringSpilitter(withOutComment).GetStringRangeSpilit(
                    this.CodeDelimiter);
        }

        protected override int GetCommentStartindex()
        {
            var rangeList =
                new StringSpilitter(this.TrimCodeString).GetStringRangeSpilit(new CharCode("'").GetCharCodeString(),
                    new ManagerStringNested("\"", "\""));

            var commentStringIndex = -1;

            foreach (var range in rangeList.Reverse())
            {
                if (range.GetIsSpilitStrings("\"", "\""))
                {
                    break;
                }

                if (range.GetIsSpilitStringStart("'"))
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsfactoryVBDotNetHasParams : SourceCodePartsfactoryVBDotNet
    {
        #region Constructor

        public SourceCodePartsfactoryVBDotNetHasParams(
            SourceCode code,
            string codeDelimiter)
            : base(code, codeDelimiter)
        {
            
        }

        #endregion

        #region Method

        #region OverRide

        protected override StringRange[] GetCodePartsRanges(string withOutComment)
        {
            return
                new StringSpilitter(withOutComment).GetStringRangeSpilit(
                    new CharCode(this.CodeDelimiter).GetCharCodeString(), new ManagerStringNested("(", ")"));
        }

        #endregion

        #endregion

    }
}

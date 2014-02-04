using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources
{
    public class SourceCodePartsfactoryVBHasParams : SourceCodePartsfactoryVB
    {
        #region Constructor

        public SourceCodePartsfactoryVBHasParams(
            SourceCode code,
            string codeDelimiter)
            : base(code, codeDelimiter)
        {
            
        }

        #endregion

        #region Method

        #region OverRide

        protected override string[] GetCodePartsWithOutComment(string withOutComment)
        {
            return
                new StringSpilitter(this.TrimCodeString).GetSpilitStringNoChilds(
                    new CharCode(this.CodeDelimiter).GetCharCodeString(), new ManagerStringNested("(", ")"));
        }

        #endregion

        #endregion

    }
}

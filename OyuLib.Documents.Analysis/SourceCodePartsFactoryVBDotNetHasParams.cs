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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodePartsFactoryHasParams : CodePartsFactory
    {
        #region Constructor

        public CodePartsFactoryHasParams(
            Code code,
            string codeDelimiter)
            : base(code, codeDelimiter)
        {
            
        }

        #endregion

        #region Method

        #region OverRide

        public override string[] GetCodeParts()
        {
            return
                new StringSpilitter(this.Code.GetTrimCodeString()).GetSpilitStringNoChilds(
                    new CharCode(this.CodeDelimiter).GetCharCodeString(), new ManagerStringNested("(", ")"));
        }

        #endregion

        #endregion

    }
}

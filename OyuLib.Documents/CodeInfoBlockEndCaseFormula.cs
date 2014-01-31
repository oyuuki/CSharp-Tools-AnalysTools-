using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockEndCaseFormula : CodeInfoBlockEnd
    {
        #region Constructor

        public CodeInfoBlockEndCaseFormula(
            int statement)
            : base(statement)
        {
            
        }

        public CodeInfoBlockEndCaseFormula(
            Code code,
            CodePartsFactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

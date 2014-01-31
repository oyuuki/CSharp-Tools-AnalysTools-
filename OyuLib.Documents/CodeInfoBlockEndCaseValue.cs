using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockEndCaseValue : CodeInfoBlockEnd
    {
        #region Constructor

        public CodeInfoBlockEndCaseValue(
            int statement)
            : base(statement)
        {
            
        }

        public CodeInfoBlockEndCaseValue(
            Code code,
            CodePartsFactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

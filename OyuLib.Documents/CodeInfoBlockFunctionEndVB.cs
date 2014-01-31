using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockFunctionEndVB : CodeInfoBlockEnd
    {
        #region Constructor

        public CodeInfoBlockFunctionEndVB(
            int statement)
            : base(statement)
        {
            
        }

        public CodeInfoBlockFunctionEndVB(
            Code code,
            CodePartsFactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

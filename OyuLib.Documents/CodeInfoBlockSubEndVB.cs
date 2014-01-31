using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockSubEndVB : CodeInfoBlockEnd
    {
        #region Constructor

        public CodeInfoBlockSubEndVB(
            int statement)
            : base(statement)
        {
            
        }

        public CodeInfoBlockSubEndVB(
            Code code,
            CodePartsFactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

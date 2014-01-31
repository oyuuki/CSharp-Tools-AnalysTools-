using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockEndWithVB : CodeInfoBlockEnd
    {
        #region Constructor

        public CodeInfoBlockEndWithVB(
            int statement)
            : base(statement)
        {
            
        }

        public CodeInfoBlockEndWithVB(
            Code code,
            CodePartsFactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

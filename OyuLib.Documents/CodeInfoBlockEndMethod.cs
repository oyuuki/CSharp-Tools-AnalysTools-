using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockEndMethod : CodeInfoBlockEnd
    {
        #region Constructor

        public CodeInfoBlockEndMethod(
            int statement)
            : base(statement)
        {
            
        }

        public CodeInfoBlockEndMethod(
            Code code,
            CodePartsFactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion

    }
}

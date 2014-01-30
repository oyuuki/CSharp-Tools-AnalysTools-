using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockEndIf : CodeInfoBlockEnd
    {
        #region Constructor

        public CodeInfoBlockEndIf(
            int statement)
            : base(statement)
        {
            
        }

        public CodeInfoBlockEndIf(
            Code code,
            CodePartsFactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

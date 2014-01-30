using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockEndFor : CodeInfoBlockEnd
    {
        #region Constructor

        public CodeInfoBlockEndFor(
            int statement)
            : base(statement)
        {
            
        }

        public CodeInfoBlockEndFor(
            Code code,
            CodePartsFactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

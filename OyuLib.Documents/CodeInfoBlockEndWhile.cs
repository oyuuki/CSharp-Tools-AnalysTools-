using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockEndWhile : CodeInfoBlockEnd
    {
        #region Constructor

        public CodeInfoBlockEndWhile(
            int statement)
            : base(statement)
        {
            
        }

        public CodeInfoBlockEndWhile(
            Code code,
            CodePartsFactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

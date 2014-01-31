using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockEndDoWhile :CodeInfoBlockEnd
    {
        #region Constructor

        public CodeInfoBlockEndDoWhile(
            int statement)
            : base(statement)
        {
            
        }

        public CodeInfoBlockEndDoWhile(
            Code code,
            CodePartsFactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

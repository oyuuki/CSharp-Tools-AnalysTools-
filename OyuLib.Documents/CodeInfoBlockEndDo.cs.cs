using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockEndDo :CodeInfoBlockEnd
    {
        #region Constructor

        public CodeInfoBlockEndDo(
            int statement)
            : base(statement)
        {
            
        }

        public CodeInfoBlockEndDo(
            Code code,
            CodePartsFactory coFac,
            int statement)
            : base(code, coFac, statement)
        {
            
        }

        #endregion
    }
}

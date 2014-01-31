using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockBeginDoWhile : CodeInfoBlockBegin<CodeInfoBlockEndDoWhile>
    {
        #region Constructor

        public CodeInfoBlockBeginDoWhile(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
            
        }

        public CodeInfoBlockBeginDoWhile(
            Code code,
            CodePartsFactory coFac,
            int statement,
            int statementObject)
            : base(code, coFac, statement, statementObject)
        {
            
        }

        #endregion
    }
}

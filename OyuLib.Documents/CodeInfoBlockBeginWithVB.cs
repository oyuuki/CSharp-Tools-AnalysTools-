using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockBeginWithVB : CodeInfoBlockBegin
    {
        #region Constructor

        public CodeInfoBlockBeginWithVB(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
            
        }

        public CodeInfoBlockBeginWithVB(
            Code code,
            CodePartsFactory coFac,
            int statement,
            int statementObject)
            : base(code, coFac, statement, statementObject)
        {

        }

        #endregion

        #region Method

        #region OverRide

        public override Type GetCodeInfoBlockEndType()
        {
            return typeof(CodeInfoBlockEndWithVB);
        }

        #endregion

        #endregion
    }
}

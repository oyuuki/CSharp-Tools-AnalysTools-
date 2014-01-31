using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockBeginCaseFormula : CodeInfoBlockBegin
    {
        #region Constructor

        public CodeInfoBlockBeginCaseFormula(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
            
        }

        public CodeInfoBlockBeginCaseFormula(
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
            return typeof(CodeInfoBlockEndCaseFormula);
        }

        #endregion

        #endregion
    }
}

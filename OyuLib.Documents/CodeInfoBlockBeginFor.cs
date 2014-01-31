using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockBeginFor : CodeInfoBlockBegin
    {
        #region Constructor

        public CodeInfoBlockBeginFor(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
            
        }

        public CodeInfoBlockBeginFor(
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
            return typeof (CodeInfoBlockEndFor);
        }

        #endregion

        #endregion
    }
}

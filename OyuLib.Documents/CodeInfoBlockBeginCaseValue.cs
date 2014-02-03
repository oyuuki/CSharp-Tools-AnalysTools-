using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockBeginCaseValue : CodeInfo
    {
        #region instanceVal

        private int _value = -1;

        #endregion

        #region Constructor

        public CodeInfoBlockBeginCaseValue(int value)
            : base()
        {
            this._value = value;
        }

        public CodeInfoBlockBeginCaseValue(
            Code code,
            CodePartsFactory coFac,
            int value)
            : base(code, coFac)
        {
            this._value = value;
        }

        #endregion

        protected override string GetCodeText()
        {
            return "CASE：";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoOther : CodeInfo
    {
        #region Constructor

        public CodeInfoOther()
        {
               
        }

        public CodeInfoOther(
            Code code,
            CodePartsFactory _coFac)
            : base(code, _coFac)
        {
        }

        #endregion

        #region Method

        #region Override

        protected override string GetCodeText()
        {
            return "その他コード：" + this.CodeString;
        }

        #endregion

        #endregion
    }
}

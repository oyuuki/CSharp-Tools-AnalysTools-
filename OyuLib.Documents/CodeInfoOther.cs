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

        public CodeInfoOther(Code code)
            : base(code)
        {
        }

        public CodeInfoOther(string codeString, string codeDelimiter)
            : base(codeString, codeDelimiter)
        {
        }

        #endregion

        #region Method

        #region Override

        public override string GetCodeText()
        {
            return "その他コード：" + this.Code.CodeString;
        }

        #endregion

        #endregion
    }
}

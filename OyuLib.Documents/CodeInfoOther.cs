using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoOther : CodeInfo<Code>
    {
        #region Constructor

        public CodeInfoOther()
        {
               
        }

        public CodeInfoOther(Code code)
            : base(code)
        {
        }

        #endregion

        #region Method

        #region Override

        public override string GetCodeText()
        {
            return "その他コード：" + this.CodeString;
        }

        #endregion

        #endregion
    }
}

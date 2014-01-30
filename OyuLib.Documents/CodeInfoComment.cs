using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoComment : CodeInfo
    {
        #region Constructor

        public CodeInfoComment()
            : base()
        {
            
        }

        public CodeInfoComment(
            Code code,
            CodePartsFactory _coFac)
            : base(code, _coFac)
        {
            
        }

        #endregion

        #region Method

        #region override

        public override string GetCodeText()
        {
            return "コメント：" + this.CodeString;
        }

        #endregion

        #endregion
    }
}

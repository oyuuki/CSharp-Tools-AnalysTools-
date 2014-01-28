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
            Code code)
            : base(code)
        {
            
        }

        public CodeInfoComment(
            string codeLine,
            string codeDelimiter)
            : base(codeLine, codeDelimiter)
        {
            
        }

        #endregion

        #region Method

        #region override

        public override string GetCodeText()
        {
            return "コメント：" + this.Code.CodeString;
        }

        #endregion

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoComment : CodeInfo<Code>
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

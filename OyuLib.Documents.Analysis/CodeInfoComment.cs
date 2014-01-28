using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
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

        public override CodeInfo GetCodeInfo()
        {
            throw new NotImplementedException();
        }

        public override bool IsCodeInfo()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}

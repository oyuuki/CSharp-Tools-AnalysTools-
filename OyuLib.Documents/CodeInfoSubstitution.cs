using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoSubstitution : CodeInfo
    {
        #region instanceVal

        private int rightHandSide = -1;
        private int leftHandSide = -1;

        #endregion

        #region Constructor

        public CodeInfoSubstitution()
            : base()
        {
            
        }

        public CodeInfoSubstitution(
            Code code)
            : base(code)
        {
            
        }

        public CodeInfoSubstitution(
            string codeLine,
            string codeDelimiter)
            : base(codeLine, codeDelimiter)
        {
            
        }

        #endregion

        #region Property


        #endregion

        #region Method

        #region override

        public override string GetCodeText()
        {
            return "右辺：" + this.Code.CodeString;
        }

        #endregion

        #endregion
    }
}

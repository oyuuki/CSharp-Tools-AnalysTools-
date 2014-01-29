using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoSubstitution : CodeInfo
    {
        #region instanceVal

        private int _rightHandSide = -1;
        private int _leftHandSide = -1;

        #endregion

        #region Constructor

        public CodeInfoSubstitution()
            : base()
        {
            
        }

        public CodeInfoSubstitution(
            Code code,
            int rightHandSide,
            int leftHandSide)
            : base(code)
        {
            this._rightHandSide = rightHandSide;
            this._leftHandSide = leftHandSide;
        }

        public CodeInfoSubstitution(
            string codeLine,
            string codeDelimiter,
            int rightHandSide,
            int leftHandSide)
            : base(codeLine, codeDelimiter)
        {
            this._rightHandSide = rightHandSide;
            this._leftHandSide = leftHandSide;
        }

        #endregion

        #region Property


        #endregion

        #region Method

        #region override

        public override string GetCodeText()
        {
            return "右辺：" + this.CodeString;
        }

        #endregion

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoSubstitution : SourceCodeInfo
    {
        #region instanceVal

        private int _rightHandSide = -1;
        private int _leftHandSide = -1;

        #endregion

        #region Constructor

        public SourceCodeInfoSubstitution()
            : base()
        {
            
        }

        public SourceCodeInfoSubstitution(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int rightHandSide,
            int leftHandSide)
            : base(code, coFac)
        {
            this._rightHandSide = rightHandSide;
            this._leftHandSide = leftHandSide;
        }

        #endregion

        #region Property

        public string RightHandSide
        {
            get { return this.GetCodePartsString(this._rightHandSide); }
        }

        public string LeftHandSide
        {
            get { return this.GetCodePartsString(this._leftHandSide); }
        }


        #endregion

        #region Method

        #region override

        protected override string GetCodeText()
        {
            return "代入式  左辺：" + this.LeftHandSide + " 右辺：" + this.RightHandSide;
        }

        #endregion

        #endregion
    }
}

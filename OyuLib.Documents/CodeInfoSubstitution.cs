﻿using System;
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

        public override string GetCodeText()
        {
            return "代入式  左辺：" + this.LeftHandSide + " 右辺：" + this.RightHandSide;
        }

        #endregion

        #endregion
    }
}

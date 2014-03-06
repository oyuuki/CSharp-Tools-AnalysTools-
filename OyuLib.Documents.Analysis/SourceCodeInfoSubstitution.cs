using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoSubstitution : SourceCodeInfo, IParamater
    {
        #region instanceVal

        private int _rightHandSide = -1;

        private int _leftHandSide = -1;

        private SourceCodeInfoParamater _sourceCodeInfoParamaterValueMethodRight = null;
        private SourceCodeInfoParamater _sourceCodeInfoParamaterValueMethodLeft = null;

        private StringRange _range = null;

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
            int leftHandSide,
            SourceCodeInfoParamater sourceCodeInfoParamaterValueMethodRight,
            SourceCodeInfoParamater sourceCodeInfoParamaterValueMethodLeft)
            : base(code, coFac)
        {
            this._rightHandSide = rightHandSide;
            this._leftHandSide = leftHandSide;
            this._sourceCodeInfoParamaterValueMethodRight = sourceCodeInfoParamaterValueMethodRight;
            this._sourceCodeInfoParamaterValueMethodLeft = sourceCodeInfoParamaterValueMethodLeft;
        }

        #endregion

        #region Property

        public string RightHandSide
        {
            get { return this.GetCodePartsString(this._rightHandSide); }
            set { this.SetOverwriteValue(this._rightHandSide, value); }
        }

        public string LeftHandSide
        {
            get { return this.GetCodePartsString(this._leftHandSide); }
            set { this.SetOverwriteValue(this._leftHandSide, value); }
        }

        public StringRange Range
        {
            get { return this._range; }
            set { this._range = value; }
        }

        #endregion

        #region Method

        #region override

        public bool GetIsOverWriteParamater()
        {
            foreach (var param in this.GetSourceCodeInfoParamaters())
            {
                foreach (var codeinfo in param.GetAllSourceCodeInfos())
                {
                    if (codeinfo.IsOverWrite())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public SourceCodeInfoParamater[] GetSourceCodeInfoParamaters()
        {
            return new SourceCodeInfoParamater[] { this._sourceCodeInfoParamaterValueMethodRight, this._sourceCodeInfoParamaterValueMethodLeft };
        }

        protected override string GetCodeText()
        {
            return "代入式  左辺：" + this.LeftHandSide + " 右辺：" + this.RightHandSide;
        }

        public override NestIndex[] GetNestIndices()
        {
            return new NestIndex[]
            {
                new NestIndex(this._rightHandSide),
                new NestIndex(this._leftHandSide)
            };
        }

        public override bool GetParamaterOverWriteValues(int index, ref StringBuilder strBu)
        {
            if (index == this._rightHandSide)
            {
                strBu.Append(this.GetSourceCodeInfoParamaters()[0].GetParamaterOverWriteValues());
                return true;
            }
            else if (index == this._leftHandSide)
            {
                strBu.Append(this.GetSourceCodeInfoParamaters()[1].GetParamaterOverWriteValues());
                return true;
            }

            return false;
        }

        #endregion

        #endregion
    }
}

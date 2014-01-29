using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public abstract class AnalyzerCodeInfo
    {
        #region instanceVal

        private string _codeString = null;

        private bool _isInsiteMethod = false;

        #endregion

        #region Constructor

        protected AnalyzerCodeInfo()
        {
        }

        protected AnalyzerCodeInfo(string codeString)
            : this(codeString, false)
        {
            this._codeString = codeString;
        }

        protected AnalyzerCodeInfo(string code, bool isInsiteMethod)
        {
            this._codeString = code;
            this._isInsiteMethod = isInsiteMethod;
        }

        #endregion

        #region Property

        protected bool IsInsiteMethod
        {
            get { return this._isInsiteMethod; }
        }

        #endregion

        #region Method

        #region Virtual

        public virtual CodeInfo GetAntherCodeInfo()
        {
            return new CodeInfoOther(this.GetCode());
        }

        #endregion

        #region Public

        public CodeInfo GetCodeInfo()
        {
            CodeInfo retValue = null;

            if (this.CheckCodeInfoComment(this.GetCode()))
            {
                return this.GetCodeInfoComment(this.GetCode());
            }

            return this.GetCodeInfoNoIncludeComment();
        }

        public CodeInfo GetCodeInfoNoIncludeComment()
        {
            if (this.CheckCodeInfoEventMethod(this.GetCode()))
            {
                return this.GetCodeInfoEventMethod(this.GetCode());
            }
            else if (this.CheckCodeInfoVariable(this.GetCode()))
            {
                return this.GetCodeInfoVariable(this.GetCode());
            }
            else if (this.CheckCodeInfoMemberVariable(this.GetCode()))
            {
                return this.GetCodeInfoMemberVariable(this.GetCode());
            }
            else if (this.CheckCodeInfoMethod(this.GetCode()))
            {
                return this.GetCodeInfoMethod(this.GetCode());
            }
            else if (this.CheckCodeInfoCallMethod(this.GetCode()))
            {
                return this.GetCodeInfoCallMethod(this.GetCodeExPartsLogic());
            }
            else if (this.CheckCodeInfoSubstitution(this.GetCode()))
            {
                return this.GetCodeInfoSubstitution(this.GetCode());
            }

            return this.GetAntherCodeInfo();
        }

        #endregion

        #region Protected


        #endregion

        #region Abstract

        protected abstract CodeInfoComment GetCodeInfoComment(Code code);
        protected abstract bool CheckCodeInfoComment(Code code);

        protected abstract CodeInfoMethod GetCodeInfoMethod(Code code);
        protected abstract bool CheckCodeInfoMethod(Code code);

        protected abstract CodeInfoEventMethod GetCodeInfoEventMethod(Code code);
        protected abstract bool CheckCodeInfoEventMethod(Code code);

        protected abstract CodeInfoValiable GetCodeInfoVariable(Code code);
        protected abstract bool CheckCodeInfoVariable(Code code);

        protected abstract CodeInfoMemberVariable GetCodeInfoMemberVariable(Code code);
        protected abstract bool CheckCodeInfoMemberVariable(Code code);

        protected abstract CodeInfoCallMethod GetCodeInfoCallMethod(CodeExPartsLogic code);
        protected abstract bool CheckCodeInfoCallMethod(Code code);

        protected abstract CodeInfoSubstitution GetCodeInfoSubstitution(Code code);
        protected abstract bool CheckCodeInfoSubstitution(Code code);

        #endregion

        #region protected

        protected Code GetCode()
        {
            return new Code(this._codeString, new SourceRuleVBDotNet().GetCodesSeparatorString());
        }

        protected CodeExPartsLogic GetCodeExPartsLogic()
        {
            return new CodeExPartsLogic(this._codeString, new SourceRuleVBDotNet().GetCodesSeparatorString());
        }

        #endregion

        #endregion

    }
}

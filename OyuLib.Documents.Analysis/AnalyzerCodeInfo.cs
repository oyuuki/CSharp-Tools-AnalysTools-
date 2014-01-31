using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public abstract class AnalyzerCodeInfo : ISourceRule
    {
        #region instanceVal

        private Code _code = null;

        private bool _isInsiteMethod = false;

        #endregion

        #region Constructor

        protected AnalyzerCodeInfo()
        {

        }

        protected AnalyzerCodeInfo(Code code)
            : this(code, false)
        {
            this._code = code;
        }

        protected AnalyzerCodeInfo(Code code, bool isInsiteMethod)
        {
            this._code = code;
            this._isInsiteMethod = isInsiteMethod;
        }

        #endregion

        #region Property

        protected bool IsInsiteMethod
        {
            get { return this._isInsiteMethod; }
        }

        private Code Code
        {
            get { return this._code; }
        }

        #endregion

        #region Method

        #region Private

        #region ControlCodeInfo

        public virtual CodeInfo GetControlCodeInfo()
        {
            Code code = this.Code;
            SourceRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            if (coFac.IsIncludeStringInCode(rule.GetControlCodeIf()))
            {
                if (coFac.IsIncludeStringInCode(rule.GetControlCodeEndIf()))
                {
                    return this.GetCodeInfoBlockEndIf(this.Code);
                }
                else
                {
                    return this.GetCodeInfoBlockBeginIf(this.Code);
                }
            }
            else if (coFac.IsIncludeStringInCode(rule.GetControlCodeFor()))
            {
                return this.GetCodeInfoBlockBeginFor(this.Code);
            }
            else if (coFac.IsIncludeStringInCode(rule.GetControlCodeEndFor()))
            {
                return this.GetCodeInfoBlockEndFor(this.Code);
            }
            else if (coFac.IsIncludeStringInCode(rule.GetControlCodeDo()))
            {
                return this.GetCodeInfoBlockBeginDo(this.Code);
            }
            else if (coFac.IsIncludeStringInCode(rule.GetControlCodeEndDo()))
            {
                return this.GetCodeInfoBlockEndDo(this.Code);
            }
            else if (coFac.IsIncludeStringInCode(rule.GetControlCodeWhile()))
            {
                if (coFac.IsIncludeStringInCode(rule.GetControlCodeEndWhile()))
                {
                    return this.GetCodeInfoBlockEndWhile(this.Code);
                }
                else
                {
                    return this.GetCodeInfoBlockBeginWhile(this.Code);
                }
            }

            return null;
        }

        #endregion

        #endregion

        #region Virtual

        public virtual CodeInfo GetAntherCodeInfo(Code code)
        {
            return new CodeInfoOther(code, new CodePartsFactoryVB(this.Code, this.GetSourceRule().GetCodeEndSeparatorString()));
        }

        #endregion

        #region Public

        public CodeInfo GetCodeInfo()
        {
            CodeInfo retValue = null;

            if (this.CheckCodeInfoComment(this.Code))
            {
                retValue =  this.GetCodeInfoComment(this.Code);
            }
            else if (this.CheckControlCode(this.Code))
            {
                retValue = this.GetControlCodeInfo();
            }

            if (retValue == null)
            {
                retValue = this.GetCodeInfoNoIncludeComment();
            }

            return retValue;
        }

        public CodeInfo GetCodeInfoNoIncludeComment()
        {
            if (this.CheckCodeInfoEventMethod(this.Code))
            {
                return this.GetCodeInfoEventMethod(this.Code);
            }
            else if (this.CheckCodeInfoVariable(this.Code))
            {
                return this.GetCodeInfoVariable(this.Code);
            }
            else if (this.CheckCodeInfoMemberVariable(this.Code))
            {
                return this.GetCodeInfoMemberVariable(this.Code);
            }
            else if (this.CheckCodeInfoMethod(this.Code))
            {
                return this.GetCodeInfoMethod(this.Code);
            }
            else if (this.CheckCodeInfoCallMethod(this.Code))
            {
                return this.GetCodeInfoCallMethod(this.Code);
            }
            else if (this.CheckCodeInfoSubstitution(this.Code))
            {
                return this.GetCodeInfoSubstitution(this.Code);
            }


            return this.GetAntherCodeInfo(this.Code);
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

        protected abstract CodeInfoCallMethod GetCodeInfoCallMethod(Code code);
        protected abstract bool CheckCodeInfoCallMethod(Code code);

        protected abstract CodeInfoSubstitution GetCodeInfoSubstitution(Code code);
        protected abstract bool CheckCodeInfoSubstitution(Code code);

        protected abstract CodeInfoBlockBeginIf GetCodeInfoBlockBeginIf(Code code);
        protected abstract CodeInfoBlockEndIf GetCodeInfoBlockEndIf(Code code);
        protected abstract CodeInfoBlockBeginDo GetCodeInfoBlockBeginDo(Code code);
        protected abstract CodeInfoBlockEndDo GetCodeInfoBlockEndDo(Code code);
        protected abstract CodeInfoBlockBeginWhile GetCodeInfoBlockBeginWhile(Code code);
        protected abstract CodeInfoBlockEndWhile GetCodeInfoBlockEndWhile(Code code);
        protected abstract CodeInfoBlockBeginFor GetCodeInfoBlockBeginFor(Code code);
        protected abstract CodeInfoBlockEndFor GetCodeInfoBlockEndFor(Code code);
        protected abstract CodeInfoBlockBeginCaseFormula GetCodeInfoBlockBeginCaseFormula(Code code);
        protected abstract CodeInfoBlockEndCaseFormula GetCodeInfoBlockEndCaseFormula(Code code);
        protected abstract CodeInfoBlockBeginCaseValue GetCodeInfoBlockBeginCaseValue(Code code);
        protected abstract CodeInfoBlockEndCaseValue GetCodeInfoBlockEndCaseValue(Code code);
        protected abstract bool CheckControlCode(Code code);

        public abstract SourceRule GetSourceRule();

        #endregion

        #endregion

    }
}

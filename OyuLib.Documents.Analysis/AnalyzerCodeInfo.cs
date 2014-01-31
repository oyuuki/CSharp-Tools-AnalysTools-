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

        private CodeInfo GetControlCodeInfo()
        {
            Code code = this.Code;
            SourceRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            if (this.CheckCodeInfoBlockBeginIf(code))
            {
                return this.GetCodeInfoBlockBeginIf(code);
            }
            else if (this.CheckCodeInfoBlockEndIf(code))
            {
                return this.GetCodeInfoBlockEndIf(code);
            }
            else if (this.CheckCodeInfoBlockBeginDoWhile(code))
            {
                return this.GetCodeInfoBlockBeginDoWhile(code);
            }
            else if (this.CheckInfoBlockEndDoWhile(code))
            {
                return this.GetInfoBlockEndDoWhile(code);
            }
            else if (this.CheckCodeInfoBlockBeginFor(code))
            {
                return this.GetCodeInfoBlockBeginFor(code);
            }
            else if (this.CheckCodeInfoBlockEndFor(code))
            {
                return this.GetCodeInfoBlockEndFor(code);
            }
            else if (this.CheckCodeInfoBlockBeginCaseFormula(code))
            {
                return this.GetCodeInfoBlockBeginCaseFormula(code);
            }
            else if (this.CheckCodeInfoBlockEndCaseFormula(code))
            {
                return this.GetCodeInfoBlockEndCaseFormula(code);
            }
            else if (this.CheckCodeInfoBlockCaseValue(code))
            {
                return this.GetCodeInfoBlockCaseValue(code);
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

            if (retValue == null)
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

        #region Abstract

        protected abstract CodeInfoComment GetCodeInfoComment(Code code);
        protected abstract bool CheckCodeInfoComment(Code code);

        protected abstract CodeInfoBlockBeginMethod GetCodeInfoMethod(Code code);
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
        protected abstract bool CheckCodeInfoBlockBeginIf(Code code);

        protected abstract CodeInfoBlockEndIf GetCodeInfoBlockEndIf(Code code);
        protected abstract bool CheckCodeInfoBlockEndIf(Code code);

        protected abstract CodeInfoBlockBeginDoWhile GetCodeInfoBlockBeginDoWhile(Code code);
        protected abstract bool CheckCodeInfoBlockBeginDoWhile(Code code);

        protected abstract CodeInfoBlockEndDoWhile GetInfoBlockEndDoWhile(Code code);
        protected abstract bool CheckInfoBlockEndDoWhile(Code code);

        protected abstract CodeInfoBlockBeginFor GetCodeInfoBlockBeginFor(Code code);
        protected abstract bool CheckCodeInfoBlockBeginFor(Code code);

        protected abstract CodeInfoBlockEndFor GetCodeInfoBlockEndFor(Code code);
        protected abstract bool CheckCodeInfoBlockEndFor(Code code);

        protected abstract CodeInfoBlockBeginCaseFormula GetCodeInfoBlockBeginCaseFormula(Code code);
        protected abstract bool CheckCodeInfoBlockBeginCaseFormula(Code code);

        protected abstract CodeInfoBlockEndCaseFormula GetCodeInfoBlockEndCaseFormula(Code code);
        protected abstract bool CheckCodeInfoBlockEndCaseFormula(Code code);

        protected abstract CodeInfoBlockBeginCaseValue GetCodeInfoBlockCaseValue(Code code);
        protected abstract bool CheckCodeInfoBlockCaseValue(Code code);

        public abstract SourceRule GetSourceRule();

        #endregion

        #endregion

    }
}

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
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

        #endregion

        #region Method

        #region Private

        #region ControlCodeInfo

        public virtual CodeInfo GetControlCodeInfo()
        {
            Code code = this.GetCode();
            SourceRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactory(code, this.GetSourceRule().GetCodesSeparatorString());

            if (coFac.IsIncludeStringInCode(rule.GetControlCodeIf()))
            {
                if (coFac.IsIncludeStringInCode(rule.GetControlCodeEndIf()))
                {
                    return this.GetAnyCodeInfoBlockEndIf();
                }
                else
                {
                    return this.GetAnyCodeInfoBlockBeginIf();
                }
            }
            else if (coFac.IsIncludeStringInCode(rule.GetControlCodeFor()))
            {
                return this.GetAnyCodeInfoBlockBeginFor();
            }
            else if (coFac.IsIncludeStringInCode(rule.GetControlCodeEndFor()))
            {
                return this.GetAnyCodeInfoBlockEndFor();
            }
            else if (coFac.IsIncludeStringInCode(rule.GetControlCodeDo()))
            {
                return this.GetAnyCodeInfoBlockBeginDo();
            }
            else if (coFac.IsIncludeStringInCode(rule.GetControlCodeEndDo()))
            {
                return this.GetAnyCodeInfoBlockEndDo();
            }
            else if (coFac.IsIncludeStringInCode(rule.GetControlCodeWhile()))
            {
                if (coFac.IsIncludeStringInCode(rule.GetControlCodeEndWhile()))
                {
                    return this.GetAnyCodeInfoBlockEndWhile();
                }
                else
                {
                    return this.GetAnyCodeInfoBlockBeginWhile();
                }
            }

            return null;
        }

        private CodeInfo GetAnyCodeInfoBlockBeginIf()
        {
            Code code = this.GetCode();
            SourceRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactoryHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeIf());
            return new CodeInfoBlockBeginIf(code, coFac, segments, segments + 1);
        }

        private CodeInfo GetAnyCodeInfoBlockEndIf()
        {
            Code code = this.GetCode();
            SourceRule rule = this.GetSourceRule();

            CodePartsFactory coFac = new CodePartsFactoryHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndIf());
            return new CodeInfoBlockEndIf(code, coFac, segments);
        }

        private CodeInfo GetAnyCodeInfoBlockBeginDo()
        {
            Code code = this.GetCode();
            SourceRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactoryHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeDo());
            return new CodeInfoBlockBeginDo(code, coFac, segments, segments + 1);
        }

        private CodeInfo GetAnyCodeInfoBlockEndDo()
        {
            Code code = this.GetCode();
            SourceRule rule = this.GetSourceRule();

            CodePartsFactory coFac = new CodePartsFactoryHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndDo());
            return new CodeInfoBlockEndDo(code, coFac, segments);
        }

        private CodeInfo GetAnyCodeInfoBlockBeginWhile()
        {
            Code code = this.GetCode();
            SourceRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactoryHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeWhile());
            return new CodeInfoBlockBeginWhile(code, coFac, segments, segments + 1);
        }

        private CodeInfo GetAnyCodeInfoBlockEndWhile()
        {
            Code code = this.GetCode();
            SourceRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactoryHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndWhile());
            return new CodeInfoBlockEndWhile(code, coFac, segments);
        }

        private CodeInfo GetAnyCodeInfoBlockBeginFor()
        {
            Code code = this.GetCode();
            SourceRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactory(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeFor());
            return new CodeInfoBlockBeginFor(code, coFac, segments, segments + 1);
        }

        private CodeInfo GetAnyCodeInfoBlockEndFor()
        {
            Code code = this.GetCode();
            SourceRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactory(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndFor());
            return new CodeInfoBlockEndFor(code, coFac, segments);
        }

        private bool CheckControlCode()
        {
            Code code = this.GetCode();
            SourceRule rule = this.GetSourceRule();

            CodePartsFactory coFac = new CodePartsFactory(code, this.GetSourceRule().GetCodesSeparatorString());

            if (!coFac.IsIncludeSomeStringInCode(rule.GetControlCodes()))
            {
                return false;
            }

            return true;
        }

        #endregion

        #endregion

        #region Virtual

        public virtual CodeInfo GetAntherCodeInfo()
        {
            return new CodeInfoOther(this.GetCode(), new CodePartsFactory(this.GetCode(), this.GetSourceRule().GetCodeEndSeparatorString()));
        }

        #endregion

        #region Public

        public CodeInfo GetCodeInfo()
        {
            CodeInfo retValue = null;

            if (this.CheckControlCode())
            {
                return this.GetControlCodeInfo();
            }
            else if (this.CheckCodeInfoComment(this.GetCode()))
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
                return this.GetCodeInfoCallMethod(this.GetCode());
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

        protected abstract CodeInfoCallMethod GetCodeInfoCallMethod(Code code);
        protected abstract bool CheckCodeInfoCallMethod(Code code);

        protected abstract CodeInfoSubstitution GetCodeInfoSubstitution(Code code);
        protected abstract bool CheckCodeInfoSubstitution(Code code);

        public abstract SourceRule GetSourceRule();

        #endregion

        #region protected

        protected Code GetCode()
        {
            return new Code(this._code);
        }

        #endregion

        #endregion

    }
}

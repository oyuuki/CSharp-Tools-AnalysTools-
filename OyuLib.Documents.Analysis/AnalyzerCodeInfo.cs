using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using OyuLib.Documents.Sources;

namespace OyuLib.Documents.Sources.Analysis
{
    internal abstract class AnalyzerCodeInfo : ISourceRule
    {
        #region instanceVal

        private SourceCode _code = null;

        private bool _isInsiteMethod = false;

        #endregion

        #region Constructor

        protected AnalyzerCodeInfo()
        {

        }

        protected AnalyzerCodeInfo(SourceCode code)
            : this(code, false)
        {
            this._code = code;
        }

        protected AnalyzerCodeInfo(SourceCode code, bool isInsiteMethod)
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

        private SourceCode Code
        {
            get { return this._code; }
        }

        #endregion

        #region Method

        #region Private

        #region ControlCodeInfo

        private SourceCodeInfo GetControlCodeInfo()
        {
            SourceCode code = this.Code;
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

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

        public virtual SourceCodeInfo GetAntherCodeInfo(SourceCode code)
        {
            return new SourceCodeInfoOther(code, new SourceCodePartsfactoryVB(this.Code, this.GetSourceRule().GetCodeEndSeparatorString()));
        }

        #endregion

        #region Public

        public SourceCodeInfo GetCodeInfo()
        {
            SourceCodeInfo retValue = null;

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

        public SourceCodeInfo GetCodeInfoNoIncludeComment()
        {
            if (this.CheckCodeInfoBlockBeginEventMethod(this.Code))
            {
                return this.GetCodeInfoBlockBeginEventMethod(this.Code);
            }
            else if (this.CheckCodeInfoVariable(this.Code))
            {
                return this.GetCodeInfoVariable(this.Code);
            }
            else if (this.CheckCodeInfoMemberVariable(this.Code))
            {
                return this.GetCodeInfoMemberVariable(this.Code);
            }
            else if (this.CheckCodeInfoBlockBeginMethod(this.Code))
            {
                return this.GetCodeInfoBlockBeginMethod(this.Code);
            }
            else if (this.CheckCodeInfoBlockEndMethod(this.Code))
            {
                return this.GetCodeInfoBlockEndMethod(this.Code);
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

        protected abstract SourceCodeInfoComment GetCodeInfoComment(SourceCode code);
        protected abstract bool CheckCodeInfoComment(SourceCode code);

        protected abstract SourceCodeInfoBlockBeginMethod GetCodeInfoBlockBeginMethod(SourceCode code);
        protected abstract bool CheckCodeInfoBlockBeginMethod(SourceCode code);

        protected abstract CodeInfoBlockBeginEventMethod GetCodeInfoBlockBeginEventMethod(SourceCode code);
        protected abstract bool CheckCodeInfoBlockBeginEventMethod(SourceCode code);

        protected abstract SourceCodeInfoBlockEndMethod GetCodeInfoBlockEndMethod(SourceCode code);
        protected abstract bool CheckCodeInfoBlockEndMethod(SourceCode code);

        protected abstract SourceCodeInfoValiable GetCodeInfoVariable(SourceCode code);
        protected abstract bool CheckCodeInfoVariable(SourceCode code);

        protected abstract SourceCodeInfoMemberVariable GetCodeInfoMemberVariable(SourceCode code);
        protected abstract bool CheckCodeInfoMemberVariable(SourceCode code);

        protected abstract SourceCodeInfoCallMethod GetCodeInfoCallMethod(SourceCode code);
        protected abstract bool CheckCodeInfoCallMethod(SourceCode code);

        protected abstract SourceCodeInfoSubstitution GetCodeInfoSubstitution(SourceCode code);
        protected abstract bool CheckCodeInfoSubstitution(SourceCode code);

        protected abstract SourceCodeInfoBlockBeginIf GetCodeInfoBlockBeginIf(SourceCode code);
        protected abstract bool CheckCodeInfoBlockBeginIf(SourceCode code);

        protected abstract SourceCodeInfoBlockEndIf GetCodeInfoBlockEndIf(SourceCode code);
        protected abstract bool CheckCodeInfoBlockEndIf(SourceCode code);

        protected abstract SourceCodeInfoBlockBeginDoWhile GetCodeInfoBlockBeginDoWhile(SourceCode code);
        protected abstract bool CheckCodeInfoBlockBeginDoWhile(SourceCode code);

        protected abstract CodeInfoBlockEndDoWhile GetInfoBlockEndDoWhile(SourceCode code);
        protected abstract bool CheckInfoBlockEndDoWhile(SourceCode code);

        protected abstract SourceCodeInfoBlockBeginFor GetCodeInfoBlockBeginFor(SourceCode code);
        protected abstract bool CheckCodeInfoBlockBeginFor(SourceCode code);

        protected abstract SourceCodeInfoBlockEndFor GetCodeInfoBlockEndFor(SourceCode code);
        protected abstract bool CheckCodeInfoBlockEndFor(SourceCode code);

        protected abstract SourceCodeInfoBlockBeginCaseFormula GetCodeInfoBlockBeginCaseFormula(SourceCode code);
        protected abstract bool CheckCodeInfoBlockBeginCaseFormula(SourceCode code);

        protected abstract SourceCodeInfoBlockEndCaseFormula GetCodeInfoBlockEndCaseFormula(SourceCode code);
        protected abstract bool CheckCodeInfoBlockEndCaseFormula(SourceCode code);

        protected abstract SourceCodeInfoBlockBeginCaseValue GetCodeInfoBlockCaseValue(SourceCode code);
        protected abstract bool CheckCodeInfoBlockCaseValue(SourceCode code);

        public abstract SourceDocumentRule GetSourceRule();

        #endregion

        #endregion

    }
}

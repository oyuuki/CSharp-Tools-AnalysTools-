using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public abstract class AnalyzerCodeInfo
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

        protected Code Code
        {
            get { return this._code; }
        }

        protected bool IsInsiteMethod
        {
            get { return this._isInsiteMethod; }
        }

        #endregion

        #region Method

        #region Public

        public CodeInfo GetCodeInfo()
        {
            CodeInfo retValue = null;

            if (this.CheckCodeInfoComment())
            {
                return this.GetCodeInfoComment();
            }

            return this.GetCodeInfoNoIncludeComment();
        }

        public CodeInfo GetCodeInfoNoIncludeComment()
        {
            if (this.CheckCodeInfoEventMethod())
            {
                return this.GetCodeInfoEventMethod();
            }
            else if (this.CheckCodeInfoVariable())
            {
                return this.GetCodeInfoVariable();
            }
            else if (this.CheckCodeInfoMemberVariable())
            {
                return this.GetCodeInfoMemberVariable();
            }
            else if (this.CheckCodeInfoMethod())
            {
                return this.GetCodeInfoMethod();
            }
            else if (this.CheckCodeInfoCallMethod())
            {
                return this.GetCodeInfoCallMethod();
            }
            
            return new CodeInfoOther(this.Code);
        }

        #endregion

        #region Protected

        protected bool IsFirstStringIsValue(string value)
        {
            return this.GetCodeParts()[0].Trim().Equals(value);
        }

        protected bool IsIncludeStringInCodeAtLast(string value)
        {
            return ArrayUtil.IsIncludeStringInCodeAtLast(this.GetCodeParts(), value);
        }

        protected bool IsIncludeSomeStringInCode(string[] values)
        {
            return ArrayUtil.IsIncludeSomeStringsInArray(this.GetCodeParts(), values);
        }

        protected bool IsIncludeStringInCode(string value)
        {
            return this.IsIncludeSomeStringInCode(new string[]{value});
        }

        protected bool IsIncludeAllStringInCode(string[] values)
        {
            return ArrayUtil.IsIncludeAllStringsInArray(this.GetCodeParts(), values);
        }

        protected string[] GetCodeParts()
        {
            return this.Code.CodeParts();
        }
        protected int GetCodePartsLength()
        {
            return this.GetCodeParts().Length;
        }

        protected int GetIndexCodeParts(string value)
        {
            return Array.IndexOf(this.GetCodeParts(), value);
        }

        protected int GetIndexCodeParts(string[] values)
        {
            foreach (var value in values)
            {
                int index = Array.IndexOf(this.GetCodeParts(), value);

                if (index >= 0)
                {
                    return index;
                }
            }

            return -1;
        }

        #endregion

        #region Abstract

        protected abstract CodeInfoComment GetCodeInfoComment();
        protected abstract bool CheckCodeInfoComment();

        protected abstract CodeInfoMethod GetCodeInfoMethod();
        protected abstract bool CheckCodeInfoMethod();

        protected abstract CodeInfoEventMethod GetCodeInfoEventMethod();
        protected abstract bool CheckCodeInfoEventMethod();

        protected abstract CodeInfoValiable GetCodeInfoVariable();
        protected abstract bool CheckCodeInfoVariable();

        protected abstract CodeInfoMemberVariable GetCodeInfoMemberVariable();
        protected abstract bool CheckCodeInfoMemberVariable();

        protected abstract CodeInfoCallMethod GetCodeInfoCallMethod();
        protected abstract bool CheckCodeInfoCallMethod();

        protected abstract CodeInfoSubstitution GetCodeInfoSubstitution();
        protected abstract bool CheckCodeInfoSubstitution();

        #endregion

        #endregion

    }
}

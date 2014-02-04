using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources
{
    public abstract class SourceCodePartsfactory
    {
        #region instanceVal

        private SourceCode _code = null;

        private string _codeDelimiter = string.Empty;

        #endregion

        #region Constructor

        public SourceCodePartsfactory(
            SourceCode code,
            string codeDelimiter)
        {
            this._code = code;
            this._codeDelimiter = codeDelimiter;
        }

        #endregion

        #region Property

        private SourceCode Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public string CodeDelimiter
        {
            get { return this._codeDelimiter; }
            set { this._codeDelimiter = value; }
        }

        public string TrimCodeString
        {
            get { return this._code.CodeString.Trim(); }
        }

        #endregion

        #region Method

        #region Public

        public bool IsFirstStringIsValue(string value)
        {
            return this.GetCodeParts()[0].Trim().Equals(value);
        }

        public bool IsIncludeStringInCodeAtLast(string value)
        {
            return ArrayUtil.IsIncludeStringInCodeAtLast(this.GetCodeParts(), value);
        }

        public bool IsIncludeStringInCodeEndWithAtLast(string value)
        {
            return ArrayUtil.IsIncludeStringInCodeEndWithAtLast(this.GetCodeParts(), value);
        }

        public bool IsIncludeSomeStringInCode(string[] values)
        {
            return ArrayUtil.IsIncludeSomeStringsInArray(this.GetCodeParts(), values);
        }

        public bool IsIncludeStringInCode(string value)
        {
            return this.IsIncludeSomeStringInCode(new string[] { value });
        }

        public bool IsIncludeAllStringInCode(string[] values)
        {
            return ArrayUtil.IsIncludeAllStringsInArray(this.GetCodeParts(), values);
        }

        public int GetCodePartsLength()
        {
            return this.GetCodeParts().Length;
        }

        public int GetIndexCodeParts(string value)
        {
            return Array.IndexOf(this.GetCodeParts(), value);
        }

        public int GetIndexCodeParts(string[] values)
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

        #region Virtual

        public string[] GetCodeParts()
        {
            var str = string.Empty;
            var commentStartIndex = this.GetCommentStartindex();

            if (commentStartIndex >= 0)
            {
                str = this.TrimCodeString.Substring(0, commentStartIndex);
            }
            else
            {
                str = this.TrimCodeString;
            }

            return this.GetCodePartsWithOutComment(str);
        }

        protected abstract string[] GetCodePartsWithOutComment(string withOutComment);

        protected abstract int GetCommentStartindex();

        #endregion

        #endregion
    }
}

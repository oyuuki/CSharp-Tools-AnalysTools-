using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodePartsfactory
    {
        #region instanceVal

        private SourceCode _code = null;

        private string[] _codeDelimiters = null;

        private bool _doTrim = false;

        #endregion

        #region Constructor

        public SourceCodePartsfactory(
            SourceCode code,
            string[] codeDelimiters)
            : this(code, codeDelimiters, true)
        {
            
        }

        public SourceCodePartsfactory(
            SourceCode code,
            string[] codeDelimiter,
            bool doTrim)
        {
            this._code = code;
            this._codeDelimiters = codeDelimiter;
            this._doTrim = doTrim;
        }

        public SourceCodePartsfactory(
            SourceCode code,
            string codeDelimiter)
            : this(code, new string[]{ codeDelimiter }, true)
        {

        }

        public SourceCodePartsfactory(
            SourceCode code,
            string codeDelimiter,
            bool doTrim)
            : this(code, new string[] { codeDelimiter }, doTrim)
        {
            
        }

        #endregion

        #region Property

        private SourceCode Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        protected string[] CodeDelimiters
        {
            get { return this._codeDelimiters; }
            set { this._codeDelimiters = value; }
        }

        protected string CodeDelimiter
        {
            get { return this.CodeDelimiters[0]; }
            set { this.CodeDelimiters[0] = value; }
        }

        public bool DoTrim
        {
            get { return this._doTrim; }
            set { this._doTrim = value; }
        }

        public string TrimCodeString
        {
            get { return this._code.CodeString.Trim(); }
        }

        #endregion

        #region Method

        #region Private

        public string GetStringWithOutComment()
        {
            var stringWithOutComment = string.Empty;

            var commentStartIndex = this.GetCommentStartindex();

            var codeString = this.Code.CodeString;

            if (this.DoTrim)
            {
                codeString = this.TrimCodeString;
            }

            if (commentStartIndex >= 0)
            {
                stringWithOutComment = this.TrimCodeString.Substring(0, commentStartIndex);
            }
            else
            {
                stringWithOutComment = this.TrimCodeString;
            }

            return stringWithOutComment.TrimEnd();
        }

        public string GetComment()
        {
            var commentStartIndex = this.GetCommentStartindex();
            var commentString = string.Empty;

            if (commentStartIndex >= 0)
            {
                commentString = this.TrimCodeString.Substring(commentStartIndex);
            }

            return commentString;
        }

        #endregion

        #region Public

        public string GetTabString()
        {
            var codeString = this._code.CodeString;
            var trimCodeString = codeString.Trim();

            var endTabStringIndex = codeString.IndexOf(trimCodeString) - 1;

            return codeString.Substring(0, endTabStringIndex + 1);
        }

        public bool IsFirstStringIsValue(string value)
        {
            var codeParts = this.GetCodeParts();

            if (codeParts == null || codeParts.Length <= 0)
            {
                return false;
            }

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

        public string[] GetCodeParts()
        {
            string strWithoutComment = this.GetStringWithOutComment();

            string[] codeparts = new StringSpilitter(
                strWithoutComment).GetSpilitStringNoChilds(
                this.GetCodePartsRanges(strWithoutComment));

            return codeparts;
        }


        public string[] GetNestedCodeParts(string spilitSeparatorStart, string spilitSeparatorEnd)
        {
            var retList = new List<string>();

            foreach (var range in this.GetCodePartsRanges())
            {
                if (range.GetIsSpilitStrings(spilitSeparatorStart, spilitSeparatorEnd))
                {
                    retList.Add(range.GetStringSpilited());
                }           
            }

            return retList.ToArray();
        }

        public StringRange[] GetNestedCodePartsRange(string spilitSeparatorStart, string spilitSeparatorEnd)
        {
            var retList = new List<StringRange>();

            foreach (var range in this.GetCodePartsRanges())
            {
                if (range.GetIsSpilitStrings(spilitSeparatorStart, spilitSeparatorEnd))
                {
                    retList.Add(range);
                }
            }

            return retList.ToArray();
        }

        public int[] GetNestedCodePartsIndex(string spilitSeparatorStart, string spilitSeparatorEnd)
        {
            var retList = new List<int>();

            int index = -1;

            foreach (var range in this.GetCodePartsRanges())
            {
                if (range.GetIsSpilitStrings(spilitSeparatorStart, spilitSeparatorEnd))
                {
                    retList.Add(index);
                }

                index++;
            }

            return retList.ToArray();
        }

        public StringRange[] GetCodePartsRanges()
        {
            return this.GetCodePartsRanges(this.GetStringWithOutComment());
        }

        #endregion

        #region Abstract

        protected abstract StringRange[] GetCodePartsRanges(string withOutComment);

        protected abstract int GetCommentStartindex();

        #endregion

        #endregion
    }
}

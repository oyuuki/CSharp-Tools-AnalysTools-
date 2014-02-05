using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
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

        #region Private

        private string GetStringWithOutComment()
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

            return str;
        }

        #endregion

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

        public string[] GetCodeParts()
        {
            string strWithoutComment = this.GetStringWithOutComment();

            string[] codeparts = new StringSpilitter(
                strWithoutComment).GetSpilitStringNoChilds(
                this.GetCodePartsRanges(strWithoutComment));

            return codeparts;
        }

        public string GetTemplateString(int[] codepartsIndexes)
        {
            string str = this.GetStringWithOutComment();

            StringRange[] ranges = this.GetCodePartsRanges(str);
            StringBuilder strBu = new StringBuilder();

            for (int index = 0; index < ranges.Length; index++)
            {
                bool isParts = false;

                strBu.Append(ranges[index].SpilitSeparatorStart);

                foreach (var indexVal in codepartsIndexes)
                {
                    if (indexVal == index)
                    {
                        strBu.Append(this.GetTemplateValue(indexVal));
                        isParts = true;
                        break;
                    }
                }

                if (!isParts)
                {
                    strBu.Append(ranges[index].GetStringSpilited());
                }

                strBu.Append(ranges[index].SpilitSeparatorEnd);
            }

            return strBu.ToString();
        }

        private string GetTemplateValue(int codepartsIndex)
        {
            return "{<<<" + codepartsIndex + ">>>}";
        }

        public string[] GetNestedCodeParts(string spilitSeparatorStart, string spilitSeparatorEnd)
        {
            var retList = new List<string>();

            foreach (var range in this.GetCodePartsRanges(this.GetStringWithOutComment()))
            {
                if (range.GetIsSpilitStrings(spilitSeparatorStart, spilitSeparatorEnd))
                {
                    retList.Add(range.GetStringSpilited());
                }           
            }

            return retList.ToArray();
        }

        #endregion

        #region Abstract

        protected abstract StringRange[] GetCodePartsRanges(string withOutComment);

        protected abstract int GetCommentStartindex();

        #endregion

        #endregion
    }
}

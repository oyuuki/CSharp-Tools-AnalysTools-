using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class Code
    {
        #region InstanceVal

        private string _codeString = string.Empty;

        private string _codeDelimiter = string.Empty;

        #endregion

        #region Constructor

        public Code()
        {
            
        }

        public Code(Code code)
            : this(code.CodeString, code.CodeDelimiter)
        {
            
        }

        public Code(string codeLine, string codeDelimiter)
        {
            this._codeString = codeLine;
            this._codeDelimiter = codeDelimiter;
        }

        #endregion

        #region Property

        public string CodeString
        {
            get { return this._codeString; }
            set { this._codeString = value; }
        }

        public string CodeDelimiter
        {
            get { return this._codeDelimiter; }
            set { this._codeDelimiter = value; }
        }

        #endregion

        #region Method

        #region Virtual

        public virtual string[] CodeParts()
        {
            return new CharCodeManager(new CharCode(this.CodeDelimiter)).GetSpilitString(this.CodeString.Trim());
        }

        #endregion

        #region protected

        public bool IsFirstStringIsValue(string value)
        {
            return this.CodeParts()[0].Trim().Equals(value);
        }

        public bool IsIncludeStringInCodeAtLast(string value)
        {
            return ArrayUtil.IsIncludeStringInCodeAtLast(this.CodeParts(), value);
        }

        public bool IsIncludeStringInCodeEndWithAtLast(string value)
        {
            return ArrayUtil.IsIncludeStringInCodeEndWithAtLast(this.CodeParts(), value);
        }

        public bool IsIncludeSomeStringInCode(string[] values)
        {
            return ArrayUtil.IsIncludeSomeStringsInArray(this.CodeParts(), values);
        }

        public bool IsIncludeStringInCode(string value)
        {
            return this.IsIncludeSomeStringInCode(new string[] { value });
        }

        public bool IsIncludeAllStringInCode(string[] values)
        {
            return ArrayUtil.IsIncludeAllStringsInArray(this.CodeParts(), values);
        }

        public int GetCodePartsLength()
        {
            return this.CodeParts().Length;
        }

        public int GetIndexCodeParts(string value)
        {
            return Array.IndexOf(this.CodeParts(), value);
        }

        public int GetIndexCodeParts(string[] values)
        {
            foreach (var value in values)
            {
                int index = Array.IndexOf(this.CodeParts(), value);

                if (index >= 0)
                {
                    return index;
                }
            }

            return -1;
        }

        #endregion

        #endregion
    }
}

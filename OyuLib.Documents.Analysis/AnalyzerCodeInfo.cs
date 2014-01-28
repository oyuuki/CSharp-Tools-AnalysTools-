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

        public abstract CodeInfo GetCodeInfo();

        public bool IsFirstStringIsValue(string value)
        {
            return this.GetCodeParts()[0].Trim().Equals(value);
        }

        public bool IsIncludeStringInCode(string[] values)
        {
            return ArrayUtil.IsIncludeStringsInArray(this.GetCodeParts(), values);
        }

        public bool IsIncludeStringInCode(string value)
        {
            return this.IsIncludeStringInCode(new string[]{value});
        }

        public bool IsIncludeAllStringInCode(string[] values)
        {
            return ArrayUtil.IsIncludeAllStringsInArray(this.GetCodeParts(), values);
        }

        public string[] GetCodeParts()
        {
            return this.Code.CodeParts();
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

    }
}

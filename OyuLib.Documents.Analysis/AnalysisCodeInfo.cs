using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public abstract class AnalysisCodeInfo
    {
        #region instanceVal

        private Code _code = null;

        #endregion

        #region Constructor

        protected AnalysisCodeInfo()
        {
        }

        protected AnalysisCodeInfo(Code code)
        {
            this._code = code;
        }

        #endregion

        #region Property

        public Code Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        #endregion

        #region Method

        public abstract CodeInfo GetCodeInfo();

        public bool IsIncludeStringInCode(string[] values)
        {
            return ArrayUtil.IsIncludeStringsInArray(this.GetCodeParts(), values);
        }

        public string[] GetCodeParts()
        {
            return this.Code.GetSpilitByDelimiter();
        }

        #endregion

    }
}

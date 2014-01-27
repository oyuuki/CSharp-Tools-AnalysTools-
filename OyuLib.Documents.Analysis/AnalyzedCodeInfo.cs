using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class AnalyzedCodeInfo
    {
        #region instanceVal

        private Code _code = null;

        #endregion

        #region Constructor

        public AnalyzedCodeInfo(Code code)
        {
            this._code = code;
        }

        #endregion

        #region Method

        public CodeInfo GetCodeInfo()
        {
            CodeInfo retValue = null;

            if (IsEventMethod(out retValue))
            {
                return retValue;
            }

            return retValue;
        }

        
        private bool IsEventMethod(out CodeInfo outCodeInfo)
        {
            outCodeInfo = null;

            return false;
        }

        #endregion

    }
}

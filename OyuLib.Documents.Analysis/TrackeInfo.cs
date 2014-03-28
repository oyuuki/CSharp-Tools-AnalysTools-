using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class TrackeInfo
    {
        #region instanceVal

        private SourceCodeInfo _callCodeInfo = null;

        private SourceCodeInfo _callingCallCodeInfo = null;

        #endregion

        #region Constructor

        public TrackeInfo(
            SourceCodeInfo callCodeInfo,
            SourceCodeInfo callingCallCodeInfo)
        {
            this._callCodeInfo = callCodeInfo;
            this._callingCallCodeInfo = callingCallCodeInfo;
        }

        #endregion

    }
}

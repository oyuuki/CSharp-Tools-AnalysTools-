using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterValueElementStrage
    {
        #region instanceVal

        private SourceCodeInfo _sourceCodeInfo = null;

        #endregion

        #region Constructor

        public SourceCodeInfoParamaterValueElementStrage(SourceCodeInfo sourceCodeInfo)
        {
            this._sourceCodeInfo = sourceCodeInfo;
        }

        #endregion

        #region Property

        public SourceCodeInfo Value
        {
            get { return this._sourceCodeInfo; }
        }

        #endregion
    }
}

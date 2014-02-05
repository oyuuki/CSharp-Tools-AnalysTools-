using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodeInfoParamater
    {
        #region instanceVal

        private SourceCodeInfoParamaterValue[] _sourceCodeInfoParamaterValues = null;

        #endregion

        #region Constructor

        public SourceCodeInfoParamater(
            SourceCodeInfoParamaterValue[] sourceCodeInfoParamaterValues)
        {
            this._sourceCodeInfoParamaterValues = sourceCodeInfoParamaterValues;
        }

        #endregion

        #region Method

        

        #endregion
    }
}

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

        private SourceCodeInfoParamaterValueElementStrage _befLinkSourceCodeinfo = null;
        private SourceCodeInfoParamaterValueElementStrage _aftLinkSourceCodeinfo = null;

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

        public SourceCodeInfoParamaterValueElementStrage BefLinkValue
        {
            get { return this._befLinkSourceCodeinfo; }
            set { this._befLinkSourceCodeinfo = value; }
        }

        public bool IsBefExistLinkValue()
        {
            return this.BefLinkValue != null;
        }

        public SourceCodeInfoParamaterValueElementStrage AefLinkValue
        {
            get { return this._aftLinkSourceCodeinfo; }
            set { this._aftLinkSourceCodeinfo = value; }
        }

        public bool IsAefExistLinkValue()
        {
            return this.AefLinkValue != null;
        }

        #endregion
    }
}

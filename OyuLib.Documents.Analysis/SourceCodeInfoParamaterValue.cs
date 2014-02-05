﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodeInfoParamaterValue : SourceCodeInfo        
    {
        #region instanceVal

        private int _parammaterName = -1;

        private int _hierarchyCount = -1;

        private SourceCodeInfoParamater _sourceCodeInfoParamater = null;

        #endregion

        #region Constructor

        public SourceCodeInfoParamaterValue(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int parammaterName, 
            int hierarchyCount)
            : base(code, coFac)
        {
            this._parammaterName = parammaterName;
            this._hierarchyCount = hierarchyCount;
        }

        #endregion

        #region Property

        public string ParammaterName
        {
            get { return this.GetCodePartsString(this._parammaterName); }
        }

        #endregion

        #region Method

        #region Public

        public SourceCodeInfoParamater GetSourceCodeInfoParamater()
        {
            return this._sourceCodeInfoParamater;
        }

        #endregion

        #region Override

        protected override int[] GetCodePartsIndex()
        {
            return new int[] { this._parammaterName };
        }

        protected override string GetCodeText()
        {
            return "パラメータ名：" + this.ParammaterName;
        }

        #endregion

        #endregion
    }
}

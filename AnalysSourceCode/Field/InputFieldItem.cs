﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalysisSourceCode.Field
{
    public abstract class InputFieldItem
    {
        #region Instance

        /// <summary>
        /// source text
        /// </summary>
        protected string _sourceText = null;

        protected int _hierarchyIndex = 0;

        protected string _itemSignature = string.Empty;

        #endregion

        #region constractor

        public InputFieldItem()
        {

        }

        public InputFieldItem(string sourceText, int hierarchyIndex, string itemSignature)
        {
            this._sourceText = sourceText;
            this._hierarchyIndex = hierarchyIndex;
            this._itemSignature = itemSignature;
        }

        #endregion
    }
}

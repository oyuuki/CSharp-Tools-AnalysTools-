﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace TestApp
{
    public abstract class ReplaceManagerSpread<T> : ReplaceManager<T>
        where T : SourceCodeInfo
    {
        #region InstanceVal

        private string _rowString = string.Empty;
        private string _colString = string.Empty;

        #endregion

        #region Constructor

        public ReplaceManagerSpread(
            string rowString, 
            string colString, 
            string comment, 
            string commentSeparator,
            T value)
            : base(value, comment, commentSeparator)
        {
            this._rowString = rowString;
            this._colString = colString;
        }

        #endregion

        #region Property

        public string RowStringMinusOne
        {
            get { return this._rowString + " - 1"; }
        }

        public string ColStringMinusOne
        {
            get { return this._colString + " - 1"; }
        }

        public string RowString
        {
            get { return this._rowString; }
            set { this._rowString = value; }
        }

        public string ColString
        {
            get { return this._colString; }
            set { this._colString = value; }
        }

        #endregion
    }
}

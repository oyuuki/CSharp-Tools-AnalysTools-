using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Search
{
    public class SearchResultItem
    {
        #region instanceVal

        /// <summary>
        /// row number Of search out Text Place
        /// </summary>
        private int _rowNumber = 0;

        /// <summary>
        /// column number Of searched Text Place
        /// </summary>
        private int _columnNumber = 0;

        /// <summary>
        /// Target Text
        /// </summary>
        private string _targetText = string.Empty;

        /// <summary>
        /// Text Line that searched out
        /// </summary>
        private string _findTextLine = string.Empty;

        #endregion

        #region Constructor

        protected SearchResultItem(int rowNumber,
                                 int columnNumber,
                                 string targetText,
                                 string findTextLine)
        {
            this._rowNumber = rowNumber;
            this._columnNumber = columnNumber;
            this._targetText = targetText;
            this._findTextLine = findTextLine;
        }


        #endregion

        #region Property

        public int RowNumber
        {
            get { return this._rowNumber; }
            set { this._rowNumber = value; }
        }

        public int ColumnNumber
        {
            get { return this._columnNumber; }
            set { this._columnNumber = value; }
        }

        public string TargetText
        {
            get { return this._targetText; }
            set { this._targetText = value; }
        }

        public string FindTextLine
        {
            get { return this._findTextLine; }
            set { this._findTextLine = value; }
        }


        #endregion

        #region Method



        #endregion
    }
}

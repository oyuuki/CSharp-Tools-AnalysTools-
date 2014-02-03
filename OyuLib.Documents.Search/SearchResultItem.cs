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
        /// Target Text
        /// </summary>
        private string _targetText = string.Empty;

        /// <summary>
        /// Text Line that searched out
        /// </summary>
        private int _findTextIndex = 0;

        #endregion

        #region Constructor

        public SearchResultItem(string targetText,
                                 int findTextIndex)
        {
            this._targetText = targetText;
            this._findTextIndex = findTextIndex;
        }


        #endregion

        #region Property
       
        public string TargetText
        {
            get { return this._targetText; }
            set { this._targetText = value; }
        }

        public int FindTextIndex
        {
            get { return this._findTextIndex; }
            set { this._findTextIndex = value; }
        }


        #endregion

        #region Method


        #endregion
    }
}

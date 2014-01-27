using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Search
{
    public class SearchItem
    {
        #region instanceVal

        /// <summary>
        /// Target String
        /// </summary>
        private string _targetString = string.Empty;

        /// <summary>
        /// Prove that String Either include regex or not
        /// </summary>
        private bool _isRegexincludePettern = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="targetString">Target String</param>
        public SearchItem(string targetString)
            : this(targetString, false)
        {
            
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="targetString">Target String</param>
        public SearchItem(string targetString, bool isRegexincludePettern)
        {
            this._isRegexincludePettern = isRegexincludePettern;
            this._targetString = targetString;
        }

        #endregion

        #region Property

        public string TargetString
        {
            get { return this._targetString; }
            set { this._targetString = value; }
        }

        public bool IsRegexincludePettern
        {
            get { return this._isRegexincludePettern; }
            set { this._isRegexincludePettern = value; }
        }

        #endregion
    }
}

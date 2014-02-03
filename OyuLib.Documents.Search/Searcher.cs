using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Search
{
    public abstract class Searcher
    {
        #region instanceVal

        /// <summary>
        /// Target String Item
        /// </summary>
        private SearchItem _sItem = null;

        /// <summary>
        /// Target text item
        /// </summary>
        private string _text = null;

        #endregion

        #region Property

        public SearchItem SItem
        {
            get { return this._sItem; }
            set { this._sItem = value; }
        }

        public string Doc
        {
            get { return this._text; }
            set { this._text = value; }
        }

        #endregion

        #region Constructor

        private Searcher(SearchItem sItem, string text)
        {
            this._sItem = sItem;
            this._text = text;
        }

        protected Searcher(string targetString, string text)
            : this(new SearchItem(targetString), text)
        {
            
        }

        protected Searcher(string targetString, bool isRegex, string text)
            : this(new SearchItem(targetString, isRegex), text)
        {

        }

        #endregion

        #region Method

        public abstract SearchResult GetSearchInfo();

        #endregion
    }
}

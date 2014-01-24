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
        private Document _doc = null;

        #endregion

        #region Property

        public SearchItem SItem
        {
            get { return this._sItem; }
            set { this._sItem = value; }
        }

        public Document Doc
        {
            get { return this._doc; }
            set { this._doc = value; }
        }

        #endregion

        #region Constructor

        private Searcher(SearchItem sItem, Document doc)
        {
            this._sItem = sItem;
            this._doc = doc;
        }

        protected Searcher(string targetString, string targetText)
            : this(new SearchItem(targetString), new Document(targetText))
        {
            
        }

        protected Searcher(string targetString, bool isRegex, string targetText)
            : this(new SearchItem(targetString, isRegex), new Document(targetText))
        {

        }

        #endregion

        #region Method

        public abstract SearchResult GetSearchInfo();

        #endregion
    }
}

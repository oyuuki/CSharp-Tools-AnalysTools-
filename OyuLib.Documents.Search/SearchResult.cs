using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Collection;


namespace OyuLib.Documents.Search
{
    public class SearchResult : EnumeratorByIndex<SearchResultItem>
    {
        #region constructor

        public SearchResult()
            : base()
        {
            
        }

        public SearchResult(SearchResultItem[] sResultItem)
            : base(sResultItem)
        {
            
        }

        public SearchResult(SearchResultItem resultItem)
            : base(resultItem)
        {
            
        }

        #endregion

        #region Method

        
        #endregion
    }
}

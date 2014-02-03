using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OyuLib.Documents.Search
{
    public class TextSercher : Searcher
    {
        #region Constructor

        public TextSercher(string targetString, string targetText)
            : base(targetString, targetText)
        {
            
        }
        public TextSercher(string targetString, bool isRegex, string targetText)
            : base(targetString, isRegex, targetText)
        {

        }

        #endregion

        #region Method

        #region override

        public override SearchResult GetSearchInfo()
        {
            var retValue = new SearchResult();

            if (this.SItem.IsRegexincludePettern)
            {
                Regex reg = new Regex(this.SItem.TargetString);

                foreach (Match matched in reg.Matches(this.Text))
                {
                    retValue.Add(new SearchResultItem(this.Text, matched.Index));
                }
            }
            else
            {
                var index = 0;

                while ((index = this.Text.IndexOf(this.SItem.TargetString, index)) >= 0)
                {
                    retValue.Add(new SearchResultItem(this.Text, index + 1));
                }
            }

            return retValue;
        }

        #endregion

        #endregion
    }
}

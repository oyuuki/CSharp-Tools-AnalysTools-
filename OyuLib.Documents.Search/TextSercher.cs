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

            foreach (var line in this.Doc.GetLineArray())
            {
                if (this.SItem.IsRegexincludePettern)
                {
                    Regex reg = new Regex(this.SItem);

                    foreach (Match matched in reg.Matches(line))
                    {
                        
                    }
                }
                else
                {
                    
                }
            }

            return retValue;
        }

        #endregion

        #endregion
    }
}

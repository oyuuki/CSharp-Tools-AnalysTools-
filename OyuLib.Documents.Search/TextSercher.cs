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

            int rownumber = 1;

            foreach (var line in this.Doc.GetLineArray())
            {
                if (this.SItem.IsRegexincludePettern)
                {
                    Regex reg = new Regex(this.SItem.TargetString);

                    foreach (Match matched in reg.Matches(line))
                    {
                        retValue.Add(new SearchResultItem(rownumber, matched.Index + 1, this.SItem.TargetString, line));
                    }
                }
                else
                {
                    var index = 0;

                    while ((index = line.IndexOf(this.SItem.TargetString, index)) >= 0)
                    {
                        retValue.Add(new SearchResultItem(rownumber, index + 1, this.SItem.TargetString, line));
                    }
                }
                
                rownumber++;
            }

            return retValue;
        }

        #endregion

        #endregion
    }
}

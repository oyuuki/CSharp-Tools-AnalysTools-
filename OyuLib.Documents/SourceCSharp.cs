using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class SourceCSharp : Source<CodeCSharp>
    {
        #region constractor

        public SourceCSharp()
            : base()
        {

        }

        public SourceCSharp(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Method

        #region override

        public override string[] GetCodeStringArray()
        {
            var retList = new List<string>();

            retList.Add(string.Empty);

            // 進捗をパーセント表示するラムダ式  
            Func<string, string> proc = (string value) =>
            {
                retList[retList.Count - 1] += value;

                if (value.EndsWith(";") || value.StartsWith("{") || value.EndsWith("}"))
                {
                    retList.Add(string.Empty);
                }

                return string.Empty;
            };

            var result = (from str in this.GetLineArray()
                          select proc(str.Trim()));

            return retList.ToArray();
        }

        #endregion

        #endregion
    }
}

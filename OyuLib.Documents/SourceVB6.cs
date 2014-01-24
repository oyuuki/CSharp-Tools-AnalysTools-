using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace OyuLib.Documents
{
    public class SourceVB6 : Source<CodeVB6>
    {
        #region constractor

        public SourceVB6()
            : base()
        {

        }

        public SourceVB6(string sourceText)
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

            Func<string, string> proc = (string value) =>
            {
                retList[retList.Count - 1] += value;

                if (value.EndsWith("_"))
                {
                    retList[retList.Count - 1] = retList[retList.Count - 1].Substring(0,
                        retList[retList.Count - 1].Length - 1);
                }
                else
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

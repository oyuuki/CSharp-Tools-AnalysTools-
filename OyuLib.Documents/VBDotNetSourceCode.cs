using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class VBDotNetSourceCode : SourceCode<VBDotNetCode>
    {
        #region constractor

        public VBDotNetSourceCode()
            : base()
        {

        }

        public VBDotNetSourceCode(string sourceText)
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

                if (!value.EndsWith("_") || !value.EndsWith(","))
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

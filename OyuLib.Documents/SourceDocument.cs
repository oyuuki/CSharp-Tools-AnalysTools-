using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace OyuLib.Documents
{
    public abstract class SourceDocument : Document, ISourceRule
    {
        #region constractor

        protected SourceDocument()
            : base()
        {

        }

        protected SourceDocument(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Method

        #region Public

        public Code[] GetCodes()
        {
            var retList = new List<Code>();

            
            Func<string, string> proc = (string value) =>
            {
                retList.Add(new Code(value, retList.Count + 1));
                return "";
            };

            foreach (var codeStr in this.GetCodeStringArray())
            {
                proc(codeStr);
            }
            
            return retList.ToArray();

        }

        public string[] GetCodeStringArray()
        {
            var retList = new List<string>();

            retList.Add(string.Empty);

            Func<string, string> proc = (string
                value) =>
            {
                retList[retList.Count - 1] += value;

                if (!ArrayUtil.IsIncludeStringEndsWith(this.GetSourceRule().GetCodeNextSeparatorStrings(), value))
                {
                    retList.Add(string.Empty);
                }
                else
                {
                    retList[retList.Count - 1] = retList[retList.Count - 1].Substring(0,
                        retList[retList.Count - 1].Length - 1);
                }

                return string.Empty;
            };


            foreach (var str in this.GetArrayCodeString())
            {
                proc(str);
            }

            return retList.ToArray();
        }

        private string[] GetArrayCodeString()
        {
            return new CharCodeManager(new CharCode(this.GetSourceRule().GetCodeEndSeparatorString())).GetSpilitString(this.Text);
        }

        #endregion

        #region Abstract

        public abstract SourceDocumentRule GetSourceRule();

        #endregion

        #endregion
    }
}

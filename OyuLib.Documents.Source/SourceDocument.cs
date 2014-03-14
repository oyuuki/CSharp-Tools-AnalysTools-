using System;
using System.Collections.Generic;
using OyuLib.IO;

namespace OyuLib.Documents.Sources
{
    public abstract class SourceDocument : Document, ISourceRule
    {
        #region constractor

        protected SourceDocument()
        {
            
        }

        protected SourceDocument(string filepath)
            : base(filepath)
        {
            
        }

        protected SourceDocument(string filepath, CharSet charactorSet)
            : base(filepath, charactorSet)
        {
            
        }

        public SourceDocument(string textString, bool dummy, bool dummy2)
            : base(textString, dummy, dummy2)
        {
            
        }

        #endregion

        #region Method

        #region Public

        public SourceCode[] GetCodes()
        {
            var retList = new List<SourceCode>();

            
            Func<string, string> proc = (string value) =>
            {
                retList.Add(new SourceCode(value, retList.Count + 1));
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

            if (string.IsNullOrEmpty(retList[retList.Count - 1].Trim()))
            {
                retList.RemoveAt(retList.Count - 1);
            }

            if (string.IsNullOrEmpty(retList[retList.Count - 2].Trim()))
            {
                retList.RemoveAt(retList.Count - 2);
            }
            

            return retList.ToArray();
        }

        private string[] GetArrayCodeString()
        {
            return this.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
        }

        #endregion

        #region Abstract

        public abstract SourceDocumentRule GetSourceRule();

        #endregion

        #endregion
    }
}

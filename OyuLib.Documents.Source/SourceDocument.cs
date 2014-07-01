using System;
using System.Collections.Generic;
using OyuLib.IO;

namespace OyuLib.Documents.Sources
{
    public abstract class SourceDocument : Document, ISourceRule
    {
        private const string CONST_KAIGYO = "\r\n";

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


            Func<SourceStringItem, string> proc = (SourceStringItem value) =>
            {
                retList.Add(new SourceCode(value.BasicSource, retList.Count + 1, value.NonModifySource));
                return "";
            };

            foreach (var codeStr in this.GetCodeStringArray())
            {
                proc(codeStr);
            }
            
            return retList.ToArray();

        }

        public SourceStringItem[] GetCodeStringArray()
        {
            var retList = new List<SourceStringItem>();

            retList.Add(new SourceStringItem("", ""));

            Func<string, string> proc = (string
                value) =>
            {
                retList[retList.Count - 1].BasicSource += value;
                retList[retList.Count - 1].NonModifySource += value;

                if (!ArrayUtil.IsIncludeStringEndsWith(this.GetSourceRule().GetCodeNextSeparatorStrings(), value))
                {
                    retList.Add(new SourceStringItem("", ""));
                }
                else
                {
                    retList[retList.Count - 1].BasicSource = retList[retList.Count - 1].BasicSource.Substring(0,
                        retList[retList.Count - 1].BasicSource.Length - 1);

                    retList[retList.Count - 1].NonModifySource = retList[retList.Count - 1].NonModifySource + CONST_KAIGYO;
                }

                return string.Empty;
            };

            foreach (var str in this.GetArrayCodeString())
            {
                proc(str);
            }

            if (string.IsNullOrEmpty(retList[retList.Count - 1].BasicSource.Trim()))
            {
                retList.RemoveAt(retList.Count - 1);
            }

            if (string.IsNullOrEmpty(retList[retList.Count - 2].BasicSource.Trim()))
            {
                retList.RemoveAt(retList.Count - 2);
            }

            

            return retList.ToArray();
        }

        private string[] GetArrayCodeString()
        {
            return this.Text.Split(new string[] { CONST_KAIGYO }, StringSplitOptions.None);
        }

        #endregion

        #region Abstract

        public abstract SourceDocumentRule GetSourceRule();

        #endregion

        #endregion
    }
}

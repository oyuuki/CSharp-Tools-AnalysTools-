using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace OyuLib.Documents
{
    public abstract class Source : Document, ISourceRule
    {
        #region constractor

        protected Source()
            : base()
        {

        }

        protected Source(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Property

        public string SourceText
        {
            get { return this.DocumnetText; }
            set { this.DocumnetText = value; }
        }

        private new string DocumentText
        {
            get { return base.DocumnetText; }
            set { base.DocumnetText = value; }
        }

        #endregion

        #region Method

        #region Public

        public Code[] GetCodes()
        {
            var retList = new List<Code>();

            
            Func<string, string> proc = (string value) =>
            {
                retList.Add(new Code(value,this.GetSourceRule().GetCodesSeparatorString()));
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
            return new CharCodeManager(new CharCode(this.GetSourceRule().GetCodeEndSeparatorString())).GetSpilitString(this.SourceText);
        }

        #endregion

        #region Abstract

        public abstract SourceRule GetSourceRule();

        #endregion

        #endregion
    }
}

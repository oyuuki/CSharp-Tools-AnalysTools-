using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace OyuLib.Documents
{
    public abstract class Source : Document
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
                retList.Add(TypeUtil.GetInstance<Code>(new object[]{ value }));
                return "";
            };

            var result = (from str in this.GetCodeStringArray()
                select proc(str));

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

                if (!ArrayUtil.IsIncludeStringEndsWith(this.GetCodeNextSeparatorStrings(), value))
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

            var result = (from str in this.GetArrayCodeString()
                          select proc(str.Trim()));

            return retList.ToArray();
        }

        private string[] GetArrayCodeString()
        {
            return new CharCodeManager(new CharCode(this.GetCodeEndSeparatorString())).GetSpilitString(this.SourceText);
        }

        #endregion

        #region Abstract

        public abstract string GetCodeEndSeparatorString();
        public abstract string[] GetAccessModifiersString();
        public abstract string[] GetCodeNextSeparatorStrings();

        #endregion

        #endregion
    }
}

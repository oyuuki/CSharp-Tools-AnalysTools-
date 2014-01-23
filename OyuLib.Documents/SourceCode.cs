using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace OyuLib.Documents
{
    public abstract class SourceCode<T> : Document
        where T : Code, new()
    {
        #region constractor

        public SourceCode()
            : base()
        {

        }

        public SourceCode(string sourceText)
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


        public T[] GetCodes()
        {
            var retList = new List<T>();

            Func<int, int> func2 = (x) => x * 2;  
            // 進捗をパーセント表示するラムダ式  
            Func<string, string> proc = (string value) =>
            {
                retList.Add(TypeUtil.GetInstance<T>(new object[]{ value }));
                return "";
            };

            var result = (from str in this.GetCodeStringArray()
                select proc(str));

            return retList.ToArray();

        }

        #endregion

        #region Abstract

        public abstract string[] GetCodeStringArray();

        #endregion

        #endregion
    }
}

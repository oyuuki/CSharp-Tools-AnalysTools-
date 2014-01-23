using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis.Sources.ScreenField
{
    public class InputFieldItemVBSourceCode : InputFieldItemSourceCode
    {
        #region const

        private const string END = "End\r\n";

        private const string BEGIN = "Begin ";

        #endregion

        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        public InputFieldItemVBSourceCode()
            : base()
        {

        }


        /// <summary>
        /// constractor
        /// </summary>
        public InputFieldItemVBSourceCode(string sourceText, int hierarchyIndex, string itemSignature)
            : base(sourceText, hierarchyIndex, itemSignature)
        {

        }


        #endregion

        #region method

        #region private

        public override bool CreateChild()
        {
            int endIndex = this.SourceText.IndexOf(END);
            int beginIndex = this.SourceText.IndexOf(BEGIN);
            int nextBeginIndex = beginIndex + BEGIN.Length + this.SourceText.Substring(beginIndex + BEGIN.Length).IndexOf(BEGIN);


            if (CountString(this.SourceText, BEGIN) <= 1
                || CountString(this.SourceText, END) <= 1)
            {
                return false;
            }

           if (nextBeginIndex < endIndex)
            {
                string rttt = this.SourceText.Substring(nextBeginIndex);
                string aarttt = rttt.Substring(rttt.IndexOf(BEGIN));
                this.ReplaceTextBrank(this.AddChild<InputFieldItemVBSourceCode>(aarttt));
            }
            else
            {
                this.ReplaceTextBrank(this.AddChild<InputFieldItemVBSourceCode>(this.SourceText.Substring(beginIndex, endIndex - beginIndex + END.Length)));
            }


           if (this.SourceText.IndexOf(END) < this.SourceText.IndexOf(BEGIN))
            {
                return false;
            }

            return true;
        }

        private void ReplaceTextBrank(InputFieldItemVBSourceCode part)
        {
            foreach (string rep in part.GetTextArray())
            {
                this.SourceText = this.SourceText.Replace(rep, "");
            }
        }

        private string GetAllTextUnderFirstBegin()
        {
            return this.SourceText.Substring(this.SourceText.IndexOf(BEGIN) + BEGIN.Length);
        }



        #endregion

        // 文字の出現回数をカウント
        public static int CountString(string s, string s2)
        {
            int ret = s.Length - s.Replace(s2, "").Length;

            return ret > 0 ? ret / s2.Length : ret;
        }

        #endregion
    }
}

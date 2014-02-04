using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis.InputFields
{
    internal class InputFieldItemAnalyzerVB6 : InputFieldItemAnalyzer
    {
        #region const

        private const string END = "End\r\n";

        private const string BEGIN = "Begin ";

        #endregion

        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        public InputFieldItemAnalyzerVB6()
            : base()
        {

        }


        /// <summary>
        /// constractor
        /// </summary>
        public InputFieldItemAnalyzerVB6(string sourceText, int hierarchyIndex, string itemSignature)
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
                this.ReplaceTextBrank(this.AddChild<InputFieldItemAnalyzerVB6>(aarttt));
            }
            else
            {
                this.ReplaceTextBrank(this.AddChild<InputFieldItemAnalyzerVB6>(this.SourceText.Substring(beginIndex, endIndex - beginIndex + END.Length)));
            }


           if (this.SourceText.IndexOf(END) < this.SourceText.IndexOf(BEGIN))
            {
                return false;
            }

            return true;
        }

        private void ReplaceTextBrank(InputFieldItemAnalyzerVB6 part)
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

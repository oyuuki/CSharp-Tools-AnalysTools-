using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalysSourceCode.Generate
{
    class VBSourceCodePart : SourceCodePart
    {
        #region const

        private const string END = "End\r\n";

        private const string BEGIN = "Begin ";

        #endregion

        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        public VBSourceCodePart()
            : base()
        {

        }


        /// <summary>
        /// constractor
        /// </summary>
        public VBSourceCodePart(string sourceText, int hierarchyIndex, string itemSignature)
            : base(sourceText, hierarchyIndex, itemSignature)
        {

        }


        #endregion

        #region method

        #region private

        public override bool CreateChild()
        {
            int endIndex = this._sourceText.IndexOf(END);
            int beginIndex = this._sourceText.IndexOf(BEGIN);
            int nextBeginIndex = beginIndex + BEGIN.Length + this._sourceText.Substring(beginIndex + BEGIN.Length).IndexOf(BEGIN);


            if (CountString(this._sourceText, BEGIN) <= 1
                || CountString(this._sourceText, END) <= 1)
            {
                return false;
            }

           if (nextBeginIndex < endIndex)
            {
                string rttt = this._sourceText.Substring(nextBeginIndex);
                string aarttt = rttt.Substring(rttt.IndexOf(BEGIN));
                this.ReplaceTextBrank(this.AddChild<VBSourceCodePart>(aarttt));
            }
            else
            {
                this.ReplaceTextBrank(this.AddChild<VBSourceCodePart>(this._sourceText.Substring(beginIndex, endIndex - beginIndex + END.Length)));
            }


            if (this._sourceText.IndexOf(END) < this._sourceText.IndexOf(BEGIN))
            {
                return false;
            }

            return true;
        }

        private void ReplaceTextBrank(VBSourceCodePart part)
        {
            foreach (string rep in part.GetTextArray())
            {
                this._sourceText = this._sourceText.Replace(rep, "");
            }
        }

        private string GetAllTextUnderFirstBegin()
        {
            return this._sourceText.Substring(this._sourceText.IndexOf(BEGIN) + BEGIN.Length);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class WinFrmFieldManagerVb6 : WinFrmFieldManager
    {
        #region const

        private const string END = "End\r\n";

        private const string BEGIN = "Begin ";

        #endregion

        #region constractor

        public WinFrmFieldManagerVb6(string sourceText) : base(sourceText)
        {

        }

        public WinFrmFieldManagerVb6()     
        {

        }

        #endregion

        #region method

        private string GetSourceTextWithoutVBForm()
        {
            return this._sourceText.Substring(this._sourceText.IndexOf(BEGIN + "VB.Form"));
        }

        private int getEndIndex(int endIndex)
        {
            return endIndex + END.Length;
        }

        #region override

        protected override AnalyzedInputFieldItem GetSourceCodePart()
        {
            return new AnalyzedVB6InputFieldItem(this.GetSourceTextWithoutVBForm(), 0, string.Empty);
        }
        
        #endregion

        #endregion
    }
}

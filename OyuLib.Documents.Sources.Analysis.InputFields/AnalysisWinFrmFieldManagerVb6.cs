using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis.InputFields
{
    public class AnalysisWinFrmFieldManagerVb6 : AnalysisWinFrmFieldManager
    {
        #region const

        private const string END = "End\r\n";

        private const string BEGIN = "Begin ";

        #endregion

        #region constractor

        public AnalysisWinFrmFieldManagerVb6(string sourceText) : base(sourceText)
        {

        }

        public AnalysisWinFrmFieldManagerVb6()     
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

        protected override InputFieldItemAnalyzer GetInputFieldItemAnalyzer()
        {
            return new InputFieldItemAnalyzerVB6(this.GetSourceTextWithoutVBForm(), 0, string.Empty);
        }
        
        #endregion

        #endregion
    }
}

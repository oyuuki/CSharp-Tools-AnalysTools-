using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Analysis.Source.Field.WindowsForm
{
    class WinFrmFieldItemCodeGeneraterFromVBSource : WinFrmFieldItemCodeGeneraterFromSource
    {
        #region const

        private const string END = "End\r\n";

        private const string BEGIN = "Begin ";

        #endregion

        #region constractor

        public WinFrmFieldItemCodeGeneraterFromVBSource(string sourceText) : base(sourceText)
        {

        }

        public WinFrmFieldItemCodeGeneraterFromVBSource()     
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


        protected override InputFieldItemSourceCode GetSourceCodePart()
        {
            return new InputFieldItemVBSourceCode(this.GetSourceTextWithoutVBForm(), 0, string.Empty);
        }
        
        #endregion

        #endregion
    }
}

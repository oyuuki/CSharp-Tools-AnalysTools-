using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalysSourceCode.Generate
{
    class InputItemCodeGeneraterFromVBSource : InputItemCodeGeneraterFromSource
    {
        #region const

        private const string END = "End\r\n";

        private const string BEGIN = "Begin ";

        #endregion

        #region constractor

        public InputItemCodeGeneraterFromVBSource(string sourceText) : base(sourceText)
        {

        }

        public InputItemCodeGeneraterFromVBSource()     
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


        protected override SourceCodePart GetSourceCodePart()
        {
            return new VBSourceCodePart(this.GetSourceTextWithoutVBForm(), 0, string.Empty);
        }
        
        #endregion

        #endregion
    }
}

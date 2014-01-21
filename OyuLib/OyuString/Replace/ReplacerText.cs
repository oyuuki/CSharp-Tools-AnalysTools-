using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.OyuFile;
using OyuLib.OyuString.Replace;
using OyuLib.OyuString.Text;
using OyuLib;

namespace OyuLib.OyuString.Replace
{
    public class ReplacerText : ReplacerAbs<ReplaceLogicText>
    {
        #region constructor

        public ReplacerText(TextFile textFile, object[] objArray)
            : base(textFile.GetOyuTextFromFile(), objArray)
        {

        }

        public ReplacerText(OyuText text, object[] objArray)
            : base(text, objArray)
        {

        }

        public ReplacerText(string textString, object[] objArray)
            : base(textString, objArray)
        {
            
        }

        #endregion

        #region overide

        protected override string[] ReplaceProc(ReplaceLogicText rep)
        {
            List<string> retList = new List<string>();

            foreach (var line in this._text.GetLineArray())
            {
                retList.Add(rep.GetReplacedText(line));
            }

            return retList.ToArray();
        }

        protected override int[] GetReplaceNumberProc(ReplaceLogicText rep)
        {
            string[] befReplaceTextArray = this._text.GetLineArray();
            string[] replacedlineArray = this.ReplaceProc(rep);

            var retList = new List<int>();

            for (int rowIndex = 0; rowIndex < befReplaceTextArray.Length; rowIndex++)
            {
                if (!befReplaceTextArray[rowIndex].Equals(replacedlineArray[rowIndex]))
                {
                    retList.Add(rowIndex + 1);
                }
            }

            return retList.ToArray();
        }

        #endregion
    }
}

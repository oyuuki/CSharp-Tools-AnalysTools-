using System.Collections.Generic;

namespace OyuLib.Text.Replace
{
    public class ReplacerText : ReplacerAbs<ReplaceLogicText>
    {
        #region constructor

        public ReplacerText(Sentence text, object[] objArray)
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

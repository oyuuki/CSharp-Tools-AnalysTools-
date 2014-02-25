using System.Collections.Generic;

namespace OyuLib.Documents.Replace
{
    public class ReplacerText : ReplacerAbs<ReplaceLogicText>
    {
        #region Constructor

        public ReplacerText(
            Document text,
            string stringWillBeReplace,
            string stringReplacing)
            : base(text, stringWillBeReplace, stringReplacing)
        {

        }

        public ReplacerText(
            string textString,
            string stringWillBeReplace,
            string stringReplacing)
            : base(textString, stringWillBeReplace, stringReplacing)
        {
            
        }

        #endregion

        #region Method

        protected override ReplaceLogicText GetReplaceClass()
        {
            return new ReplaceLogicText(this.StringWillBeReplace, this.StringReplacing, this.IsRegexincludePettern);
        }

        #endregion
    }
}

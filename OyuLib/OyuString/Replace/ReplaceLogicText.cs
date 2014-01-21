using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.OyuString.Replace
{
    public class ReplaceLogicText : ReplaceLogicAbs
    {
        #region Constructor


        public ReplaceLogicText()
            : base()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ReplaceLogicText(string stringWillBeReplace, string stringReplacing)
            : base(stringWillBeReplace, stringReplacing)
        {
        }

        #endregion

        #region Method

        public override string GetReplacedText(string replaceText)
        {
            return this.GetReplaceTextProc(replaceText);
        }

        #endregion
    }
}

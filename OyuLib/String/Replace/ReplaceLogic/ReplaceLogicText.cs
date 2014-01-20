using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.String.Replace.ReplaceLogic
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
        public ReplaceLogicText(string stringReplacing, string stringWillBeReplace)
            : base(stringReplacing, stringWillBeReplace)
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

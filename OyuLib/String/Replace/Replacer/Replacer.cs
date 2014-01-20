using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.String.Replace.Replacer;
using OyuLib.String.Replace.ReplaceLogic;
using OyuLib.String.Text;
using OyuLib;

namespace OyuLib.String.Replace.Replacer
{
    public class Replacer : ReplacerAbs<ReplaceLogicText>
    {
        #region constructor

        public Replacer(OyuText text, object[] objArray)
            : base(text, objArray)
        {

        }

        public Replacer(string textString, object[] objArray)
            : base(textString, objArray)
        {
            
        }

        #endregion

        #region overide

        public override string[] ReplaceProc(ReplaceLogicText rep)
        {
            return this._text.GetLineArray().Select(str => rep.GetReplacedText(str)).ToArray();
        }

        #endregion
    }
}

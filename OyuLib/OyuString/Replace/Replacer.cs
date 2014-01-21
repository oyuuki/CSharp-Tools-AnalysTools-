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
    public class Replacer : ReplacerAbs<ReplaceLogicText>
    {
        #region constructor

        public Replacer(TextFile textFile, object[] objArray)
            : base(textFile.GetOyuTextFromFile(), objArray)
        {

        }

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

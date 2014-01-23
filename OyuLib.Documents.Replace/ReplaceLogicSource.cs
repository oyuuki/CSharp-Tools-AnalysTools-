using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Replace
{
    public class ReplaceLogicSource : ReplaceLogicText
    {
        #region Constructor
        
        public ReplaceLogicSource()
            : base()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ReplaceLogicSource(string stringWillBeReplace, string stringReplacing)
            : base(stringWillBeReplace, stringReplacing)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ReplaceLogicSource(ReplaceInfo reInfo)
            : base(reInfo)
        {
        }

        #endregion

        #region Method

        public override string GetReplacedText(string replaceText)
        {
            return null;
        }

        #endregion
    }
}

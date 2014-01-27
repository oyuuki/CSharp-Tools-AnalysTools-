using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class SourceVBDotNet : Source
    {
        #region constractor

        public SourceVBDotNet()
            : base()
        {

        }

        public SourceVBDotNet(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Method

        #region Override

        public override string GetCodeEndSeparatorString()
        {
            return new LineCharCode().GetCharCodeString();
        }

        public override string[] GetAccessModifiersString()
        {
            return new string[]{"Friend", "ProtectedFriend","Protected", "Public", "Private"};
        }

        public override string[] GetCodeNextSeparatorStrings()
        {
            return new string[] {"_", ","};
        }

        #endregion

        #endregion        
    }
}

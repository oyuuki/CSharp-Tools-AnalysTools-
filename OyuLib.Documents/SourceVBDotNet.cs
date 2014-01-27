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

        public override SourceRule GetSourceRule()
        {
            return new SourceRuleVBDotNet();
        }

        #endregion

        #endregion        
    }
}

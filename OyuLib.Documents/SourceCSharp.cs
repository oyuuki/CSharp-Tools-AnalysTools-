using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class SourceCSharp : Source
    {
        #region constractor

        public SourceCSharp()
            : base()
        {

        }

        public SourceCSharp(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Method

        #region override

        public override SourceRule GetSourceRule()
        {
            return new SourceRuleCSharp();
        }

        #endregion

        #endregion
    }
}

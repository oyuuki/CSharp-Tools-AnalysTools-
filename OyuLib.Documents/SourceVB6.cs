using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace OyuLib.Documents
{
    public class SourceVB6 : Source
    {
        #region constractor

        public SourceVB6()
            : base()
        {

        }

        public SourceVB6(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Method

        #region Override

        public override SourceRule GetSourceRule()
        {
            return new SourceRuleVB6();
        }


        #endregion

        #endregion
    }
}

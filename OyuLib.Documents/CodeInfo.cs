using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public abstract class CodeInfo : Code
    {
        #region Constructor

        protected CodeInfo()
        {
            
        }

        protected CodeInfo(string codeLine)
            : base(codeLine)
        {
            
        }

        #endregion
    }
}

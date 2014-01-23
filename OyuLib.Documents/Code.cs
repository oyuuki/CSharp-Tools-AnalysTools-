using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public abstract class Code
    {
        #region InstanceVal

        private string _codeLine = string.Empty;

        #endregion

        #region Constructor

        public Code()
        {
            
        }

        public Code(string codeLine)
        {
            this._codeLine = codeLine;
        }

        #endregion
    }
}

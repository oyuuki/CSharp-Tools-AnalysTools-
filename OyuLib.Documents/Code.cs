using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class Code
    {
        #region InstanceVal

        private string _codeString = string.Empty;

        #endregion

        #region Constructor

        public Code()
        {
            
        }

        public Code(string codeLine)
        {
            this._codeString = codeLine;
        }

        #endregion

        #region Property

        public string CodeString
        {
            get { return this._codeString; }
            set { this._codeString = value; }
        }

        #endregion
    }
}

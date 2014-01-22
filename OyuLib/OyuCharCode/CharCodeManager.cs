using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.OyuCharCode
{
    public class CharCodeManager
    {
        #region instanceVal

        protected CharCode _cCode = null;

        #endregion

        #region constructor

        public CharCodeManager(CharCode cCode)
        {
            this._cCode = cCode;
        }

        #endregion

        public string[] GetSpilitString(string text)
        {
            return text.Split(new string[] { this._cCode.GetCharCodeString() }, StringSplitOptions.None);
        }
    }
}

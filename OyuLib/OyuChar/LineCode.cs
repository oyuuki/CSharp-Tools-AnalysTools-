using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.OyuChar
{
    public class LineCode : CharCode
    {

        #region constructor

        public LineCode()
            : base('\n')
        {
        }

        #region constructor

        public LineCode(char charCode)
            : base(charCode)
        {
        }

        public LineCode(string stringCode)
            : base(stringCode)
        {
        }

        #endregion

        #endregion
    }
}

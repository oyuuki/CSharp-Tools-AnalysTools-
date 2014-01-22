using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.OyuAttribute;

namespace OyuLib.OyuCharCode
{
    public class LineCharCode : CharCode
    {
        #region constructor

        public LineCharCode()
            : base(ConstAttributeManager<LineCharCodeKind>.GetValueByEnumValue(LineCharCodeKind.EnN))
        {
            
        }


        public LineCharCode(LineCharCodeKind charCodeKind)
            : base(ConstAttributeManager<LineCharCodeKind>.GetValueByEnumValue(charCodeKind))
        {
        }

        #endregion
    }
}

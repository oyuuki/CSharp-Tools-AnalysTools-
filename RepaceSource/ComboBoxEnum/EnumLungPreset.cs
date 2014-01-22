using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.OyuAttribute;

namespace RepaceSource.ComboBoxEnum
{
    public enum EnumLungPreset
    {
        [ConstValue(EnumConstValue.CONST_NONE, "")]
        None,
        [ConstValue(EnumConstValue.CONST_VBDOTNET, "VB.NET")]
        VbDotNet,
        [ConstValue(EnumConstValue.CONST_CSHARP, "C#")]
        CSharp        
    }
}

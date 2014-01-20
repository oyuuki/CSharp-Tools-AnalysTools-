using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ConstAttribute;

namespace RepaceSource.ComboBoxEnum
{
    public enum EnumLungPreset
    {
        [ConstValue("0", "")]
        None,
        [ConstValue("1", "VB.NET")]
        VbDotNet,
        [ConstValue("2", "C#")]
        CSharp        
    }
}

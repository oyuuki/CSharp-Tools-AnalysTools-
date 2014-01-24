using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib;

namespace RepaceSource.ComboBoxEnum
{
    public enum LanguagePreset
    {
        [ConstValue(LanguageNumber.CONST_NONE, "")]
        None,
        [ConstValue(LanguageNumber.CONST_VBDOTNET, "VB.NET")]
        VbDotNet,
        [ConstValue(LanguageNumber.CONST_CSHARP, "C#")]
        CSharp        
    }
}

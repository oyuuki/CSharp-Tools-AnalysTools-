using OyuLib;

namespace RepaceSource.ComboBoxEnum
{
    public enum LanguagePresetExtension
    {
        [ConstValue(LanguageNumber.CONST_NONE, "")]
        None,
        [ConstValue(LanguageNumber.CONST_VBDOTNET, ".vb")]
        VbDotNet,
        [ConstValue(LanguageNumber.CONST_CSHARP, ".cs")]
        CSharp        
    }
}


namespace OyuLib.Analysis.Field
{
    public enum TranceType
    {
        [ConstValue("VB.CommandButton", "Button")]
        Button = 1,
        //  imText6Ctl.imText     → TextBox
        [ConstValue("imText6Ctl.imText", "TextBox")]
        ImText,
        //  imNumber6Ctl.imNumber → TextBox
        [ConstValue("imNumber6Ctl.imNumber", "TextBox")]
        imDate,
        //  imDate6Ctl.imDate     → ComboBox(Calendar)
        [ConstValue("imDate6Ctl.imDate", "ComboBox(Calendar)")]
        imNumber,
        //  VB.Label              → Label
        [ConstValue("VB.Label", "Label")]
        Label,
        //  VB.Frame              → Frame
        [ConstValue("VB.Frame", "Frame")]
        Frame,
        //  VB.OptionButton       → OptionButton
        [ConstValue("VB.OptionButton", "OptionButton")]
        OptionButton,
        //  VB.CheckBox           → CheckBox
        [ConstValue("VB.CheckBox", "CheckBox")]
        CheckBox,
        //  VB.ComboBox           → ComboBox           
        [ConstValue("VB.ComboBox", "ComboBox")]
        ComboBox,
        //  FPSpread.vaSpread → Table
        [ConstValue("FPSpread.vaSpread", "Table")]
        Table,
        //  imPostal6Ctl.imPostal → TextBox
        [ConstValue("imPostal6Ctl.imPostal", "TextBox")]
        imPostal,
        //  MSComctlLib.StatusBar → StatusBar
        [ConstValue("MSComctlLib.StatusBar", "")]
        StatusBar,
        //  ReportCtl.XlsReport → XlsReport
        [ConstValue("ReportCtl.XlsReport", "")]
        XlsReport,
        //  TabDlg.SSTab → SSTab
        [ConstValue("TabDlg.SSTab", "TabControl")]
        SSTab
    }
}

using System;
using System.Windows.Forms;

using RepaceSource.Preset;
using RepaceSource.ComboBoxEnum;

namespace RepaceSource
{
    public partial class PresetOption : Form
    {
        #region instance

        private PresetProfileDgvXml _preset = null;

        #endregion

        #region const

        private const string CONST_COLNAME_NO = "ColNo";

        #endregion

        #region constructor

        public PresetOption()
        {
            InitializeComponent();
        }


        public PresetOption(EnumLungPreset enmPreset)
            : this()
        {
            this._preset = new PresetProfileDgvXml(enmPreset, "Option", this.exDgvReplaceText, CONST_COLNAME_NO);
        }

        #endregion

        #region EventHandler

        private void exComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._preset.PresetEnum = this.exComboBox1.GetSelectedItemEnum<EnumLungPreset>();
            this._preset.ReadDataToDgv();
        }

        private void exDgvReplaceText_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.exDgvReplaceText.SetNoToCell(CONST_COLNAME_NO);
        }

        private void PresetOption_Load(object sender, EventArgs e)
        {
            this.InitializeCompornentOriginal();
        }

        private void exBtnExecute_Click(object sender, EventArgs e)
        {
            this.SaveDataToXml();
        }


        private void exBtnReturn_Click(object sender, EventArgs e)
        {
            this.CloseSelf();
        }

        private void exBtnSpecialReplace_Click(object sender, EventArgs e)
        {
            this.ShowSpecial();
        }

        private void exAddRow_Click(object sender, EventArgs e)
        {
            this.AddRows(10);
        }

        #endregion

        #region method

        private void InitializeCompornentOriginal()
        {
            exComboBox1.SetItemsFromEnumValue<EnumLungPreset>(true);

            this._preset.ReadDataToDgv();
            this.exComboBox1.SetSelectedIndexBykey(this._preset.GetPresetNumber());            
        }

        private void SaveDataToXml()
        {
            this._preset.WriteDataToXmlFromDgv();
        }

        private void ShowSpecial()
        {
            var form = new Special(this.exComboBox1.GetSelectedItemEnum<EnumLungPreset>());
            form.ShowDialog();
        }

        private void CloseSelf()
        {
            this.Close();
        }

        private void AddRows(int countAddRow)
        {
            this.exDgvReplaceText.Rows.Add(countAddRow);
        }

        #endregion

        
    }
}

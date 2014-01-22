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
        private const string CONST_COLNAME_TARGETTEXT = "ColTargetText";
        private const string CONST_COLNAME_REPLACETEXT = "ColReplaceText";
        private const string CONST_COLNAME_ISREGEX = "ColIsRegex";

        #endregion

        #region constructor

        public PresetOption()
        {
            InitializeComponent();
        }


        public PresetOption(string constValue)
            : this()
        {
            this._preset = new PresetProfileDgvXml(constValue, "Option", this.exDgvReplaceText, CONST_COLNAME_NO, new string[] { CONST_COLNAME_NO, CONST_COLNAME_TARGETTEXT, CONST_COLNAME_REPLACETEXT, CONST_COLNAME_ISREGEX });
            this.exDgvReplaceText.ColumnNamesortAsNumber = new string[] { CONST_COLNAME_NO };
        }

        #endregion

        #region EventHandler

        private void exComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._preset.Prof = new PresetProfile(this.exComboBox1.GetSelectedItemKey());
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

        #region private

        private void InitializeCompornentOriginal()
        {
            exComboBox1.SetItemsFromEnumValue<EnumLungPreset>(true);

            this._preset.ReadDataToDgv();
            this.exComboBox1.SetSelectedIndexBykey(this._preset.Prof.GetPresetNumber());            
        }

        private void SaveDataToXml()
        {
            this._preset.WriteDataToXmlFromDgv();
        }

        private void ShowSpecial()
        {
            var form = new Special(this.exComboBox1.GetSelectedItemKey());
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

        #region Public

        public DataGridViewRowCollection GetDgvRows()
        {
            return this.exDgvReplaceText.Rows;
        }

        #endregion

        #endregion
    }
}

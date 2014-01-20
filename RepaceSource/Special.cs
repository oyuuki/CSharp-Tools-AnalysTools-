using System;
using System.Windows.Forms;

using RepaceSource.Preset;
using RepaceSource.ComboBoxEnum;

namespace RepaceSource
{
    public partial class Special : Form
    {
        #region instance

        private PresetProfileDgvXmlAndImmutableData _preset = null;

        #endregion

        #region const

        private const string CONST_COLNAME_NO = "ColNo";

        #endregion

        #region constructor

        public Special()
        {
            InitializeComponent();
        }

        public Special(string constValue)
            : this()
        {
            this._preset = new PresetProfileDgvXmlAndImmutableData(constValue, "SpecialOption", this.exDgvSpe, CONST_COLNAME_NO);
        }

        #endregion

        #region eventHandler

        private void exDgvSpe_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.exDgvSpe.SetNoToCell(CONST_COLNAME_NO);
        }

        private void Special_Load(object sender, EventArgs e)
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

        private void exAddRow_Click(object sender, EventArgs e)
        {
            this.AddRows(10);
        }

        #endregion

        #region method

        #region private

        private void InitializeCompornentOriginal()
        {
            this.lblPreset.Text = this._preset.Prof.GetPresetName();
            this._preset.ReadDataToDgv();
        }

        private void SaveDataToXml()
        {
            this._preset.WriteDataToXmlFromDgv();
        }

        private void CloseSelf()
        {
            this.Close();
        }

        private void AddRows(int countAddRow)
        {
            this.exDgvSpe.Rows.Add(countAddRow);
        }

        #endregion

        #region Public

        public DataGridViewRowCollection GetDgvRows()
        {
            return this.exDgvSpe.Rows;
        }

        #endregion

        #endregion
    }
}

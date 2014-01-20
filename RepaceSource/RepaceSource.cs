using System;
using System.Windows.Forms;

using RepaceSource.ComboBoxEnum;
using OyuLib.OyuFile;

namespace RepaceSource
{
    public partial class RepaceSource : Form
    {
        #region const

        private const string CONST_COLNAME_NO = "ColNo";

        #endregion

        #region constructor

        public RepaceSource()
        {
            InitializeComponent();

             // 初期処理
            Init();
        }

        #endregion

        #region method

        /// <summary>
        /// Initializes Any compornent
        /// </summary>
        private void Init()
        {
            exComboBox1.SetItemsFromEnumValue<EnumLungPreset>(true);
        }

        private void ShowPresetOption()
        {
            var form = new PresetOption(this.exComboBox1.GetSelectedItemEnum<EnumLungPreset>());
            form.ShowDialog();
        }

        /// <summary>
        /// Make sure Valid that input data
        /// </summary>
        /// <returns></returns>
        private bool IsValidInputData()
        {
            if (!(this.exComboBox1.IsValidValue() && this.extxtProFolder.IsValidValue()))
            {
                return false;
            }

            if (!FileUtil.IsExistFileCheck(this.extxtProFolder.Text))
            {
                return false;
            }

            return true;
        }

        private void ReplaceSourceProc()
        {
            if (!this.IsValidInputData())
            {
                return;
            }

            foreach (var filePathString in FileUtil.GetFilePathList(extxtProFolder.GetTrimedText()))
            {
                var sourceText = FileUtil.GetAllTextShiftJIS(filePathString);


            }
        }

        #endregion

        #region EventHandler

        private void extxtProFolder_TextChanged(object sender, EventArgs e)
        {
            this.ReplaceSourceProc();
        }

        private void exComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ReplaceSourceProc();
        }

        private void exBtnExecute_Click(object sender, EventArgs e)
        {
            this.ReplaceSourceProc();
        }

        private void exDgvLog_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.exDgvLog.SetNoToCell(CONST_COLNAME_NO);
        }

        private void exButton1_Click(object sender, EventArgs e)
        {
            this.ShowPresetOption();
        }

        #endregion
    }
}

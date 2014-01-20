using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OyuLib.String.Replace.Replacer;
using RepaceSource.ComboBoxEnum;
using OyuLib.OyuFile;
using OyuLib.String.Replace;
using RepaceSource.Preset;

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
            var form = new PresetOption(this.exComboBox1.GetSelectedItemKey());
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

            return true;
        }

        private void ReplaceSourceProc()
        {
            if (!this.IsValidInputData())
            {
                return;
            }

            this.ReplaceSourceProcNormal();
        }

        private void ReplaceSourceProcNormal()
        {
            string retString = string.Empty;

            foreach (var filePathString in FileUtil.GetFileList(extxtProFolder.GetTrimedText(), new PresetProfile(this.exComboBox1.GetSelectedItemKey()).GetFileExtension()))
            {
                var sourceText = FileUtil.GetAllTextShiftJIS(filePathString);

                sourceText = this.ReplaceSourceProcNormal2(sourceText);

                //書き込むファイルが既に存在している場合は、上書きする
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    filePathString + "back.vb",
                    true,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                //TextBox1.Textの内容を書き込む
                sw.Write(sourceText);
                //閉じる
                sw.Close();
            }
        }

        private string ReplaceSourceProcNormal2(string sourceText)
        {
            PresetOption op = new PresetOption(this.exComboBox1.GetSelectedItemKey());

            op.Show();
            op.Hide();
            
            foreach (DataGridViewRow row in op.GetDgvRows())
            {
                var paramList = new List<string>();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 0)
                    {
                        paramList.Add(cell.Value.ToString());
                    }
                }

                Replacer rep = new Replacer(sourceText, paramList.ToArray());
                sourceText = rep.GetReplacedText();
            }

            return sourceText;
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

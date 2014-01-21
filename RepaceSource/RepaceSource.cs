using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OyuLib.OyuString.Replace;
using OyuLib.OyuString.Text;
using RepaceSource.ComboBoxEnum;
using OyuLib.OyuFile;
using RepaceSource.Preset;

namespace RepaceSource
{
    public partial class RepaceSource : Form
    {
        #region const

        private const string CONST_COLNAME_NO = "ColNo";
        private const string CONST_COLNAME_LINENUMBER = "ColLineNumber";
        private const string CONST_COLNAME_OLDTEXT = "ColOldText";
        private const string CONST_COLNAME_NEWTEXT = "ColNewText";
        

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
                TextFile sourceFile = new TextFile(filePathString);

                OyuText befSourceText = sourceFile.GetOyuTextFromFile();

                var sourceText = this.ReplaceSourceProcNormal2(filePathString);

                var replaceFodelrpath = Path.Combine(Path.GetDirectoryName(filePathString), "Replaced");
                var replacefileName = Path.GetFileName(filePathString);

                Directory.CreateDirectory(replaceFodelrpath);

                using(var tFile = new TextFile(Path.Combine(replaceFodelrpath, replacefileName)))
                {
                    tFile.OpenFileForse();
                    tFile.Write(sourceText);
                    this.AddLogForNormalReplace(new OyuText(sourceText), befSourceText);
                }
            }
        }

        private string ReplaceSourceProcNormal2(string filePathString)
        {

            TextFile sourceFile = new TextFile(filePathString);

            OyuText befSourceText = sourceFile.GetOyuTextFromFile();

            string retSourceText = sourceFile.GetAllReadText();

            

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

                Replacer rep = new Replacer(new TextFile(filePathString), paramList.ToArray());

                retSourceText = rep.GetReplacedText();
            }

            op.Close();

            return retSourceText;
        }

        private void AddLogForNormalReplace(OyuText NowText, OyuText BefText)
        {
            string[] nowTextArray = NowText.GetLineArray();
            string[] befTextArray = BefText.GetLineArray();

            for (int index = 0; index < nowTextArray.Length; index++)
            {
                if (!nowTextArray[index].Equals(befTextArray[index]))
                {
                    int rowIndex = this.exDgvLog.Rows.Add();

                    this.exDgvLog[CONST_COLNAME_LINENUMBER, rowIndex].Value = index + 1;
                    this.exDgvLog[CONST_COLNAME_NEWTEXT, rowIndex].Value = nowTextArray[index];
                    this.exDgvLog[CONST_COLNAME_OLDTEXT, rowIndex].Value = befTextArray[index];
                }
            }
        }

        #endregion

        #region EventHandler

        private void extxtProFolder_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void exComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

        private void exBtnSaveLog_Click(object sender, EventArgs e)
        {
            this.exDgvLog.StoreDatatoXml(DateTime.Now.ToString("yyyyMMddHHmmss") + "ReplaceLog", CONST_COLNAME_NO);
        }

        #endregion
    }
}

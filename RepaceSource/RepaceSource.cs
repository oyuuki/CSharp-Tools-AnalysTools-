using System;
using System.Collections.Generic;

using System.IO;
using System.Windows.Forms;
using OyuLib.IO;
using OyuLib.Documents;
using OyuLib.Documents.Replace;
using OyuLib.Windows.Forms.DataGridView;
using RepaceSource.ComboBoxEnum;
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
        private const string CONST_COLNAME_REPLACESTRING = "ColReplaceString";
        private const string CONST_COLNAME_FILENAME = "ColFileName";
        
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
            exComboBox1.SetItemsFromEnumValue<LanguagePreset>(true);
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
            this.exDgvLog.Rows.Clear();

            string retString = string.Empty;

            PresetOption op = new PresetOption(this.exComboBox1.GetSelectedItemKey());

            op.Show();


            foreach (var filePathString in FileUtil.GetFileList(extxtProFolder.GetTrimedText(), new LanguagePresetProfile(this.exComboBox1.GetSelectedItemKey()).GetFileExtension()))
            {
                TextFile sourceFile = new TextFile(filePathString);

                Document befSourceText = new Document(sourceFile.GetAllReadText());

                var sourceText = this.ReplaceSourceProcNormal2(filePathString, op.GetDgvRows());

                var replaceFodelrpath = Path.Combine(Path.GetDirectoryName(filePathString), "Replaced");
                var replacefileName = Path.GetFileName(filePathString);

                Directory.CreateDirectory(replaceFodelrpath);

                using(var tFile = new TextFile(Path.Combine(replaceFodelrpath, replacefileName)))
                {
                    tFile.OpenFileForse();
                    tFile.Write(sourceText);   
                }
            }

            op.Show();
        }

        private string ReplaceSourceProcNormal2(string filePathString, DataGridViewRowCollection col)
        {

            TextFile sourceFile = new TextFile(filePathString);

            Document befSourceText = new Document(sourceFile.GetAllReadText());

            string retSourceText = sourceFile.GetAllReadText();


            var replaceplaceList = new List<int[]>();

            foreach (DataGridViewRow row in col)
            {
                var paramList = new List<string>();

                paramList.Add(row.Cells[1].Value.ToString());
                paramList.Add(row.Cells[2].Value.ToString());

                ReplacerText rep = new ReplacerText(new Document(retSourceText), paramList.ToArray());
                rep.IsRegexincludePettern = bool.Parse(new TranceDataGridViewCellValue(row.Cells[4]).GetTrancedValue().ToString());
                retSourceText = rep.GetReplacedText();
                replaceplaceList.Add(rep.GetReplacedNumberArray());
            }

            this.AddLogForNormalReplace(new Document(retSourceText), befSourceText, replaceplaceList.ToArray(), col, Path.GetFileName(filePathString));

            return retSourceText;
        }

        private void AddLogForNormalReplace(Document NowText, Document BefText, int[][] rePlacePlaceArray, DataGridViewRowCollection col, string fileName)
        {
            string[] nowTextArray = NowText.GetLineArray();
            string[] befTextArray = BefText.GetLineArray();

            for (int index = 0; index < nowTextArray.Length; index++)
            {
                if (!nowTextArray[index].Equals(befTextArray[index]))
                {
                    int rowIndex = this.exDgvLog.Rows.Add();
                    int lineNumber = index + 1;

                    this.exDgvLog[CONST_COLNAME_LINENUMBER, rowIndex].Value = lineNumber;
                    this.exDgvLog[CONST_COLNAME_NEWTEXT, rowIndex].Value = nowTextArray[index];
                    this.exDgvLog[CONST_COLNAME_OLDTEXT, rowIndex].Value = befTextArray[index];
                    this.exDgvLog[CONST_COLNAME_REPLACESTRING, rowIndex].Value = 
                        this.GetTextOfReplacePlaceNumber(lineNumber, rePlacePlaceArray, col);
                    this.exDgvLog[CONST_COLNAME_FILENAME, rowIndex].Value = fileName;

                }
            }
        }

        private string GetTextOfReplacePlaceNumber(int lineNumber, int[][] ReplacePlaceArray,  DataGridViewRowCollection col)
        {
            var retString = string.Empty;
            
            for (int replaceStringIndex = 0; replaceStringIndex < col.Count; replaceStringIndex++)
            {
                int any = -1;

                if((any = Array.IndexOf(ReplacePlaceArray[replaceStringIndex], lineNumber)) >= 0)
                {
                    DataGridViewRow row = col.SharedRow(replaceStringIndex);
                    retString = retString + row.Cells[1].Value + "→" + row.Cells[2].Value + "：";

                    object countString = row.Cells[3].Value;

                    if (countString == null || string.IsNullOrWhiteSpace(countString.ToString()))
                    {
                        row.Cells[3].Value = 1;
                    }
                    else
                    {
                        row.Cells[3].Value = int.Parse(countString.ToString()) + 1;
                    }
                    
                }
            }

            return retString;
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

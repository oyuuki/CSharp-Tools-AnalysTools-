using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using OyuLib;
using OyuLib.Documents.Sources.Analysis;
using OyuLib.Documents.Sources;
using OyuLib.Documents;

using System.Threading;

namespace CreateTestMatrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private PartialClass[] GetFilePaths(string folderPath)
        {
            var retList = new List<PartialClass>();

            foreach (var filepath in Directory.GetFiles(folderPath))
            {
                string fileName = Path.GetFileName(filepath);

                if (fileName.StartsWith("frm") && fileName.EndsWith(".vb") && !filepath.EndsWith("Designer.vb"))
                {
                    PartialClass part = new PartialClass(
                        Path.Combine(folderPath, fileName),
                        Path.Combine(folderPath, fileName.Replace(".vb", string.Empty) + ".Designer.vb"));

                    retList.Add(part);
                }
                else

                    if (!fileName.StartsWith("frm") && fileName.EndsWith(".vb"))
                    {
                        PartialClass part = new PartialClass(
                            Path.Combine(folderPath, fileName),
                            string.Empty);

                        retList.Add(part);
                    }
            }

            return retList.ToArray();
        }

        private PartialClass[] Test()
        {
            var retList = new List<PartialClass>();

            retList.Add(new PartialClass(@"D:\TETETETE\frm002010.vb", @"D:\TETETETE\frm002010.Designer.vb"));

            return retList.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // スプレッド置換処理で置換してはいけない部分を修正する関数
            //this.ExecuteReplaceFor1Replace();
            // GcDateのYear、Month、Day、　ADODBのField関数のコードを修正する
            //this.ExecuteReplace1_2();
            //this.ExecuteSearch_1();
            //this.ExecuteReplace1();
            // this.ExecuteReplace3();

            button1.Enabled = false; // いったんボタンを無効化
            this.ExecuteReplace3();
            button1.Enabled = true; // いったんボタンを無効化
            //this.ExecuteReplaceCellsToRowsOrColumns();
        }

        private void ExecuteReplace3()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            // this.GetFilePaths(targetSourceDirectory)
            // this.Test()

            //- セルへの入力 (EditModeOn)
            //- Spreadへのフォーカス移動時 Enter
            //- セルからのフォーカス移動 LeaveCell
            //- セルの編集後 (EditModeOff, EditModeOn)
            //- セルのクリック(Button)  .ButtonClicked
            //- セルの表示内容  (Spreadがある画面は全て)
            //  - 書式
            //  - Combobox内のコレクション   
            //- CheckBoxの判定 ×(アナライズするのは難しそう)
            //- セルのダブルクリック (CellDoubleClick)
            //- 右クリック時の処理 MouseDown(Spreadのみに絞る)               
            this.CreateMatrixSpreadEvent(targetSourceDirectory);
            MessageBox.Show("おわり★");
        }

        private void CreateMatrixSpreadEvent(string targetSourceDirectory)
        {
            var headHash = new Hashtable();
            var sourceHash = new Hashtable();

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                var itemArray = this.GetEventItemArraySpread(source);

                if (itemArray == null)
                {
                    continue;
                }

                sourceHash.Add(Path.GetFileNameWithoutExtension(source.BussinessClassFilePath), itemArray);

                foreach (var item in itemArray)
                {
                    if (!headHash.ContainsKey(item.EventName))
                    {
                        headHash.Add(item.EventName, "");
                    }
                }
            }

            var strbu = new StringBuilder();

            var headString = string.Empty;

            foreach (var key in headHash.Keys)
            {
                headString += key + "   ";
            }

            strbu.AppendLine(headString);

            foreach (var sourrceKey in sourceHash.Keys)
            {
                var str = sourrceKey + "    ";
                var itemArray = (ProfileAnalysisEvent.ProfileEventItem[])sourceHash[sourrceKey];

                foreach (var key in headHash.Keys)
                {
                    var isExist = false;

                    foreach (var item in itemArray)
                    {
                        if (item.EventName.Equals(key))
                        {
                            isExist = true;
                            break;
                        }
                    }

                    if (!isExist)
                    {
                        str += "-	";
                    }
                    else
                    {
                        str += "●	";
                    }
                }
                strbu.AppendLine(str);
            }
            this.exTextBox1.Text = strbu.ToString();
        }

        private ProfileAnalysisEvent.ProfileEventItem[] GetEventItemArray(PartialClass source, string name, string typeName)
        {
            if (!string.IsNullOrEmpty(source.DesinerClassFilePath))
            {
                string filename = Path.GetFileName(source.BussinessClassFilePath).Replace(".vb", "");

                // デザイナコード解析
                var mana = new AnalysisSourceDocumentManagerVBDotNet(source.DesinerClassFilePath);


                // ビジネスコード解析
                var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);

                var profile = new ProfileAnalysisEvent(typeName, name, mana2, mana);

                return profile.GetImplementEventName();
            }

            return null;
        }

        private bool GetIsUsingInputMan(PartialClass source, string name, string typeName)
        {
            if (!string.IsNullOrEmpty(source.DesinerClassFilePath))
            {
                string filename = Path.GetFileName(source.BussinessClassFilePath).Replace(".vb", "");

                // デザイナコード解析
                var mana = new AnalysisSourceDocumentManagerVBDotNet(source.DesinerClassFilePath);

                var memberCodeArray = mana.GetSourceCodeInfoMemberVariableByTypeLike("GrapeCity.Win.Editors.");

                if (memberCodeArray != null && memberCodeArray.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        private ProfileAnalysisEvent.ProfileEventItem[] GetEventItemArraySpread(PartialClass source)
        {
            return this.GetEventItemArray(source, "一覧表系", "FarPoint.Win.Spread.FpSpread");
        }

        private ProfileAnalysisEvent.ProfileEventItem[] GetEventItemArrayButton(PartialClass source)
        {
            return this.GetEventItemArray(source, "ボタン押下", "System.Windows.Forms.Button");
        }
    }
}

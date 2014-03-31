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
            //this.ExecuteReplace3();
            this.ExecuteReplace10();
            button1.Enabled = true; // いったんボタンを無効化
            //this.ExecuteReplaceCellsToRowsOrColumns();
        }

        private void ExecuteReplace3()
        {
             string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            //string targetSourceDirectory = @"C:\Users\PASEO\Desktop\test\";
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

        private void ExecuteReplace3_1()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            //string targetSourceDirectory = @"C:\Users\PASEO\Desktop\test\";
            // this.GetFilePaths(targetSourceDirectory)
            // this.Test()

            // CreateMatrixSpreadEvent のSpreadオブジェクト毎版
            this.CreateMatrixSpreadEventBySpdControl(targetSourceDirectory);
            MessageBox.Show("おわり★");
        }

        private void ExecuteReplace4()
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
            this.CreateMatrixIsUsedinputMan(targetSourceDirectory);
            MessageBox.Show("おわり★");
        }

        private void ExecuteReplace5()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            
            // - VBReports (印刷プログラムのテスト)
            // - プレビュー画面で確認
            //  - 印刷された紙
            // - ActiveReports(印刷プログラムのテスト)
            // - プレビュー画面で確認
            // - 印刷された紙
            this.CreateMatrixIsUsedVBReport(targetSourceDirectory);
            MessageBox.Show("おわり★");
        }

        private void ExecuteReplace6()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";

            // - VBReports (印刷プログラムのテスト)
            // - プレビュー画面で確認
            //  - 印刷された紙
            // - ActiveReports(印刷プログラムのテスト)
            // - プレビュー画面で確認
            // - 印刷された紙
            this.CreateMatrixIsUsedActiveReports(targetSourceDirectory);
            MessageBox.Show("おわり★");
        }

        private void ExecuteReplace7()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            //string targetSourceDirectory = @"C:\Users\PASEO\Desktop\test\";
            // - VBReports (印刷プログラムのテスト)
            // - プレビュー画面で確認
            //  - 印刷された紙
            // - ActiveReports(印刷プログラムのテスト)
            // - プレビュー画面で確認
            // - 印刷された紙
            this.CreateMatrixSpreadButton(targetSourceDirectory);
            MessageBox.Show("おわり★");
        }

        private void ExecuteReplace8()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            //string targetSourceDirectory = @"C:\Users\PASEO\Desktop\test\";
            // - VBReports (印刷プログラムのテスト)
            // - プレビュー画面で確認
            //  - 印刷された紙
            // - ActiveReports(印刷プログラムのテスト)
            // - プレビュー画面で確認
            // - 印刷された紙
            this.CreateMatrixContextMenuStripShow(targetSourceDirectory);
            MessageBox.Show("おわり★");



            // ShowDialog
            //       ・メッセージボックスによる処理の分岐  = MsgBox("新規       if MsgBox() = 
            //     - Spread以外のイベント処理  （どのようなイベントがあるか項目単位で解析

        }

        private void ExecuteReplace9()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            //string targetSourceDirectory = @"C:\Users\PASEO\Desktop\test\";
            // - VBReports (印刷プログラムのテスト)
            // - プレビュー画面で確認
            //  - 印刷された紙
            // - ActiveReports(印刷プログラムのテスト)
            // - プレビュー画面で確認
            // - 印刷された紙
            this.CreateShowDialogDispId(targetSourceDirectory);
            MessageBox.Show("おわり★");



            // ShowDialog
            //       ・メッセージボックスによる処理の分岐  = MsgBox("新規       if MsgBox() = 
            //     - Spread以外のイベント処理  （どのようなイベントがあるか項目単位で解析

        }

        private void ExecuteReplace10()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            //string targetSourceDirectory = @"C:\Users\PASEO\Desktop\test\";
            // - VBReports (印刷プログラムのテスト)
            // - プレビュー画面で確認
            //  - 印刷された紙
            // - ActiveReports(印刷プログラムのテスト)
            // - プレビュー画面で確認
            // - 印刷された紙
            this.CreateMatrixSpreadEventByNotSpdControl(targetSourceDirectory);
            MessageBox.Show("おわり★");



            // ShowDialog
            //       ・メッセージボックスによる処理の分岐  = MsgBox("新規       if MsgBox() = 
            //     - Spread以外のイベント処理  （どのようなイベントがあるか項目単位で解析

        }


                

        
        


        private void CreateMatrixSpreadButton(string targetSourceDirectory)
        {
            var sourceHash = new Hashtable();

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                var itemArray = this.GetEventItemArrayButton(source);

                if (itemArray == null)
                {
                    continue;
                }

                sourceHash.Add(Path.GetFileNameWithoutExtension(source.BussinessClassFilePath), itemArray);
            }

            var strbu = new StringBuilder();
            strbu.AppendLine("	ボタンクリック	ボタン名一覧");

            foreach (var sourrceKey in sourceHash.Keys)
            {
                var itemArray = (ProfileAnalysisEvent.ProfileEventItem[])sourceHash[sourrceKey];
                var isNotSameObj = false;

                var buttonNameHash = new Hashtable();

                foreach (var item in itemArray)
                {
                    if (!buttonNameHash.ContainsKey(item.EventObject))
                    {
                        buttonNameHash.Add(item.EventObject, string.Empty);
                    }
                }

                var str = sourrceKey + "	" + (buttonNameHash.Keys.Count > 0 ? "●" : "-") + "	";

                foreach(string objName in buttonNameHash.Keys)
                {
                    str += "	[" + objName + "]ボタン";
                }

                strbu.AppendLine(str);
            }
            this.exTextBox1.Text = strbu.ToString();
        }      

        private void CreateShowDialogDispId(string targetSourceDirectory)
        {
            var strbu = new StringBuilder();

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                var dispIds = this.GetShowDialogDispId(source);

                if(string.IsNullOrEmpty(dispIds))
                {
                    continue;
                }

                strbu.AppendLine(dispIds);
            }

            
            this.exTextBox1.Text = strbu.ToString();
        }

        private void CreateMatrixContextMenuStripShow(string targetSourceDirectory)
        {
            var headHash = new Hashtable();
            var sourceHash = new Hashtable();

            var strbu = new StringBuilder();

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                var isExist = this.GetIsExistContextMenuStrip(source);
                var str = Path.GetFileNameWithoutExtension(source.BussinessClassFilePath) + "	";

                if (!isExist)
                {
                    str += "-	";
                }
                else
                {
                    str += "●	";
                }

                strbu.AppendLine(str);
            }

            
            this.exTextBox1.Text = strbu.ToString();
        }

        private void CreateMatrixNotSpreadEvent(string targetSourceDirectory)
        {
            var headHash = new Hashtable();
            var sourceHash = new Hashtable();

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                var itemArray = this.GetEventItemArrayNotSpread(source);

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

            var headString = "	";

            foreach (var key in headHash.Keys)
            {
                headString += key + "	";
            }

            strbu.AppendLine(headString);

            foreach (var sourrceKey in sourceHash.Keys)
            {
                var itemArray = (ProfileAnalysisEvent.ProfileEventItem[])sourceHash[sourrceKey];
                var objName = string.Empty;
                var isNotSameObj = false;

                foreach (var item in itemArray)
                {
                    if (string.IsNullOrEmpty(objName))
                    {
                        objName = item.EventObject;
                    }
                    else if (!objName.Equals(item.EventObject))
                    {
                        isNotSameObj = true;
                        break;
                    }
                }

                var str = sourrceKey + "	" + (isNotSameObj ? "有" : "-") + "	";

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

            var headString = "	";

            foreach (var key in headHash.Keys)
            {
                headString += key + "	";
            }

            strbu.AppendLine(headString);

            foreach (var sourrceKey in sourceHash.Keys)
            {
                var itemArray = (ProfileAnalysisEvent.ProfileEventItem[])sourceHash[sourrceKey];
                var objName = string.Empty;
                var isNotSameObj = false;

                foreach (var item in itemArray)
                {
                    if (string.IsNullOrEmpty(objName))
                    {
                        objName = item.EventObject;     
                    }
                    else if (!objName.Equals(item.EventObject))
                    {
                        isNotSameObj = true;
                        break;
                    }         
                }

                var str = sourrceKey + "	" + (isNotSameObj ? "有" : "-") + "	";

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

        private void CreateMatrixSpreadEventBySpdControl(string targetSourceDirectory)
        {
            var headHash = new Hashtable();
            var sourceHash = new Hashtable();

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                var itemArrayDic = this.GetEventItemArrayByMemberSpread(source);

                if (itemArrayDic == null)
                {
                    continue;
                }

                sourceHash.Add(Path.GetFileNameWithoutExtension(source.BussinessClassFilePath), itemArrayDic);

                foreach (var itemArray in itemArrayDic.Values)
                {
                    foreach (var item in itemArray)
                    {
                        if (!headHash.ContainsKey(item.EventName))
                        {
                            headHash.Add(item.EventName, "");
                        }
                    }
                }
            }

            var strbu = new StringBuilder();

            var headString = "	";

            foreach (var key in headHash.Keys)
            {
                headString += key + "	";
            }

            strbu.AppendLine(headString);

            foreach (var sourrceKey in sourceHash.Keys)
            {
                var itemArrayDic = (Dictionary<string, ProfileAnalysisEvent.ProfileEventItem[]>)sourceHash[sourrceKey];
                foreach (var dickey in itemArrayDic.Keys)
                {
                    var itemArray = itemArrayDic[dickey];
                    var str = sourrceKey + "	" + dickey + "	";
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
            }
            this.exTextBox1.Text = strbu.ToString();
        }

        private void CreateMatrixSpreadEventByNotSpdControl(string targetSourceDirectory)
        {
            var headHash = new Hashtable();
            var sourceHash = new Hashtable();

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                var itemArrayDic = this.GetEventItemArrayByMemberNotSpread(source);

                if (itemArrayDic == null)
                {
                    continue;
                }

                sourceHash.Add(Path.GetFileNameWithoutExtension(source.BussinessClassFilePath), itemArrayDic);

                foreach (var itemArray in itemArrayDic.Values)
                {
                    foreach (var item in itemArray)
                    {
                        if (!headHash.ContainsKey(item.EventName))
                        {
                            headHash.Add(item.EventName, "");
                        }
                    }
                }
            }

            var strbu = new StringBuilder();

            var headString = "	";

            foreach (var key in headHash.Keys)
            {
                headString += key + "	";
            }

            strbu.AppendLine(headString);

            foreach (var sourrceKey in sourceHash.Keys)
            {
                var itemArrayDic = (Dictionary<string, ProfileAnalysisEvent.ProfileEventItem[]>)sourceHash[sourrceKey];
                foreach (var dickey in itemArrayDic.Keys)
                {
                    var itemArray = itemArrayDic[dickey];
                    var str = sourrceKey + "	" + dickey + "	";
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

                    if (str.IndexOf("●") >= 0)
                    {
                        strbu.AppendLine(str);
                    }
                    
                }
            }
            this.exTextBox1.Text = strbu.ToString();
        }

        private void CreateMatrixIsUsedinputMan(string targetSourceDirectory)
        {
            var sourceHash = new Hashtable();
            var strbu = new StringBuilder();

            strbu.AppendLine("	入力可能文字数	入力可能書式	IMEモード");

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                sourceHash.Add(Path.GetFileNameWithoutExtension(source.BussinessClassFilePath), this.GetIsUsingInputManMatrix(source));
            }

            foreach (var sourrceKey in sourceHash.Keys)
            {
                strbu.AppendLine(sourrceKey + "	" + (string)sourceHash[sourrceKey]);
            }

            this.exTextBox1.Text = strbu.ToString();
        }

        private void CreateMatrixIsUsedVBReport(string targetSourceDirectory)
        {
            var sourceHash = new Hashtable();
            var strbu = new StringBuilder();

            //Me.ShowPreview
            //Me.DoPrint
            //Me.DoExportFile
            strbu.AppendLine("	印刷プレビュー	印刷	エクスポート");

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                sourceHash.Add(Path.GetFileNameWithoutExtension(source.BussinessClassFilePath), this.GetPrintingVBReportMatrix(source));
            }

            foreach (var sourrceKey in sourceHash.Keys)
            {
                strbu.AppendLine(sourrceKey + "	" + (string)sourceHash[sourrceKey]);
            }

            this.exTextBox1.Text = strbu.ToString();
        }

        private void CreateMatrixIsUsedActiveReports(string targetSourceDirectory)
        {
            var sourceHash = new Hashtable();
            var strbu = new StringBuilder();

            //prtNomalDenpyo rpt納品書
            //prtUriageDenpyo rpt売上伝票
            //prtToitsuDenpyo rpt統一伝票
            //prtToitsuDenpyo2 rpt統一伝票2
            //ExpensesCheck_Print rpt納品書
            //Print_PassportDenpyo rptパスポート納品書
            //Print_MamaikukoDenpyo rptママイクコ
            strbu.AppendLine("	納品書		売上伝票		統一伝票		統一伝票2		rpt納品書		rptパスポート納品書		rptママイクコ");
            strbu.AppendLine("	直接印刷	印刷プレビュー	直接印刷	印刷プレビュー	直接印刷	印刷プレビュー	直接印刷	印刷プレビュー	直接印刷	印刷プレビュー	直接印刷	印刷プレビュー	直接印刷	印刷プレビュー");

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                sourceHash.Add(Path.GetFileNameWithoutExtension(source.BussinessClassFilePath), this.GetPrintingActiveReportsMatrix(source));
            }

            foreach (var sourrceKey in sourceHash.Keys)
            {
                strbu.AppendLine(sourrceKey + "	" + (string)sourceHash[sourrceKey]);
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

                var profile = new ProfileAnalysisEvent(name, typeName, mana2, mana);

                return profile.GetImplementEventName();
            }

            return null;
        }

        private ProfileAnalysisEvent.ProfileEventItem[] GetEventItemArrayNotTypeName(PartialClass source, string name, string typeName)
        {
            if (!string.IsNullOrEmpty(source.DesinerClassFilePath))
            {
                string filename = Path.GetFileName(source.BussinessClassFilePath).Replace(".vb", "");
                // デザイナコード解析
                var mana = new AnalysisSourceDocumentManagerVBDotNet(source.DesinerClassFilePath);
                // ビジネスコード解析
                var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);

                var profile = new ProfileAnalysisEvent(name, typeName, mana2, mana);

                return profile.GetImplementEventNameNotTypeName();
            }

            return null;
        }

        private ProfileAnalysisEvent.ProfileEventItem[] GetEventItemArrayMemberCaption(PartialClass source, string name, string typeName)
        {
            if (!string.IsNullOrEmpty(source.DesinerClassFilePath))
            {
                string filename = Path.GetFileName(source.BussinessClassFilePath).Replace(".vb", "");
                // デザイナコード解析
                var mana = new AnalysisSourceDocumentManagerVBDotNet(source.DesinerClassFilePath);
                // ビジネスコード解析
                var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);

                var profile = new ProfileAnalysisEvent(name, typeName, mana2, mana);

                return profile.GetImplementEventNameMemberCaption();
            }

            return null;
        }

        private Dictionary<string, ProfileAnalysisEvent.ProfileEventItem[]> GetEventItemArrayByMember(PartialClass source, string name, string typeName)
        {
            if (!string.IsNullOrEmpty(source.DesinerClassFilePath))
            {
                string filename = Path.GetFileName(source.BussinessClassFilePath).Replace(".vb", "");
                // デザイナコード解析
                var mana = new AnalysisSourceDocumentManagerVBDotNet(source.DesinerClassFilePath);
                // ビジネスコード解析
                var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);

                var profile = new ProfileAnalysisEvent(name, typeName, mana2, mana);

                return profile.GetImplementEventNameByMember();
            }

            return null;
        }

        private Dictionary<string, ProfileAnalysisEvent.ProfileEventItem[]> GetEventItemArrayByMemberNotType(PartialClass source, string name, string[] typeNames)
        {
            if (!string.IsNullOrEmpty(source.DesinerClassFilePath))
            {
                string filename = Path.GetFileName(source.BussinessClassFilePath).Replace(".vb", "");
                // デザイナコード解析
                var mana = new AnalysisSourceDocumentManagerVBDotNet(source.DesinerClassFilePath);
                // ビジネスコード解析
                var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);

                var profile = new ProfileAnalysisEvent(name, typeNames, mana2, mana);

                return profile.GetImplementEventNameByMemberNotType();
            }

            return null;
        }

        private string GetIsUsingInputManMatrix(PartialClass source)
        {
            var result = this.GetIsUsingInputMan(source);

            if(result)
            {
                return "●	●	●";
            }
            else
            {
                return "-	-	-";
            }
        }


        private string GetPrintingVBReportMatrix(PartialClass source)
        {
            if (!string.IsNullOrEmpty(source.DesinerClassFilePath))
            {
                string filename = Path.GetFileName(source.BussinessClassFilePath).Replace(".vb", "");

                // デザイナコード解析
                var mana = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);
                var objName = new string[]{"Me", string.Empty};

                // Me.ShowPreview
                var callInfoShowPreviews = mana.GetSourceCodeInfoCallMethod("ShowPreview", objName);
                // Me.DoPrint
                var callInfoDoPrints = mana.GetSourceCodeInfoCallMethod("DoPrint", objName);
                // Me.DoExportFile
                var callInfoDoExportFiles = mana.GetSourceCodeInfoCallMethod("DoExportFile", objName);

                return this.GetExistsCode(callInfoShowPreviews) +
                    "	" +
                    this.GetExistsCode(callInfoDoPrints) +
                    "	" +
                    this.GetExistsCode(callInfoDoExportFiles);
            }

            return null;
        }

        private string GetPrintingActiveReportsMatrix(PartialClass source)
        {
            if (!string.IsNullOrEmpty(source.DesinerClassFilePath))
            {
                string filename = Path.GetFileName(source.BussinessClassFilePath).Replace(".vb", "");

                // デザイナコード解析
                var mana = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);


                // prtNomalDenpyo
                var callInfoprtNomalDenpyos = mana.GetSourceCodeInfoCallMethod("prtNomalDenpyo");
                // prtUriageDenpyo
                var callInfoprtUriageDenpyos = mana.GetSourceCodeInfoCallMethod("prtUriageDenpyo");

                var callInfoDoprtToitsuDenpyos = mana.GetSourceCodeInfoCallMethod("prtToitsuDenpyo");
                // prtToitsuDenpyo2
                var callInfoDoprtToitsuDenpyo2s = mana.GetSourceCodeInfoCallMethod("prtToitsuDenpyo2");

                // ExpensesCheck_Print
                var callInfoExpensesCheckPrints = mana.GetSourceCodeInfoCallMethod("ExpensesCheck_Print");
                // Print_PassportDenpyo
                var callInfoPrintPassportDenpyos = mana.GetSourceCodeInfoCallMethod("Print_PassportDenpyo");
                // Print_MamaikukoDenpyo
                var callInfoPrintMamaikukoDenpyos = mana.GetSourceCodeInfoCallMethod("Print_MamaikukoDenpyo");

                return (this.GetExistsCode(callInfoprtNomalDenpyos).Equals("●") ? "●	●	" : "-	-	") +
                    (this.GetExistsCode(callInfoprtUriageDenpyos).Equals("●") ? "●	●	" : "-	-	") +
                    (this.GetExistsCode(callInfoDoprtToitsuDenpyos).Equals("●") ? "●	●	" : "-	-	") +
                    (this.GetExistsCode(callInfoDoprtToitsuDenpyo2s).Equals("●") ? "●	●	" : "-	-	") +
                    (this.GetExistsCode(callInfoExpensesCheckPrints).Equals("●") ? "●	●	" : "-	-	") +
                    (this.GetExistsCode(callInfoPrintPassportDenpyos).Equals("●") ? "●	●	" : "-	-	") +
                    (this.GetExistsCode(callInfoPrintMamaikukoDenpyos).Equals("●") ? "●	●	" : "-	-	" );
            }

            return null;
        }

        private string GetExistsCode(SourceCodeInfo[] callMethods)
        {
            if(callMethods != null && callMethods.Length > 0)
            {
                return "●";
            }

            return string.Empty;
        }

        private bool GetIsUsingInputMan(PartialClass source)
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


        private string GetShowDialogDispId(PartialClass source)
        {
            var retValue = new StringBuilder();

            if (!string.IsNullOrEmpty(source.DesinerClassFilePath))
            {
                string filename = Path.GetFileName(source.BussinessClassFilePath).Replace(".vb", "");
                // ビジネスコード解析
                var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);

                foreach (var codeInfo in mana2.GetSourceCodeInfoVariableByTypeLike("frm"))
                {
                    retValue.AppendLine(filename + "	" + codeInfo.TypeName);
                }
            }

            return retValue.ToString();
        }

        private bool GetIsExistContextMenuStrip(PartialClass source)
        {
            if (!string.IsNullOrEmpty(source.DesinerClassFilePath))
            {
                string filename = Path.GetFileName(source.BussinessClassFilePath).Replace(".vb", "");
                // デザイナコード解析
                var mana = new AnalysisSourceDocumentManagerVBDotNet(source.DesinerClassFilePath);
                // ビジネスコード解析
                var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);

                foreach(var codeInfo in mana.GetSourceCodeInfoMemberVariableByType("System.Windows.Forms.ContextMenuStrip"))
                {
                    var callShowMethodInfo = mana2.GetSourceCodeInfoCallMethod();

                    if(callShowMethodInfo != null && callShowMethodInfo.Length > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private ProfileAnalysisEvent.ProfileEventItem[] GetEventItemArraySpread(PartialClass source)
        {
            return this.GetEventItemArray(source, "一覧表系", "FarPoint.Win.Spread.FpSpread");
        }

        private ProfileAnalysisEvent.ProfileEventItem[] GetEventItemArrayNotSpread(PartialClass source)
        {
            return this.GetEventItemArrayNotTypeName(source, "一覧表系", "FarPoint.Win.Spread.FpSpread");
        }

        private Dictionary<string, ProfileAnalysisEvent.ProfileEventItem[]> GetEventItemArrayByMemberSpread(PartialClass source)
        {
            return this.GetEventItemArrayByMember(source, "一覧表系", "FarPoint.Win.Spread.FpSpread");
        }

        private Dictionary<string, ProfileAnalysisEvent.ProfileEventItem[]> GetEventItemArrayByMemberNotSpread(PartialClass source)
        {
            return this.GetEventItemArrayByMemberNotType(source, "一覧表系", new string[] { "FarPoint.Win.Spread.FpSpread", "System.Windows.Forms.Button" });
        }
        
        
        private ProfileAnalysisEvent.ProfileEventItem[] GetEventItemArrayButton(PartialClass source)
        {
            return this.GetEventItemArrayMemberCaption(source, "ボタン押下", "System.Windows.Forms.Button");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Text.RegularExpressions;

using OyuLib;
using OyuLib.Documents.Sources;
using OyuLib.Documents.Sources.Analysis;

using OyuLib.Documents.Replace;

namespace RepaceSource
{
    public partial class Form2 : Form
    {
        public Form2()
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
            this.ExecuteReplace4();
            //this.ExecuteReplaceCellsToRowsOrColumns();
        }

        private void ExecuteReplace3()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            // this.GetFilePaths(targetSourceDirectory)
            // this.Test()

            int num = this.GetFilePaths(targetSourceDirectory).Length;

            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = num;

            this.progressBar1.Value = 0;

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                if(!string.IsNullOrEmpty(source.DesinerClassFilePath))
                {
                    string filename = Path.GetFileName(source.BussinessClassFilePath).Replace(".vb","");

                    // デザイナコード解析
                    var mana = new AnalysisSourceDocumentManagerVBDotNet(source.DesinerClassFilePath);
                    // ビジネスコード解析
                    var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);

                    var spreadwithBlockNameList = new List<string>();

                    this.ReplaceSpreadCodeWithFormName(mana, mana2, filename);

                    string outputDirctory = targetSourceDirectory + "Test";

                    if (!Directory.Exists(outputDirctory))
                    {
                        Directory.CreateDirectory(outputDirctory);
                    }

                    mana.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(source.DesinerClassFilePath)));
                    mana2.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(source.BussinessClassFilePath)));
                }

                this.progressBar1.Value++;
                this.progressBar1.Update();
            }
        }


        private void ReplaceSpreadCodeWithFormName(
            AnalysisSourceDocumentManagerVBDotNet manaDes,
            AnalysisSourceDocumentManagerVBDotNet manaBus,
            string fileName)
        {
            var spreadwithBlockNameList = GetWithStatementNames(manaDes, manaBus, "FarPoint.Win.Spread.FpSpread", fileName);

            // スプレッドに関連する置換処理を行う
            foreach (var name in spreadwithBlockNameList)
            {
                string namestring = fileName + "." + name; 
                string colString = string.Empty;
                string rowString = string.Empty;


                // スプレッド変数名のWithステートメントブロックを抽出する
                foreach (var value in manaBus.GetCodeInfosRoundWithBlockNotRequiredInnerBlock(namestring))
                {
                    this.ReplaceSpreadCodeInfo(value, ref rowString, ref colString, string.Empty);
                }

                foreach (var value in manaBus.GetAllCodeInfos())
                {
                    this.ReplaceSpreadCodeInfo(value, ref rowString, ref colString, namestring);
                }
            }
        }

        private void ExecuteSearch_1()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            // this.GetFilePaths(targetSourceDirectory)
            // this.Test()

            int num = this.GetFilePaths(targetSourceDirectory).Length;

            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = num;

            this.progressBar1.Value = 0;
            string outputDirctory = targetSourceDirectory + "Test";

            
            var table = new Hashtable();
            var errorTable = new Hashtable();

            string codeString = string.Empty;

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                var list = new List<string>();
                var errorlist = new List<string>();

                table.Add(source.BussinessClassFilePath, list);
                errorTable.Add(source.BussinessClassFilePath, errorlist);

                if (!string.IsNullOrEmpty(source.DesinerClassFilePath))
                {
                    // ビジネスコード解析
                    var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);
                    // デザイナコード解析
                    var mana = new AnalysisSourceDocumentManagerVBDotNet(source.DesinerClassFilePath);

                    foreach(var info in mana.GetAllCodeInfos())
                    {
                        if(info is SourceCodeInfoCallMethod)
                        {
                            // var methodName = ((SourceCodeInfoCallMethod)info).CallmethodName;
                            var methodName = info.GetCodeWithOutComment();

                            if(methodName.IndexOf(".GetInteger") >= 0
                                || methodName.IndexOf(".GetFloat") >= 0
                                || methodName.IndexOf(".GetText") >= 0
                                || methodName.IndexOf(".SetInteger") >= 0
                                || methodName.IndexOf(".SetText") >= 0
                                || methodName.IndexOf(".SetFloat") >= 0)
                            {
                                list.Add(info.GetCodeString());
                            }
                        }
                        else if(info is SourceCodeInfoError)
                        {
                            list.Add(info.GetCodeString());
                        }

                    }

                }

            }

            this.listBox1.Items.Add("メソッド一覧");

            foreach(var key in table.Keys)
            {
                this.listBox1.Items.Add("   " + key);
                foreach(var str in ((List<string>)table[key]).ToArray())
                {
                    this.listBox1.Items.Add(str);    
                }


            }

            this.listBox1.Items.Add("エラーコード");

            foreach (var key in errorTable.Keys)
            {
                this.listBox1.Items.Add("   " + key);
                foreach (var str in ((List<string>)errorTable[key]).ToArray())
                {
                    this.listBox1.Items.Add(str);
                }
            }
        }

        private void ExecuteReplace2()
        {
            string filepath = @"D:\TETETETE\test.vb";

            var mana = new AnalysisSourceDocumentManagerVBDotNet(filepath);

            foreach(var value in mana.GetSourceCodeAnalysis())
            {
                if(value is SourceCodeInfoCallMethod)
                {
                    var s = (SourceCodeInfoCallMethod)value;

                    var paramater = s.GetSourceCodeInfoParamaters();
                    paramater[0].ChangeParamaterIndex(0, 1);

                    s.CallmethodName = "test";
                    MessageBox.Show(s.GetCodePartsOverWriteValues());
                }
            }

        }

        private void ExecuteReplaceCellsToRowsOrColumns()
        { 
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
             //string targetSourceDirectory = @"D:\test\";
            
            // this.GetFilePaths(targetSourceDirectory)
            // this.Test()

            int num = this.GetFilePaths(targetSourceDirectory).Length;

            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = num;

            this.progressBar1.Value = 0;
            string outputDirctory = targetSourceDirectory + "Test";

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                // ビジネスコード解析
                var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);
                this.ReplaceSpreadCellsToRowsOrColumns(mana2);

                if (!Directory.Exists(outputDirctory))
                {
                    Directory.CreateDirectory(outputDirctory);
                }

                mana2.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(source.BussinessClassFilePath)));
            }
        }

        private void ExecuteReplace4()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            // this.GetFilePaths(targetSourceDirectory)
            // this.Test()

            int num = this.GetFilePaths(targetSourceDirectory).Length;

            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = num;

            this.progressBar1.Value = 0;
            string outputDirctory = targetSourceDirectory + "Test";

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                // ビジネスコード解析
                var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);
                this.ReplaceInputManADODBRecordSet(mana2);

                if (!Directory.Exists(outputDirctory))
                {
                    Directory.CreateDirectory(outputDirctory);
                }

                mana2.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(source.BussinessClassFilePath)));
            }
        }

        private void ExecuteReplace1_2()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            // this.GetFilePaths(targetSourceDirectory)
            // this.Test()

            int num = this.GetFilePaths(targetSourceDirectory).Length;

            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = num;

            this.progressBar1.Value = 0;
            string outputDirctory = targetSourceDirectory + "Test";

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                // ビジネスコード解析
                var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);

                if (!string.IsNullOrEmpty(source.DesinerClassFilePath))
                {
                    // デザイナコード解析
                    var mana = new AnalysisSourceDocumentManagerVBDotNet(source.DesinerClassFilePath);
                    

                    this.ReplaceInputManGcDate(mana, mana2);

                    

                    if (!Directory.Exists(outputDirctory))
                    {
                        Directory.CreateDirectory(outputDirctory);
                    }

                    mana.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(source.DesinerClassFilePath)));
                }

                // this.ReplaceInputManADODBRecordSet(mana2);

                if (!Directory.Exists(outputDirctory))
                {
                    Directory.CreateDirectory(outputDirctory);
                }

                mana2.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(source.BussinessClassFilePath)));
            }
        }

        /// <summary>
        /// SpreadのWithブロックでないブロックのValue、Textを元に戻す
        /// </summary>
        private void ExecuteReplaceFor1Replace()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            // this.GetFilePaths(targetSourceDirectory)
            // this.Test()

            int num = this.GetFilePaths(targetSourceDirectory).Length;

            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = num;

            this.progressBar1.Value = 0;

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                if (string.IsNullOrEmpty(source.DesinerClassFilePath))
                {
                    
                }
                else
                {
                    // デザイナコード解析
                    var mana = new AnalysisSourceDocumentManagerVBDotNet(source.DesinerClassFilePath);
                    // ビジネスコード解析
                    var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);

                    var spreadwithBlockNameList = new List<string>();

                    this.ReplaceSpreadCodeFix(mana, mana2);

                    string outputDirctory = targetSourceDirectory + "Test";

                    if (!Directory.Exists(outputDirctory))
                    {
                        Directory.CreateDirectory(outputDirctory);
                    }

                    mana.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(source.DesinerClassFilePath)));
                    mana2.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(source.BussinessClassFilePath)));
                }

                this.progressBar1.Value++;
                this.progressBar1.Update();
            }
        }

        private void ReplaceSpreadCodeFix(
            AnalysisSourceDocumentManagerVBDotNet manaDes,
            AnalysisSourceDocumentManagerVBDotNet manaBus)
        {
            var spreadwithBlockNameList = new List<string>();
            spreadwithBlockNameList.AddRange(this.GetWithStatementNames(manaDes, manaBus, "FarPoint.Win.Spread.FpSpread", string.Empty));

            // その他のローカル変数、引数でspreadが使用されている箇所の置換
            var localSpreadList = manaBus.GetValiableNameCollection("FarPoint.Win.Spread.FpSpread");

            if (localSpreadList.Count() >= 1)
            {
                spreadwithBlockNameList.AddRange(localSpreadList.ToArray());
            }

            

            
             // Withステートメントブロック内のコードに対して処理する
            foreach (var value in manaBus.GetCodeInfosRoundWithBlocksNotIncludeNames(spreadwithBlockNameList.ToArray(), true))
            {
                var str = value.GetCodeWithOutComment();
                ReplacerSource rep = new ReplacerSource(str.Trim(), "[ ,(]\\.ActiveSheet\\.|^\\.ActiveSheet\\.", "", "", "");
                rep.IsRegexincludePettern = true;

                if(rep.IsMatch())
                {
                    var strMotoCode = value.GetCodeString();
                    var searchStr = "元コード：";

                    var motoCodeIndex = strMotoCode.LastIndexOf(searchStr);
                    var replaceString = strMotoCode.Substring(motoCodeIndex + searchStr.Length);

                    value.SetAllOverWriteString(replaceString, "", "");
                }
            }
        }                                              


        private void ExecuteReplace1()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\";
            // this.GetFilePaths(targetSourceDirectory)
            // this.Test()

            int num = this.GetFilePaths(targetSourceDirectory).Length;

            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = num;

            this.progressBar1.Value = 0;

            foreach (var source in this.GetFilePaths(targetSourceDirectory))
            {
                if(string.IsNullOrEmpty(source.DesinerClassFilePath))
                {
                    // ビジネスコード解析
                    var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);
                    // その他のローカル変数、引数でspreadが使用されている箇所の置換
                    var spreadValiableCol = mana2.GetValiableNameCollection("FarPoint.Win.Spread.FpSpread");

                    // スプレッドに関連する置換処理を行う
                    foreach (var name in spreadValiableCol)
                    {
                        string colString = string.Empty;
                        string rowString = string.Empty;

                        // スプレッド変数名のWithステートメントブロックを抽出する
                        foreach (var value in mana2.GetCodeInfosRoundWithBlockNotRequiredInnerBlock(name))
                        {
                            this.ReplaceSpreadCodeInfo(value, ref rowString, ref colString, string.Empty);
                        }

                        foreach (var value in mana2.GetAllCodeInfos())
                        {
                            this.ReplaceSpreadCodeInfo(value, ref rowString, ref colString, name);
                        }
                    }

                    string outputDirctory = targetSourceDirectory + "Test";

                    if (!Directory.Exists(outputDirctory))
                    {
                        Directory.CreateDirectory(outputDirctory);
                    }

                    mana2.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(source.BussinessClassFilePath)));
                }
                else
                {
                    // デザイナコード解析
                    var mana = new AnalysisSourceDocumentManagerVBDotNet(source.DesinerClassFilePath);
                    // ビジネスコード解析
                    var mana2 = new AnalysisSourceDocumentManagerVBDotNet(source.BussinessClassFilePath);

                    var spreadwithBlockNameList = new List<string>();

                    //this.ReplaceLoadMethod(mana2);
                    this.ReplaceSpreadCode(mana, mana2);
                    //this.ExecuteReplaceControlArray(mana, mana2);


                    string outputDirctory = targetSourceDirectory + "Test";

                    if (!Directory.Exists(outputDirctory))
                    {
                        Directory.CreateDirectory(outputDirctory);
                    }

                    mana.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(source.DesinerClassFilePath)));
                    mana2.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(source.BussinessClassFilePath)));
                }

                this.progressBar1.Value++;
                this.progressBar1.Update();
            }
        }


        private void ReplaceInputManGcDate(
            AnalysisSourceDocumentManagerVBDotNet manaDes,
            AnalysisSourceDocumentManagerVBDotNet manaBus)
        {
            var spreadwithBlockNameList = GetWithStatementNames(manaDes, manaBus, "GrapeCity.Win.Editors.GcDate", string.Empty);
            var gcDataList = this.GetFiledNamelist(manaDes, "GrapeCity.Win.Editors.GcDate");

            var list = new List<string>();

            list.AddRange(spreadwithBlockNameList);
            list.AddRange(gcDataList);



            foreach (var valiableName in list)
            {
                foreach (var codeInfo in manaBus.GetAllCodeInfos())
                {
                    this.ReplaceInputManGcDateProc(valiableName, codeInfo);
                }

                // スプレッド変数名のWithステートメントブロックを抽出する
                foreach (var value in manaBus.GetCodeInfosRoundWithBlockNotRequiredInnerBlock(valiableName))
                {
                    this.ReplaceInputManGcDateProc(string.Empty, value);
                }

            }
        }                               

        private void ReplaceInputManGcDateProc(string valiableName, SourceCodeInfo codeInfo)
        {
            // 代入式のリプレイス
            if (codeInfo is SourceCodeInfoSubstitution)
            {
                new ReplaceManagerHaveParamaterValueGcDate(valiableName, (IParamater)codeInfo).Replace();
                var replaceManager = new ReplaceManagerGcDateSubstitution(
                    valiableName,
                    "",
                    "",
                    (SourceCodeInfoSubstitution)codeInfo);

                replaceManager.Replace();
            }
            // 上記以外のIparamaterを実装するクラス
            else if (codeInfo is IParamater)
            {
                new ReplaceManagerHaveParamaterValueGcDate(valiableName, (IParamater)codeInfo).Replace();
            }

        }

        private void ReplaceSpreadCellsToRowsOrColumns(
            AnalysisSourceDocumentManagerVBDotNet manaBus)
        {
            foreach (var codeInfo in manaBus.GetAllCodeInfos())
            {

                if (codeInfo is SourceCodeInfoCallMethod)
                {
                    new ReplaceDotNetCodeManagerSpread(
                        "",
                        "",
                        (SourceCodeInfoCallMethod)codeInfo).Replace();
                }
                else if (codeInfo is IParamater)
                {
                    new ReplaceDotNetCodeHaveParamaterSpread((IParamater)codeInfo).Replace();
                }

            }
        }

        private void ReplaceInputManADODBRecordSet(
            AnalysisSourceDocumentManagerVBDotNet manaBus)
        {
            var adoDataList = manaBus.GetValiableNameCollection("Recordset");


            foreach (var codeInfo in manaBus.GetAllCodeInfos())
            {
                foreach (var valiableName in adoDataList)
                {
                    if (codeInfo is SourceCodeInfoCallMethod)
                    {
                        new ReplaceManagerAdoDatasetCallMethod(
                            valiableName,
                            "",
                            "",
                            (SourceCodeInfoCallMethod)codeInfo).Replace();
                    }
                    else if (codeInfo is IParamater)
                    {
                        new ReplaceManagerHaveParamaterValueAdoDataset(valiableName, (IParamater)codeInfo).Replace();
                    }
                }
            }
        }

        

        private void ReplaceLoadMethod(AnalysisSourceDocumentManagerVBDotNet manaBus)
        {
            foreach (var codeinfo in manaBus.GetSourceCodeInfoCallMethod())
            {
                var codeInfoMethod = (SourceCodeInfoCallMethod)codeinfo;

                if(codeInfoMethod.CallmethodName.Equals("Load"))
                {
                    var formName = codeInfoMethod.GetSourceCodeInfoParamaters()[0].GetSourceCodeInfoParamaterValue()[0].ParamaterName;
                    codeInfoMethod.SetAllOverWriteString("Dim " + formName + " As New " + formName, "'", "★[]★置換ツールにより置換");
                }
            }
        }

        private string[] GetWithStatementNames(
           AnalysisSourceDocumentManagerVBDotNet manaDes,
           AnalysisSourceDocumentManagerVBDotNet manaBus,
           string typename,
           string fileName)
        {
            var withBlockNameList = new List<string>();
            var filedNameList = this.GetFiledNamelist(manaDes, typename);

            // コントロール配列のスプレッドシート変数を対象に、
            // Withステートメントコードを全て抽出し
            // デザイナで定義されている変数名に置換する
            foreach (var withBlockBegin in manaBus.GetSourceCodeInfoblockBeginWith())
            {
                var locWithName = withBlockBegin.StatementObject;
                var motoName = withBlockBegin.StatementObject;

                // コントロール配列による宣言を行っている場合 例) "vaSpread(0)"
                if (locWithName.EndsWith(")"))
                {
                    // "_vaSpread_0" のように文字列を組み替える
                    locWithName = "_" + locWithName;
                    locWithName = locWithName.Replace("(", "_").Replace(")", "");
                }

                // スプレッドフィールド名を保持する
                foreach (var name in filedNameList)
                {
                    if (locWithName.Equals(name) || locWithName.Equals(fileName + "." + name))
                    {
                        bool isSameObjectName = false;

                        foreach (var va in withBlockNameList)
                        {
                            if (va.Equals(motoName))
                            {
                                isSameObjectName = true;
                                break;
                            }
                        }

                        if (!isSameObjectName)
                        {
                            withBlockNameList.Add(motoName);
                        }
                    }
                }
            }

            return withBlockNameList.ToArray();
        }

        private void ReplaceSpreadCode(
            AnalysisSourceDocumentManagerVBDotNet manaDes,
            AnalysisSourceDocumentManagerVBDotNet manaBus)
        {
            var spreadwithBlockNameList = GetWithStatementNames(manaDes, manaBus, "FarPoint.Win.Spread.FpSpread", string.Empty);
            // スプレッドに関連する置換処理を行う
            foreach (var name in spreadwithBlockNameList)
            {
                string colString = string.Empty;
                string rowString = string.Empty;

                // スプレッドが関連しているイベントメソッドの抽出
                foreach(var value in manaBus.GetSourceCodeInfoBlockBeginEventMethodSuggestObjectName(name))
                {
                    this.ReplaceSpreadEventMethod(value);
                }

                // スプレッド変数名のWithステートメントブロックを抽出する
                foreach (var value in manaBus.GetCodeInfosRoundWithBlockNotRequiredInnerBlock(name))
                {
                    this.ReplaceSpreadCodeInfo(value, ref rowString, ref colString, string.Empty);                    
                }

                foreach (var value in manaBus.GetAllCodeInfos())
                {
                    this.ReplaceSpreadCodeInfo(value, ref rowString, ref colString, name);                    
                }
            }

            // その他のローカル変数、引数でspreadが使用されている箇所の置換
            var spreadValiableCol = manaBus.GetValiableNameCollection("FarPoint.Win.Spread.FpSpread");

            // スプレッドに関連する置換処理を行う
            foreach (var name in spreadValiableCol)
            {
                string colString = string.Empty;
                string rowString = string.Empty;

                // スプレッド変数名のWithステートメントブロックを抽出する
                foreach (var value in manaBus.GetCodeInfosRoundWithBlockNotRequiredInnerBlock(name))
                {
                    this.ReplaceSpreadCodeInfo(value, ref rowString, ref colString, string.Empty);
                }

                foreach (var value in manaBus.GetAllCodeInfos())
                {
                    this.ReplaceSpreadCodeInfo(value, ref rowString, ref colString, name);
                }
            }


        }

        private void ReplaceSpreadEventMethod(
            SourceCodeInfoBlockBeginEventMethod codeinfo)
        {
            new ReplaceManagerSpreadEventMethod(codeinfo, "", "").Replace();
        }

        private void ExecuteReplaceControlArray(
            AnalysisSourceDocumentManagerVBDotNet manaDes,
            AnalysisSourceDocumentManagerVBDotNet manaBus)
        {
            string pattern = "_\\d{1,}$";
            Regex reg = new Regex(pattern);

            var dic = new Dictionary<string, List<SourceCodeInfoMemberVariable>>();

            // コントロール配列だったコントロールのコレクションを取得
            foreach (var valiable in manaDes.GetSourceCodeInfoMemberVariableRegex(pattern))
            {
                var keyName = reg.Replace(valiable.Name, "").Substring(1);

                if (!dic.ContainsKey(keyName))
                {
                    dic.Add(keyName, new List<SourceCodeInfoMemberVariable>());
                }

                dic[keyName].Add(valiable);
            }

            // コントロール配列に関連するイベントメソッドの取得
            var dicEvent = new Dictionary<string, List<SourceCodeInfoBlockBeginEventMethod>>();

            foreach (var keyName in dic.Keys)
            {
                dicEvent.Add(keyName, new List<SourceCodeInfoBlockBeginEventMethod>());

                // コントロール配列だったコントロールのコレクションを取得
                foreach (var methodInfo in manaBus.GetSourceCodeInfoBlockBeginEventMethodSuggestObjectName(keyName))
                {
                    dicEvent[keyName].Add(methodInfo);
                    methodInfo.IsDeleteHandles = true;
                }
            }


            // Imports文を追加
            manaBus.AddCodeInfoImports(new SourceCodeInfoOther[] { new SourceCodeInfoOther(new SourceCode("Imports System.Collections.Generic")) });

            // コントロール配列メンバー変数を生成
            var addValiableMemList = new List<SourceCodeInfoOther>();

            foreach (var keyName in dic.Keys)
            {
                if (!dic[keyName][0].TypeName.StartsWith("System."))
                {
                    addValiableMemList.Add(
                        new SourceCodeInfoOther(
                            new SourceCode(
                                "Private " + keyName + " As Dictionary(Of Integer, " + dic[keyName][0].TypeName + ")")));
                }
            }

            // 生成したメンバー変数をコレクションに追加
            manaBus.AddValiableMemberCode(addValiableMemList.ToArray());


            // コントロール配列初期化コードを生成

            var addInitControlCollectionCode = new List<SourceCodeInfoOther>();

            foreach (var keyName in dic.Keys)
            {
                if (!dic[keyName][0].TypeName.StartsWith("System."))
                {
                    addInitControlCollectionCode.Add(
                        new SourceCodeInfoOther(
                            new SourceCode(
                                "        " + keyName + " = New Dictionary(Of Integer, " + dic[keyName][0].TypeName + ")")));
                }

                

                foreach (var list in dic[keyName])
                {
                    if (!dic[keyName][0].TypeName.StartsWith("System."))
                    {
                        var indexString = reg.Match(list.Name).ToString().Substring(1);

                        addInitControlCollectionCode.Add(
                            new SourceCodeInfoOther(
                                new SourceCode("        Me." + keyName + ".Add(" + indexString + ", " + list.Name + ")")));
                    }

                    foreach (var eventMethodInfo in dicEvent[keyName])
                    {
                        var indexString = reg.Match(list.Name).ToString().Substring(1);
                        // AddHandler Me.imn諸経費(0).Leave, AddressOf Me.imn諸経費_Leave
                        addInitControlCollectionCode.Add(
                            new SourceCodeInfoOther(
                                new SourceCode("        AddHandler Me." + keyName + "(" + indexString + ")"
                                    + "." + eventMethodInfo.EventName + ", AddressOf Me." + eventMethodInfo.Name)));
                    }
                }
            }

            manaBus.AddOtherCodeToEventMethod(addInitControlCollectionCode.ToArray(), "Load");
        }

        private string[] GetFiledNamelist(AnalysisSourceDocumentManagerVBDotNet mana, string typeName)
        {
            // フィールド名を保持する
            var filedNameList = new List<string>();

            foreach (var value in mana.GetSourceCodeInfoMemberVariableByType(typeName))
            {
                filedNameList.Add(value.Name);
            }

            return filedNameList.ToArray();
        }

        private void SetIfparamtersValue(SourceCodeInfoBlockBeginIf codeInfo, ReplaceItem replaceItem)
        {
            foreach (var value in codeInfo.Paramater.GetParamaterValue(replaceItem.TargetString))
            {
                value.ParamaterName = replaceItem.ReplaceString;
            }
        }

        private void ReplaceSpreadCodeInfo(SourceCodeInfo codeInfo, ref string rowString, ref string colString, string spreadValiableName)
        {
            // 代入式のリプレイス
            if (codeInfo is SourceCodeInfoSubstitution)
            {
                this.ReplaceSpreadCodeInfoSubstitution((SourceCodeInfoSubstitution)codeInfo, ref rowString, ref colString, spreadValiableName);
            }
            // メソッド呼び出しのリプレイス
            else if (codeInfo is SourceCodeInfoCallMethod)
            {
                new ReplaceManagerSpreadCallMethod(
                    rowString, 
                    colString,
                    spreadValiableName,
                    "",
                    "",
                    (SourceCodeInfoCallMethod) codeInfo).Replace();
            }
            else if (codeInfo is SourceCodeInfoComment)
            {
                var codeString = codeInfo.GetCodeString();
                var commentString = "' ★置換ツールによりコメント化";
                var commentString2 = "★このコードは置換ツールによってコメント化されました。 '";

                if (codeString.IndexOf(commentString) >= 0)
                {
                    var sourceCode = new SourceCode(codeString.Replace("' ★置換ツールによりコメント化", "").Replace(commentString2, ""));
                    var reviveCodeInfo = new SourceCodeInfoAnalyzerVBDotNet(sourceCode).GetCodeInfo();

                    if (reviveCodeInfo is SourceCodeInfoSubstitution)
                    {
                        this.ReplaceSpreadCodeInfoSubstitution((SourceCodeInfoSubstitution)reviveCodeInfo, ref rowString, ref colString, spreadValiableName);
                    }
                }
            }
            // 上記以外のIparamaterを実装するクラス
            else if (codeInfo is IParamater)
            {
                new ReplaceManagerHaveParamaterValueSpread(rowString, colString, spreadValiableName, (IParamater)codeInfo).Replace();
            }
            
        }


        private void ReplaceSpreadCodeInfoSubstitution(SourceCodeInfoSubstitution codeInfo, ref string rowString, ref string colString, string spreadValiableName)
        {

            new ReplaceManagerHaveParamaterValueSpread(rowString, colString, spreadValiableName, (IParamater)codeInfo).Replace();
            var replaceManager = new ReplaceManagerSpreadSubstitution(
                rowString,
                colString,
                spreadValiableName,
                "",
                "",
                (SourceCodeInfoSubstitution)codeInfo);

            replaceManager.Replace();


            rowString = replaceManager.RowString;
            colString = replaceManager.ColString;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new RepaceSource();

            form.Show();
        }
    }
}

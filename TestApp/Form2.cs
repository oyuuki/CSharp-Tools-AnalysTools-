using System;
using System.Collections.Generic;
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

namespace TestApp
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
            this.ExecuteReplaceControlArray(); 
        }


        private void ExecuteReplaceControlArray()
        {
            var classPath = Test()[0];

            var manaDes = new AnalysisSourceDocumentManagerVBDotNet(classPath.DesinerClassFilePath);
            var manaBus = new AnalysisSourceDocumentManagerVBDotNet(classPath.BussinessClassFilePath);

            string a = string.Empty;

            string pattern = "_\\d{1,}$";
            var dic = new Dictionary<string, List<SourceCodeInfoMemberVariable>>();

            // コントロール配列だったコントロールのコレクションを取得
            foreach (var valiable in manaDes.GetSourceCodeInfoMemberVariableRegex(pattern))
            {
                Regex reg = new Regex(pattern);
                var keyName = reg.Replace(valiable.Name, "");

                if(!dic.ContainsKey(keyName))
                {
                    dic.Add(keyName, new List<SourceCodeInfoMemberVariable>());
                }

                dic[keyName].Add(valiable);            
            }

            // Imports文を追加
            //manaBus.AddCodeInfoImports(new SourceCodeInfoOther[] { new SourceCodeInfoOther(new SourceCode("Imports System.Collections.Generic")) });

            // コントロール配列メンバー変数を生成
            var addValiableMemList = new List<SourceCodeInfoOther>();

            foreach(var keyName in dic.Keys)
            {   
                addValiableMemList.Add(
                    new SourceCodeInfoOther(
                        new SourceCode(
                            "Private " + keyName + " As Dictionary(Of Integer, " + dic[keyName][0].TypeName + ")")));
            }

            // 生成したメンバー変数をコレクションに追加
            manaBus.AddValiableMemberCode(addValiableMemList.ToArray());

            string outputDirctory = @"D:\TETETETE\Test2\";

            if (!Directory.Exists(outputDirctory))
            {
                Directory.CreateDirectory(outputDirctory);
            }

            manaBus.CreateAnalysisSourceFile(outputDirctory + @"\test.vb");
            manaDes.CreateAnalysisSourceFile(outputDirctory + @"\test.Desiner.vb");
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

                    var paramater = s.GetSourceCodeInfoParamater();
                    paramater.ChangeParamaterIndex(0, 1);

                    s.CallmethodName = "test";
                    MessageBox.Show(s.GetCodePartsOverWriteValues());
                }


                int a = 1;
            }

        }

        private void ExecuteReplace1()
        {
            string targetSourceDirectory = @"D:\TETETETE\";
            // this.GetFilePaths(targetSourceDirectory)
            // this.Test()

            int num = this.GetFilePaths(targetSourceDirectory).Length;

            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = num;

            this.progressBar1.Value = 0;

            foreach (var form in this.GetFilePaths(targetSourceDirectory))
            {
                // デザイナコード解析
                var mana = new AnalysisSourceDocumentManagerVBDotNet(form.DesinerClassFilePath);
                // スプレッドフィールド名を保持する
                var filedNameList = this.GetFiledNamelist(mana, "FarPoint.Win.Spread.FpSpread");

                // ビジネスコード解析
                var mana2 = new AnalysisSourceDocumentManagerVBDotNet(form.BussinessClassFilePath);

                var spreadwithBlockNameList = new List<string>();

                // コントロール配列のスプレッドシート変数を対象に、
                // Withステートメントコードを全て抽出し
                // デザイナで定義されている変数名に置換する
                foreach (var withBlockBegin in mana2.GetSourceCodeInfoblockBeginWith())
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

                    // デザイナの変数名に置換する
                    foreach (var name in filedNameList)
                    {
                        if (locWithName.Equals(name))
                        {
                            withBlockBegin.StatementObject = locWithName;
                            spreadwithBlockNameList.Add(motoName);
                        }
                    }
                }

                // スプレッドに関連する置換処理を行う
                foreach (var name in spreadwithBlockNameList)
                {
                    string colString = string.Empty;
                    string rowString = string.Empty;

                    var a = mana2.GetCodeInfosRoundWithBlock(name);

                    // スプレッド変数名のWithステートメントブロックを抽出する
                    foreach (var value in mana2.GetCodeInfosRoundWithBlock(name))
                    {
                        // "."で始まるコードを対象に置換処理を行う
                        if (value.GetCodeString().Trim().StartsWith("."))
                        {
                            this.SetSpreadRowCol(value, ref rowString, ref colString);
                        }
                        else if (value is SourceCodeInfoBlockBeginIf)
                        {
                            new ReplaceManagerHaveParamaterValueSpread(rowString, colString, (IParamater)value).Replace();
                        }
                    }
                }

                string outputDirctory = targetSourceDirectory + "Test";

                if (!Directory.Exists(outputDirctory))
                {
                    Directory.CreateDirectory(outputDirctory);
                }

                mana.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(form.DesinerClassFilePath)));
                mana2.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(form.BussinessClassFilePath)));

                this.progressBar1.Value++;
                this.progressBar1.Update();
            }
        }

        private string[] GetFiledNamelist(AnalysisSourceDocumentManagerVBDotNet mana, string typeName)
        {
            // スプレッドフィールド名を保持する
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

        private void SetSpreadRowCol(SourceCodeInfo codeInfo, ref string rowString, ref string colString)
        {
            if (codeInfo is SourceCodeInfoSubstitution)
            {
                var replaceManager = new ReplaceManagerSpreadSubstitution(rowString, colString,
                    (SourceCodeInfoSubstitution) codeInfo);

                replaceManager.Replace();

                rowString = replaceManager.RowString;
                colString = replaceManager.ColString;
            }
            else if (codeInfo is SourceCodeInfoCallMethod)
            {
                new ReplaceManagerSpreadCallMethod(rowString, colString, (SourceCodeInfoCallMethod) codeInfo).Replace();
            }
        }
    }
}

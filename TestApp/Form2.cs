using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

            retList.Add(new PartialClass(@"D:\TETETETE\frm002006.vb", @"D:\TETETETE\frm002006.Designer.vb"));

            return retList.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string targetSourceDirectory = @"D:\TETETETE\";
            // this.GetFilePaths(targetSourceDirectory)
            // this.Test()
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
                    }
                }

                string outputDirctory = targetSourceDirectory + "Test";

                if (!Directory.Exists(outputDirctory))
                {
                    Directory.CreateDirectory(outputDirctory);
                }

                mana.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(form.DesinerClassFilePath)));
                mana2.CreateAnalysisSourceFile(Path.Combine(outputDirctory, Path.GetFileName(form.BussinessClassFilePath)));
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

        private bool SetSubstitutionValue(
            SourceCodeInfoSubstitution codeinfo,
            string rowString,
            string colString,
            string targetString,
            string replaceString)
        {
            if (codeinfo.LeftHandSide.Equals(targetString))
            {
                codeinfo.LeftHandSide = replaceString;
                return true;
            }
            else if (codeinfo.RightHandSide.Equals(targetString))
            {
                codeinfo.RightHandSide = replaceString;
                return true;
            }

            return false;
        }

        private void SetSpreadRowCol(SourceCodeInfo codeInfo, ref string rowString, ref string colString)
        {
            if (codeInfo is SourceCodeInfoSubstitution)
            {
                var subCodeInfo = (SourceCodeInfoSubstitution) codeInfo;

                if (subCodeInfo.LeftHandSide.Equals(".Row"))
                {
                    rowString = subCodeInfo.RightHandSide + " -1";
                    subCodeInfo.LeftHandSide = "' 置換ツールによりコメント化" + subCodeInfo.LeftHandSide;
                }
                else if (subCodeInfo.LeftHandSide.Equals(".Col"))
                {
                    colString = subCodeInfo.RightHandSide + " -1";
                    subCodeInfo.LeftHandSide = "' 置換ツールによりコメント化" + subCodeInfo.LeftHandSide;
                }
                else if (subCodeInfo.RightHandSide.Equals(".Row"))
                {
                    subCodeInfo.RightHandSide = rowString;
                }
                else if (subCodeInfo.RightHandSide.Equals(".Col"))
                {
                    subCodeInfo.RightHandSide = colString;
                }
                else if (this.SetSubstitutionValue(subCodeInfo, rowString, colString, ".Value", ".ActiveSheet.Cell(" + rowString + "," + colString + ").Value"))
                {
                    
                }
                else if (this.SetSubstitutionValue(subCodeInfo, rowString, colString, ".MaxRows", ".ActiveSheet.Rows.Count"))
                {
                    
                }

            }
            else if (codeInfo is SourceCodeInfoCallMethod)
            {
                var subCodeInfo = (SourceCodeInfoCallMethod)codeInfo;
                var paramater = subCodeInfo.Paramater;

                var rowParamaterValues = subCodeInfo.Paramater.GetParamaterValue(".Row");

                if (rowParamaterValues != null)
                {
                    foreach (var value in rowParamaterValues)
                    {
                        value.ParammaterName = rowString;
                    }                    
                }

                var colParamaterValues = subCodeInfo.Paramater.GetParamaterValue(".Col");

                if (colParamaterValues != null)
                {
                    foreach (var value in colParamaterValues)
                    {
                        value.ParammaterName = colString;
                    }
                }

                if (subCodeInfo.CallmethodName.Equals("SetInteger")||
                    subCodeInfo.CallmethodName.Equals("SetFloat") ||
                    subCodeInfo.CallmethodName.Equals("SetText"))
                {
                    if (subCodeInfo.CallmethodName.Equals("SetText"))
                    {
                        subCodeInfo.CallmethodName = "ActiveSheet.SetText";                        
                    }
                    else
                    {
                        subCodeInfo.CallmethodName = "ActiveSheet.SetValue";    
                    }

                    var paramaterValues = paramater.ParamaterValues;

                    var list = new List<SourceCodeInfoParamaterValue>();

                    list.Add(paramaterValues[1]);
                    list.Add(paramaterValues[0]);
                    list.Add(paramaterValues[2]);
                    paramater.ParamaterValues = list.ToArray();
                }

            }
        }
    }
}

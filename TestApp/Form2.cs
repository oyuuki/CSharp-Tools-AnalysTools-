using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void button1_Click(object sender, EventArgs e)
        {
            // デザイナクラスを読み込み
            var mana = new AnalysisSourceDocumentManagerVBDotNet(@"D:\TETETETE\frm000099.Designer.vb");
            // スプレッドフィールド名を保持する
            var filedNameList = this.GetFiledNamelist(mana, "FarPoint.Win.Spread.FpSpread");

            // 処理クラスを読み込み
            var mana2 = new AnalysisSourceDocumentManagerVBDotNet(@"D:\TETETETE\frm000099.vb");

            var spreadwithBlockNameList = new List<string>();

            foreach (var withBlockBegin in mana2.GetSourceCodeInfoblockBeginWith())
            {
                var locWithName = withBlockBegin.StatementObject;
                var motoName = withBlockBegin.StatementObject;

                if (locWithName.EndsWith(")"))
                {
                    locWithName = "_" + locWithName;
                    locWithName = locWithName.Replace("(", "_").Replace(")", "");
                }

                foreach (var name in filedNameList)
                {

                    if (locWithName.Equals(name))
                    {                   
                        withBlockBegin.StatementObject = locWithName;
                        spreadwithBlockNameList.Add(motoName);
                    }
                }
            }

            // スプレッドに関連する
            foreach (var name in spreadwithBlockNameList)
            {
                string colString = string.Empty;
                string rowString = string.Empty;


                var blocks = mana2.GetCodeInfosRoundWithBlock(name);

                foreach (var value in mana2.GetCodeInfosRoundWithBlock(name))
                {
                    if (value.GetCodeString().Trim().StartsWith("."))
                    {
                        this.SetSpreadRowCol(value, ref rowString, ref colString);
                    }
                }
            }

            mana2.CreateAnalysisSourceFile(@"D:\TETETETE\test\test.vb");
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

                var rowParamaterValues = subCodeInfo.Paramater.GetParamaterValue("Row");

                if (rowParamaterValues == null)
                {
                    foreach (var value in rowParamaterValues)
                    {
                        value.ParammaterName = rowString;
                    }                    
                }

                var colParamaterValues = subCodeInfo.Paramater.GetParamaterValue("Col");

                if (colParamaterValues == null)
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

                    var rowValue = paramaterValues[1].ParammaterName;
                    var colValue = paramaterValues[0].ParammaterName;
                    var setValue = paramaterValues[2].ParammaterName;

                    paramaterValues[0].ParammaterName = rowValue;
                    paramaterValues[1].ParammaterName = colValue;
                    paramaterValues[2].ParammaterName = setValue;
                }

            }
        }
    }
}

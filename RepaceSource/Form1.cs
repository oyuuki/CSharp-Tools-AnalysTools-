﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Schema;

using OyuLib;
using OyuLib.Documents.Sources.Analysis;
using OyuLib.Documents.Sources;
using OyuLib.Documents;

namespace RepaceSource
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string[] GetFilePaths(string folderPath)
        {
            var retList = new List<string>();

            foreach (var filepath in Directory.GetFiles(folderPath))
            {
                if (filepath.IndexOf("Designer.vb") < 0 && filepath.EndsWith(".vb"))
                {
                    retList.Add(filepath);
                }
            }

            return retList.ToArray();
        }

        private int getLineCount(string folderpath)
        {
            int length = 0;

            foreach(string filepath in this.GetFilePaths(folderpath))
            {
                Document doc = new Document(filepath);
                length += doc.GetLineArray().Length;
            }

            return length;
        }


        private string OutParamaterValue(IParamater param)
        {
            string paramString = string.Empty;

            foreach (var paramValue in param.GetSourceCodeInfoParamaters())
            {
                if (!paramValue.HasParamater)
                {
                    return paramString;
                }


                paramString = "{";

                foreach (var value in paramValue.ParamaterValues)
                {
                    foreach (var element in value.ElementStrages)
                    {
                        var elemetValue = element.Value;

                        if (elemetValue is SourceCodeInfoCallMethod)
                        {
                            paramString += "メ：{①" + ((SourceCodeInfoCallMethod)elemetValue).CallmethodName + "①}";
                            paramString += "パ：[" + OutParamaterValue((IParamater)elemetValue) + "]";
                        }
                        else
                        {
                            paramString += "パ：[" + ((SourceCodeInfoParamaterValueElement)elemetValue).ParamaterName + "]";
                        }
                    }
                }
            }

            paramString += "}";

            return paramString;
        }

        private string ChasngeIndexParamaterValue(IParamater param, int paramIndex)
        {
            string paramString = string.Empty;
            var paramValues = param.GetSourceCodeInfoParamaters()[paramIndex].ParamaterValues;

            if (param.GetSourceCodeInfoParamaters()[paramIndex].HasParamater && paramValues.Length > 1)
            {
                param.GetSourceCodeInfoParamaters()[paramIndex].ChangeParamaterIndex(0, 1);
            }

            foreach (var paramValue in param.GetSourceCodeInfoParamaters()[paramIndex].ParamaterValues)
            {
                foreach(var element in paramValue.ElementStrages)
                {
                    if(element.Value is IParamater)
                    {
                        paramString += "Inner：" + this.ChasngeIndexParamaterValue((IParamater)element.Value, 0);
                    }

                }

            }
           
            return paramString;
        }

        private void testCode()
        {
            var mana = new AnalysisSourceDocumentManagerVBDotNet(@"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\EnterDeTab.NET\frm004006.vb");

            foreach (var info in mana.GetAllCodeInfos())
            {
                this.exListBox1.Items.Add(info.ToString());
                this.exListBox2.Items.Add(info.GetCodeString());
            }
        }

        private void exButton1_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();
            this.exListBox2.Items.Clear();


             this.testCode();

                        

            //var filedNameList = new List<string>();
            
            //foreach (var value in mana.GetMemValCodeIndoFiltTypeName("FarPoint.Win.Spread.FpSpread"))
            //{
            //    this.exListBox1.Items.Add(value.ToString());
            //    filedNameList.Add(value.Name);
            //}      

            //this.exListBox1.Items.Add("ここまでがフィールド抽出処理");

            //mana = new AnalysisSourceDocumentManagerVBDotNet(@"D:\TETETETE\frm002005.vb");

            //foreach (var name in filedNameList)
            //{
            //    this.exListBox1.Items.Add("フィールド：" + name + "に関連するイベントメソッド一覧");

            //    foreach (var value in mana.GetEventMethodCodeIndoFiltFieldName(name))
            //    {
            //        this.exListBox1.Items.Add(value.ToString());
            //    }
    
            //    this.exListBox1.Items.Add("");
            //}

            //this.exListBox1.Items.Add("ここまでがフィールドに関連するイベントメソッド抽出処理");


            //foreach (var name in filedNameList)
            //{
            //    this.exListBox1.Items.Add("フィールド：" + name + "に関連する代入一覧");

            //    var withNextCount = new List<bool>();

            //    foreach (var value in mana.GetSourceCodeAnalysis())
            //    {
            //        if (withNextCount.Count > 0 && withNextCount[withNextCount.Count - 1])
            //        {
            //            if (value is SourceCodeInfoSubstitution)
            //            {

            //                var a = (SourceCodeInfoSubstitution) value;

            //                if (a.LeftHandSide.IndexOf(".Row") >= 0 || a.LeftHandSide.IndexOf(".Col") >= 0)
            //                {
            //                    this.exListBox1.Items.Add(value.ToString());
            //                }

            //            }
            //            else if (value is SourceCodeInfoCallMethod)
            //            {
            //                this.exListBox1.Items.Add(value.ToString());
            //            }
            //        }

            //        if (value is SourceCodeInfoBlockBeginWithVB)
            //        {
            //            var blockWithInfo = (SourceCodeInfoBlockBeginWithVB)value;
                        
            //            if (blockWithInfo.StatementObject.Equals(name))
            //            {
            //                this.exListBox1.Items.Add(value.ToString());
            //                withNextCount.Add(true);
            //            }
            //            else
            //            {
            //                withNextCount.Add(false);
            //            }
            //        }
            //        else if (value is SourceCodeInfoBlockEndWithVB)
            //        {
            //            if (withNextCount.Count > 0)
            //            {
            //                if (withNextCount[withNextCount.Count - 1])
            //                {
            //                    this.exListBox1.Items.Add(value.ToString());        
            //                }

            //                withNextCount.RemoveAt(withNextCount.Count - 1);    
            //            }

                        
            //        }
            //    }

            //    this.exListBox1.Items.Add("");
            //}
        }

        private void exButton2_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();
            this.exListBox2.Items.Clear();

            string a =
                @"new SourceVBDotNet(new TextFile(""""D:\TETETETE\frm002005.vb"""").GetAllReadText()).GetText(""""test"""").Text";

            a =
                @"new SourceVBDotNet(new TextFile(""""D:\TETETETE\frm002005.vb"""").GetAllReadText(a = GetText(1 + 2 + 3 + .GetAllReadText(Text)))).GetText(""""test"""").Text";

            a =
                "Private Sub spd選択_LeaveCell(ByVal eventSender As System.Object, ByVal eventArgs As AxFPSpread._DSpreadEvents_LeaveCellEvent) Handles spd選択.LeaveCell";

            a = "a(a,b)";

            StringSpilitter s = new StringSpilitter(a);
            StringRange[] cc = s.GetHierarchicalStringWithRangeSpilit(" ", new ManagerStringNested("(", ")"));

            // this.exListBox1.Items.Add(a);

            foreach (var va in cc)
            {
                Test(a, va, "");
            }

            this.exListBox2.Items.Add("ワード検索");

            foreach (var va in cc)
            {
                TestSearch(a, va, "", "new");
            }

            this.exListBox2.Items.Add("コードパーツを生成しよう");

            var str = string.Empty;

            foreach (var va in cc)
            {
                str += Test3435(a, va);
            }


            this.exListBox2.Items.Add(str);
            this.exListBox2.Items.Add(a);
        }

        private void Test(string a, StringRange str, string blank)
        {
            //this.exListBox1.Items.Add(blank + " " +  str.IndexStart + ":" + str.CutStringCount);
            this.exListBox1.Items.Add(blank + str.GetStringSpilited());

            if (str.Childs == null)
            {
                return;
            }

            foreach (var va in str.Childs)
            {                          
                Test(a, va, blank + "    ");
            }
        }

        private void TestSearch(string a, StringRange str, string blank, string search)
        {
            //this.exListBox1.Items.Add(blank + " " +  str.IndexStart + ":" + str.CutStringCount);

            if (search.Equals(str.GetStringSpilited()))
            {
                this.exListBox1.Items.Add(str.IndexStart + ":" + str.IndexEnd);
            }

            

            if (str.Childs == null)
            {
                return;
            }

            foreach (var va in str.Childs)
            {
                TestSearch(a, va, blank + "    ", search);
            }
        }

        private string Test3435(string a, StringRange str)
        {
            string retStr = string.Empty;

            //this.exListBox1.Items.Add(blank + " " +  str.IndexStart + ":" + str.CutStringCount);
            retStr = "[" + str.GetStringSpilited() + "] " ;

            if (str.Childs == null)
            {
                return retStr;
            }

            foreach (var va in str.Childs)
            {
                retStr += Test3435(a, va);
            }

            return retStr;
        }

        private void exButton3_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();
            this.exListBox2.Items.Clear();

            var mana = new AnalysisSourceDocumentManagerVBDotNet(@"D:\TETETETE\test\test.vb");
        }

        private void exButton4_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();
            this.exListBox2.Items.Clear();

            var mana = new AnalysisSourceDocumentManagerVBDotNet(@"D:\TETETETE\test\test.vb");
           
        }

        private void exButton5_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();
            this.exListBox2.Items.Clear();

            var mana = new AnalysisSourceDocumentManagerVBDotNet(@"D:\TETETETE\test\test.vb");

            foreach (var codeinfo in mana.GetCodeInfoSubstitutionsRoundBlock("spd選択"))
            {
                this.exListBox1.Items.Add(codeinfo.GetTemplateString());
                this.exListBox2.Items.Add(codeinfo.GetCodeString());
            }

            foreach (var codeinfo in mana.GetSourceCodeInfoBlockBeginEventMethodSuggestObjectName("spd選択"))
            {
                this.exListBox1.Items.Add(codeinfo.GetTemplateString());
                this.exListBox2.Items.Add(codeinfo.GetCodeLineNumber());
            }

            foreach (var codeinfo in mana.GetSourceCodeInfoBlockBeginEventMethodSuggestObjectName("spd選択"))
            {
                codeinfo.EventName = "うわああああ";                

                this.exListBox1.Items.Add(codeinfo.GetCodePartsOverWriteValues());
                this.exListBox2.Items.Add(codeinfo.GetCodeString());
            }

            foreach (var codeinfo in mana.GetSourceCodeInfoCallMethodSuggestObjectName("Err"))
            {
                codeinfo.CallmethodName = "うほ";

                this.exListBox1.Items.Add(codeinfo.GetCodePartsOverWriteValues());
                this.exListBox2.Items.Add(codeinfo.GetCodeString());
            }

           
            foreach (var codeinfo in mana.GetCodeInfoCallMethodsRoundBlock("spd選択"))
            {


                this.exListBox1.Items.Add(codeinfo.GetCodePartsOverWriteValues());
                this.exListBox2.Items.Add(codeinfo.GetCodeString());
            }
        }

        private void Test2(StringRange[] strRange, string kaisou)
        {
            foreach (var inVal in strRange)
            {
                if (inVal.Childs != null)
                {
                    Test2(inVal.Childs, kaisou + "  ");
                }
                else
                {
                    this.exListBox1.Items.Add(kaisou + inVal.GetStringSpilited());
                    this.exListBox2.Items.Add(kaisou + inVal.GetStringSpilited());
                }
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            exListBox1.TopIndex = exListBox2.TopIndex;
            exListBox1.SelectedIndex = exListBox2.SelectedIndex;
        }

        
    }
}

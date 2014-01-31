using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Schema;
using OyuLib;
using OyuLib.Documents;
using OyuLib.Documents.Analysis;
using OyuLib.IO;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exButton1_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();
            this.exListBox2.Items.Clear();

            SourceVBDotNet source = new SourceVBDotNet(new TextFile(@"D:\TETETETE\frm002005.Designer.vb").GetAllReadText());
            ManagerAnalysisCode mana = new ManagerAnalysisCode(source.SourceText);

            var filedNameList = new List<string>();
            
            foreach (var value in mana.GetMemValCodeIndoFiltTypeName("FarPoint.Win.Spread.FpSpread"))
            {
                this.exListBox1.Items.Add(value.ToString());
                filedNameList.Add(value.Name);
            }      

            this.exListBox1.Items.Add("ここまでがフィールド抽出処理");

            source = new SourceVBDotNet(new TextFile(@"D:\TETETETE\frm002005.vb").GetAllReadText());
            mana = new ManagerAnalysisCode(source.SourceText);

            foreach (var name in filedNameList)
            {
                this.exListBox1.Items.Add("フィールド：" + name + "に関連するイベントメソッド一覧");

                foreach (var value in mana.GetEventMethodCodeIndoFiltFieldName(name))
                {
                    this.exListBox1.Items.Add(value.ToString());
                }
    
                this.exListBox1.Items.Add("");
            }

            this.exListBox1.Items.Add("ここまでがフィールドに関連するイベントメソッド抽出処理");


            foreach (var name in filedNameList)
            {
                this.exListBox1.Items.Add("フィールド：" + name + "に関連する代入一覧");

                var withNextCount = new List<bool>();

                foreach (var value in mana.GetVbSourceCodeAnalysis())
                {
                    if (withNextCount.Count > 0 && withNextCount[withNextCount.Count - 1])
                    {
                        if (value is CodeInfoSubstitution)
                        {

                            var a = (CodeInfoSubstitution) value;

                            if (a.LeftHandSide.IndexOf(".Row") >= 0 || a.LeftHandSide.IndexOf(".Col") >= 0)
                            {
                                this.exListBox1.Items.Add(value.ToString());
                            }

                        }
                        else if (value is CodeInfoCallMethod)
                        {
                            this.exListBox1.Items.Add(value.ToString());
                        }
                    }

                    if (value is CodeInfoBlockBeginWithVB)
                    {
                        var blockWithInfo = (CodeInfoBlockBeginWithVB)value;
                        
                        if (blockWithInfo.StatementObject.Equals(name))
                        {
                            this.exListBox1.Items.Add(value.ToString());
                            withNextCount.Add(true);
                        }
                        else
                        {
                            withNextCount.Add(false);
                        }
                    }
                    else if (value is CodeInfoBlockEndWithVB)
                    {
                        if (withNextCount.Count > 0)
                        {
                            if (withNextCount[withNextCount.Count - 1])
                            {
                                this.exListBox1.Items.Add(value.ToString());        
                            }

                            withNextCount.RemoveAt(withNextCount.Count - 1);    
                        }

                        
                    }
                }

                this.exListBox1.Items.Add("");
            }
        }

        private void exButton2_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();
            this.exListBox2.Items.Clear();

            StringSpilitter s = new StringSpilitter(@"new SourceVBDotNet(new TextFile(""""D:\TETETETE\frm002005.vb"""").GetAllReadText()).GetText(""""test"""").Text");

            string[] aa = s.GetSpilitStringNoChilds(" ", new ManagerStringNested("(", ")"));

            foreach (var value in aa)
            {
                this.exListBox1.Items.Add(value);
            }
        }

        private void exButton3_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();
            this.exListBox2.Items.Clear();

            SourceVBDotNet source = new SourceVBDotNet(new TextFile(@"D:\TETETETE\frm002005.vb").GetAllReadText());
            ManagerAnalysisCode mana = new ManagerAnalysisCode(source.SourceText);

            foreach (var value in mana.GetVbSourceCodeAnalysis())
            {
                if (value is CodeInfoSubstitution)
                {
                    var a = (CodeInfoSubstitution) value;

                    if (a.LeftHandSide.IndexOf(".Row") >= 0 || a.LeftHandSide.IndexOf(".Col") >= 0)
                    {
                 //       this.exListBox1.Items.Add(value.ToString());        
                    }
                }
                else if (value is CodeInfoCallMethod)
                {
                    this.exListBox1.Items.Add(value.ToString());
                }
            }
        }

        private void exButton4_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();
            this.exListBox2.Items.Clear();

            SourceVBDotNet source = new SourceVBDotNet(new TextFile(@"D:\TETETETE\frm002005.vb").GetAllReadText());
            ManagerAnalysisCode mana = new ManagerAnalysisCode(source.SourceText);

            foreach (var value in mana.GetVbSourceCodeAnalysis())
            {
                if (value is CodeInfoSubstitution)
                {
                    var a = (CodeInfoSubstitution)value;

                    if (a.LeftHandSide.IndexOf(".Row") >= 0 || a.LeftHandSide.IndexOf(".Col") >= 0)
                    {
                        this.exListBox1.Items.Add(value.ToString());
                    }
                }
                else if (value is CodeInfoBlockBegin || value is CodeInfoBlockEnd)
                {
                    this.exListBox1.Items.Add(value.ToString());
                }
            }
        }

        private void exButton5_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();
            this.exListBox2.Items.Clear();

            SourceVBDotNet source = new SourceVBDotNet(new TextFile(@"D:\TETETETE\frm002005.vb").GetAllReadText());
            ManagerAnalysisCode mana = new ManagerAnalysisCode(source.SourceText);

            foreach (var value in mana.GetVbSourceCodeAnalysis())
            {
                this.exListBox1.Items.Add(value.ToString());
                
            }

            foreach (var str in source.GetLineArray())
            {
                this.exListBox2.Items.Add(str);
            }

            var sourceBlock = new SourceBlock(mana.GetVbSourceCodeAnalysis());
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

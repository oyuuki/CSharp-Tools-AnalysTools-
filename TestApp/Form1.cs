using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            SourceVBDotNet source = new SourceVBDotNet(new TextFile(@"C:\Users\PASEO\Desktop\FreeMarket.NET\frm002005.Designer.vb").GetAllReadText());
            ManagerAnalysisCode mana = new ManagerAnalysisCode(source.SourceText);

            var filedNameList = new List<string>();
            /*
            foreach (var value in mana.GetMemValCodeIndoFiltTypeName("FarPoint.Win.Spread.FpSpread"))
            {
                this.exListBox1.Items.Add(value.ToString());
                filedNameList.Add(value.Name);
            }

            this.exListBox1.Items.Add("ここまでがフィールド抽出処理");

            source = new SourceVBDotNet(new TextFile(@"C:\Users\PASEO\Desktop\FreeMarket.NET\frm002005.vb").GetAllReadText());
            mana = new AnalysisCodeManager(source.SourceText);

            foreach (var name in filedNameList)
            {
                this.exListBox1.Items.Add("フィールド：" + name + "に関連するイベントメソッド一覧");

                foreach (var value in mana.GetEventMethodCodeIndoFiltFieldName(name))
                {
                    this.exListBox1.Items.Add(value.ToString());
                }
    
                this.exListBox1.Items.Add("");
            }
             * */

            foreach (var value in mana.GetVbSourceCodeAnalysis())
            {
                this.exListBox1.Items.Add(value.ToString());
            }

        }
    }
}

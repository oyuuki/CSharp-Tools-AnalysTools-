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
            SourceVBDotNet source = new SourceVBDotNet(new TextFile(@"C:\Users\PASEO\Desktop\FreeMarket.NET\frm002005.Designer.vb").GetAllReadText());

            AnalysisCodeManager mana = new AnalysisCodeManager(source.SourceText);

            foreach (var value in mana.GetVBSourceCodeSourceAnalysis())
            {
                this.exListBox1.Items.Add(value.ToString());
            }
        }
    }
}

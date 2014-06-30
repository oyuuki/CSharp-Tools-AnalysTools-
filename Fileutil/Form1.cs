using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OyuLib.IO;

namespace FileUtil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private OyuLib.IO.FileUtil.SearchResult[] GetSearchFilepath()
        {
            return OyuLib.IO.FileUtil.GetResultSearchFiles(this.txtFolder.Text, this.txtFileNames.Text.Split(','));
        }

        private string[] GetSearchFilepathStrings()
        {
            var retValue = new List<string>();

            foreach(var value in OyuLib.IO.FileUtil.GetResultSearchFiles(this.txtFolder.Text, this.txtFileNames.Text.Split(',')))
            {
                retValue.Add(value.Filename);
            }

            return retValue.ToArray();
        }

        private void ShowSearchResult()
        {
            this.exListBox1.Items.Clear();

            foreach (var resValue in this.GetSearchFilepath())
            {
                this.exListBox1.Items.Add(resValue.Filename + (resValue.IsFind ? "○" : ""));
            }
        }

        private void exButton1_Click(object sender, EventArgs e)
        {
            this.ShowSearchResult();
        }

        private void exButton2_Click(object sender, EventArgs e)
        {
            OyuLib.IO.FileUtil.ChangeFileExtension(this.GetSearchFilepathStrings(), this.txtFolder.Text, this.txtBefExtension.Text, this.txtAftExtention.Text);
            this.ShowSearchResult();
        }
    }
}

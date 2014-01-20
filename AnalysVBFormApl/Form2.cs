using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CommonCompornent.ExDataGridView.Events;
using AnalysVBFormApl.Interface;
using ConsoleUtil;

using CommonLogic;
using AnalysVBFormApl.DataSet1TableAdapters;

namespace AnalysVBFormApl
{
    public partial class Form2 : Form
    {
        #region const

        /// <summary>
        /// Column Name of DataGridView: ColLineNumber
        /// </summary>
        private const string COLUMNNAME_COLLINENUMBER = "ColLineNumber";

        /// <summary>
        /// Column Name of DataGridView: ColType
        /// </summary>
        private const string COLUMNNAME_COLTYPE = "ColType";

        /// <summary>
        /// Column Name of DataGridView: ColGrid
        /// </summary>
        private const string COLUMNNAME_COLGRID = "ColGrid";



        /// <summary>
        /// Column Name of DataGridView: ColDbName2
        /// </summary>
        private const string COLUMNNAME_COLDBNAME2 = "ColDbName2";

        /// <summary>
        /// Column Name of DataGridView: ColDBColumnName2
        /// </summary>
        private const string COLUMNNAME_COLDBCOLUMNNAME2 = "ColDBColumnName2";

        /// <summary>
        /// Column Name of DataGridView: ColDBType2
        /// </summary>
        private const string COLUMNNAME_COLDBTYPE2 = "ColDBType2";

        /// <summary>
        /// Column Name of DataGridView: ColDBSize2
        /// </summary>
        private const string COLUMNNAME_COLDBSIZE2 = "ColDBSize2";



        #endregion

        #region instance

        private string _filePath = null;

        private Form1ToForm2[] _findSourceLine = null;

        #endregion

        #region constractor

        private Form2()
        {
            InitializeComponent();
        }

        private Form2(string filePath, Form1ToForm2[] findSourceLine, bool isTemae)
            : this()    
        {
            this._filePath = filePath;
            this._findSourceLine = findSourceLine;
            this.TopMost = isTemae;
        }

       
        #endregion

        #region method

        public static Form2 ShowForm(string filePath, Form1ToForm2[] findSourceLine, bool isTemae)
        {
            Form2 form = new Form2(filePath, findSourceLine, isTemae);
            
            
            form.Show();

            return form;
        }

        public void InitShowData()
        {
            foreach (Form1ToForm2 rowValues in this._findSourceLine)
            {
                this.SetRowData(rowValues);
            }

            this.exDataGridViewControl12222.Rows.Add(10);
        }

        private void SetRowData(Form1ToForm2 value)
        {
            int rowindex = this.exDataGridView1.Rows.Add();

            this.exDataGridView1[COLUMNNAME_COLLINENUMBER, rowindex].Value = value.GetLineNumber();
            this.exDataGridView1[COLUMNNAME_COLTYPE, rowindex].Value = value.GetLineString();

            if (value.GetLineString().Trim().StartsWith("'"))
            {
                this.exDataGridView1.Rows[rowindex].DefaultCellStyle.BackColor = Color.Gray;
            }

        }

        #region event

        /// <summary>
        /// CellClickのイベントデリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public void TestCellClick(object sender, EventArgs e)
        {
            DataGridViewCellEventArgs ee = (DataGridViewCellEventArgs)e;
            string lineNumber = this.exDataGridView1.GetStringValue(COLUMNNAME_COLLINENUMBER, ee.RowIndex);
            ConcoleManager.Exec(
                AnalysVBFormApl.Properties.Settings.Default.SakuraPath, 
                this._filePath + " " + "-Y=" + lineNumber);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.exDataGridView1.AddTempEvent<ExDataGridViewCellEventValue>(COLUMNNAME_COLGRID, EnumDGVEvent.eveCellClick, TestCellClick);
            this.exDataGridView1.SetEventFromTemp();
            this.exDataGridView1.ColumnNamesortAsNumber = new string[] { COLUMNNAME_COLLINENUMBER };
            InitShowData();
        }

        private void exButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void exButton2_Click(object sender, EventArgs e)
        {
            
            using (SqlServerDBCOntrolManager manager =
                new SqlServerDBCOntrolManager(AnalysVBFormApl.Properties.Settings.Default.DbUserId,
                                            AnalysVBFormApl.Properties.Settings.Default.DBUserPassword,
                                            AnalysVBFormApl.Properties.Settings.Default.DBServerName,
                                            AnalysVBFormApl.Properties.Settings.Default.DBName))
            {
                manager.Open();

                DataTable1TableAdapter Adap = new DataTable1TableAdapter();

                Adap.Connection = manager.Connection;

                DataSet1.DataTable1DataTable table = new DataSet1.DataTable1DataTable();


                for (int rowIndex = 0; rowIndex < this.exDataGridViewControl12222.Rows.Count; rowIndex++)
                {
                    string dbName = this.exDataGridViewControl12222.GetStringValue(COLUMNNAME_COLDBNAME2, rowIndex);
                    string dbColumnName = this.exDataGridViewControl12222.GetStringValue(COLUMNNAME_COLDBCOLUMNNAME2, rowIndex);

                    table = Adap.GetData(dbName, dbColumnName);

                    if (table.Rows.Count > 0)
                    {
                        DataSet1.DataTable1Row row = ((DataSet1.DataTable1Row)table.Rows[0]);

                        this.exDataGridViewControl12222[COLUMNNAME_COLDBTYPE2, rowIndex].Value = row.column_data_type;
                        this.exDataGridViewControl12222[COLUMNNAME_COLDBSIZE2, rowIndex].Value = row.max_length;
                    }
                    else
                    {
                        this.exDataGridViewControl12222[COLUMNNAME_COLDBTYPE2, rowIndex].Value = "";
                        this.exDataGridViewControl12222[COLUMNNAME_COLDBSIZE2, rowIndex].Value = "";
                    }
                }

            }

        }

        #endregion

        private void exButton3_Click(object sender, EventArgs e)
        {
            this.exDataGridViewControl12222.Rows.Add(10);
        }

        #endregion
    }
}

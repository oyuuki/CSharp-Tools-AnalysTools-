using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using System.IO;
using OyuLib.Documents.Analysis;
using OyuLib.IO;
using OyuLib.Windows.Forms;
using OyuLib.Windows.Forms.DataGridView;

using AnalysisVBFormApl.Interface;
using OyuLib.Xml;
using OyuLib;

namespace AnalysisVBFormApl
{
    public partial class Form1 : Form
    {
        #region const

        /// <summary>
        /// Column Name of DataGridView: ColId
        /// </summary>
        private const string COLUMNNAME_COLID = "ColId";

        /// <summary>
        /// Column Name of DataGridView: ColName
        /// </summary>
        private const string COLUMNNAME_COLNAME = "ColName";

        /// <summary>
        /// Column Name of DataGridView: ColType
        /// </summary>
        private const string COLUMNNAME_COLTYPE = "ColType";

        /// <summary>
        /// Column Name of DataGridView: ColSize
        /// </summary>
        private const string COLUMNNAME_COLSIZE = "ColSize";

        /// <summary>
        /// Column Name of DataGridView: ColTabIndex
        /// </summary>
        private const string COLUMNNAME_COLTABINDEX = "ColTabIndex";
        /// <summary>
        /// Column Name of DataGridView: ColFormat
        /// </summary>
        private const string COLUMNNAME_COLFORMAT = "ColFormat";

        /// <summary>
        /// Column Name of DataGridView: ColDoGrid
        /// </summary>
        private const string COLUMNNAME_COLDOGRID = "ColDoGrid";

        /// <summary>
        /// Column Name of DataGridView: ColSource
        /// </summary>
        private const string COLUMNNAME_COLSOURCE = "ColSource";

        /// <summary>
        /// Column Name of DataGridView: ColNumber
        /// </summary>
        private const string COLUMNNAME_COLNUMBER = "Colnumber";

        /// <summary>
        /// Column Name of DataGridView: ColReadOnly
        /// </summary>
        private const string COLUMNNAME_COLREADONLY = "ColReadOnly";

        /// <summary>
        /// Column Name of DataGridView: ColImeMode
        /// </summary>
        private const string COLUMNNAME_COLIMEMODE = "ColImeMode";

        /// <summary>
        /// Column Name of DataGridView: ColSigu
        /// </summary>
        private const string COLUMNNAME_COLSIGU = "ColSigu";

        /// <summary>
        /// Column Name of DataGridView: ColMemo
        /// </summary>
        private const string COLUMNNAME_COLMEMO = "ColMemo";

        /// <summary>
        /// Column Name of DataGridView: ColOriginalSortNo
        /// </summary>
        private const string COLUMNNAME_COLORIGINALSORTNO = "ColOriginalSortNo";

        #endregion

        #region constracotr

        public Form1()
        {
            InitializeComponent();

        }

        #endregion

        #region event

        #region CellContentClick

        #endregion

        #region Form Load

        private void Form1_Load(object sender, EventArgs e)
        {
            this.exDataGridView1.AddTempEvent<ExDataGridViewCellEventValue>(COLUMNNAME_COLDOGRID, EnumDGVEvent.eveCellClick, TestCellClick);
            this.exDataGridView1.SetEventFromTemp();
            this.exDataGridView1.ColumnNamesortAsNumber = new string[] { COLUMNNAME_COLORIGINALSORTNO, COLUMNNAME_COLTABINDEX, COLUMNNAME_COLNUMBER };
            this.lblFileName.Clear();
            this.exTextSource.Clear();
        }

        #endregion

        #region TextChanged

        private void exTxtSourcepath_TextChanged(object sender, EventArgs e)
        {
            this.ReadSource();
        }

        #endregion

        private void exTxtSearchText_Click(object sender, EventArgs e)
        {
            string text = this.exTxtSearch.Text;

            DataGridViewCell currentCell = this.exDataGridView1.CurrentCell;
            DataGridViewCell firstFindCell = null;

            try
            {
                foreach (DataGridViewRow row in this.exDataGridView1.GetRowsLikeValues(COLUMNNAME_COLNAME, text))
                {
                    if (firstFindCell == null)
                    {
                        firstFindCell = this.exDataGridView1[COLUMNNAME_COLNAME, row.Index];
                    }

                    if (currentCell == null || currentCell.RowIndex < row.Index)
                    {
                        this.exDataGridView1.CurrentCell = this.exDataGridView1[COLUMNNAME_COLNAME, row.Index];
                        return;
                    }
                }

                if (firstFindCell != null)
                {
                    this.exDataGridView1.CurrentCell = firstFindCell;
                }
            }
            finally
            {
                this.exDataGridView1.Refresh();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = this.checkBox1.Checked;
        }

        private void exTextSource_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void exTxtMemo_TextChanged(object sender, EventArgs e)
        {
            if (this.exDataGridView1.CurrentCell != null)
            {
                this.exDataGridView1[COLUMNNAME_COLMEMO, this.exDataGridView1.GetCurrentRowIndex()].Value = 
                    new Memo(this.exTxtMemo.Text, this.exTxtDBCRUD.Text);
            }
        }

        private void exBtnWrite_Click(object sender, EventArgs e)
        {
            SaveXml();
            MessageBox.Show("メモを保存しました。");
        }

        private void AllSaveProc()
        {
            this.SaveXml();
            this.SetRowColorExistMemo();
        }

        private void SaveOriNo()
        {
            this.exDataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            this.exDataGridView1.StoreDatatoXml(this.getXmlFileNameOriginalNo(), COLUMNNAME_COLNUMBER, new string[] { COLUMNNAME_COLORIGINALSORTNO });
        }

        private void SaveXml()
        {
            if (this.exDataGridView1.Rows.Count <= 0)
            {
                return;
            }

            List<XmlValueTypeKeyAndValue> list = new List<XmlValueTypeKeyAndValue>();

            for (int rowIndex = 0; rowIndex < this.exDataGridView1.Rows.Count; rowIndex++)
            {
                Memo memo = (Memo)this.exDataGridView1[COLUMNNAME_COLMEMO, rowIndex].Value;

                if (memo == null)
                {
                    continue;
                }

                list.Add(new XmlValueTypeKeyAndValue(
                    this.exDataGridView1.GetStringValue(COLUMNNAME_COLNUMBER, rowIndex),
                    memo.GetMemoStr()));
            }

            string xmlfileName = this.getXmlFileName();

            XmlSerializerManager.WriteXmlFile<XmlValueTypeKeyAndValue>(xmlfileName, list.ToArray());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.AllSaveProc();
        }

        private void exBtnReload_Click(object sender, EventArgs e)
        {
            this.SetRowColorExistMemo();

            string numberStr = this.exDataGridView1.GetStringValue(COLUMNNAME_COLNUMBER, this.exDataGridView1.GetCurrentRowIndex());

            Dictionary<string, Memo> dic = this.GetMemoDictionalyFromXmlFile();

            if (dic.Count > 0)
            {
                this.exTxtMemo.Text = dic[numberStr].GetMemo();
                this.exTxtDBCRUD.Text = dic[numberStr].GetDBName();
            }
        }

        private void exBtnCopyMemo_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (DataGridViewCell cell in this.exDataGridView1.SelectedCells)
            {
                string numberStr = cell.RowIndex.ToString();
                Memo memo = (Memo)this.exDataGridView1[COLUMNNAME_COLMEMO, cell.RowIndex].Value;

                if (memo != null)
                {
                    dic.Add(numberStr, memo.GetMemo());
                }
            }

            List<KeyValuePair<string, string>> list = sortByValue<string, string>(dic);
            string strClip = string.Empty;

            foreach (KeyValuePair<string, string> value in list)
            {
                strClip += value.Value + "\n";
            }

            strClip = strClip.TrimEnd() + " ";

            Clipboard.SetText(strClip);
        }

        private static List<KeyValuePair<TKey, TValue>>
        sortByValue<TKey, TValue>(IDictionary<TKey, TValue> dict)
        where TValue : IComparable<TValue>
        {
            List<KeyValuePair<TKey, TValue>> list
              = new List<KeyValuePair<TKey, TValue>>(dict);

            // Valueの大きい順にソート
            list.Sort(
              delegate(KeyValuePair<TKey, TValue> kvp1, KeyValuePair<TKey, TValue> kvp2)
              {
                  return int.Parse(kvp1.Key.ToString()) - int.Parse(kvp2.Key.ToString());
              });
            return list;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            SetRowColorExistMemo();
        }


        #endregion

        #region method

        #region readSource

        private void InitBefReadSource()
        {
            this.exDataGridView1.Rows.Clear();

            SetEnableControlSuggestDgv(false);

            this.chkColorMemo.Checked = false;

            this.exTxtMemo.Text = string.Empty;
            this.exTxtDBCRUD.Text = string.Empty;

            this.lblFileName.Clear();
        }

        private void ReadSource()
        {
            this.exDataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            this.InitBefReadSource();
            
            string filePath = exTxtSourcepath.Text;

            TextFile file = new TextFile(filePath, CharSet.ShiftJis);


            ManagerAnalysisInputFieldItem ana = new ManagerAnalysisInputFieldItem(file.GetAllReadText());
            WinFrmField[] items = ana.GetSourceAnalysisWinFrmFields<ManagerWinFrmFieldVb6>();

            if (items == null)
            {
                return;
            }


            this.lblFileName.Text = Path.GetFileName(filePath);

            this.ShowData(items);
            this.exDataGridView1.ReadDatatoXmlByKey(this.getXmlFileNameOriginalNo(), COLUMNNAME_COLNUMBER, new string[] { COLUMNNAME_COLORIGINALSORTNO });
        }


        #endregion

        #region event(delegate)

        /// <summary>
        /// CellClickのイベントデリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public void TestCellClick(object sender, EventArgs e)
        {

            DataGridViewCellEventArgs ee = (DataGridViewCellEventArgs)e;

            string searchText = this.exDataGridView1.GetStringValue(COLUMNNAME_COLID, ee.RowIndex);
            string[] sourceArray = new TextFile(this.exTxtSourcepath.Text).GetAllReadText().Split(new string[] { "\r\n" }, StringSplitOptions.None);

            List<Form1ToForm2> retList = new List<Form1ToForm2>();

            for(int index = 0; index < sourceArray.Length; index++)
            {
                string valuewithIndex = sourceArray[index];

                if (valuewithIndex.IndexOf(" Begin ") < 0 && valuewithIndex.IndexOf(searchText) >= 0)
                {
                    Form1ToForm2 value = new Form1ToForm2((index + 1).ToString(), valuewithIndex);
                    retList.Add(value);
                }
            }
            
            Form2.ShowForm(this.exTxtSourcepath.Text, retList.ToArray(), this.checkBox1.Checked);
        }

        #endregion

        private string getXmlFileName()
        {
            return Path.GetFileName(exTxtSourcepath.Text);
        }

        private string getXmlFileNameOriginalNo()
        {
            return Path.GetFileName(exTxtSourcepath.Text) + "OriNo";
        }

        private Dictionary<string, Memo> GetMemoDictionalyFromXmlFile()
        {
            return this.GetMemoDictionalyFromXmlFile(this.getXmlFileName());
        }

        private Dictionary<string, Memo> GetMemoDictionalyFromXmlFile(string xmlfileName)
        {
            Dictionary<string, Memo> retDic = new Dictionary<string, Memo>();


            Dictionary<string, string> dic = XmlSerializerManager.ReadXmlFileDictionaly(xmlfileName);

            foreach (KeyValuePair<string, string> value in dic)
            {
                retDic.Add(value.Key, new Memo(value.Value));
            }

            return retDic;
        }

        private void ShowData(WinFrmField[] array)
        {
            Dictionary<string, Memo> memoDic = GetMemoDictionalyFromXmlFile();
            
            foreach (WinFrmField value in array)
            {
                this.SetRowData(this.exDataGridView1.Rows.Add(), value, memoDic);
            }
        }

        private void SetRowData(int rowIndex, WinFrmField item, Dictionary<string, Memo> dic)
        {
            string nameTab = string.Empty;

            for (int index = 1; index < item.GetHierarchyIndex(); index++)
            {
                nameTab += "	";
            }

            this.exDataGridView1[COLUMNNAME_COLNUMBER, rowIndex].Value = rowIndex + 1;
            this.exDataGridView1[COLUMNNAME_COLNAME, rowIndex].Value = nameTab + item.GetName();
            this.exDataGridView1[COLUMNNAME_COLTYPE, rowIndex].Value = item.GetExType();
            this.exDataGridView1[COLUMNNAME_COLSIZE, rowIndex].Value = item.GetBeam();
            this.exDataGridView1[COLUMNNAME_COLTABINDEX, rowIndex].Value = item.GetTabIndex();
            this.exDataGridView1[COLUMNNAME_COLFORMAT, rowIndex].Value = item.GetFormat();
            this.exDataGridView1[COLUMNNAME_COLSOURCE, rowIndex].Value = item.GetSource();
            this.exDataGridView1[COLUMNNAME_COLID, rowIndex].Value = item.GetId();
            this.exDataGridView1[COLUMNNAME_COLREADONLY, rowIndex].Value = item.GetReadOnly();
            this.exDataGridView1[COLUMNNAME_COLIMEMODE, rowIndex].Value = item.GetImeMode();
            this.exDataGridView1[COLUMNNAME_COLSIGU, rowIndex].Value = item.GetItemSignature();

            string numberStr = this.exDataGridView1.GetStringValue(COLUMNNAME_COLNUMBER, rowIndex);

            if (dic.ContainsKey(numberStr))
            {
                this.exDataGridView1[COLUMNNAME_COLMEMO, rowIndex].Value = dic[numberStr];
            }
            else
            {
                this.exDataGridView1[COLUMNNAME_COLMEMO, rowIndex].Value = new Memo(string.Empty, string.Empty);
            }
        }


        private void SetEnableControlSuggestDgv(bool isEnable)
        {
            this.exTxtMemo.ReadOnly = !isEnable;
            this.exTxtDBCRUD.ReadOnly = !isEnable;
            this.exBtnWrite.Enabled = isEnable;
            this.exBtnReload.Enabled = isEnable;
            this.exBtnCopyMemo.Enabled = isEnable;
            this.exBtnCopyOrino.Enabled = isEnable;
        }

        private void SetRowColorExistMemo()
        {
            if (!this.chkColorMemo.Checked)
            {
                this.ClearRowColor();
                return;
            }

            foreach (DataGridViewRow row in this.exDataGridView1.Rows)
            {
                Memo memo = (Memo)this.exDataGridView1[COLUMNNAME_COLMEMO, row.Index].Value;

                if (memo != null && !string.IsNullOrEmpty(memo.GetMemo()))
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        private void exDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.SetRowColorExistMemo();

            int rowIndex = this.exDataGridView1.GetCurrentRowIndex();
            SetEnableControlSuggestDgv(true);

            this.ShowSource(rowIndex);
            this.ShowSiguneture(rowIndex);
            this.ShowMemo(rowIndex);
        }

        private void ShowSource(int rowIndex)
        {
            string str = this.exDataGridView1.GetStringValue(COLUMNNAME_COLSOURCE, rowIndex);
            this.exTextSource.Clear();
            this.exTextSource.Text = str.ToString();
        }

        private void ShowSiguneture(int rowIndex)
        {
            /*
            DataGridViewRow row = this.exDataGridView1.Rows[rowIndex];
            
            this.ClearRowColor();
            this.SetParentColor(row.Index);
            this.SetChildColor(row.Index);
            this.SetRowColorLine(row, Color.Blue);
            */
        }

        private void ShowMemo(int rowIndex)
        {
            Memo memo = (Memo)this.exDataGridView1[COLUMNNAME_COLMEMO, rowIndex].Value;

            if (memo == null)
            {
                return;
            }

            this.exTxtMemo.Text = memo.GetMemo();
            this.exTxtDBCRUD.Text = memo.GetDBName();
        }

        private void ClearRowColor()
        {
            foreach (DataGridViewRow row in this.exDataGridView1.Rows)
            {
                SetRowColorLine(row, Color.White);
            }
        }

        private void SetParentColor(int rowIndex)
        {
            string sigu = this.exDataGridView1.GetStringValue(COLUMNNAME_COLSIGU, rowIndex);
            string[] strArray = sigu.Split('.');

            string str2 = "." + strArray[strArray.Length - 1];

            if (string.IsNullOrEmpty(str2))
            {
                return;
            }

            sigu = sigu.Replace(str2, "");
            
            foreach (DataGridViewRow row in this.exDataGridView1.Rows)
            {
                if (this.exDataGridView1.GetStringValue(COLUMNNAME_COLSIGU, row.Index).Equals(sigu))
                {
                    SetRowColorLine(row, Color.Red);
                }
            }
        }

        private void SetChildColor(int rowIndex)
        {
            string sigu = this.exDataGridView1.GetStringValue(COLUMNNAME_COLSIGU, rowIndex) + ".";

            foreach (DataGridViewRow row in this.exDataGridView1.Rows)
            {
                if (this.exDataGridView1.GetStringValue(COLUMNNAME_COLSIGU, row.Index).StartsWith(sigu))
                {
                    SetRowColorLine(row, Color.Yellow);
                }
            }
        }

        private void SetRowColorLine(DataGridViewRow row, Color color)
        {
            row.DefaultCellStyle.BackColor = color;
        }

        private void exButton1_Click(object sender, EventArgs e)
        {
            ReadSource();

            this.exDataGridView1.Sort(this.exDataGridView1.Columns[1], ListSortDirection.Ascending);
            Regex reg = new Regex("[a-z,A-Z]");

            Dictionary<object, DataGridViewRowValues> dic = new Dictionary<object, DataGridViewRowValues>();

            foreach (DataGridViewRow row in this.exDataGridView1.GetRowsHasSameValue(COLUMNNAME_COLTYPE, "VB.Label"))
            {
                foreach (DataGridViewRow row2 in this.exDataGridView1.Rows)
                {
                    if (exDataGridView1.GetIsBlank(row2.Index))
                    {
                        continue;
                    }

                    if (row.Index == row2.Index)
                    {
                        continue;
                    }

                    if (row2.Cells[COLUMNNAME_COLTYPE].Value.ToString().Equals("VB.Label"))
                    {
                        continue;
                    }

                    object obj = row2.Cells[COLUMNNAME_COLNAME].Value;

                    
                    if (obj == null)
                    {
                        continue;
                    }

                    string objStr = reg.Replace(obj.ToString().Trim(), "");
                    string valueStr = row.Cells[COLUMNNAME_COLNAME].Value.ToString().Trim();
                    valueStr = valueStr.Replace("：", "");
                    valueStr = valueStr.Replace(":", "");

                    if (valueStr.Equals(objStr))
                    {
                        object key = row2.Cells[COLUMNNAME_COLNUMBER].Value;

                        if (dic.ContainsKey(key))
                        {
                            continue;
                        }

                        dic.Add(key, new DataGridViewRowValues(row));
                        this.exDataGridView1.ClearValueOfRow(row.Index);
                        break;
                    }
                }
            }


            foreach (DataGridViewRow row in this.exDataGridView1.GetRowsHasSameValue(COLUMNNAME_COLTYPE, "VB.Label"))
            {
                foreach (DataGridViewRow row2 in this.exDataGridView1.Rows)
                {
                    if (exDataGridView1.GetIsBlank(row2.Index))
                    {
                        continue;
                    }

                    object obj = row2.Cells[COLUMNNAME_COLNAME].Value;

                    if (row.Index == row2.Index)
                    {
                        continue;
                    }


                    if (row2.Cells[COLUMNNAME_COLTYPE].Value.ToString().Equals("VB.Label"))
                    {
                        continue;
                    }

                    if (obj == null)
                    {
                        continue;
                    }

                    string objStr = reg.Replace(obj.ToString().Trim(), "");

                    if (row.Cells[COLUMNNAME_COLNAME].Value.ToString().Trim().IndexOf(objStr) > 0
                        || objStr.IndexOf(row.Cells[COLUMNNAME_COLNAME].Value.ToString().Trim()) > 0)
                    {
                        object key = row2.Cells[COLUMNNAME_COLNUMBER].Value;

                        if (dic.ContainsKey(key))
                        {
                            continue;
                        }

                        dic.Add(key, new DataGridViewRowValues(row));
                        this.exDataGridView1.ClearValueOfRow(row.Index);
                        break;
                    }
                }
            }
            
            foreach (object key in dic.Keys)
            {
                int insertIndex = this.exDataGridView1.GetRowsHasSameValue(COLUMNNAME_COLNUMBER, key.ToString())[0].Index;
                this.exDataGridView1.Rows.Insert(insertIndex);

                DataGridViewRow insertedRow = this.exDataGridView1.Rows[insertIndex];
                dic[key].SetValues(ref insertedRow);
                this.TranceRowlabelValue(ref insertedRow);
            }
                       
            this.exDataGridView1.RemoveBlankRows();
        }

        private void exButton2_Click(object sender, EventArgs e)
        {
            this.GetTextCopyToClipbored();
        }

        private void exButton3_Click(object sender, EventArgs e)
        {
            this.ReadSource();
        }

        private void exDataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //表示されているコントロールがDataGridViewTextBoxEditingControlか調べる
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                DataGridView dgv = (DataGridView)sender;

                //編集のために表示されているコントロールを取得
                DataGridViewTextBoxEditingControl tb =
                    (DataGridViewTextBoxEditingControl)e.Control;

                //イベントハンドラを削除
                tb.PreviewKeyDown -=
                    new PreviewKeyDownEventHandler(dataGridViewTextBox_KeyDown);

                //該当する列か調べる
                if (dgv.CurrentCell.OwningColumn.Name.Equals(COLUMNNAME_COLORIGINALSORTNO))
                {
                    //KeyPressイベントハンドラを追加
                    tb.PreviewKeyDown +=
                        new PreviewKeyDownEventHandler(dataGridViewTextBox_KeyDown);
                }
            }
        }


        //DataGridViewに表示されているテキストボックスのKeyPressイベントハンドラ
        private void dataGridViewTextBox_KeyDown(object sender,
            PreviewKeyDownEventArgs e)
        {
            if (KeyUtil.IsPushThisKey(e.KeyData, Keys.P, true, false, false))
            {
                int maxoriNum = 0;

                if (this.exDataGridView1.CurrentCell.Value != null)
                {
                    return;
                }

                for (int rowIndex = 0; rowIndex < this.exDataGridView1.Rows.Count; rowIndex++)
                {
                    string oriNum = this.exDataGridView1.GetStringValue(COLUMNNAME_COLORIGINALSORTNO, rowIndex);

                    if (string.IsNullOrEmpty(oriNum))
                    {
                        continue;
                    }

                    int oriNumInt = 0;

                    if (!int.TryParse(oriNum, out oriNumInt))
                    {
                        continue;
                    }

                    if (oriNumInt > maxoriNum)
                    {
                        maxoriNum = oriNumInt;
                    }
                }

                this.exDataGridView1.EditingControl.Text = (maxoriNum + 1).ToString();
                this.exDataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            else if (KeyUtil.IsPushDialogDownKey(e.KeyData)
                || KeyUtil.IsPushEnterKey(e.KeyData))
            {
                this.SaveOriNo();
            }

        }

        #region inner class

        private class DataGridViewRowValues
        {
            #region instance

            /// <summary>
            /// Column Name of DataGridView: ColId
            /// </summary>
            private object _colId = null;

            /// <summary>
            /// Column Name of DataGridView: ColName
            /// </summary>
            private object _colName = null;

            /// <summary>
            /// Column Name of DataGridView: ColType
            /// </summary>
            private object _colType = null;

            /// <summary>
            /// Column Name of DataGridView: ColSize
            /// </summary>
            private object _colSize = null;

            /// <summary>
            /// Column Name of DataGridView: ColTabIndex
            /// </summary>
            private object _colTabIndex = null;
            /// <summary>
            /// Column Name of DataGridView: ColFormat
            /// </summary>
            private object _colFormat = null;

            /// <summary>
            /// Column Name of DataGridView: ColSource
            /// </summary>
            private object _colSource = null;

            /// <summary>
            /// Column Name of DataGridView: ColNumber
            /// </summary>
            private object _colNumber = null;

            /// <summary>
            /// Column Name of DataGridView: ColReadOnly
            /// </summary>
            private object _colReadOnly = null;

            /// <summary>
            /// Column Name of DataGridView: ColImeMode
            /// </summary>
            private object _colImeMode = null;

            /// <summary>
            /// Column Name of DataGridView: colSigu
            /// </summary>
            private object _colSigu = null;

            /// <summary>
            /// Column Name of DataGridView: ColMemo
            /// </summary>
            private object _colMemo = null;

            /// <summary>
            /// Column Name of DataGridView: ColOriginalSortNo
            /// </summary>
            private object _colOriginalSortNo = null;

            #endregion

            #region constractor

            /// <summary>
            /// 
            /// </summary>
            /// <param name="colId">ID</param>
            /// <param name="colName">名前</param>
            /// <param name="colType">型</param>
            /// <param name="colSize">サイズ</param>
            /// <param name="colTabIndex">TabIndex</param>
            /// <param name="colFormat">Format</param>
            /// <param name="colDoGrid"></param>
            /// <param name="colSource"></param>
            /// <param name="colNumber"></param>
            public DataGridViewRowValues(
                object colId,
                object colName,
                object colType,
                object colSize,
                object colTabIndex,
                object colFormat,
                object colSource,
                object colNumber,
                object colReadOnly,
                object colImeMode,
                object colSigu,
                object colMemo,
                object colOriginalSortNo)
            {
                this._colId = colId;
                this._colName = colName;
                this._colType = colType;
                this._colSize = colSize;
                this._colTabIndex = colTabIndex;
                this._colFormat = colFormat;
                this._colSource = colSource;
                this._colNumber = colNumber;
                this._colReadOnly = colReadOnly;
                this._colImeMode = colImeMode;
                this._colSigu = colSigu;
                this._colMemo = colMemo;
                this._colOriginalSortNo = colOriginalSortNo;
            }



            /// <summary>
            /// 
            /// </summary>
            /// <param name="colId">ID</param>
            /// <param name="colName">名前</param>
            /// <param name="colType">型</param>
            /// <param name="colSize">サイズ</param>
            /// <param name="colTabIndex">TabIndex</param>
            /// <param name="colFormat">Format</param>
            /// <param name="colDoGrid"></param>
            /// <param name="colSource"></param>
            /// <param name="colNumber"></param>
            public DataGridViewRowValues(DataGridViewRow row)
                : this(row.Cells[COLUMNNAME_COLID].Value,
                row.Cells[COLUMNNAME_COLNAME].Value,
                row.Cells[COLUMNNAME_COLTYPE].Value,
                row.Cells[COLUMNNAME_COLSIZE].Value,
                row.Cells[COLUMNNAME_COLTABINDEX].Value,
                row.Cells[COLUMNNAME_COLFORMAT].Value,
                row.Cells[COLUMNNAME_COLSOURCE].Value,
                row.Cells[COLUMNNAME_COLNUMBER].Value,
                row.Cells[COLUMNNAME_COLREADONLY].Value,
                row.Cells[COLUMNNAME_COLIMEMODE].Value,
                row.Cells[COLUMNNAME_COLSIGU].Value,
                row.Cells[COLUMNNAME_COLMEMO].Value,
                row.Cells[COLUMNNAME_COLORIGINALSORTNO].Value)
            {

            }

            #endregion

            #region method

            #region SetValues

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void SetValues(ref DataGridViewRow row)
            {
                row.Cells[COLUMNNAME_COLID].Value = this._colId;
                row.Cells[COLUMNNAME_COLNAME].Value = this._colName;
                row.Cells[COLUMNNAME_COLTYPE].Value = this._colType;
                row.Cells[COLUMNNAME_COLSIZE].Value = this._colSize;
                row.Cells[COLUMNNAME_COLTABINDEX].Value = this._colTabIndex;
                row.Cells[COLUMNNAME_COLFORMAT].Value = this._colFormat;
                row.Cells[COLUMNNAME_COLSOURCE].Value = this._colSource;
                row.Cells[COLUMNNAME_COLNUMBER].Value = this._colNumber;
                row.Cells[COLUMNNAME_COLREADONLY].Value = this._colReadOnly;
                row.Cells[COLUMNNAME_COLIMEMODE].Value = this._colImeMode;
                row.Cells[COLUMNNAME_COLSIGU].Value = this._colSigu;
                row.Cells[COLUMNNAME_COLMEMO].Value = this._colMemo;
                row.Cells[COLUMNNAME_COLORIGINALSORTNO].Value = this._colOriginalSortNo;
            }

            #endregion

            #region GetNumber

            public object GetNumber()
            {
                return this._colNumber;
            }

            #endregion

            #endregion
        }

        #endregion

        #endregion

        #region TraceForArcBook

        private void TranceRow(ref DataGridViewRow row)
        {
            //■型文字列の置換
            //  VB.CommandButton      → Button
            //  imText6Ctl.imText     → TextBox
            //  imNumber6Ctl.imNumber → TextBox
            //  imDate6Ctl.imDate     → ComboBox(Curender)
            //  VB.Label              → Label
            //  VB.Frame              → Frame
            //  VB.OptionButton       → OptionButton
            //  VB.CheckBox           → CheckBox
            //  VB.ComboBox           → ComboBox
            

            //■階層構造を表に視覚的に反映(現状ちょいとむずい)
            //  ・TABで表現
            //    主にフレームの中のオブジェクト

            //■設計書へのコピー機能
            //  ・設計書レイアウトに合わせたテキストのコピー機能(クリップボードへ)
        }

        private void TranceRowTypeValue(ref DataGridViewRow row)
        {
            row.Cells[COLUMNNAME_COLTYPE].Value = ConstAttributeManager<TranceType>.GetValueSuggestConst(row.Cells[COLUMNNAME_COLTYPE].Value.ToString());
        }

        private void TranceRowlabelValue(ref DataGridViewRow row)
        {
            row.Cells[COLUMNNAME_COLNAME].Value = row.Cells[COLUMNNAME_COLNAME].Value + "(タイトル)";
        }

        private void GetTextCopyToClipbored()
        {
            if (this.exDataGridView1.Rows.Count <= 0)
            {
                return;
            }

            StringBuilder strBr = new StringBuilder();

            foreach (DataGridViewRow row in this.exDataGridView1.Rows)
            {
                strBr.AppendLine(this.GetTextCopyToClipboredLine(row));
            }

            Clipboard.SetText(strBr.ToString());
        }

        private string GetTextCopyToClipboredLine(DataGridViewRow row)
        {
            string formatStr = "[0]		[1]							[2]					[3]		[4]					[5]		[6]		[7]";

            int tabCount = this.GetTrancedName(row.Index).Split(new string[] { "	" }, StringSplitOptions.None).Count();

            for(int count = 1; count < tabCount; count++)
            {
                formatStr = formatStr.Replace("[1]	", "[1]");
            }

            formatStr = formatStr.Replace("[0]", this.GetTrancedNo(row.Index));
            formatStr = formatStr.Replace("[1]", this.GetTrancedName(row.Index));
            formatStr = formatStr.Replace("[2]", this.GetTrancedType(row.Index));
            formatStr = formatStr.Replace("[3]", this.GetTrancedSize(row.Index));
            formatStr = formatStr.Replace("[4]", this.GetTrancedFormat(row.Index));
            formatStr = formatStr.Replace("[5]", this.GetTrancedInOut(row.Index));
            formatStr = formatStr.Replace("[6]", this.GetTrancedIme(row.Index));
            formatStr = formatStr.Replace("[7]", this.GetTrancedRemark(row.Index));

            return formatStr;
        }

        private string GetTrancedNo(int rowIndex)
        {
            // ●項目名　明細.項目名をそのまま出力
            return (rowIndex + 1).ToString();
        }

        private string GetTrancedName(int rowIndex)
        {
            // ●項目名　明細.項目名をそのまま出力
            return this.exDataGridView1.GetStringValue(COLUMNNAME_COLNAME, rowIndex);
        }

        private string GetTrancedType(int rowIndex)
        {
            // ●属性    型をそのまま出力
            return ConstAttributeManager<TranceType>.GetValueSuggestConst(this.exDataGridView1.GetStringValue(COLUMNNAME_COLTYPE, rowIndex));
        }

        private string GetTrancedSize(int rowIndex)
        {
            // ●属性    明細.桁数をそのまま出力
            return this.exDataGridView1.GetStringValue(COLUMNNAME_COLSIZE, rowIndex);
        }


        private string GetTrancedFormat(int rowIndex)
        {
            // ●書式    条件：TextBoxの場合
            //   ReadOnlyの場合は"-"
            ReadOnly redOnly = ConstAttributeManager<ReadOnly>.GetEnumValue(this.exDataGridView1.GetStringValue(COLUMNNAME_COLREADONLY, rowIndex));

            TranceType trType = ConstAttributeManager<TranceType>.GetEnumValue(
                this.exDataGridView1.GetStringValue(COLUMNNAME_COLTYPE, rowIndex));


            if (trType != TranceType.imPostal && redOnly == ReadOnly.On)
            {
                return "-";
            }

            //   それ以外の場合は、明細.書式をそのまま出力(空の場合は"全ての文字")
            return this.exDataGridView1.GetStringValue(COLUMNNAME_COLFORMAT, rowIndex);
        }

        private string GetTrancedInOut(int rowIndex)
        {
            //  ●入力    条件：TextBoxの場合
            //               ReadOnlyであれば"出"
            TranceType trType = ConstAttributeManager<TranceType>.GetEnumValue(
                this.exDataGridView1.GetStringValue(COLUMNNAME_COLTYPE, rowIndex));
            ReadOnly redOnly = ConstAttributeManager<ReadOnly>.GetEnumValue(
                this.exDataGridView1.GetStringValue(COLUMNNAME_COLREADONLY, rowIndex));

            string retValue = "-";

            switch (trType)
            {
                case TranceType.ImText:
                case TranceType.ImNumber:
                case TranceType.ImDate:
                

                    if (redOnly == ReadOnly.On)
                    {
                        retValue = "出";
                    }
                    else
                    {
                        retValue = "入出";
                    }

                    break;

                case TranceType.imPostal:

                    retValue = "入出";
                    break;

                case TranceType.OptionButton:
                case TranceType.ComboBox:

                    //            条件：OptionButton, ComboBoxの場合
                    //               "入出"
                    retValue = "入出";
                    break;

                case TranceType.Label:

                    //            条件：Labelの場合
                    //               "(タイトル)"の場合"-"
                    //                それ以外は"出"
                    if (this.exDataGridView1.GetStringValue(COLUMNNAME_COLNAME, rowIndex).IndexOf("(タイトル)") < 0)
                    {
                        retValue = "出";
                    }
                    break;

                default:

                    break;

            }
            
            return retValue;

        }

        private string GetTrancedIme(int rowIndex)
        {
              // ●IME     TextBoxのIMEの値によって変換したものを出力
              // OFF,ON,規定値
            string imeStr = ConstAttributeManager<ImeMode>.GetValueSuggestConst(this.exDataGridView1.GetStringValue(COLUMNNAME_COLIMEMODE, rowIndex));

            ReadOnly redOnly = ConstAttributeManager<ReadOnly>.GetEnumValue(
                this.exDataGridView1.GetStringValue(COLUMNNAME_COLREADONLY, rowIndex));

            if (redOnly == ReadOnly.On || string.IsNullOrEmpty(imeStr))
            {
                return "-";
            }

            return imeStr;
        }

        private string GetTrancedRemark(int rowIndex)
        {
            // ●備考    Labelの場合かつ"(タイトル)"の場合
            string name = this.exDataGridView1.GetStringValue(COLUMNNAME_COLNAME, rowIndex);

            if (name.IndexOf("(タイトル)") >= 0)
            {
                //   " + 項目名から"(タイトル)"を削除した文字列 + " を出力
                return "\"" + name.Replace("(タイトル)", "") + "\"";
            }

            TranceType trType = ConstAttributeManager<TranceType>.GetEnumValue(
                this.exDataGridView1.GetStringValue(COLUMNNAME_COLTYPE, rowIndex));
            ReadOnly redOnly = ConstAttributeManager<ReadOnly>.GetEnumValue(
                this.exDataGridView1.GetStringValue(COLUMNNAME_COLREADONLY, rowIndex));

            string retValue = string.Empty;

            switch (trType)
            {
                case TranceType.ImText:
                case TranceType.ImNumber:
                case TranceType.ImDate:
                case TranceType.imPostal:

                    retValue = this.exDataGridView1.GetStringValue(COLUMNNAME_COLNAME, rowIndex);
                    retValue += "を表示" + (redOnly == ReadOnly.Off ? "、入力" : "") + "する";

                    break;

                case TranceType.ComboBox:

                    //            条件：OptionButton, ComboBoxの場合
                    //               "入出"
                    retValue = this.exDataGridView1.GetStringValue(COLUMNNAME_COLNAME, rowIndex) + "を選択、表示する";
                    break;

                default:

                    break;

            }

            return retValue;
        }        

        #endregion

        #region GetCopyCrudToClipBored

        private void GetCopyCrudToClipBored(string[] xmlFilenNameArray)
        {
            
            Dictionary<string, DBCRUD> dicCrud = new Dictionary<string, DBCRUD>();
            string botsuStr = string.Empty;

            foreach (string xmlFileName in xmlFilenNameArray)
            {
                Dictionary<string, Memo> dic = this.GetMemoDictionalyFromXmlFile(xmlFileName);

                foreach (Memo memo in dic.Values)
                {
                    foreach (string dbNameValue in memo.GetDBName().Split(new string[] { "\r\n" }, StringSplitOptions.None))
                    {
                        if(string.IsNullOrEmpty(dbNameValue.Trim()))
                        {
                            continue;
                        }

                        string[] dbNameArray = dbNameValue.Split(' ');

                        if (dbNameArray == null || dbNameArray.Length <= 1)
                        {
                            string str = memo.GetDBName();

                            if (!string.IsNullOrEmpty(str))
                            {
                                botsuStr += str + "\n";
                            }

                            continue;
                        }

                        string dbName = dbNameArray[0];
                        string dbCrud = dbNameArray[1];

                        DBCRUD crud = new DBCRUD(dbName, dbCrud);

                        if (dicCrud.ContainsKey(dbName))
                        {
                            dicCrud[dbName].MargeCrud(crud);
                        }
                        else
                        {
                            dicCrud.Add(dbName, crud);
                        }
                    }
                }

            }

            string clipBoredValue = string.Empty;
            int number = 1;

            foreach (DBCRUD crud in dicCrud.Values)
            {
                clipBoredValue += this.GetCrudString(crud, number);
                number++;
            }

            if (string.IsNullOrEmpty(clipBoredValue))
            {
                MessageBox.Show("CRUD情報は見つかりませんでした。");
                return;
            }

            Clipboard.SetText(clipBoredValue);

            if (!string.IsNullOrEmpty(botsuStr))
            {
                MessageBox.Show("以下の項目は入力情報が不足していたためCRUDが出力されませんでした。\n\n" + botsuStr);
            }
        }

        #endregion

        #region GetCopyCrudToClipBored

        private void GetCopyMemoToClipBored(string[] xmlFilenNameArray)
        {
            string clipBoredValue = string.Empty;
            Dictionary<string, DBCRUD> dicCrud = new Dictionary<string, DBCRUD>();

            foreach (string xmlFileName in xmlFilenNameArray)
            {
                Dictionary<string, Memo> dic = this.GetMemoDictionalyFromXmlFile(xmlFileName);

                foreach (Memo memo in dic.Values)
                {
                    clipBoredValue += memo.GetMemo() + "\n";
                }

            }
           
            Clipboard.SetText(clipBoredValue);
        }

        #endregion

        private void exBtnCopyOrino_Click(object sender, EventArgs e)
        {
            SaveOriNo();
        }

        private string GetCrudString(DBCRUD crud, int number)
        {
            string clipBoredValueFormat = "[0]		[1]											[2]							[C]	[R]	[U]	[D]";

            clipBoredValueFormat = clipBoredValueFormat.Replace("[0]", number.ToString());
            clipBoredValueFormat = clipBoredValueFormat.Replace("[1]", crud.GetDbName());
            clipBoredValueFormat = clipBoredValueFormat.Replace("[2]", "");
            clipBoredValueFormat = clipBoredValueFormat.Replace("[C]", crud.GetIsDBCrudC() ? "○" : "");
            clipBoredValueFormat = clipBoredValueFormat.Replace("[R]", crud.GetIsDBCrudR() ? "○" : "");
            clipBoredValueFormat = clipBoredValueFormat.Replace("[U]", crud.GetIsDBCrudU() ? "○" : "");
            clipBoredValueFormat = clipBoredValueFormat.Replace("[D]", crud.GetIsDBCrudD() ? "○" : "");

            return clipBoredValueFormat + "\n";
        }

        private void exButton4_Click(object sender, EventArgs e)
        {
            this.GetCopyCrudToClipBored(new string[] { this.getXmlFileName() });
        }

        private void exButton5_Click(object sender, EventArgs e)
        {
            string fileNames = DialogUtil.ShowFileDialogFileName(
                true, 
                "Visual Basic Form (.frm)|*.frm|Visual Basic Script (.bas)|*.bas",
                1,
                ',');

            this.GetCopyCrudToClipBored(fileNames.Split(','));
        }

        private void exButton6_Click(object sender, EventArgs e)
        {
            string fileNames = DialogUtil.ShowFileDialogFileName(
                true,
                "Visual Basic Form (.frm)|*.frm|Visual Basic Script (.bas)|*.bas",
                1,
                ',');

            this.GetCopyMemoToClipBored(fileNames.Split(','));
        }
    }
}

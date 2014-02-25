using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;

using System.Windows.Forms;
using OyuLib.Xml;

namespace OyuLib.Windows.Forms.DataGridView
{
    /// <summary>
    /// DataGridView継承コントロール
    /// </summary>
    public partial class ExDataGridViewControl : System.Windows.Forms.DataGridView
    {
        #region const

        /// <summary>
        /// SEPARATOR COLUMN
        /// </summary>
        private const string SEPARATORCOL = "1q2w3e4r5t6y";

        /// <summary>
        /// SEPARATOR COLUMNVALUE
        /// </summary>
        private const string SEPARATORCOLVALUE = ",##$$%%&&";

        #endregion

        #region instance variable

        /// <summary>
        /// store the Info of the event that be adding the row
        /// </summary>
        private ExDataGridViewEventManager _exmanager = null;

        private List<string> _lstColumnNamesortAsNumber = null;

        /// <summary>
        /// provide to Admission Control For DataGridView
        /// </summary>
        private DataGridViewAdmissionControlGeneral _dgvControl = null;

        /// <summary>
        /// choose Either focus it or not to the readonly cell
        /// </summary>
        private bool _isSkipFocusReadOnlyCell = false;        

        #endregion

        #region Propaty

        /// <summary>
        /// Choise whether skip or not to focus ReadOnly Cell
        /// </summary>
        [Browsable(true)]
        [Description("Choise whether skip or not to focus ReadOnly Cell")]
        [Category("ControlAdmission")]
        public bool IsSkipFocusReadOnlyCell
        {
            get { return this._isSkipFocusReadOnlyCell; }
            set { _isSkipFocusReadOnlyCell = value; }
        }

        public string[] ColumnNamesortAsNumber
        {
            get{ return this._lstColumnNamesortAsNumber.ToArray(); }
            set{ this._lstColumnNamesortAsNumber = new List<string>(value); }
        }

        #endregion

        #region constructer

        /// <summary>
        /// constructer proc.
        /// </summary>
        public ExDataGridViewControl()
        {
            InitializeComponent();
            this.Init();
        }

        /// <summary>
        /// constructer proc.
        /// </summary>
        /// <param name="container"></param>
        public ExDataGridViewControl(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.Init();
        }

        #endregion

        #region Methods

        #region public

        #region Initialize Proc

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Init()
        {
            this._exmanager = new ExDataGridViewEventManager(this);
            this._dgvControl = new DataGridViewAdmissionControlGeneral(this);
            this._lstColumnNamesortAsNumber = new List<string>();
        }

        #endregion

        #region Add Event

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="method"></param>
        public void AddTempEvent<T>(string colName, EnumDGVEvent eventKind, ExDelegateClass.DelegateCellConClick<EventArgs> method)
            where T : ExDataGridViewEventValue, new()
        {
            this._exmanager.AddTempEvent<T>(colName, eventKind, method);
        }

        #endregion

        #region GetCurrentIndex

        public int GetCurrentRowIndex()
        {
            return this.CurrentCell.RowIndex;
        }

        public int GetCurrentColumnIndex()
        {
            return this.CurrentCell.ColumnIndex;
        }

        #endregion

        #region SetEvent

        public void SetEventFromTemp()
        {
            this._exmanager.AddAllEventToDgv();
        }

        #endregion

        #region GetStringValue

        public string GetStringValue(string columnName, int rowIndex)
        {
            object value = this[columnName, rowIndex].Value;

            if(value == null)
            {
                return string.Empty;
            }

            return value.ToString();
        }

        #endregion

        #region ClearValuesOfCol

        public void ClearValuesOfCol(string colName)
        {
            foreach (DataGridViewRow row in this.Rows)
            {
                row.Cells[colName].Value = string.Empty;
            }
        }

        #endregion

        #region Clear

        public void ClearValueOfRow(int rowIndex)
        {
            foreach (DataGridViewCell cell in this.Rows[rowIndex].Cells)
            {
                cell.Value = null;
            }
            
        }

        public void RemoveBlankRows()
        {
            bool isRemove = true;

            while (isRemove)
            {
                isRemove = false;

                foreach (DataGridViewRow row in this.Rows)
                {
                    if (this.GetIsBlank(row.Index))
                    {
                        this.Rows.Remove(row);
                        isRemove = true;
                    }
                }
            }
        }

        #endregion

        #region Check

        #region isBlank

        public bool GetIsBlank(int rowIndex)
        {
            foreach (DataGridViewCell cell in this.Rows[rowIndex].Cells)
            {
                if (cell.Value != null)
                {
                    if (!string.IsNullOrEmpty(cell.Value.ToString().Trim()))
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        #endregion

        #endregion

        #region Search

        public DataGridViewRow[] GetRowsHasSameValue(string columnName, object value)
        {
            List<DataGridViewRow> retList = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in this.Rows)
            {
                object obj = row.Cells[columnName].Value;

                if(obj == null)
                {
                    continue;
                }

                if (obj.ToString().Equals(value.ToString()))
                {
                    retList.Add(row);
                }
            }

            return retList.ToArray();
        }

        public DataGridViewRow[] GetRowsLikeValues(string columnName, object value)
        {
            List<DataGridViewRow> retList = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in this.Rows)
            {
                object obj = row.Cells[columnName].Value;

                if (obj == null)
                {
                    continue;
                }

                if (obj.ToString().IndexOf(value.ToString()) > 0)
                {
                    retList.Add(row);
                }
            }

            return retList.ToArray();
        }

        #endregion

        #region Xml

        #region Store

        /// <summary>
        /// store data that was inputted in DataGridView to xml file
        /// </summary>
        /// <param name="xmlFileNameWithOutExtension"></param>
        /// <param name="colNameArray"></param>
        public void StoreDatatoXml(string xmlFileNameWithOutExtension, string keyColName, params string[] colNameArray)
        {
            var xmlValueList = new List<XmlValueTypeKeyAndValue>();

            colNameArray = GetColNameArray(colNameArray);

            for (int rowIndex = 0; rowIndex < this.Rows.Count; rowIndex++)
            {
                xmlValueList.Add(CreateXmlValue(rowIndex, keyColName, colNameArray));
            }

            XmlSerializerManager.WriteXmlFile<XmlValueTypeKeyAndValue>(xmlFileNameWithOutExtension, xmlValueList.ToArray());
        }

        #endregion

        #region GetCellsArray

        public string[][] GetCellsValueArray(params string[] paramColName)
        {
            string[] colNameArray = GetColNameArray(paramColName);
            var retList = new List<string[]>();

            foreach (DataGridViewRow row in this.Rows)
            {
                var cellValues = new List<string>();

                foreach (var colName in colNameArray)
                {
                    cellValues.Add(this.GetStringValue(colName, row.Index));
                }    

                retList.Add(cellValues.ToArray());
            }

            return retList.ToArray();
        }

        #endregion

        #region Read

        /// <summary>
        /// read data that stored as xml data
        /// </summary>
        /// <param name="xmlFileNameWithOutExtension"></param>
        /// <param name="paramColName"></param>
        public void ReadDatatoXmlByKey(string xmlFileNameWithOutExtension, string keyColName, params string[] paramColName)
        {
            Dictionary<string, string> dic = XmlSerializerManager.ReadXmlFileDictionaly(xmlFileNameWithOutExtension);

            string[] colNameArray = GetColNameArray(paramColName);

            var keyHash = new Hashtable();

            for(int rowIndex = 0; rowIndex < this.Rows.Count; rowIndex++)
            {
                string key = this.GetStringValue(keyColName, rowIndex);

                keyHash.Add(key, rowIndex); 
            }

            foreach (KeyValuePair<string, string> keyValue in dic)
            {
                Dictionary<string, string> dicValue = this.GetXmlValueDicFromXmlValue(keyValue.Value);

                foreach (KeyValuePair<string, string> dicValueDic in dicValue)
                {
                    TranceDataGridViewCellValue tCell = new TranceDataGridViewCellValue(this[dicValueDic.Key, int.Parse(keyHash[keyValue.Key].ToString())]);
                    tCell.SetValue(dicValueDic.Value);
                }
            }
        }

        /// <summary>
        /// read data that stored as xml data
        /// </summary>
        /// <param name="xmlFileNameWithOutExtension"></param>
        /// <param name="paramColName"></param>
        public void ReadDatatoXml(string xmlFileNameWithOutExtension, params string[] paramColName)
        {
            this.Rows.Clear();

            Dictionary<string, string> dic = XmlSerializerManager.ReadXmlFileDictionaly(xmlFileNameWithOutExtension);

            string[] colNameArray = GetColNameArray(paramColName);

            foreach (KeyValuePair<string, string> keyValue in dic)
            {
                var rowIndex = this.Rows.Add();

                Dictionary<string, string> dicValue 
                    = this.GetXmlValueDicFromXmlValue(keyValue.Value);

                foreach (KeyValuePair<string, string> dicValueDic in dicValue)
                {
                    TranceDataGridViewCellValue tCell = new TranceDataGridViewCellValue(this[dicValueDic.Key, rowIndex]);
                    tCell.SetValue(dicValueDic.Value);
                }
            }
        }

        #endregion

        #endregion

        #region SetNextNoToCell

        public void SetNoToCell(string colName)
        {
            int nextNo = this.GetNextNo(colName);

            for (int rowIndex = 0; rowIndex < this.Rows.Count; rowIndex++)
            {
                if (string.IsNullOrEmpty(this.GetStringValue(colName, rowIndex)))
                {
                    this[colName, rowIndex].Value = nextNo;
                    nextNo++;
                }
            }
        }

        #region GetNextNo

        public int GetNextNo(string colName)
        {
            int MaxNo = 0;

            for (int rowIndex = 0; rowIndex < this.Rows.Count; rowIndex++)
            {
                string value = this.GetStringValue(colName, rowIndex);

                if(!string.IsNullOrEmpty(value))
                {
                    int intValue = int.Parse(value);

                    if ((intValue > MaxNo))
                    {
                        MaxNo = intValue;
                    }
                }
            }

            return MaxNo + 1;
        }

        #endregion

        #endregion

        #region private

        #region move focus

        /// <summary>
        /// Move Focus To Next Cell
        /// </summary>
        private void MoveFocus()
        {
            this._dgvControl.MoveCurrentCell(!(Control.ModifierKeys == Keys.Shift));
        }

        #endregion

        #region Delete SelectedCell value

        private void DeleteSelectedCellValue()
        {
            foreach (DataGridViewCell cell in this.SelectedCells)
            {
                if (!cell.ReadOnly)
                {
                    cell.Value = "";
                }
            }
        }

        #endregion

        #region PasteTextFromClipBored

        private List<List<string>> CreatePasteTextFromClipbored()
        {
            string text = Clipboard.GetText();

            List<List<string>> textList = new List<List<string>>();


            foreach (string textLine in text.Split(new string[] { "\r\n" }, StringSplitOptions.None))
            {
                List<string> lineValue = new List<string>();

                foreach (string textValue in textLine.Split('\t'))
                {
                    lineValue.Add(textValue);
                }

                textList.Add(lineValue);
            }

            return textList;
        }

        private string[][] GetTransposedMatrixArray(List<List<string>> textList)
        {
            List<string> temp = new List<string>();
            for (int index = 0; index < textList.Count; index++)
            {
                temp.Add("");
            }

            int countaa = textList[0].Count;

            var textArray = new string[textList[0].Count][];

            for (int i = 0; i < textList[0].Count; i++)
            {
                textArray[i] = temp.ToArray();
            }

            for (int i = 0; i < textList.Count; i++)
            {
                for (int j = 0; j < textList[i].Count; j++)
                {
                    textArray[j][i] = textList[i][j];
                }
            }

            return textArray;
        }


        private void PasteTextFromClipBored()
        {
            List<List<string>> textList = CreatePasteTextFromClipbored();
            string[][] textArray = this.GetTransposedMatrixArray(textList);
            
            int columnIndex = this.GetCurrentColumnIndex();

            foreach (string[] textLine in textArray)
            {
                while (this.Columns.Count > columnIndex)
                {
                    DataGridViewColumn col = this.Columns[columnIndex];

                    if (col.ReadOnly || !col.CellType.Equals(typeof(DataGridViewTextBoxCell)))
                    {
                        columnIndex++;
                        continue;
                    }

                    int rowIndex = this.GetCurrentRowIndex();

                    foreach (string textValue in textLine)
                    {
                        if (rowIndex >= this.Rows.Count)
                        {
                            break;
                        }

                        this[col.Index, rowIndex].Value = textValue;
                        rowIndex++;
                    }

                    columnIndex++;
                    break;
                }
            }
        }

        #endregion

        #region GetIsNumberColumn

        private bool GetIsNumberColumn(int columnIndex)
        {
             foreach(string columnName in this.ColumnNamesortAsNumber)
             {
                 if(this.Columns[columnIndex].Name.Equals(columnName))
                 {
                     return true;
                 }
             }

            return false;
        }


        #endregion

        #region GetCastNumber

        private int GetCastNumber(object obj)
        {
            if (obj == null)
            {
                return 99999;
            }

            string objToStr = obj.ToString();

            if (objToStr.Trim().Equals(string.Empty))
            {
                return 99999;
            }

            int intToStr = -2;

            int.TryParse(objToStr, out intToStr);

            return intToStr;
        }

        #endregion

        #region CreateXmlValue

        private XmlValueTypeKeyAndValue CreateXmlValue(int rowIndex, string keyColName, params string[] colNameArray)
        {
            List<string> valuelist = new List<string>();

            foreach (string colName in colNameArray)
            {
                TranceDataGridViewCellValue tCell = new TranceDataGridViewCellValue(this[colName, rowIndex]);
                valuelist.Add(colName + SEPARATORCOL + tCell.GetTrancedValue());
            }

            return new XmlValueTypeKeyAndValue(this.GetStringValue(keyColName, rowIndex), string.Join(SEPARATORCOLVALUE, valuelist.ToArray()));
        }

        #endregion

        #region GetStringFromXmlValue

        private Dictionary<string, string> GetXmlValueDicFromXmlValue(string value)
        {
            Dictionary<string, string> retDic = new Dictionary<string, string>();

            string[] valueArray = value.Split(new string[] { SEPARATORCOLVALUE }, StringSplitOptions.None);

            foreach (string colValue in valueArray)
            {
                string[] colNameValue = colValue.Split(new string[] { SEPARATORCOL }, StringSplitOptions.None);

                if (colNameValue.Length <= 1)
                {
                    retDic.Add(colNameValue[0], string.Empty);
                }
                else
                {
                    retDic.Add(colNameValue[0], colNameValue[1]);
                }

                
            }

            return retDic;
        }

        #endregion

        #endregion

        #region event

        private void ExDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        /// <summary>
        /// CellClick Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this._exmanager.ExecProc(e.ColumnIndex, EnumDGVEvent.eveCellClick, sender, e);
        }

        #endregion

        #region Override(Event)

        protected override void OnSortCompare(DataGridViewSortCompareEventArgs e)
        {
            if(this.GetIsNumberColumn(e.Column.Index))
            {
                e.SortResult = this.GetCastNumber(e.CellValue1) - this.GetCastNumber(e.CellValue2);
                e.Handled = true;
            }
        }

        protected override void  OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
 	        base.OnEditingControlShowing(e);
        
            this.EditingControl.PreviewKeyDown -= new PreviewKeyDownEventHandler(this.dataGridViewTextBox_PreviewKeyDown);
            this.EditingControl.PreviewKeyDown += new PreviewKeyDownEventHandler(this.dataGridViewTextBox_PreviewKeyDown);
   
        }

        //DataGridViewに表示されているテキストボックスのKeyPressイベントハンドラ
        private void dataGridViewTextBox_PreviewKeyDown(object sender,
            PreviewKeyDownEventArgs e)
        {
            // pushed the Deletekey, Remove text From text of selected cell
            if (KeyUtil.IsPushThisKey(e.KeyData, Keys.Delete))
            {
                // delete cell value that was selected
                this.DeleteSelectedCellValue();
            }

            // pushed The CtrlKey and Vkey, 
            if (KeyUtil.IsPushThisKey(e.KeyData, Keys.V, true, false, false))
            {
                this.PasteTextFromClipBored();
            }
        }

        #endregion

        #region OverRide

        #region ProcessKey

        [System.Security.Permissions.UIPermission(
        System.Security.Permissions.SecurityAction.LinkDemand,
        Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.Rows.Count <= 0)
            {
                return true;
            }

            //Enterキーが押された時は、Tabキーが押されたようにする
            if (KeyUtil.IsPushEnterKey(keyData))
            {
                this.MoveFocus();
                return true;
            }

            // Case to push Ctrl + C key
            if (KeyUtil.IsPushThisKey(keyData, Keys.C, true, false, false))
            {
                // copy to data to ClipBoard from Current Cell of DataGridView
               // this._dgvControl.CopySelectCellsDataClip();
            }

            return base.ProcessDialogKey(keyData);
        }

        [System.Security.Permissions.SecurityPermission(
        System.Security.Permissions.SecurityAction.LinkDemand,
        Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (this.Rows.Count <= 0)
            {
                return true;
            }

            // pushed the EnterKey, move focus The next control
            if (KeyUtil.IsPushEnterKey(e))
            {
                // move focus The next control
                this.MoveFocus();
                return true;
            }

            return base.ProcessDataGridViewKey(e);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand,
         Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Ctrl+Vを無効にする
            if ((keyData & Keys.Control) == Keys.Control &&
                (keyData & Keys.KeyCode) == Keys.V)
                return true;
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #endregion

        #endregion

        #region Private

        private string[] GetColNameArray(params string[] paramColName)
        {
            var retColName = new List<string>();

            if (paramColName == null || paramColName.Length <= 0)
            {
                foreach (DataGridViewColumn col in this.Columns)
                {
                    retColName.Add(col.Name);
                }                
            }
            else
            {
                return paramColName;
            }

            return retColName.ToArray();
        }

        #endregion

        #endregion
    }
}

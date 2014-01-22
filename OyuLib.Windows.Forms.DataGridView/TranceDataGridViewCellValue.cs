using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OyuLib.Windows.Forms.DataGridView
{
    public class TranceDataGridViewCellValue
    {
        #region InstanceVal

        private DataGridViewCell _cell = null;

        #endregion

        #region Property

        public DataGridViewCell Cell
        {
            get { return this._cell; }
            set { this._cell = value; }
        }

        #endregion

        #region Constructor

        public TranceDataGridViewCellValue(DataGridViewCell cell)
        {
            this._cell = cell;
        }

        public object GetTrancedValue()
        {
            if (this.Cell is DataGridViewTextBoxCell)
            {
                return this.Cell.Value;
            }
            else if (this.Cell is DataGridViewCheckBoxCell)
            {
                return this.GetDataGridViewCheckBoxCellValue(this.Cell);
            }

            return null;
        }

        public void SetValue(object value)
        {
            if (this.Cell is DataGridViewTextBoxCell)
            {
                this.Cell.Value = value;
            }
            else if (this.Cell is DataGridViewCheckBoxCell)
            {
                this.SetValueDataGridViewCheckBox(value);
            }
        }

        private object GetDataGridViewCheckBoxCellValue(DataGridViewCell cell)
        {
            if (cell.Value == null)
            {
                return false;
            }

            return (bool) cell.Value;
        }

        private void SetValueDataGridViewCheckBox(object value)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                this.Cell.Value = false;
                return;
            }


            this.Cell.Value = bool.Parse(value.ToString().ToLower());
        }

        #endregion

    }
}

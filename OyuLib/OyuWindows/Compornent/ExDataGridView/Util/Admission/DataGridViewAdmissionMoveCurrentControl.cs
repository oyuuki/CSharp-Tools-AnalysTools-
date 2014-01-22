using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace OyuLib.OyuWindows.Compornent.ExDataGridView.Util.Admission
{
    class DataGridViewAdmissionMoveCurrentControl
    {

        #region Instance

        private ExDataGridViewControl _dgv = null;

        #endregion

        #region constractor

        /// <summary>
        /// Constractor
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        public DataGridViewAdmissionMoveCurrentControl(ExDataGridViewControl dgv)
        {
            this._dgv = dgv;
        }

        #endregion

        #region MoveMethod

        /// <summary>
        /// Move focus to Next Cell
        /// (likely "Tab")
        /// </summary>
        public void MoveNextCell()
        {
            // Get And Store ActiveCell
            DataGridViewCell activeCell = this._dgv.CurrentCell;

            int rowIndex = activeCell.RowIndex;
            int columnIndex = activeCell.ColumnIndex + 1;

            while (true)
            {
                for (int count = columnIndex; count < this._dgv.ColumnCount; count++)
                {
                    if (this.IsExistCell(count))
                    {
                        if (this.MoveAndEditCell(count, rowIndex))
                        {
                            return;
                        }
                    }
                }

                columnIndex = 0;
                rowIndex++;

                if (_dgv.RowCount <= rowIndex)
                {
                    rowIndex = 0;
                }

            }
        }

        #region Move Cell

        /// <summary>
        /// Move focus to Prev Cell
        /// (likely "Shift Tab")
        /// </summary>
        public void MovePrevCell()
        {
            // Get And Store ActiveCell
            DataGridViewCell activeCell = this._dgv.CurrentCell;

            int rowIndex = activeCell.RowIndex;
            int columnIndex = activeCell.ColumnIndex - 1;

            while (true)
            {
                for (int count = columnIndex; count >= 0; count--)
                {
                    if (this.IsExistCell(count))
                    {
                        if (this.MoveAndEditCell(count, rowIndex))
                        {
                            return;
                        }
                    }
                }

                columnIndex = this._dgv.ColumnCount - 1;
                rowIndex--;

                if (rowIndex < 0)
                {
                    rowIndex = this._dgv.RowCount - 1;
                }
            }
        }

        #endregion

        /// <summary>
        /// Move to Cell And Begin Edit Cell
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="rowIndex"></param>
        private bool MoveAndEditCell(int columnIndex, int rowIndex)
        {
            if (this._dgv.IsSkipFocusReadOnlyCell)
            {
                if (!this._dgv[columnIndex, rowIndex].ReadOnly)
                {
                    this.MoveCell(columnIndex, rowIndex);
                    this._dgv.BeginEdit(true);
                    return true;
                }
            }
            else
            {
                this.MoveCell(columnIndex, rowIndex);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Move to Cell 
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="rowIndex"></param>
        private void MoveCell(int columnIndex, int rowIndex)
        {
            this._dgv.CurrentCell = this._dgv[columnIndex, rowIndex];
        }

        /// <summary>
        /// jugde That Exist or not left Cell
        /// </summary>
        /// <param name="startColumnIndex">start columnindex</param>
        /// <returns></returns>
        private bool IsExistCell(int startColumnIndex)
        {
            if (this._dgv.ColumnCount > startColumnIndex)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}

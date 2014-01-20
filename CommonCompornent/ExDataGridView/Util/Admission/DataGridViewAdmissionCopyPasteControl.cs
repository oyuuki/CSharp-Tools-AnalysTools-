using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using CommonCompornent.ExDataGridView.Cell;
using CommonCompornent.Logic.ExType;

namespace CommonCompornent.ExDataGridView.Util.Admission
{
    class DataGridViewAdmissionCopyPasteControl
    {
        #region Instance

        private ExDataGridViewControl _dgv = null;

        #endregion

        #region constractor

        /// <summary>
        /// Constractor
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        public DataGridViewAdmissionCopyPasteControl(ExDataGridViewControl dgv)
        {
            this._dgv = dgv;
        }

        #endregion

        #region copy text data to clipbored

        /// <summary>
        /// Move focus to Next Cell
        /// (likely "Tab")
        /// </summary>
        public string GetTextData()
        {
            DataGridViewSelectedCellCollection cellCol = this._dgv.SelectedCells;

            StringBuilder strBr = new StringBuilder();

            // get to text data with tab-delimited from cell
            foreach (DataGridViewCell cell in cellCol)
            {
                strBr.Append(this.GetTextValue(cell));
                strBr.Append('\t');
            }

            return strBr.ToString();
        }


        #region get text data

        /// <summary>
        /// get text data from cell value
        /// </summary>
        /// <returns></returns>
        private string GetTextValue(DataGridViewCell cell)
        {
            TypeUtil tutil = new TypeUtil(cell);
            CellValue cValue = new CellValue(cell);

            return cValue.GetText();
        }

        #endregion

        private bool IsTypeof(Object obj, Type type)
        {
            return obj.GetType() == type;
        }

        #endregion
    }
}

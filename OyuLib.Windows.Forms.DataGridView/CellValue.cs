using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace OyuLib.Windows.Forms.DataGridView
{
    /// <summary>
    /// the class that  suggest value of CellValue
    /// </summary>
    class CellValue
    {
        #region Instance

        /// <summary>
        /// Stored DataGridViewCell
        /// </summary>
        private DataGridViewCell _cell = null;

        #endregion

        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="cell"></param>
        public CellValue(DataGridViewCell cell)
        {
            this._cell = cell;
        }

        #endregion

        #region GetText

        public string GetText()
        {
            object val = this._cell.Value;

            if (val == null)
            {
                return "";
            }

            return val.ToString();
        }

        #endregion
    }
}

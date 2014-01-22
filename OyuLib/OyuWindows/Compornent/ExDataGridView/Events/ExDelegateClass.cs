using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OyuLib.OyuWindows.Compornent.ExDataGridView.Events
{
    /// <summary>
    /// class is provide Event Delegate For ExDataGridView.
    /// </summary>
    public static class ExDelegateClass
    {
        #region delegate

        /// <summary>
        /// CellContentsClickのイベントデリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void DelegateCellConClick<T>(object sender, T e);

        #endregion
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OyuLib.Windows.Forms.DataGridView
{
    /// <summary>
    /// For Cell EventTemplate
    /// </summary>
    public class ExDataGridViewCellEventValue : ExDataGridViewEventValue
    {
        public ExDataGridViewCellEventValue()
        {

        }

        public ExDataGridViewCellEventValue(
            string compornentId,
            EnumDGVEvent compornentType,
            ExDelegateClass.DelegateCellConClick<EventArgs> del)
            : base(compornentId, compornentType, del)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OyuLib.OyuWindows.Compornent.ExButton
{
    public partial class ExButton : Button
    {
        #region Constractor

        public ExButton()
        {
            InitializeComponent();
        }

        public ExButton(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        #endregion

        #region method


        #endregion
    }
}

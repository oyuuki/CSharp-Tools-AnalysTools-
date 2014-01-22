using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OyuLib.OyuWindows.Interface
{
    public partial class ExTextBox : TextBox, IValidateInputData
    {
        #region constructor

        public ExTextBox()
        {
            InitializeComponent();
        }

        public ExTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region method

        public string GetTrimedText()
        {
            return this.Text.Trim();
        }

        #endregion

        #region override

        #region event

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            
            // Case to push Ctrl + A key
            if (KeyUtil.IsPushThisKey(e.KeyData, Keys.A, true, false, false))
            {
                // copy to data to ClipBoard from Current Cell of DataGridView
                this.SelectAll();
            }
        }

        #endregion

        #region implement an interface

        public bool IsValidValue()
        {
            return !string.IsNullOrEmpty(this.GetTrimedText());
        }

        #endregion

        #endregion
    }
}

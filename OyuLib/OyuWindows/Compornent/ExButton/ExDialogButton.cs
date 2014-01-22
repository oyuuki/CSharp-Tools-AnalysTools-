using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace OyuLib.OyuWindows.Compornent.ExButton
{
    public abstract partial class ExDialogButton : ExButton
    {
        #region Instance

        protected TextBox _inter_test;

        #endregion

        #region conctractor

        public ExDialogButton()
        {
            InitializeComponent();
        }

        public ExDialogButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region propaty

        /// <summary>
        /// propaty of inter_test
        /// </summary>
        [Browsable(true)]
        [Description("Choise textbox that is setting text from return Value of show dialog value ")]
        [Category("ControlAdmission")]
        public TextBox Inter_test
        {
            get{ return this._inter_test; }
            set { this._inter_test = value; }
        }


        #endregion

        #region Method

        #region override(Event)

        /// <summary>
        /// override(event):OnClick
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            this.SetTextFromDialog();
        }


        #endregion

        #region Fited

        /// <summary>
        /// Set to text to TextBox from Dialog
        /// </summary>
        public void SetTextFromDialog()
        {
            this.Inter_test.Text = this.GetTextFromDialog();
        }

        #endregion

        #region Nofited

        public abstract string GetTextFromDialog();

        #endregion

        #endregion
    }
}

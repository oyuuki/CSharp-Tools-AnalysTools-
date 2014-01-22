using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OyuLib.OyuWindows.Compornent.ExButton
{
    public partial class ExVBFileDialogButton : ExFileDialogButton
    {
        #region instance

        private bool _isMultiple = false;

        #endregion

        #region Propaty

        /// <summary>
        /// IsMultiple Propaty
        /// </summary>
        public bool IsMultiple
        {
            get { return this._isMultiple; }
            set { this._isMultiple = value; }

        }

        #endregion


        #region constractor

        public ExVBFileDialogButton()
        {
            InitializeComponent();
        }

        public ExVBFileDialogButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion  

        #region method

        #region Override

        #region GetFilter

        protected override string GetFileter()
        {
            return "Visual Basic Form (.frm)|*.frm|Visual Basic Script (.bas)|*.bas";
        }

        #endregion

        #endregion

        #region GetIsMultiple

        protected override bool GetIsMultiple()
        {
            return this.IsMultiple;
        }

        #endregion

        #endregion

    }
}

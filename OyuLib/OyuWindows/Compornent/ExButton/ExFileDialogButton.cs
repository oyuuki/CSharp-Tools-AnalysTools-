using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using OyuLib.OyuWindows.Interface.Logic;


namespace OyuLib.OyuWindows.Interface.ExButton
{
    public abstract partial class ExFileDialogButton : ExDialogButton
    {
        #region constractor

        public ExFileDialogButton()
        {
            InitializeComponent();
        }

        public ExFileDialogButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region method

        #region override

        /// <summary>
        /// Override From Abstruct class: GetTextFromDialog
        /// </summary>
        /// <returns></returns>
        public override string GetTextFromDialog()
        {
            return DialogUtil.ShowFileDialog(this.GetIsMultiple(), this.GetFileter(), this.GetFileterIndex(), this.GetFileSeparator());
        }

        #endregion

        #region abstruct

        #region GetFilter

        protected abstract string GetFileter();

        #endregion

        #region GetFilterIndex

        protected virtual int GetFileterIndex()
        {
            return 1;
        }

        #endregion

        #region GetisMultiple

        protected abstract bool GetIsMultiple();

        #endregion

        #region GetFileSeparator

        protected virtual char GetFileSeparator()
        {
            return ',';
        }

        #endregion

        #endregion

        #endregion

    }
}

﻿using System.ComponentModel;

namespace OyuLib.Windows.Forms
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

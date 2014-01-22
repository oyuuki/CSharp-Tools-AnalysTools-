using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using OyuLib.OyuWindows.Interface;
using OyuLib.OyuWindows.Interface.Logic;

namespace OyuLib.OyuWindows.Interface.ExButton
{
    public partial class ExFolderDialogButton : ExDialogButton
    {
        #region constractor

        public ExFolderDialogButton()
        {
            InitializeComponent();
        }

        public ExFolderDialogButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Override

        /// <summary>
        /// Override From Abstruct class: GetTextFromDialog
        /// </summary>
        /// <returns></returns>
        public override string GetTextFromDialog()
        {
            return DialogUtil.ShowFolderDialog();
        }

        #endregion
    }
}

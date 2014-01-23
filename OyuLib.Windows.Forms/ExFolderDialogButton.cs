using System.ComponentModel;

namespace OyuLib.Windows.Forms
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

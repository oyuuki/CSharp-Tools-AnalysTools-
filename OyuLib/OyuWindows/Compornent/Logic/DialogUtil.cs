using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace OyuLib.OyuWindows.Interface.Logic
{
    /// <summary>
    
    /// </summary>
    public static class DialogUtil
    {
        /// <summary>
        /// Show Folder Dialog,
        /// and return the text that is selected.
        /// </summary>
        /// <returns></returns>
        public static string ShowFolderDialog()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedPath;
                }
            }

            return "";
        }

        /// <summary>
        /// Show File Dialog,
        /// and return the text that is selected.
        /// </summary>
        /// <returns></returns>
        public static string ShowFileDialog(bool isMultiSelect, string filter, int filterIndex, char sepa)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = isMultiSelect;
                dialog.Filter = filter;
                dialog.FilterIndex = filterIndex;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return isMultiSelect ? string.Join(sepa.ToString(), dialog.FileNames) : dialog.FileName;
                }
            }

            return "";
        }

        /// <summary>
        /// Show File Dialog,
        /// and return the text that is selected.
        /// </summary>
        /// <returns></returns>
        public static string ShowFileDialogFileName(bool isMultiSelect, string filter, int filterIndex, char sepa)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = isMultiSelect;
                dialog.Filter = filter;
                dialog.FilterIndex = filterIndex;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return isMultiSelect ? string.Join(sepa.ToString(), dialog.SafeFileNames) : dialog.FileName;
                }
            }

            return "";
        }
    }
}

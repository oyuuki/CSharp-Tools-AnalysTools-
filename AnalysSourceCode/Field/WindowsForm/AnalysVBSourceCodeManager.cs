using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OyuLib.AnalysisSourceCode.Field.WindowsForm;

namespace OyuLib.AnalysisSourceCode.Field.WindowsForm
{
    /// <summary>
    /// Manage to analys VBCode
    /// </summary>
    public class AnalysisSourceCodeManager
    {
        #region Instance

        /// <summary>
        /// source text
        /// </summary>
        protected string _filePath = null;

        #endregion

        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="source"></param>
        public AnalysisSourceCodeManager(string filePath)
        {
            this._filePath = filePath;
        }

        #endregion

        #region Method

        /// <summary>
        /// Analys Code to item
        /// </summary>
        public WindowsFormFieldItem[] ExecAnalysToInputItemInfos()
        {
            if (File.Exists(this._filePath))
            {
                WinFrmFieldItemCodeGeneraterFromVBSource gene = WinFrmFieldItemCodeGeneraterFromSource.GetInstanceOfFile<WinFrmFieldItemCodeGeneraterFromVBSource>(File.ReadAllText(this._filePath));
                WindowsFormFieldItem[] array = gene.GetItemInfos<WinFrmFieldGeneraterFromVBSource>();
                return array;
            }

            return null;
        }

        #endregion
    }
}

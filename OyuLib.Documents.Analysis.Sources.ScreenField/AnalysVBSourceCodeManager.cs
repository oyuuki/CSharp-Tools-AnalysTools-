using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OyuLib.Documents.Analysis.Sources.ScreenField;

namespace OyuLib.Documents.Analysis.Sources.ScreenField
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
        public WinFrmField[] ExecAnalysToInputItemInfos()
        {
            if (File.Exists(this._filePath))
            {
                WinFrmFieldManagerVb6 gene = WinFrmFieldManager.GetInstanceOfFile<WinFrmFieldManagerVb6>(File.ReadAllText(this._filePath));
                WinFrmField[] array = gene.GetWinFrmFields<WinFrmFieldExtractorVB6>();
                return array;
            }

            return null;
        }

        #endregion
    }
}

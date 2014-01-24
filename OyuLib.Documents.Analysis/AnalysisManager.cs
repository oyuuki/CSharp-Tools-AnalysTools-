using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OyuLib.Documents.Analysis;

namespace OyuLib.Documents.Analysis
{
    /// <summary>
    /// Manage to analys VBCode
    /// </summary>
    public class AnalysisManager
    {
        #region Instance

        /// <summary>
        /// source text
        /// </summary>
        protected string _sourceText = null;

        #endregion

        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="source"></param>
        public AnalysisManager(string sourceText)
        {
            this._sourceText = sourceText;
        }

        #endregion

        #region Property

        public string SourceText
        {
            get { return this._sourceText; }
            set { this._sourceText = value;  }
        }

        #endregion

        #region Method

        /// <summary>
        /// Analys Code to item
        /// </summary>
        public WinFrmField[] GetAnalysisToWinFrmFields<T>()
            where T : WinFrmFieldManager, new()
        {
            var gene = TypeUtil.GetInstance<T>(new [] { this.SourceText });
            return gene.GetWinFrmFields<WinFrmFieldExtractorVB6>();
        }

        #endregion
    }
}

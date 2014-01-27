using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class AnalysisInputFieldItemManager : AnalysisManager
    {
        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        public AnalysisInputFieldItemManager()
            : base()
        {
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="sourceText"></param>
        public AnalysisInputFieldItemManager(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Method

        /// <summary>
        /// Analys Code to item
        /// </summary>
        public WinFrmField[] GetSourceAnalysisWinFrmFields<T>()
            where T : WinFrmFieldManager, new()
        {
            var gene = TypeUtil.GetInstance<T>(new [] { this.SourceText });
            return gene.GetWinFrmFields<WinFrmFieldExtractorVB6>();
        }

        #endregion
    }
}

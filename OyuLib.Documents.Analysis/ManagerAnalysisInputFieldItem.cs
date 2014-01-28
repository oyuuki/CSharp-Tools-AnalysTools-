using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class ManagerAnalysisInputFieldItem : ManagerAnalysis
    {
        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        public ManagerAnalysisInputFieldItem()
            : base()
        {
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="sourceText"></param>
        public ManagerAnalysisInputFieldItem(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Method

        /// <summary>
        /// Analys Code to item
        /// </summary>
        public WinFrmField[] GetSourceAnalysisWinFrmFields<T>()
            where T : ManagerWinFrmField, new()
        {
            var gene = TypeUtil.GetInstance<T>(new [] { this.SourceText });
            return gene.GetWinFrmFields<WinFrmFieldExtractorVB6>();
        }

        #endregion
    }
}

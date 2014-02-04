using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis.InputFields
{
    public class AnalysisInputFieldItemManager
    {
        #region Instance

        /// <summary>
        /// source text
        /// </summary>
        protected SourceDocument _source = null;

        #endregion

        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        public AnalysisInputFieldItemManager()
        {
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="source"></param>
        public AnalysisInputFieldItemManager(SourceDocument source)
        {
            this._source = source;
        }

        #endregion

        #region Property

        public SourceDocument Source
        {
            get { return this._source; }
            set { this._source = value; }
        }

        #endregion

        #region Method

        /// <summary>
        /// Analys Code to item
        /// </summary>
        public WinFrmInputField[] GetSourceAnalysisWinFrmFields<T>()
            where T : AnalysisWinFrmFieldManager, new()
        {
            var gene = TypeUtil.GetInstance<T>(new [] { this.Source.Text });
            return gene.GetWinFrmFields<WinFrmInputFieldExtractorVB6>();
        }

        #endregion
    }
}

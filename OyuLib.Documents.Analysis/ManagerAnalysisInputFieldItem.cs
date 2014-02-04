﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
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
        /// <param name="source"></param>
        public ManagerAnalysisInputFieldItem(SourceDocument source)
            : base(source)
        {
            
        }

        #endregion

        #region Method

        /// <summary>
        /// Analys Code to item
        /// </summary>
        public WinFrmInputField[] GetSourceAnalysisWinFrmFields<T>()
            where T : ManagerWinFrmField, new()
        {
            var gene = TypeUtil.GetInstance<T>(new [] { this.Source.Text });
            return gene.GetWinFrmFields<ExtractorWinFrmInputFieldVB6>();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Documents;

namespace OyuLib.Documents.Analysis
{
    public class AnalysisCodeManager<T> : AnalysisManager
        where T : Source, new()
    {
        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        public AnalysisCodeManager()
            : base()
        {
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="sourceText"></param>
        public AnalysisCodeManager(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Method

        /// <summary>
        /// Analys Code to item
        /// </summary>
        public CodeInfo[] GetVBDotNetSourceAnalysis()
        {
            var gene = TypeUtil.GetInstance<T>(new[] { this.SourceText });
            
            return null;
        }

        #endregion
    }
}

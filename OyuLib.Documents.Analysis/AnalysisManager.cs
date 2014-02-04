using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    /// <summary>
    /// Manage to analys VBCode
    /// </summary>
    public abstract class AnalysisManager
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
        /// </summary
        public AnalysisManager()
        {
            
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="source"></param>
        public AnalysisManager(SourceDocument source)
        {
            this._source = source;
        }

        #endregion

        #region Property

        public SourceDocument Source
        {
            get { return this._source; }
            set { this._source = value;  }
        }

        #endregion

        #region Method

        #endregion
    }
}

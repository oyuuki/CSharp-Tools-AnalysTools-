using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

using OyuLib.Documents;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class AnalysisCodeManager
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
        public AnalysisCodeManager()
            : base()
        {
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

        #region Public

        public SourceCodeblockInfo GetSourceCodeblockInfo()
        {
            return new SourceCodeblockInfo(this.GetSourceCodeAnalysis());
        }

        /// <summary>
        /// Analys Code to item
        /// </summary>
        public abstract SourceCodeInfo[] GetSourceCodeAnalysis();

        #endregion

        #endregion
    }
}

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
    public class ManagerAnalysis
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
        public ManagerAnalysis()
        {
            
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="sourceText"></param>
        public ManagerAnalysis(SourceDocument sourceText)
        {
            this._source = sourceText;
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

        #region 

        public SourceCodeInfo[] GetAnalysisCodeInfoFiltedType(SourceCodeInfo[] codeInfoArray, Type[] filterTypes)
        {
            if (filterTypes == null || filterTypes.Length <= 0)
            {
                return codeInfoArray;
            }

            var retList = new List<SourceCodeInfo>();

            foreach (var codeInfo in codeInfoArray)
            {
                if (TypeUtil.IsSameTypesObject(filterTypes, codeInfo))
                {
                    retList.Add(codeInfo);
                }
            }

            return retList.ToArray();
        }

        #endregion

        #endregion
    }
}

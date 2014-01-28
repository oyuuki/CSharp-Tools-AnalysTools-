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
    public class ManagerAnalysis
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
        /// </summary
        public ManagerAnalysis()
        {
            
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="sourceText"></param>
        public ManagerAnalysis(string sourceText)
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

        #region 

        public CodeInfo[] GetAnalysisCodeInfoFiltedType(CodeInfo[] codeInfoArray, Type[] filterTypes)
        {
            if (filterTypes == null || filterTypes.Length <= 0)
            {
                return codeInfoArray;
            }

            var retList = new List<CodeInfo>();

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

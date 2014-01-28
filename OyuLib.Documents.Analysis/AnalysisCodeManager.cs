using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Documents;

namespace OyuLib.Documents.Analysis
{
    public class AnalysisCodeManager : AnalysisManager
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
        public CodeInfo[] GetVBSourceCodeSourceAnalysis()
        {
            var source = new SourceVBDotNet(this.SourceText);
            var isInsiteMethod = false;
            var retList = new List<CodeInfo>();

            foreach (var code in source.GetCodes())
            {
                var ainfo = new AnalysisCodeInfoVBDotNet(code, isInsiteMethod);
                var codeInfo = ainfo.GetCodeInfo();
                retList.Add(codeInfo);

                if (codeInfo is CodeInfoEventMethod || codeInfo is CodeInfoMethod)
                {
                    isInsiteMethod = true;
                }
                else if (ArrayUtil.IsIncludeString(new string[] { "End Sub", "End Function" }, code.CodeString))
                {
                    isInsiteMethod = false;
                }
            }

            return retList.ToArray();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using OyuLib.IO;

namespace OyuLib.Documents.Sources.Analysis
{
    public class AnalysisSourceDocumentManagerVBDotNet : AnalysisSourceDocumentManager
    {
        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        public AnalysisSourceDocumentManagerVBDotNet()
            : base()
        {
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="sourcefilepath"></param>
        public AnalysisSourceDocumentManagerVBDotNet(string sourcefilepath)
            : this(sourcefilepath, CharSet.ShiftJis)
        {
            
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="sourcefilepath"></param>
        /// <param name="charactorSet"></param>
        public AnalysisSourceDocumentManagerVBDotNet(string sourcefilepath, CharSet charactorSet)
        {
            this.Sourcedocument =  new SourceDocumentVBDotNet(sourcefilepath, charactorSet);
            this.Init();
        }

        #endregion

        #region Method

        #region Public

        /// <summary>
        /// Analys Code to item
        /// </summary>
        protected override SourceCodeInfo[] GetSourceCodeAnalysis()
        {
            var isInsiteMethod = false;
            var retList = new List<SourceCodeInfo>();

            foreach (var code in this.Sourcedocument.GetCodes())
            {
                var ainfo = new SourceCodeInfoAnalyzerVBDotNet(code, isInsiteMethod);
                var codeInfo = ainfo.GetCodeInfo();
                retList.Add(codeInfo);

                if (codeInfo is SourceCodeInfoBlockBeginEventMethod || codeInfo is SourceCodeInfoBlockBeginMethod)
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

        //３．Withというオブジェクトに関連する○○ブロックで囲まれた式コードを取得
        public SourceCodeInfoSubstitution[] GetCodeInfoSubstitutionsRoundBlock(string objectName)
        {
            return GetCodeInfoWithKeyNameRangeBlock<SourceCodeInfoSubstitution, SourceCodeInfoBlockBeginWithVB>
                (this.CodeObjects, objectName,
                 delegate(string lockeyName, SourceCodeInfoSubstitution info)
                 {
                    return info.LeftHandSide.Equals(objectName);
                 });
        }

        #endregion

        #endregion
    }
}

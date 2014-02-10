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
        public SourceCodeInfoSubstitution[] GetCodeInfoSubstitutionsRoundBlock(string blockName)
        {
            return GetCodeInfoWithKeyNameRangeBlock<SourceCodeInfoSubstitution, SourceCodeInfoBlockBeginWithVB>
                (this.CodeObjects, "",
                 delegate(string lockeyName, SourceCodeInfoSubstitution info)
                 {
                     return info.GetCodeString().Trim().StartsWith(".");
                 },
                 blockName,
                 delegate(string lockeyName, SourceCodeInfoBlockBeginWithVB info)
                 {
                     return info.Statement.Equals("With") && info.StatementObject.Equals(lockeyName); ;
                 });
        }

        //３．Withというオブジェクトに関連する○○ブロックで囲まれたコールメソッドを取得
        public SourceCodeInfoCallMethod[] GetCodeInfoCallMethodsRoundBlock(string blockName)
        {
            return GetCodeInfoWithKeyNameRangeBlock<SourceCodeInfoCallMethod, SourceCodeInfoBlockBeginWithVB>
                (this.CodeObjects, "",
                 delegate(string lockeyName, SourceCodeInfoCallMethod info)
                 {
                     return info.GetCodeString().Trim().StartsWith(".");
                 },
                 blockName,
                 delegate(string lockeyName, SourceCodeInfoBlockBeginWithVB info)
                 {
                     return info.Statement.Equals("With") && info.StatementObject.Equals(lockeyName);;
                 });
        }

        //３．Withというオブジェクトに関連する○○ブロックで囲まれた式コードを取得
        public SourceCodeInfo[] GetCodeInfosRoundWithBlock(string blockName)
        {
            return GetCodeInfoWithKeyNameRangeBlock<SourceCodeInfo, SourceCodeInfoBlockBeginWithVB>
                (this.CodeObjects, "",
                 delegate(string lockeyName, SourceCodeInfo info)
                 {
                     return true;
                 },
                 blockName,
                 delegate(string lockeyName, SourceCodeInfoBlockBeginWithVB info)
                 {
                     return info.Statement.Equals("With") && info.StatementObject.Equals(lockeyName); ;
                 });
        }

        public SourceCodeInfoBlockBeginWithVB[] GetSourceCodeInfoblockBeginWith()
        {
            var retList = new List<SourceCodeInfoBlockBeginWithVB>();

            foreach (var codeBlock in this.GetSourceCodeblockInfo<SourceCodeInfoBlockBeginWithVB>())
            {
                retList.Add((SourceCodeInfoBlockBeginWithVB)codeBlock.GetSourceCodeInfoBlockBegin());
            }

            return retList.ToArray();
        }

        #endregion

        #endregion
    }
}

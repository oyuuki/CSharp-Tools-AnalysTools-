﻿using System;
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
        public override SourceCodeInfo[] GetSourceCodeAnalysis()
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

        // Withというオブジェクトに関連する○○ブロックで囲まれた式コードを取得
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

        // Withというオブジェクトに関連する○○ブロックで囲まれたコールメソッドを取得
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

        // Withステートメントブロック内のコードを全て取得する
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
                     return info.Statement.Equals("With") && info.StatementObject.Equals(lockeyName);
                 });
        }

        


        // Withステートメントコードを全て取得
        public SourceCodeInfoBlockBeginWithVB[] GetSourceCodeInfoblockBeginWith()
        {
            return base.GetSourceCodeInfoblockBegin<SourceCodeInfoBlockBeginWithVB>();
        }

        // Withステートメントブロック内のIfステートメントコードを全て取得する
        public SourceCodeInfoBlockBeginIf[] GetCodeInfosIfBeginRoundWithBlock(string blockName)
        {
            return GetCodeInfoWithKeyNameRangeBlock<SourceCodeInfoBlockBeginIf, SourceCodeInfoBlockBeginWithVB>
                (this.CodeObjects, "",
                 delegate(string lockeyName, SourceCodeInfoBlockBeginIf info)
                 {
                     return true;
                 },
                 blockName,
                 delegate(string lockeyName, SourceCodeInfoBlockBeginWithVB info)
                 {
                     return info.Statement.Equals("With") && info.StatementObject.Equals(lockeyName); ;
                 });
        }

        // Withステートメントブロックを取得する
        public SourceCodeblockInfo[] GetCodeWithBlocks()
        {
            var retCodeBlockList = new List<SourceCodeblockInfo>();

            foreach (var block in this.GetSourceCodeblockInfo<SourceCodeInfoBlockBeginWithVB>(this.CodeObjects))
            {
                retCodeBlockList.Add(block);
            }

            return retCodeBlockList.ToArray();
        }

        // Withステートメントブロックを取得する
        public SourceCodeInfo[] GetCodeInfosRoundWithBlocksNotIncludeNames(string[] withOutNames)
        {
            var blockList = this.GetCodeWithBlocks();
            var retList = new List<SourceCodeInfo>();

            foreach (var block in blockList)
            {
                bool isMatchName = false;

                foreach (var withOutName in withOutNames)
                {
                    if(block.GetSourceCodeInfoBlockBegin().StatementObject.Equals(withOutName))
                    {
                        isMatchName = true;
                        break;
                    }
                }

                if(!isMatchName)
                {
                    retList.AddRange(block.GetSourceCodeInfosNotIncludeAppointBlock<SourceCodeInfoBlockBeginWithVB>());
                }
            }

            return retList.ToArray();
        }

        public void AddCodeInfoImports(SourceCodeInfoOther[] codeInfos)
        {
            int startIndex = 0;

            for (int index = 0; index < this.CodeObjects.Length; index++)
            {
                var codeObj = this.CodeObjects[index];

                if (codeObj is SourceCodeInfo && ((SourceCodeInfo)codeObj).GetCodeString().Trim().StartsWith("Option"))
                {
                    startIndex = index + 1;
                }
            }


            this.CodeObjects = this.GetAddedCodeInfo(codeInfos, this.CodeObjects, startIndex);
        }

        #endregion

        #endregion
    }
}

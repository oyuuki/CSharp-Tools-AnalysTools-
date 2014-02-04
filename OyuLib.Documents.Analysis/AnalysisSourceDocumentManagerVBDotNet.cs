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

        public SourceCodeInfoBlockBeginEventMethod[] GetEventMethodCodeIndoFiltFieldName(string fieldname)
        {
            var retValue = new List<SourceCodeInfoBlockBeginEventMethod>();

            foreach (var codeInfo in this.GetSourceCodeAnalysis())
            {
                if (codeInfo is SourceCodeInfoBlockBeginEventMethod)
                {
                    var locCodeInfo = (SourceCodeInfoBlockBeginEventMethod)codeInfo;

                    if (locCodeInfo.ObjNamesuggestEventName.Equals(fieldname))
                    {
                        retValue.Add(locCodeInfo);
                    }
                }

            }

            return retValue.ToArray();
        }

        public SourceCodeInfoMemberVariable[] GetMemValCodeIndoFiltTypeName(string typeName)
        {
            var retValue = new List<SourceCodeInfoMemberVariable>();

            foreach (var codeInfo in this.GetSourceCodeAnalysis())
            {
                if (codeInfo is SourceCodeInfoMemberVariable)
                {
                    var locCodeInfo = (SourceCodeInfoMemberVariable)codeInfo;

                    if (locCodeInfo.TypeName.Equals(typeName))
                    {
                        retValue.Add(locCodeInfo);
                    }
                }
            }

            return retValue.ToArray();
        }

        public SourceCodeInfoBlockBeginEventMethod[] GetEventMethodCodeIndoFiltTypeName(string typeName)
        {
            var retValue = new List<SourceCodeInfoBlockBeginEventMethod>();

            foreach (var codeInfo in this.GetSourceCodeAnalysis())
            {
                if (codeInfo is SourceCodeInfoBlockBeginEventMethod)
                {
                    var locCodeInfo = (SourceCodeInfoBlockBeginEventMethod)codeInfo;

                    if (locCodeInfo.ReturnTypeName.Equals(typeName))
                    {
                        retValue.Add(locCodeInfo);
                    }
                }
            }

            return retValue.ToArray();
        }

        #endregion

        #region private

        private SourceCodeInfo[] GetVbSourceCodeAnalysisFiltedType(Type[] filterTypes)
        {
            return this.GetAnalysisCodeInfoFiltedType(this.GetSourceCodeAnalysis(), filterTypes);
        }

        private SourceCodeInfo[] GetAnalysisCodeInfoFiltedType(SourceCodeInfo[] codeInfoArray, Type[] filterTypes)
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

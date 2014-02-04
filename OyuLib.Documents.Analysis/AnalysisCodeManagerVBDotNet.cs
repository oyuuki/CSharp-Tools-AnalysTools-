using System;
using System.Collections.Generic;
using OyuLib.IO;

namespace OyuLib.Documents.Sources.Analysis
{
    public class AnalysisCodeManagerVBDotNet : AnalysisCodeManager
    {
        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        public AnalysisCodeManagerVBDotNet()
            : base()
        {
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="sourcefilepath"></param>
        public AnalysisCodeManagerVBDotNet(string sourcefilepath)
            : this(sourcefilepath, CharSet.ShiftJis)
        {
            
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="sourcefilepath"></param>
        /// <param name="charactorSet"></param>
        public AnalysisCodeManagerVBDotNet(string sourcefilepath, CharSet charactorSet)
        {
            this._source = new SourceDocumentVBDotNet(sourcefilepath, charactorSet);
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

            foreach (var code in this.Source.GetCodes())
            {
                var ainfo = new SourceCodeInfoAnalyzerVBDotNet(code, isInsiteMethod);
                var codeInfo = ainfo.GetCodeInfo();
                retList.Add(codeInfo);

                if (codeInfo is CodeInfoBlockBeginEventMethod || codeInfo is SourceCodeInfoBlockBeginMethod)
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

        public CodeInfoBlockBeginEventMethod[] GetEventMethodCodeIndoFiltFieldName(string fieldname)
        {
            var retValue = new List<CodeInfoBlockBeginEventMethod>();

            foreach (var codeInfo in this.GetSourceCodeAnalysis())
            {
                if (codeInfo is CodeInfoBlockBeginEventMethod)
                {
                    var locCodeInfo = (CodeInfoBlockBeginEventMethod)codeInfo;

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

        public CodeInfoBlockBeginEventMethod[] GetEventMethodCodeIndoFiltTypeName(string typeName)
        {
            var retValue = new List<CodeInfoBlockBeginEventMethod>();

            foreach (var codeInfo in this.GetSourceCodeAnalysis())
            {
                if (codeInfo is CodeInfoBlockBeginEventMethod)
                {
                    var locCodeInfo = (CodeInfoBlockBeginEventMethod)codeInfo;

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

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

using OyuLib.Documents;

namespace OyuLib.Documents.Sources.Analysis
{
    public class ManagerAnalysisCode : ManagerAnalysis
    {
        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        public ManagerAnalysisCode()
            : base()
        {
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="source"></param>
        public ManagerAnalysisCode(SourceDocument source)
            : base(source)
        {
            
        }

        #endregion

        #region Method

        #region Public


        public SourceCodeblockInfo GetSource()
        {
            return new SourceCodeblockInfo(this.GetVbSourceCodeAnalysis());
        }

        /// <summary>
        /// Analys Code to item
        /// </summary>
        public SourceCodeInfo[] GetVbSourceCodeAnalysis()
        {
            var isInsiteMethod = false;
            var retList = new List<SourceCodeInfo>();

            foreach (var code in this.Source.GetCodes())
            {
                var ainfo = new AnalyzerCodeInfoVBDotNet(code, isInsiteMethod);
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

            foreach (var codeInfo in this.GetVbSourceCodeAnalysis())
            {
                if(codeInfo is CodeInfoBlockBeginEventMethod)
                {
                    var locCodeInfo = (CodeInfoBlockBeginEventMethod) codeInfo;

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

            foreach (var codeInfo in this.GetVbSourceCodeAnalysis())
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

            foreach (var codeInfo in this.GetVbSourceCodeAnalysis())
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
            return this.GetAnalysisCodeInfoFiltedType(this.GetVbSourceCodeAnalysis(), filterTypes);
        }

        #endregion

        #endregion
    }
}

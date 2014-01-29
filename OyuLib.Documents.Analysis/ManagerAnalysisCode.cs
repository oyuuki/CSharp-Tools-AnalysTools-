using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

using OyuLib.Documents;

namespace OyuLib.Documents.Analysis
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
        /// <param name="sourceText"></param>
        public ManagerAnalysisCode(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Method

        #region Public

        /// <summary>
        /// Analys Code to item
        /// </summary>
        public CodeInfo<Code>[] GetVbSourceCodeAnalysis()
        {
            var source = new SourceVBDotNet(this.SourceText);
            var isInsiteMethod = false;
            var retList = new List<CodeInfo<Code>>();

            foreach (var code in source.GetCodes())
            {
                var ainfo = new AnalyzerCodeInfoVBDotNet(code, isInsiteMethod);
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

        public CodeInfoEventMethod[] GetEventMethodCodeIndoFiltFieldName(string fieldname)
        {
            var retValue = new List<CodeInfoEventMethod>();

            foreach (var codeInfo in this.GetVbSourceCodeAnalysis())
            {
                if(codeInfo is CodeInfoEventMethod)
                {
                    var locCodeInfo = (CodeInfoEventMethod) codeInfo;

                    if (locCodeInfo.ObjNamesuggestEventName.Equals(fieldname))
                    {
                        retValue.Add(locCodeInfo);
                    }
                }
                
            }

            return retValue.ToArray();
        }

        public CodeInfoMemberVariable[] GetMemValCodeIndoFiltTypeName(string typeName)
        {
            var retValue = new List<CodeInfoMemberVariable>();

            foreach (var codeInfo in this.GetVbSourceCodeAnalysis())
            {
                if (codeInfo is CodeInfoMemberVariable)
                {
                    var locCodeInfo = (CodeInfoMemberVariable)codeInfo;

                    if (locCodeInfo.TypeName.Equals(typeName))
                    {
                        retValue.Add(locCodeInfo);
                    }
                }
            }

            return retValue.ToArray();
        }

        public CodeInfoEventMethod[] GetEventMethodCodeIndoFiltTypeName(string typeName)
        {
            var retValue = new List<CodeInfoEventMethod>();

            foreach (var codeInfo in this.GetVbSourceCodeAnalysis())
            {
                if (codeInfo is CodeInfoEventMethod)
                {
                    var locCodeInfo = (CodeInfoEventMethod)codeInfo;

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

        private CodeInfo<Code>[] GetVbSourceCodeAnalysisFiltedType(Type[] filterTypes)
        {
            return this.GetAnalysisCodeInfoFiltedType(this.GetVbSourceCodeAnalysis(), filterTypes);
        }

        #endregion

        #endregion
    }
}

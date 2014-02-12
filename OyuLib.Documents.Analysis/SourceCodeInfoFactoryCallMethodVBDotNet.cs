using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public static class SourceCodeInfoFactoryCallMethodVBDotNet
    {
        public static SourceCodeInfoCallMethod GetCodeInfoCallMethod(SourceCode code, params StringRange[] paramRanges)
        {
            int methodName = 0;
            int callIndex = 0;
            int objName = -1;
            int paramaterIndex = 0;
            var paramaterString = string.Empty;

            var coFac = new SourceCodePartsFactorySomeParamater(code, new string[] { ".", "," });
            var a = coFac.GetCodeParts();

            if (coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_STATEMENT_CALL))
            {
                callIndex = 0;
            }
            else
            {
                callIndex = -1;
            }

            var partRanges = coFac.GetCodePartsRanges();

            for (int index = callIndex + 1; index < partRanges.Length; index++)
            {
                if (partRanges[index].SpilitSeparatorEnd.Equals("."))
                {
                    if (!string.IsNullOrEmpty(a[index]))
                    {
                        objName = index;
                    }

                    
                }
            }

            methodName = objName + 1;
            paramaterIndex = methodName + 1;
            paramaterString = coFac.GetCodeParts()[paramaterIndex];
            var range = coFac.GetCodePartsRanges()[paramaterIndex];



            var parameter =
                        new SourceCodeInfoParamaterFactoryVBDotNetCallMethod(
                            0,
                            range)
                            .GetSourceCodeInfoParamater();

            var retValue = new SourceCodeInfoCallMethod(code, coFac, ",", methodName, objName, parameter, paramaterIndex);

            if (!ArrayUtil.IsNullOrNoLength(paramRanges))
            {
                retValue.Range = paramRanges[0];
            }

            return retValue;
        }
    }
}

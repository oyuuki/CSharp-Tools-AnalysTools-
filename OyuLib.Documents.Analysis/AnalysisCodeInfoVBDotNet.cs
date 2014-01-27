using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class AnalysisCodeInfoVBDotNet : AnalysisCodeInfo
    {
        
        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        public AnalysisCodeInfoVBDotNet()
            : base()
        {
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="code"></param>
        public AnalysisCodeInfoVBDotNet(Code code)
            : base(code)
        {
            
        }

        #endregion

        #region Method

        #region Override

        public override CodeInfo GetCodeInfo()
        {
            CodeInfo retValue = null;

            if (this.IsMethod(out retValue))
            {
                return retValue;
            }

            return retValue;
        }

        private bool IsMethod(out CodeInfo outCodeInfo)
        {
            outCodeInfo = null;
            string[] codeParts = this.Code.CodeParts();

            SourceRuleVBDotNet rule = new SourceRuleVBDotNet();

            this.IsIncludeStringInCode(rule.GetMethodHead());

            if (this.IsIncludeStringInCode(rule.GetMethodHead()))
            {
                int methodHead = this.GetIndexCodeParts(rule.GetMethodHead());

                int accessModifier = this.GetIndexCodeParts(new SourceRuleVBDotNet().GetAccessModifiersString());
                int name = methodHead + 1;
                int typeName = -1;

                if (this.Code.CodeParts()[methodHead].Equals(SyntaxStringVBDotNet.CONST_METHODHEAD_FUNCTION))
                {
                    typeName = this.Code.CodeParts().Length - 1;
                }

                int returnTypeName = -1;

                if (this.IsIncludeStringInCode(new string[] { SyntaxStringVBDotNet.CONST_EVENTS_HANDLES }))
                {
                    int eventName = this.Code.CodeParts().Length - 1;

                    outCodeInfo = new CodeInfoEventMethod(this.Code, accessModifier, name, typeName, null, eventName);
                    return true;
                }
                else
                {
                    
                    outCodeInfo = new CodeInfoMethod(this.Code, accessModifier, name, typeName, null);
                    return true;
                }
            }

            return false;
        }

        private bool IsMemberVariable(out CodeInfo outCodeInfo)
        {
            outCodeInfo = null;


            return false;
        }

        #endregion

        #endregion

    }
}

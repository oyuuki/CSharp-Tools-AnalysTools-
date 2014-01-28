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

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="isInsiteMethod"></param>
        public AnalysisCodeInfoVBDotNet(Code code, bool isInsiteMethod)
            : base(code, isInsiteMethod)
        {

        }

        #endregion

        #region Method

        #region Override

        public override CodeInfo GetCodeInfo()
        {
            CodeInfo retValue = null;

            if (IsComment(out retValue))
            {
                return retValue;
            }
            else if (this.IsMethod(out retValue))
            {
                return retValue;
            }
            else if (this.IsVariable(out retValue))
            {
                return retValue;
            }

            return new CodeInfoOther(this.Code);
        }

        private bool IsComment(out CodeInfo outCodeInfo)
        {
            outCodeInfo = null;

            if (!this.Code.CodeString.Trim().StartsWith("'"))
            {
                return false;
            }

            outCodeInfo = new CodeInfoComment(this.Code);
            return true;
        }

        private bool IsMethod(out CodeInfo outCodeInfo)
        {
            outCodeInfo = null;
            string[] codeParts = this.Code.CodeParts();

            SourceRuleVBDotNet rule = new SourceRuleVBDotNet();

            int methodHead = this.GetIndexCodeParts(rule.GetMethodHead());
            if (methodHead < 0)
            {
                return false;
            }

            if (this.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_END) 
                || this.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_EXIT))
            {
                return false;
            }

            int accessModifier = this.GetIndexCodeParts(new SourceRuleVBDotNet().GetAccessModifiersString());
            int name = methodHead + 1;
            int typeName = -1;

            if (this.Code.CodeParts()[methodHead].Equals(SyntaxStringVBDotNet.CONST_METHODHEAD_FUNCTION))
            {
                typeName = this.Code.CodeParts().Length - 1;
            }

            int returnTypeName = -1;

            if (this.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_EVENTS_HANDLES))
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


            return false;
        }

        private bool IsVariable(out CodeInfo outCodeInfo)
        {
            outCodeInfo = null;
            string[] codeParts = this.Code.CodeParts();

            SourceRuleVBDotNet rule = new SourceRuleVBDotNet();
            // ■頭がnew、returnで始まっているものは排除 → ただのコード (class:OtherCode)
            // ■=が含まれておらず、分割して2ワードになっているもの
            // ■=が含まれておらず、分割して3ワードになっており、かつ先頭がアクセス修飾子
            // ■=が含まれており、=より前のワードが2ワードになっているもの
            // ■=が含まれており、=より前のワードが3ワードになっていてかつ先頭がアクセス修飾子

            if (this.IsIncludeStringInCode(rule.GetMethodHead()))
            {
                return false;
            }

            if (!this.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_AS))
            {
                return false;
            }

            int value = -1;
            int equals = this.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_EQUALS);

            if (equals >= 0)
            {
                value = equals + 1;
            }

            int accessModifier = this.GetIndexCodeParts(new SourceRuleVBDotNet().GetAccessModifiersString());
            bool isConst = this.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_CONST) >= 0;
            int name = this.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_AS) - 1; ;
            int typeName = this.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_AS) + 1; ;
            
            if(this.IsInsiteMethod)
            {
                outCodeInfo = new CodeInfoValiable(this.Code, value, name, typeName, isConst);
            }
            else
            {
                outCodeInfo = new CodeInfoMemberVariable(this.Code, value, name, typeName, accessModifier, isConst);
            }

            return true;
        }

        #endregion

        #endregion

    }
}

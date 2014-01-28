using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class AnalyzerCodeInfoVBDotNet : AnalyzerCodeInfo
    {
        #region constractor

        /// <summary>
        /// constractor
        /// </summAnalysisary>
        public AnalyzerCodeInfoVBDotNet()
            : base()
        {
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="code"></param>
        public AnalyzerCodeInfoVBDotNet(Code code)
            : base(code)
        {
            
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="isInsiteMethod"></param>
        public AnalyzerCodeInfoVBDotNet(Code code, bool isInsiteMethod)
            : base(code, isInsiteMethod)
        {

        }

        #endregion

        #region Method

        #region Override

        public override CodeInfo GetCodeInfo()
        {
            CodeInfo retValue = null;

            if (this.CheckComment())
            {
                return this.GetCodeInfoComment();
            }

            return this.GetCodeInfoNoIncludeComment();
        }

        #endregion

        #region Private

        private CodeInfo GetCodeInfoNoIncludeComment()
        {
            if (this.CheckMethod())
            {
                return this.GetCodeInfoMethod();
            }
            else if (this.CheckVariable())
            {
                return this.GetCodeInfoVariable();
            }

            return new CodeInfoOther(this.Code);
        }

        private CodeInfo GetCodeInfoComment()
        {
            return new CodeInfoComment(this.Code);
        }

        private bool CheckComment()
        {
            if (!this.Code.CodeString.Trim().StartsWith("'"))
            {
                return false;
            }

            return true;
        }

        private CodeInfo GetCodeInfoMethod()
        {
            CodeInfo retValue = null;

            int methodHead = this.GetIndexCodeParts(new SourceRuleVBDotNet().GetMethodHead());

            int accessModifier = this.GetIndexCodeParts(new SourceRuleVBDotNet().GetAccessModifiersString());
            int name = methodHead + 1;
            int typeName = -1;

            if (this.Code.CodeParts()[methodHead].Equals(SyntaxStringVBDotNet.CONST_METHODHEAD_FUNCTION))
            {
                typeName = this.Code.CodeParts().Length - 1;
            }

            if (this.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_EVENTS_HANDLES))
            {
                int eventName = this.Code.CodeParts().Length - 1;
                retValue = new CodeInfoEventMethod(this.Code, accessModifier, name, typeName, null, eventName);
            }
            else
            {
                retValue = new CodeInfoMethod(this.Code, accessModifier, name, typeName, null);
            }

            return retValue;
        }

        private bool CheckMethod()
        {
            int methodHead = this.GetIndexCodeParts(new SourceRuleVBDotNet().GetMethodHead());

            if (methodHead < 0)
            {
                return false;
            }

            if (this.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_END)
                || this.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_EXIT))
            {
                return false;
            }

            return true;
        }

        private CodeInfo GetCodeInfoVariable()
        {
            CodeInfo retValue = null;
            string[] codeParts = this.Code.CodeParts();            
            // ■頭がnew、returnで始まっているものは排除 → ただのコード (class:OtherCode)
            // ■=が含まれておらず、分割して2ワードになっているもの
            // ■=が含まれておらず、分割して3ワードになっており、かつ先頭がアクセス修飾子
            // ■=が含まれており、=より前のワードが2ワードになっているもの
            // ■=が含まれており、=より前のワードが3ワードになっていてかつ先頭がアクセス修飾子

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
                retValue = new CodeInfoValiable(this.Code, value, name, typeName, isConst);
            }
            else
            {
                retValue = new CodeInfoMemberVariable(this.Code, value, name, typeName, accessModifier, isConst);
            }

            return retValue;
        }


        private bool CheckVariable()
        {
            if (this.IsIncludeStringInCode(new SourceRuleVBDotNet().GetMethodHead()))
            {
                return false;
            }

            if (!this.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_AS))
            {
                return false;
            }

            return true;
        }

        private CodeInfo GetCodeInfoCallMethod()
        {
            return null;
        }

        private bool CheckCallMethod()
        {
            //・代入コード「=」が存在しない
            //")"で終わっている
            //     1. "("より前のコードは" "で分割されず、常に一つ
            //     2. ()の中身のみが" "で分割されることがある
            //     3. ()は複数あるかもしれない。
            //上記以外
            //     1. " "で分割されず、常に一つ
            //         例外あり：　頭がNewで開始されているもの
            if (this.IsIncludeStringInCode(new SourceRuleVBDotNet().GetMethodHead()))
            {
                return false;
            }

            if (!this.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_AS))
            {
                return false;
            }

            return true;
        }

        #endregion

        #endregion

    }
}

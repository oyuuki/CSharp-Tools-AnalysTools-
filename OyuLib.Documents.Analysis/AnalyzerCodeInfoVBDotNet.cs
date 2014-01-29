using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class AnalyzerCodeInfoVBDotNet : AnalyzerCodeInfo
    {
        #region Constractor

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
        public AnalyzerCodeInfoVBDotNet(string codeString)
            : base(codeString)
        {
            
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="isInsiteMethod"></param>
        public AnalyzerCodeInfoVBDotNet(string codeString, bool isInsiteMethod)
            : base(codeString, isInsiteMethod)
        {

        }

        #endregion

        #region InnerClass

        #region CommonCodeInfoValiableInfo

        private class CommonCodeInfoValiableInfo
        {
            #region InstanceVal

            private int _value = -1;

            private int _equals = -1;

            private bool _isConst = false;

            private int _name = -1;

            private int _typeName = -1;

            #endregion

            #region Constructor

            public CommonCodeInfoValiableInfo(
                int value,
                int equals,
                bool isConst,
                int name,
                int typeName)
            {
                this._value = value;
                this._equals = equals;
                this._isConst = isConst;
                this._name = name;
                this._typeName = typeName;
            }

            #endregion

            #region Property

            public int Value
            {
                get { return this._value; }
                set { this._value = value; }
            }

            public int Equals
            {
                get { return this._equals; }
                set { this._equals = value; }
            }

            public bool IsConst
            {
                get { return this._isConst; }
                set { this._isConst = value; }
            }

            public int Name
            {
                get { return this._name; }
                set { this._name = value; }
            }

            public int TypeName
            {
                get { return this._typeName; }
                set { this._typeName = value; }
            }

            #endregion
        }

        #endregion

        #region CommonCodeInfoMethodInfo

        private class CommonCodeInfoMethodInfo
        {
            #region InstanceVal

            private int _accessModifier = -1;

            private int _name = -1;

            private int _typeName = -1;

            private CodeInfoValiable[] _valiables = null;

            #endregion

            #region Constructor

            public CommonCodeInfoMethodInfo(
                int accessModifier,
                int name,
                int typeName,
                CodeInfoValiable[] valiables)
            {
                this._accessModifier = accessModifier;
                this._name = name;
                this._typeName = typeName;
                this._valiables = valiables;
            }

            #endregion

            #region Property

            public int AccessModifier
            {
                get { return this._accessModifier; }
                set { this._accessModifier = value; }
            }

            public int Name
            {
                get { return this._name; }
                set { this._name = value; }
            }

            public int TypeName
            {
                get { return this._typeName; }
                set { this._typeName = value; }
            }

            public CodeInfoValiable[] Valiables
            {
                get { return this._valiables; }
                set { this._valiables = value; }
            }

            #endregion
        }

        #endregion

        #endregion

        #region Method

        #region Private

        private bool CheckCommonCodeInfoMethod(Code code)
        {
            int methodHead = code.GetIndexCodeParts(new SourceRuleVBDotNet().GetMethodHead());

            if (methodHead < 0)
            {
                return false;
            }

            if (code.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_END)
                || code.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_EXIT))
            {
                return false;
            }

            return true;
        }

        private CommonCodeInfoMethodInfo GetCommonCodeInfoMethod(Code code)
        {
            int methodHead = code.GetIndexCodeParts(new SourceRuleVBDotNet().GetMethodHead());

            int accessModifier = code.GetIndexCodeParts(new SourceRuleVBDotNet().GetAccessModifiersString());
            int name = methodHead + 1;
            int typeName = -1;

            if (code.CodeParts()[methodHead].Equals(SyntaxStringVBDotNet.CONST_METHODHEAD_FUNCTION))
            {
                typeName = code.CodeParts().Length - 1;
            }

            return new CommonCodeInfoMethodInfo(accessModifier, name, typeName, null);
        }

        private CommonCodeInfoValiableInfo GetCommonCodeInfoVariable(Code code)
        {
            // ■頭がnew、returnで始まっているものは排除 → ただのコード (class:OtherCode)
            // ■=が含まれておらず、分割して2ワードになっているもの
            // ■=が含まれておらず、分割して3ワードになっており、かつ先頭がアクセス修飾子
            // ■=が含まれており、=より前のワードが2ワードになっているもの
            // ■=が含まれており、=より前のワードが3ワードになっていてかつ先頭がアクセス修飾子

            int value = -1;
            int equals = code.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_EQUALS);

            if (equals >= 0)
            {
                value = equals + 1;
            }

            int accessModifier = code.GetIndexCodeParts(new SourceRuleVBDotNet().GetAccessModifiersString());
            bool isConst = code.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_CONST) >= 0;
            int name = code.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_AS) - 1;
            int typeName = code.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_AS) + 1;

            return new CommonCodeInfoValiableInfo(value, equals, isConst, name, typeName); 
        }

        private bool CheckCommonCodeInfoVariable(Code code)
        {
            if (code.IsIncludeSomeStringInCode(new SourceRuleVBDotNet().GetMethodHead()))
            {
                return false;
            }

            if (!code.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_AS))
            {
                return false;
            }

            return true;
        }

        #region GetOtherCodeInfo関係

        private bool CheckCodeInfoWithBlock(Code code)
        {
            SourceRuleVBDotNet rule = new SourceRuleVBDotNet();

            // include "With"
            if (!code.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_STATEMENT_WITH))
            {
                return false;
            }

            return true;
        }

        private CodeInfo GetCodeInfoWithBlock(Code code)
        {
            int length = code.CodeParts().Length;

            int statement = code.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_STATEMENT_WITH);
            int statementObjName = length - 1;

            if (!code.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_END))
            {
                return new CodeInfoBlockBegin(code, statement, statementObjName);
            }
            else
            {
                return new CodeInfoBlockEnd();
            }
        }

        #endregion

        #endregion

        #region Override

        public override CodeInfo GetAntherCodeInfo()
        {
            if (this.CheckCodeInfoWithBlock(this.GetCode()))
            {
                return this.GetCodeInfoWithBlock(this.GetCode());
            }

            return base.GetAntherCodeInfo();
        }

        #region CodeInfoComment

        protected override CodeInfoComment GetCodeInfoComment(Code code)
        {
            return new CodeInfoComment(code);
        }

        protected override bool CheckCodeInfoComment(Code code)
        {
            if (!code.CodeString.Trim().StartsWith("'"))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region CodeInfoValiable

        protected override CodeInfoValiable GetCodeInfoVariable(Code code)
        {
            var commonInfo = this.GetCommonCodeInfoVariable(code);
            return new CodeInfoValiable(code, commonInfo.Value, commonInfo.Name, commonInfo.TypeName, commonInfo.IsConst); ;
        }

        protected override bool CheckCodeInfoVariable(Code code)
        {
            return this.CheckCommonCodeInfoVariable(code) && this.IsInsiteMethod;
        }

        #endregion

        #region CodeInfoMemberVariable

        protected override CodeInfoMemberVariable GetCodeInfoMemberVariable(Code code)
        {
            var commonInfo = this.GetCommonCodeInfoVariable(code);
            int accessModifier = code.GetIndexCodeParts(new SourceRuleVBDotNet().GetAccessModifiersString());
            return new CodeInfoMemberVariable(code, commonInfo.Value, commonInfo.Name, commonInfo.TypeName, accessModifier, commonInfo.IsConst);
        }

        protected override bool CheckCodeInfoMemberVariable(Code code)
        {
            return this.CheckCommonCodeInfoVariable(code) && !this.IsInsiteMethod;
        }

        #endregion

        #region CodeInfoCallMethod

        protected override CodeInfoCallMethod GetCodeInfoCallMethod(CodeExPartsLogic code)
        {
            int methodName = 0;
            int paramater = 1;

            return new CodeInfoCallMethod(code, methodName, paramater);
        }

        protected override bool CheckCodeInfoCallMethod(Code code)
        {
            SourceRuleVBDotNet rule = new SourceRuleVBDotNet();

            // No include "As", "Sub", "Function"
            if (code.IsIncludeSomeStringInCode(
                new string[]
                {
                    SyntaxStringVBDotNet.CONST_AS, 
                    SyntaxStringVBDotNet.CONST_METHODHEAD_SUB, 
                    SyntaxStringVBDotNet.CONST_METHODHEAD_FUNCTION
                }))
            {
                return false;
            }

            // No Include "="
            if (code.GetCodePartsLength() >= 3)
            {
                if (code.CodeParts()[1].Equals(SyntaxStringVBDotNet.CONST_EQUALS))
                {
                    return false;
                }
            }

            // End with ")"
            if (!code.IsIncludeStringInCodeEndWithAtLast(SyntaxStringVBDotNet.CONST_CALLMETHOS_END))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region CodeInfoEventMethod

        protected override bool CheckCodeInfoEventMethod(Code code)
        {
            return this.CheckCommonCodeInfoMethod(code) &&
                   code.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_EVENTS_HANDLES);
        }

        protected override CodeInfoEventMethod GetCodeInfoEventMethod(Code code)
        {
            var commonInfo = this.GetCommonCodeInfoMethod(code);
            int eventName = code.CodeParts().Length - 1;
            return new CodeInfoEventMethod(code, commonInfo.AccessModifier, commonInfo.Name, commonInfo.TypeName, commonInfo.Valiables, eventName);
        }

        #endregion

        #region CodeInfoMethod

        protected override bool CheckCodeInfoMethod(Code code)
        {
            return this.CheckCommonCodeInfoMethod(code) &&
                   !code.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_EVENTS_HANDLES);
        }

        protected override CodeInfoMethod GetCodeInfoMethod(Code code)
        {
            var commonInfo = this.GetCommonCodeInfoMethod(code);
            return new CodeInfoMethod(code, commonInfo.AccessModifier, commonInfo.Name, commonInfo.TypeName, commonInfo.Valiables);
        }

        #endregion

        #region CodeInfoSubstitution

        protected override bool CheckCodeInfoSubstitution(Code code)
        {
            SourceRuleVBDotNet rule = new SourceRuleVBDotNet();

            // No Begin with "If ","For ","While ", "Do "
            if (code.IsIncludeSomeStringInCode(rule.GetControlStatementsString()))
            {
                return false;
            }
            // No include "As"
            if (code.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_AS))
            {
                return false;
            }

            // composed right-hand side and lefthand side
            if (code.GetCodePartsLength() < 3 || !code.CodeParts()[1].Equals(SyntaxStringVBDotNet.CONST_EQUALS))
            {
                return false;
            }

            return true;
        }

        protected override CodeInfoSubstitution GetCodeInfoSubstitution(Code code)
        {
            int equals = code.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_EQUALS);
            int rightHandSide = equals + 1;
            int leftHandSide = equals - 1;

            return new CodeInfoSubstitution(code, rightHandSide, leftHandSide); 
        }

        #endregion

        #endregion

        #endregion
    }
}

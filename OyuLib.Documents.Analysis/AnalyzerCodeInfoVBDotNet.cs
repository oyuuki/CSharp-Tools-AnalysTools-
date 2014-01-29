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

        #region InnerClass

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

        #region Method

        #region Private

        private bool CheckCommonCodeInfoMethod()
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

        private CommonCodeInfoMethodInfo GetCommonCodeInfoMethod()
        {
            int methodHead = this.GetIndexCodeParts(new SourceRuleVBDotNet().GetMethodHead());

            int accessModifier = this.GetIndexCodeParts(new SourceRuleVBDotNet().GetAccessModifiersString());
            int name = methodHead + 1;
            int typeName = -1;

            if (this.Code.CodeParts()[methodHead].Equals(SyntaxStringVBDotNet.CONST_METHODHEAD_FUNCTION))
            {
                typeName = this.Code.CodeParts().Length - 1;
            }

            return new CommonCodeInfoMethodInfo(accessModifier, name, typeName, null);
        }

        private CommonCodeInfoValiableInfo GetCommonCodeInfoVariable()
        {
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
            int name = this.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_AS) - 1;
            int typeName = this.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_AS) + 1;

            return new CommonCodeInfoValiableInfo(value, equals, isConst, name, typeName); ;
        }

        private bool CheckCommonCodeInfoVariable()
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

        #endregion

        #region Override

        #region CodeInfoComment

        protected override CodeInfoComment GetCodeInfoComment()
        {
            return new CodeInfoComment(this.Code);
        }

        protected override bool CheckCodeInfoComment()
        {
            if (!this.Code.CodeString.Trim().StartsWith("'"))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region CodeInfoValiable

        protected override CodeInfoValiable GetCodeInfoVariable()
        {
            var commonInfo = this.GetCommonCodeInfoVariable();
            return new CodeInfoValiable(this.Code, commonInfo.Value, commonInfo.Name, commonInfo.TypeName, commonInfo.IsConst);;
        }

        protected override bool CheckCodeInfoVariable()
        {
            return this.CheckCommonCodeInfoVariable() && this.IsInsiteMethod;
        }

        #endregion

        #region CodeInfoMemberVariable

        protected override CodeInfoMemberVariable GetCodeInfoMemberVariable()
        {
            var commonInfo = this.GetCommonCodeInfoVariable();
            int accessModifier = this.GetIndexCodeParts(new SourceRuleVBDotNet().GetAccessModifiersString());
            return new CodeInfoMemberVariable(this.Code, commonInfo.Value, commonInfo.Name, commonInfo.TypeName, accessModifier, commonInfo.IsConst);
        }

        protected override bool CheckCodeInfoMemberVariable()
        {
            return this.CheckCommonCodeInfoVariable() && !this.IsInsiteMethod;
        }

        #endregion

        #region CodeInfoCallMethod

        protected override CodeInfoCallMethod GetCodeInfoCallMethod()
        {
            throw new NotImplementedException();
        }

        protected override bool CheckCodeInfoCallMethod()
        {
            //・代入コード「=」が存在しない
            //")"で終わっている
            //     1. "("より前のコードは" "で分割されず、常に一つ
            //     2. ()の中身のみが" "で分割されることがある
            //     3. ()は複数あるかもしれない。
            //上記以外
            //     1. " "で分割されず、常に一つ
            //         例外あり：　頭がNewで開始されているもの
            return false;
        }

        #endregion

        #region CodeInfoEventMethod

        protected override bool CheckCodeInfoEventMethod()
        {
            return this.CheckCommonCodeInfoMethod() &&
                   this.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_EVENTS_HANDLES);
        }

        protected override CodeInfoEventMethod GetCodeInfoEventMethod()
        {
            var commonInfo = this.GetCommonCodeInfoMethod();
            int eventName = this.Code.CodeParts().Length - 1;
            return new CodeInfoEventMethod(this.Code, commonInfo.AccessModifier, commonInfo.Name, commonInfo.TypeName, null, eventName);
        }

        #endregion

        #region CodeInfoMethod

        protected override bool CheckCodeInfoMethod()
        {
            return this.CheckCommonCodeInfoMethod() &&
                   !this.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_EVENTS_HANDLES);
        }
                          
        protected override CodeInfoMethod GetCodeInfoMethod()
        {
            var commonInfo = this.GetCommonCodeInfoMethod();
            return new CodeInfoMethod(this.Code, commonInfo.AccessModifier, commonInfo.Name, commonInfo.TypeName, null);
        }

        #endregion

        #endregion

        #endregion

    }
}

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

            private int _paramaters = -1;

            private CodeInfoValiable[] _valiables = null;

            #endregion

            #region Constructor

            public CommonCodeInfoMethodInfo(
                int accessModifier,
                int name,
                int typeName,
                int paramaters,
                CodeInfoValiable[] valiables)
            {
                this._accessModifier = accessModifier;
                this._name = name;
                this._typeName = typeName;
                this._paramaters = paramaters;
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

            public int Paramaters
            {
                get { return this._paramaters; }
                set { this._paramaters = value; }
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
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");

            int methodHead = coFac.GetIndexCodeParts(new SourceRuleVBDotNet().GetMethodHead());

            if (methodHead < 0)
            {
                return false;
            }

            if (coFac.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_END)
                || coFac.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_EXIT))
            {
                return false;
            }

            return true;
        }

        private CommonCodeInfoMethodInfo GetCommonCodeInfoMethod(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, " ");
            int methodHead = coFac.GetIndexCodeParts(new SourceRuleVBDotNet().GetMethodHead());
            int accessModifier = coFac.GetIndexCodeParts(new SourceRuleVBDotNet().GetAccessModifiersString());
            int name = methodHead + 1;
            int paramaters = name + 1;
            int typeName = -1;

            if (coFac.GetCodeParts()[methodHead].Equals(SyntaxStringVBDotNet.CONST_METHODHEAD_FUNCTION))
            {
                typeName = coFac.GetCodeParts().Length - 1;
            }

            return new CommonCodeInfoMethodInfo(accessModifier, name, typeName, paramaters, null);
        }

        private CommonCodeInfoValiableInfo GetCommonCodeInfoVariable(Code code, CodePartsFactory coFac)
        {
            // ■頭がnew、returnで始まっているものは排除 → ただのコード (class:OtherCode)
            // ■=が含まれておらず、分割して2ワードになっているもの
            // ■=が含まれておらず、分割して3ワードになっており、かつ先頭がアクセス修飾子
            // ■=が含まれており、=より前のワードが2ワードになっているもの
            // ■=が含まれており、=より前のワードが3ワードになっていてかつ先頭がアクセス修飾子

            int value = -1;
            int equals = coFac.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_EQUALS);

            if (equals >= 0)
            {
                value = equals + 1;
            }

            int accessModifier = coFac.GetIndexCodeParts(new SourceRuleVBDotNet().GetAccessModifiersString());
            bool isConst = coFac.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_CONST) >= 0;
            int name = coFac.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_AS) - 1;
            int typeName = coFac.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_AS) + 1;

            return new CommonCodeInfoValiableInfo(value, equals, isConst, name, typeName); 
        }

        private bool CheckCommonCodeInfoVariable(Code code, CodePartsFactory coFac)
        {
            if (coFac.IsIncludeSomeStringInCode(new SourceRuleVBDotNet().GetMethodHead()))
            {
                return false;
            }

            if (!coFac.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_AS))
            {
                return false;
            }

            return true;
        }

        #region GetOtherCodeInfo関係

        private bool CheckCommonCodeInfoBlock(Code code, string[] blockNames)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            
            // include "With"
            if (!coFac.IsIncludeAllStringInCode(blockNames))
            {
                return false;
            }

            return true;
        }

        private CodeInfo GetCodeInfoWithBlock(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");

            int length = coFac.GetCodeParts().Length;

            int statement = coFac.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_STATEMENT_WITH);
            int statementObjName = length - 1;

            if (!coFac.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_END))
            {
                return new CodeInfoBlockBegin(code, coFac, statement, statementObjName);
            }
            else
            {
                return new CodeInfoBlockEnd(code, coFac, statement);
            }
        }

        private CodeInfo GetCodeInfoSubEndBlock(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            int statement = coFac.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_METHODHEAD_SUB);
            return new CodeInfoBlockSubEndVB(code, coFac, statement);
        }

        private CodeInfo GetCodeInfoFunctionEndBlock(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            int statement = coFac.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_METHODHEAD_SUB);
            return new CodeInfoBlockFunctionEndVB(code, coFac, statement);
        }

        #endregion

        #endregion

        #region Override

        public override CodeInfo GetAntherCodeInfo(Code code)
        {
            if (this.CheckCommonCodeInfoBlock(code, new string[] { SyntaxStringVBDotNet.CONST_STATEMENT_WITH }))
            {
                return this.GetCodeInfoWithBlock(code);
            }
            else if (this.CheckCommonCodeInfoBlock(code, new string[] { SyntaxStringVBDotNet.CONST_METHODHEAD_SUB, SyntaxStringVBDotNet.CONST_END }))
            {
                return this.GetCodeInfoSubEndBlock(code);
            }
            else if (this.CheckCommonCodeInfoBlock(code, new string[] { SyntaxStringVBDotNet.CONST_METHODHEAD_FUNCTION, SyntaxStringVBDotNet.CONST_END }))
            {
                return this.GetCodeInfoFunctionEndBlock(code);
            }

            return base.GetAntherCodeInfo(code);
        }

        public override SourceRule GetSourceRule()
        {
            return new SourceRuleVBDotNet();
        }

        #region CodeInfoComment

        protected override CodeInfoComment GetCodeInfoComment(Code code)
        {
            return new CodeInfoComment(code, new CodePartsFactoryVB(code, " "));
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
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            var commonInfo = this.GetCommonCodeInfoVariable(code, coFac);
            return new CodeInfoValiable(
                code, 
                coFac, 
                commonInfo.Value, 
                commonInfo.Name, 
                commonInfo.TypeName, 
                commonInfo.IsConst);
        }

        protected override bool CheckCodeInfoVariable(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            return this.CheckCommonCodeInfoVariable(code, coFac) && this.IsInsiteMethod;
        }

        #endregion

        #region CodeInfoMemberVariable

        protected override CodeInfoMemberVariable GetCodeInfoMemberVariable(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            var commonInfo = this.GetCommonCodeInfoVariable(code, coFac);
            int accessModifier = coFac.GetIndexCodeParts(new SourceRuleVBDotNet().GetAccessModifiersString());
            return new CodeInfoMemberVariable(code, coFac, commonInfo.Value, commonInfo.Name, commonInfo.TypeName, accessModifier, commonInfo.IsConst);
        }

        protected override bool CheckCodeInfoMemberVariable(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            return this.CheckCommonCodeInfoVariable(code, coFac) && !this.IsInsiteMethod;
        }

        #endregion

        #region CodeInfoCallMethod

        protected override CodeInfoCallMethod GetCodeInfoCallMethod(Code code)
        {
            int methodName = 0;
            int paramater = 0;

            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            if (coFac.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_STATEMENT_CALL))
            {
                methodName = 1;
            }

            paramater = methodName + 1;

            return new CodeInfoCallMethod(code, coFac, methodName, paramater);
        }

        protected override bool CheckCodeInfoCallMethod(Code code)
        {
            SourceRuleVBDotNet rule = new SourceRuleVBDotNet();
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");

            // No include "As", "Sub", "Function"
            if (coFac.IsIncludeSomeStringInCode(
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
            if (coFac.GetCodePartsLength() >= 3)
            {
                if (coFac.GetCodeParts()[1].Equals(SyntaxStringVBDotNet.CONST_EQUALS))
                {
                    return false;
                }
            }


            // End with ")"
            if (!coFac.IsIncludeStringInCodeEndWithAtLast(SyntaxStringVBDotNet.CONST_CALLMETHOS_END)
                && !coFac.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_STATEMENT_CALL))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region CodeInfoEventMethod

        protected override bool CheckCodeInfoEventMethod(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            return this.CheckCommonCodeInfoMethod(code) &&
                   coFac.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_EVENTS_HANDLES);
        }

        protected override CodeInfoEventMethod GetCodeInfoEventMethod(Code code)
        {
            var commonInfo = this.GetCommonCodeInfoMethod(code);

            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, " ");
            int eventName = coFac.GetCodeParts().Length - 1;

            return new CodeInfoEventMethod(code, coFac, commonInfo.AccessModifier, commonInfo.Name, commonInfo.TypeName, commonInfo.Paramaters, eventName);
        }

        #endregion

        #region CodeInfoMethod

        protected override bool CheckCodeInfoMethod(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            return this.CheckCommonCodeInfoMethod(code) &&
                   !coFac.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_EVENTS_HANDLES);
        }

        protected override CodeInfoMethod GetCodeInfoMethod(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, " ");
            var commonInfo = this.GetCommonCodeInfoMethod(code);
            return new CodeInfoMethod(code, coFac, commonInfo.AccessModifier, commonInfo.Name, commonInfo.TypeName, commonInfo.Paramaters);
        }

        #endregion

        #region CodeInfoSubstitution

        protected override bool CheckCodeInfoSubstitution(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            SourceRuleVBDotNet rule = new SourceRuleVBDotNet();

            // No Begin with "If ","For ","While ", "Do "
            if (coFac.IsIncludeSomeStringInCode(rule.GetControlStatementsString()))
            {
                return false;
            }
            // No include "As"
            if (coFac.IsIncludeStringInCode(SyntaxStringVBDotNet.CONST_AS))
            {
                return false;
            }

            // composed right-hand side and lefthand side
            if (coFac.GetCodePartsLength() < 3 || !coFac.GetCodeParts()[1].Equals(SyntaxStringVBDotNet.CONST_EQUALS))
            {
                return false;
            }

            return true;
        }

        protected override CodeInfoSubstitution GetCodeInfoSubstitution(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            int equals = coFac.GetIndexCodeParts(SyntaxStringVBDotNet.CONST_EQUALS);
            int rightHandSide = equals + 1;
            int leftHandSide = equals - 1;

            return new CodeInfoSubstitution(code, coFac, rightHandSide, leftHandSide); 
        }

        #endregion

        #region CodeInfoBlock

        protected override CodeInfoBlockBeginIf GetCodeInfoBlockBeginIf(Code code)
        {
            SourceRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeIf());
            return new CodeInfoBlockBeginIf(code, coFac, segments, segments + 1);
        }

        protected override CodeInfoBlockEndIf GetCodeInfoBlockEndIf(Code code)
        {
            SourceRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndIf());
            return new CodeInfoBlockEndIf(code, coFac, segments);
        }

        protected override CodeInfoBlockBeginDo GetCodeInfoBlockBeginDo(Code code)
        {
            SourceRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeDo());
            return new CodeInfoBlockBeginDo(code, coFac, segments, segments + 1);
        }

        protected override CodeInfoBlockEndDo GetCodeInfoBlockEndDo(Code code)
        {
            SourceRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndDo());
            return new CodeInfoBlockEndDo(code, coFac, segments);
        }

        protected override CodeInfoBlockBeginWhile GetCodeInfoBlockBeginWhile(Code code)
        {
            SourceRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeWhile());
            return new CodeInfoBlockBeginWhile(code, coFac, segments, segments + 1);
        }

        protected override CodeInfoBlockEndWhile GetCodeInfoBlockEndWhile(Code code)
        {
            SourceRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndWhile());
            return new CodeInfoBlockEndWhile(code, coFac, segments);
        }

        protected override CodeInfoBlockBeginFor GetCodeInfoBlockBeginFor(Code code)
        {
            SourceRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeFor());
            return new CodeInfoBlockBeginFor(code, coFac, segments, segments + 1);
        }

        protected override CodeInfoBlockEndFor GetCodeInfoBlockEndFor(Code code)
        {
            SourceRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndFor());
            return new CodeInfoBlockEndFor(code, coFac, segments);
        }

        protected override bool CheckControlCode(Code code)
        {
            SourceRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            if (!coFac.IsIncludeSomeStringInCode(rule.GetControlCodes()))
            {
                return false;
            }

            return true;
        }

        protected override CodeInfoBlockBeginCaseFormula GetCodeInfoBlockBeginCaseFormula(Code code)
        {
            throw new NotImplementedException();
        }

        protected override CodeInfoBlockEndCaseFormula GetCodeInfoBlockEndCaseFormula(Code code)
        {
            throw new NotImplementedException();
        }

        protected override CodeInfoBlockBeginCaseValue GetCodeInfoBlockBeginCaseValue(Code code)
        {
            throw new NotImplementedException();
        }

        protected override CodeInfoBlockEndCaseValue GetCodeInfoBlockEndCaseValue(Code code)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #endregion
    }
}

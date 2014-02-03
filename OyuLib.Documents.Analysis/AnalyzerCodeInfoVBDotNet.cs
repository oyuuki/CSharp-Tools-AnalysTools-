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

            private int _statement = -1;

            private int _statementObj = -1;

            private int _name = -1;

            private int _typeName = -1;

            private int _paramaters = -1;

            private CodeInfoValiable[] _valiables = null;

            #endregion

            #region Constructor

            public CommonCodeInfoMethodInfo(
                int accessModifier,
                int statement,
                int statementObj,
                int name,
                int typeName,
                int paramaters,
                CodeInfoValiable[] valiables)
            {
                this._accessModifier = accessModifier;
                this._statement = statement;
                this._statementObj = statementObj;
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

            public int Statement
            {
                get { return this._statement; }
                set { this._statement = value; }
            }

            public int StatementObj
            {
                get { return this._statementObj; }
                set { this._statementObj = value; }
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

        #region CodeInfoMethod

        private bool CheckCommonCodeInfoMethod(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");

            int methodHead = coFac.GetIndexCodeParts(new SourceDocumentRuleVBDotNet().GetMethodHead());

            if (methodHead < 0)
            {
                return false;
            }

            if (coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_END)
                || coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_EXIT))
            {
                return false;
            }

            return true;
        }

        private CommonCodeInfoMethodInfo GetCommonCodeInfoMethod(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, " ");
            int methodHead = coFac.GetIndexCodeParts(new SourceDocumentRuleVBDotNet().GetMethodHead());
            int accessModifier = coFac.GetIndexCodeParts(new SourceDocumentRuleVBDotNet().GetAccessModifiersString());
            int name = methodHead + 1;
            int paramaters = name + 1;
            int typeName = -1;

            if (coFac.GetCodeParts()[methodHead].Equals(SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_FUNCTION))
            {
                typeName = coFac.GetCodeParts().Length - 1;
            }

            return new CommonCodeInfoMethodInfo(accessModifier, methodHead, -1,name, typeName, paramaters, null);
        }

        #endregion

        #region CodeInfoValiable

        private CommonCodeInfoValiableInfo GetCommonCodeInfoVariable(Code code, CodePartsFactory coFac)
        {
            // ■頭がnew、returnで始まっているものは排除 → ただのコード (class:OtherCode)
            // ■=が含まれておらず、分割して2ワードになっているもの
            // ■=が含まれておらず、分割して3ワードになっており、かつ先頭がアクセス修飾子
            // ■=が含まれており、=より前のワードが2ワードになっているもの
            // ■=が含まれており、=より前のワードが3ワードになっていてかつ先頭がアクセス修飾子

            int value = -1;
            int equals = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_EQUALS);

            if (equals >= 0)
            {
                value = equals + 1;
            }

            int accessModifier = coFac.GetIndexCodeParts(new SourceDocumentRuleVBDotNet().GetAccessModifiersString());
            bool isConst = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_CONST) >= 0;
            int name = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_AS) - 1;
            int typeName = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_AS) + 1;

            return new CommonCodeInfoValiableInfo(value, equals, isConst, name, typeName); 
        }

        private bool CheckCommonCodeInfoVariable(Code code, CodePartsFactory coFac)
        {
            if (coFac.IsIncludeSomeStringInCode(new SourceDocumentRuleVBDotNet().GetMethodHead()))
            {
                return false;
            }

            if (!coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_AS))
            {
                return false;
            }

            return true;
        }

        #endregion

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

            int statement = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_STATEMENT_WITH);
            int statementObjName = length - 1;

            if (!coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_END))
            {
                return new  CodeInfoBlockBeginWithVB(code, coFac, statement, statementObjName);
            }
            else
            {
                return new CodeInfoBlockEndWithVB(code, coFac, statement);
            }
        }

        private CodeInfo GetCodeInfoSubEndBlock(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            int statement = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_SUB);
            return new CodeInfoBlockSubEndVB(code, coFac, statement);
        }

        private CodeInfo GetCodeInfoFunctionEndBlock(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            int statement = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_SUB);
            return new CodeInfoBlockFunctionEndVB(code, coFac, statement);
        }

        #endregion

        #region CodeInfoBlockIf 
            
        private  bool CheckCommonCodeInfoBlockBeginIf(Code code, bool isEnd)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeBeginIf()) && isEnd == coFac.IsIncludeStringInCode(rule.GetControlCodeEndIf());
        }

        #endregion

        #region

        private bool CheckCommonCodeInfoBlockBeginCaseFomula(Code code, bool isEnd)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeBeginCaseFomula()) && isEnd == coFac.IsIncludeStringInCode(rule.GetControlCodeEndCaseFomula());
        }

        #endregion

        #endregion

        #region Override

        #region GetAntherCodeInfo

        public override CodeInfo GetAntherCodeInfo(Code code)
        {
            if (this.CheckCommonCodeInfoBlock(code, new string[] { SourceDocumentSyntaxVBDotNet.CONST_STATEMENT_WITH }))
            {
                return this.GetCodeInfoWithBlock(code);
            }
            else if (this.CheckCommonCodeInfoBlock(code, new string[] { SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_SUB, SourceDocumentSyntaxVBDotNet.CONST_END }))
            {
                return this.GetCodeInfoSubEndBlock(code);
            }
            else if (this.CheckCommonCodeInfoBlock(code, new string[] { SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_FUNCTION, SourceDocumentSyntaxVBDotNet.CONST_END }))
            {
                return this.GetCodeInfoFunctionEndBlock(code);
            }

            return base.GetAntherCodeInfo(code);
        }

        #endregion

        #region GetSourceRule

        public override SourceDocumentRule GetSourceRule()
        {
            return new SourceDocumentRuleVBDotNet();
        }

        #endregion

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
            int accessModifier = coFac.GetIndexCodeParts(new SourceDocumentRuleVBDotNet().GetAccessModifiersString());
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

            if (coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_STATEMENT_CALL))
            {
                methodName = 1;
            }

            paramater = methodName + 1;

            return new CodeInfoCallMethod(code, coFac, methodName, paramater);
        }

        protected override bool CheckCodeInfoCallMethod(Code code)
        {
            SourceDocumentRuleVBDotNet rule = new SourceDocumentRuleVBDotNet();
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");

            // No include "As", "Sub", "Function"
            if (coFac.IsIncludeSomeStringInCode(
                new string[]
                {
                    SourceDocumentSyntaxVBDotNet.CONST_AS, 
                    SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_SUB, 
                    SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_FUNCTION
                }))
            {
                return false;
            }

            // No Include "="
            if (coFac.GetCodePartsLength() >= 3)
            {
                if (coFac.GetCodeParts()[1].Equals(SourceDocumentSyntaxVBDotNet.CONST_EQUALS))
                {
                    return false;
                }
            }


            // End with ")"
            if (!coFac.IsIncludeStringInCodeEndWithAtLast(SourceDocumentSyntaxVBDotNet.CONST_CALLMETHOS_END)
                && !coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_STATEMENT_CALL))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region

        protected override bool CheckCodeInfoBlockEndMethod(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeSomeStringInCode(
                new string[]
                {
                    SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_SUB,
                    SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_FUNCTION,
                })
                   && coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_END);
        }

        protected override CodeInfoBlockEndMethod GetCodeInfoBlockEndMethod(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_END);
            return new CodeInfoBlockEndMethod(code, coFac, segments + 1);
        }

        #endregion

        #region CodeInfoEventMethod

        protected override bool CheckCodeInfoBlockBeginEventMethod(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            return this.CheckCommonCodeInfoMethod(code) &&
                   coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_EVENTS_HANDLES);
        }

        protected override CodeInfoBlockBeginEventMethod GetCodeInfoBlockBeginEventMethod(Code code)
        {
            var commonInfo = this.GetCommonCodeInfoMethod(code);

            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, " ");
            int eventName = coFac.GetCodeParts().Length - 1;

            return new CodeInfoBlockBeginEventMethod(
                code, 
                coFac,
                ",",
                commonInfo.AccessModifier, 
                commonInfo.Statement, 
                commonInfo.StatementObj, 
                commonInfo.Name, 
                commonInfo.TypeName, 
                commonInfo.Paramaters, 
                eventName);
        }

        #endregion

        #region CodeInfoMethod

        protected override bool CheckCodeInfoBlockBeginMethod(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            return this.CheckCommonCodeInfoMethod(code) &&
                   !coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_EVENTS_HANDLES);
        }

        protected override CodeInfoBlockBeginMethod GetCodeInfoBlockBeginMethod(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, " ");
            var commonInfo = this.GetCommonCodeInfoMethod(code);
            return new CodeInfoBlockBeginMethod(
                code,
                coFac,
                ",",
                commonInfo.AccessModifier,
                commonInfo.Statement, 
                commonInfo.AccessModifier, 
                commonInfo.Name, 
                commonInfo.TypeName, 
                commonInfo.Paramaters);
        }

        #endregion

        #region CodeInfoSubstitution

        protected override bool CheckCodeInfoSubstitution(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            SourceDocumentRuleVBDotNet rule = new SourceDocumentRuleVBDotNet();

            // No Begin with "If ","For ","While ", "Do "
            if (coFac.IsIncludeSomeStringInCode(rule.GetControlStatementsString()))
            {
                return false;
            }
            // No include "As"
            if (coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_AS))
            {
                return false;
            }

            // composed right-hand side and lefthand side
            if (coFac.GetCodePartsLength() < 3 || !coFac.GetCodeParts()[1].Equals(SourceDocumentSyntaxVBDotNet.CONST_EQUALS))
            {
                return false;
            }

            return true;
        }

        protected override CodeInfoSubstitution GetCodeInfoSubstitution(Code code)
        {
            CodePartsFactory coFac = new CodePartsFactoryVB(code, " ");
            int equals = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_EQUALS);
            int rightHandSide = equals + 1;
            int leftHandSide = equals - 1;

            return new CodeInfoSubstitution(code, coFac, rightHandSide, leftHandSide); 
        }

        #endregion

        #region CodeInfoBlock

        protected override CodeInfoBlockBeginIf GetCodeInfoBlockBeginIf(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeBeginIf());
            return new CodeInfoBlockBeginIf(code, coFac, segments, segments + 1);
        }

        protected override bool CheckCodeInfoBlockBeginIf(Code code)
        {
            return CheckCommonCodeInfoBlockBeginIf(code, false);
        }

        protected override CodeInfoBlockEndIf GetCodeInfoBlockEndIf(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndIf());
            return new CodeInfoBlockEndIf(code, coFac, segments);
        }

        protected override bool CheckCodeInfoBlockEndIf(Code code)
        {
            return CheckCommonCodeInfoBlockBeginIf(code, true);
        }

        protected override CodeInfoBlockBeginDoWhile GetCodeInfoBlockBeginDoWhile(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndDoWhile());
            return new CodeInfoBlockBeginDoWhile(code, coFac, segments, segments + 1);
        }

        protected override bool CheckCodeInfoBlockBeginDoWhile(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeBeginDoWhile());
        }

        protected override CodeInfoBlockEndDoWhile GetInfoBlockEndDoWhile(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVBHasParams(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndDoWhile());
            return new CodeInfoBlockEndDoWhile(code, coFac, segments);
        }

        protected override bool CheckInfoBlockEndDoWhile(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeEndDoWhile());
        }

        protected override CodeInfoBlockBeginFor GetCodeInfoBlockBeginFor(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;

            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeBeginFor());
            return new CodeInfoBlockBeginFor(code, coFac, segments, segments + 1);
        }

        protected override bool CheckCodeInfoBlockBeginFor(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeBeginFor());
        }

        protected override CodeInfoBlockEndFor GetCodeInfoBlockEndFor(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndFor());
            return new CodeInfoBlockEndFor(code, coFac, segments);
        }

        protected override bool CheckCodeInfoBlockEndFor(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeEndFor());
        }

        protected override CodeInfoBlockBeginCaseFormula GetCodeInfoBlockBeginCaseFormula(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeBeginCaseFomula());
            return new CodeInfoBlockBeginCaseFormula(code, coFac, segments, segments + 1);
        }

        protected override bool CheckCodeInfoBlockBeginCaseFormula(Code code)
        {
            return this.CheckCommonCodeInfoBlockBeginCaseFomula(code, false);   
        }

        protected override CodeInfoBlockEndCaseFormula GetCodeInfoBlockEndCaseFormula(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndCaseFomula());
            return new CodeInfoBlockEndCaseFormula(code, coFac, segments);
        }

        protected override bool CheckCodeInfoBlockEndCaseFormula(Code code)
        {
            return this.CheckCommonCodeInfoBlockBeginCaseFomula(code, true);
        }

        protected override CodeInfoBlockBeginCaseValue GetCodeInfoBlockCaseValue(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodeInfo retinfo = null;
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeCaseValue()) + 1;
            return new CodeInfoBlockBeginCaseValue(code, coFac, segments);
        }

        protected override bool CheckCodeInfoBlockCaseValue(Code code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            CodePartsFactory coFac = new CodePartsFactoryVB(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeCaseValue());
        }

        #endregion

        #endregion

        #endregion
    }
}

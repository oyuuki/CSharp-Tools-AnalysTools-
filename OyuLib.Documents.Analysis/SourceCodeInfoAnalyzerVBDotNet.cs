using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    internal class SourceCodeInfoAnalyzerVBDotNet : SourceCodeInfoAnalyzer
    {
        #region Constractor

        /// <summary>
        /// constractor
        /// </summAnalysisary>
        public SourceCodeInfoAnalyzerVBDotNet()
            : base()
        {
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="code"></param>
        public SourceCodeInfoAnalyzerVBDotNet(SourceCode code)
            : base(code)
        {
            
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="isInsiteMethod"></param>
        public SourceCodeInfoAnalyzerVBDotNet(SourceCode code, bool isInsiteMethod)
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

            private string _paramaters = string.Empty;

            #endregion

            #region Constructor

            public CommonCodeInfoMethodInfo(
                int accessModifier,
                int statement,
                int statementObj,
                int name,
                int typeName,
                string paramaters,
                SourceCodeInfoValiable[] valiables)
            {
                this._accessModifier = accessModifier;
                this._statement = statement;
                this._statementObj = statementObj;
                this._name = name;
                this._typeName = typeName;
                this._paramaters = paramaters;
            }

            #endregion

            #region Property

            public int AccessModifier
            {
                get { return this._accessModifier; }
            }

            public int Statement
            {
                get { return this._statement; }
            }

            public int StatementObj
            {
                get { return this._statementObj; }
            }

            public int Name
            {
                get { return this._name; }
            }

            public int TypeName
            {
                get { return this._typeName; }
            }

            public SourceCodeInfoParamaterMethod ParamatersFactory
            {                    
                get
                {
                    return
                        new SourceCodeInfoParamaterFactoryVBDotNetMethod(
                            0,
                            new SourceCodePartsFactoryVBDotNetEvent(new SourceCode(_paramaters)))
                            .GetSourceCodeInfoParamater();
                }
            }


            #endregion
        }

        #endregion

        #endregion

        #region Method

        #region Private

        #region CodeInfoMethod

        private bool CheckCommonCodeInfoMethod(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");

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

        private CommonCodeInfoMethodInfo GetCommonCodeInfoMethod(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsFactoryVBDotNetMethod(code);
            int methodHead = coFac.GetIndexCodeParts(new SourceDocumentRuleVBDotNet().GetMethodHead());
            int accessModifier = coFac.GetIndexCodeParts(new SourceDocumentRuleVBDotNet().GetAccessModifiersString());
            int name = methodHead + 1;
            string paramaters = coFac.GetCodeParts()[name + 1];
            int typeName = -1;

            if (coFac.GetCodeParts()[methodHead].Equals(SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_FUNCTION))
            {
                typeName = coFac.GetCodeParts().Length - 1;
            }

            return new CommonCodeInfoMethodInfo(accessModifier, methodHead, -1,name, typeName, paramaters, null);
        }

        #endregion

        #region CodeInfoValiable

        private CommonCodeInfoValiableInfo GetCommonCodeInfoVariable(SourceCode code, SourceCodePartsfactory coFac)
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

        private bool CheckCommonCodeInfoVariable(SourceCode code, SourceCodePartsfactory coFac)
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

        private bool CheckCommonCodeInfoBlock(SourceCode code, string[] blockNames)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");
            
            // include "With"
            if (!coFac.IsIncludeAllStringInCode(blockNames))
            {
                return false;
            }

            return true;
        }

        private SourceCodeInfo GetCodeInfoWithBlock(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");

            int length = coFac.GetCodeParts().Length;

            int statement = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_STATEMENT_WITH);
            int statementObjName = length - 1;

            if (!coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_END))
            {
                return new  SourceCodeInfoBlockBeginWithVB(code, coFac, statement, statementObjName);
            }
            else
            {
                return new SourceCodeInfoBlockEndWithVB(code, coFac, statement);
            }
        }

        private SourceCodeInfo GetCodeInfoSubEndBlock(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");
            int statement = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_SUB);
            return new SourceCodeInfoBlockSubEndVB(code, coFac, statement);
        }

        private SourceCodeInfo GetCodeInfoFunctionEndBlock(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");
            int statement = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_SUB);
            return new SourceCodeInfoBlockFunctionEndVB(code, coFac, statement);
        }

        #endregion

        #region CodeInfoBlockIf 
            
        private  bool CheckCommonCodeInfoBlockBeginIf(SourceCode code, bool isEnd)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeBeginIf()) && isEnd == coFac.IsIncludeStringInCode(rule.GetControlCodeEndIf());
        }

        #endregion

        #region  CodeInfoBlockBeginCaseFomula

        private bool CheckCommonCodeInfoBlockBeginCaseFomula(SourceCode code, bool isEnd)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeBeginCaseFomula()) && isEnd == coFac.IsIncludeStringInCode(rule.GetControlCodeEndCaseFomula());
        }

        #endregion

        #endregion

        #region Override

        #region GetAntherCodeInfo

        public override SourceCodeInfo GetAntherCodeInfo(SourceCode code)
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

        protected override SourceCodeInfoComment GetCodeInfoComment(SourceCode code)
        {
            return new SourceCodeInfoComment(code, new SourceCodePartsfactoryVBDotNet(code, " "));
        }

        protected override bool CheckCodeInfoComment(SourceCode code)
        {
            if (!code.CodeString.Trim().StartsWith("'"))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region CodeInfoValiable

        protected override SourceCodeInfoValiable GetCodeInfoVariable(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");
            var commonInfo = this.GetCommonCodeInfoVariable(code, coFac);
            return new SourceCodeInfoValiable(
                code, 
                coFac, 
                commonInfo.Value, 
                commonInfo.Name, 
                commonInfo.TypeName, 
                commonInfo.IsConst);
        }

        protected override bool CheckCodeInfoVariable(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");
            return this.CheckCommonCodeInfoVariable(code, coFac) && this.IsInsiteMethod;
        }

        #endregion

        #region CodeInfoMemberVariable

        protected override SourceCodeInfoMemberVariable GetCodeInfoMemberVariable(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");
            var commonInfo = this.GetCommonCodeInfoVariable(code, coFac);
            int accessModifier = coFac.GetIndexCodeParts(new SourceDocumentRuleVBDotNet().GetAccessModifiersString());
            return new SourceCodeInfoMemberVariable(code, coFac, commonInfo.Value, commonInfo.Name, commonInfo.TypeName, accessModifier, commonInfo.IsConst);
        }

        protected override bool CheckCodeInfoMemberVariable(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");
            return this.CheckCommonCodeInfoVariable(code, coFac) && !this.IsInsiteMethod;
        }

        #endregion

        #region CodeInfoCallMethod

        protected override SourceCodeInfoCallMethod GetCodeInfoCallMethod(SourceCode code)
        {
            int methodName = 0;
            int paramater = 0;

            SourceCodePartsfactory coFac = new SourceCodePartsFactoryVBDotNetMethod(code);

            if (coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_STATEMENT_CALL))
            {
                methodName = 1;
            }

            paramater = methodName + 1;

            return new SourceCodeInfoCallMethod(code, coFac, ",", methodName, paramater);
        }

        protected override bool CheckCodeInfoCallMethod(SourceCode code)
        {
            SourceDocumentRuleVBDotNet rule = new SourceDocumentRuleVBDotNet();
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");

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

        protected override bool CheckCodeInfoBlockEndMethod(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeSomeStringInCode(
                new string[]
                {
                    SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_SUB,
                    SourceDocumentSyntaxVBDotNet.CONST_METHODHEAD_FUNCTION,
                })
                   && coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_END);
        }

        protected override SourceCodeInfoBlockEndMethod GetCodeInfoBlockEndMethod(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodePartsfactory coFac = new SourceCodePartsFactoryVBDotNetMethod(code);

            int segments = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_END);
            return new SourceCodeInfoBlockEndMethod(code, coFac, segments + 1);
        }

        #endregion

        #region CodeInfoEventMethod

        protected override bool CheckCodeInfoBlockBeginEventMethod(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");
            return this.CheckCommonCodeInfoMethod(code) &&
                   coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_EVENTS_HANDLES);
        }

        protected override SourceCodeInfoBlockBeginEventMethod GetCodeInfoBlockBeginEventMethod(SourceCode code)
        {
            var commonInfo = this.GetCommonCodeInfoMethod(code);


            var coFac = new SourceCodePartsFactoryVBDotNetEvent(code);
            int eventName = coFac.GetCodeParts().Length - 1;
            int eventObjectName = coFac.GetCodeParts().Length - 2;

            return new SourceCodeInfoBlockBeginEventMethod(
                code, 
                coFac,
                ",",
                commonInfo.AccessModifier, 
                commonInfo.Statement, 
                commonInfo.StatementObj, 
                commonInfo.Name, 
                commonInfo.TypeName, 
                eventObjectName,
                eventName,
                commonInfo.ParamatersFactory);
        }

        #endregion

        #region CodeInfoMethod

        protected override bool CheckCodeInfoBlockBeginMethod(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");
            return this.CheckCommonCodeInfoMethod(code) &&
                   !coFac.IsIncludeStringInCode(SourceDocumentSyntaxVBDotNet.CONST_EVENTS_HANDLES);
        }

        protected override SourceCodeInfoBlockBeginMethod GetCodeInfoBlockBeginMethod(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsFactoryVBDotNetMethod(code);
            var commonInfo = this.GetCommonCodeInfoMethod(code);
            return new SourceCodeInfoBlockBeginMethod(
                code,
                coFac,
                ",",
                commonInfo.AccessModifier,
                commonInfo.Statement, 
                commonInfo.AccessModifier, 
                commonInfo.Name, 
                commonInfo.TypeName, 
                commonInfo.ParamatersFactory);
        }

        #endregion

        #region CodeInfoSubstitution

        protected override bool CheckCodeInfoSubstitution(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");
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

        protected override SourceCodeInfoSubstitution GetCodeInfoSubstitution(SourceCode code)
        {
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, " ");
            int equals = coFac.GetIndexCodeParts(SourceDocumentSyntaxVBDotNet.CONST_EQUALS);
            int rightHandSide = equals + 1;
            int leftHandSide = equals - 1;

            return new SourceCodeInfoSubstitution(code, coFac, rightHandSide, leftHandSide); 
        }

        #endregion

        #region CodeInfoBlock

        protected override SourceCodeInfoBlockBeginIf GetCodeInfoBlockBeginIf(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodeInfo retinfo = null;

            SourceCodePartsfactory coFac = new SourceCodePartsFactoryVBDotNetMethod(code);

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeBeginIf());
            return new SourceCodeInfoBlockBeginIf(code, coFac, segments, segments + 1);
        }

        protected override bool CheckCodeInfoBlockBeginIf(SourceCode code)
        {
            return CheckCommonCodeInfoBlockBeginIf(code, false);
        }

        protected override SourceCodeInfoBlockEndIf GetCodeInfoBlockEndIf(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodePartsfactory coFac = new SourceCodePartsFactoryVBDotNetMethod(code);

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndIf());
            return new SourceCodeInfoBlockEndIf(code, coFac, segments);
        }

        protected override bool CheckCodeInfoBlockEndIf(SourceCode code)
        {
            return CheckCommonCodeInfoBlockBeginIf(code, true);
        }

        protected override SourceCodeInfoBlockBeginDoWhile GetCodeInfoBlockBeginDoWhile(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodeInfo retinfo = null;

            SourceCodePartsfactory coFac = new SourceCodePartsFactoryVBDotNetMethod(code);

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndDoWhile());
            return new SourceCodeInfoBlockBeginDoWhile(code, coFac, segments, segments + 1);
        }

        protected override bool CheckCodeInfoBlockBeginDoWhile(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeBeginDoWhile());
        }

        protected override SourceCodeInfoBlockEndDoWhile GetInfoBlockEndDoWhile(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodePartsfactory coFac = new SourceCodePartsFactoryVBDotNetMethod(code);

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndDoWhile());
            return new SourceCodeInfoBlockEndDoWhile(code, coFac, segments);
        }

        protected override bool CheckInfoBlockEndDoWhile(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeEndDoWhile());
        }

        protected override SourceCodeInfoBlockBeginFor GetCodeInfoBlockBeginFor(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodeInfo retinfo = null;

            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeBeginFor());
            return new SourceCodeInfoBlockBeginFor(code, coFac, segments, segments + 1);
        }

        protected override bool CheckCodeInfoBlockBeginFor(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeBeginFor());
        }

        protected override SourceCodeInfoBlockEndFor GetCodeInfoBlockEndFor(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodeInfo retinfo = null;
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndFor());
            return new SourceCodeInfoBlockEndFor(code, coFac, segments);
        }

        protected override bool CheckCodeInfoBlockEndFor(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeEndFor());
        }

        protected override SourceCodeInfoBlockBeginCaseFormula GetCodeInfoBlockBeginCaseFormula(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodeInfo retinfo = null;
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeBeginCaseFomula());
            return new SourceCodeInfoBlockBeginCaseFormula(code, coFac, segments, segments + 1);
        }

        protected override bool CheckCodeInfoBlockBeginCaseFormula(SourceCode code)
        {
            return this.CheckCommonCodeInfoBlockBeginCaseFomula(code, false);   
        }

        protected override SourceCodeInfoBlockEndCaseFormula GetCodeInfoBlockEndCaseFormula(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodeInfo retinfo = null;
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeEndCaseFomula());
            return new SourceCodeInfoBlockEndCaseFormula(code, coFac, segments);
        }

        protected override bool CheckCodeInfoBlockEndCaseFormula(SourceCode code)
        {
            return this.CheckCommonCodeInfoBlockBeginCaseFomula(code, true);
        }

        protected override SourceCodeInfoBlockBeginCaseValue GetCodeInfoBlockCaseValue(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodeInfo retinfo = null;
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, this.GetSourceRule().GetCodesSeparatorString());

            int segments = coFac.GetIndexCodeParts(rule.GetControlCodeCaseValue()) + 1;
            return new SourceCodeInfoBlockBeginCaseValue(code, coFac, segments);
        }

        protected override bool CheckCodeInfoBlockCaseValue(SourceCode code)
        {
            SourceDocumentRule rule = this.GetSourceRule();
            SourceCodePartsfactory coFac = new SourceCodePartsfactoryVBDotNet(code, this.GetSourceRule().GetCodesSeparatorString());

            return coFac.IsIncludeStringInCode(rule.GetControlCodeCaseValue());
        }

        #endregion

        #endregion

        #endregion
    }
}

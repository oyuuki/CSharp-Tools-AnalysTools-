using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodeInfoParamaterFactory<TParamaterValue, TParamaterValueFactory, TParamaterElementFactory>
        where TParamaterValue : SourceCodeInfo
        where TParamaterValueFactory : SourceCodePartsfactory
        where TParamaterElementFactory : SourceCodePartsfactory
    {
        #region InstanceVal

        private int _parentIndex = -1;

        private StringRange _range = null;

        private string _paramValueSeparator = string.Empty;

        #endregion

        #region Constructor

        public SourceCodeInfoParamaterFactory(
            int parentIndex,
            StringRange range,
            string paramValueSeparator)
        {
            this._parentIndex = parentIndex;
            this._range = range;
            this._paramValueSeparator = paramValueSeparator;
        }


        #endregion

        #region Property

        public int ParentIndex
        {
            get { return this._parentIndex; }
        }

        public StringRange Range
        {
            get { return this._range; }
        }

        public string ParamValueSeparator
        {
            get { return this._paramValueSeparator; }
        }

        #endregion

        #region Method

        #region Public

        public SourceCodeInfoParamater GetSourceCodeInfoParamater()
        {
            return GetSourceCodeInfoParamater(this.GetParamaterValueFactory(this.Range.GetStringSpilited()), 1, this.Range);
        }

        #endregion

        #region Private

        #endregion

        #region Protected

        protected SourceCodeInfoParamaterValue GetSourceCodeInfoParamaterValue(
            string paramaterValueString, 
            int hierarchyCount,
            int groupCount, 
            StringRange range)
        {
            var sourceCode = new SourceCode(paramaterValueString);
            var fac = this.GetParamaterElementFactory(sourceCode.CodeString);
            string paramaterString = string.Empty;
            int paramaterStringIndex = 0;
            StringRange paramaterRange = null;


            var retValue = new SourceCodeInfoParamaterValue(this.GetSourceCodeInfoParamaterValueLogic(
                sourceCode,
                fac,
                range,
                groupCount,
                hierarchyCount),
                this.ParamValueSeparator);
            

            return retValue;
        }

        protected SourceCodeInfoParamaterValueElementStrage[] GetSourceCodeInfoParamaterValueLogicForhasReturnValue(
           SourceCode sourceCode,
           SourceCodePartsfactory fac,
           StringRange rangeParam,
           int groupCount,
           int hierarchyCount)
        {
            
            
            int parammaterName = 0;

            var paramaterStrings = fac.GetNestedCodeParts("(", ")");

            var aaa = fac.GetCodeParts();

            //var innerFacParam = new SourceCodePartsFactoryVBDotNetIfValue(sourceCode);

            //if (innerFacParam.GetCodePartsLength() >= 2)
            //{

            //}

            //var innerParamRange = new StringRange()

            var retList = new List<SourceCodeInfoParamaterValueElementStrage>();

            // Exist Paramater
            if (paramaterStrings != null && paramaterStrings.Length > 0 && !string.IsNullOrEmpty(paramaterStrings[0]) && !paramaterStrings[0].StartsWith("("))
            {
                var startIndex = 0;
                var sourceCodeString = sourceCode.CodeString.Trim();
                // セパレータ文字列を保持
                var endSeparator = rangeParam.SpilitSeparatorEnd;
                

                foreach (var param in paramaterStrings)
                {
                    var paramKakko = "(" + param + ")";

                    var paramIndex = sourceCodeString.IndexOf(paramKakko, startIndex);
                    var endIndex = paramIndex + paramKakko.Length;

                    var paramSourceCode =
                        new SourceCode(sourceCodeString.Substring(startIndex, endIndex - startIndex));
                    var range = new StringRange(startIndex, endIndex, "", "", sourceCodeString);

                    startIndex = paramIndex + paramKakko.Length;

                    retList.Add(new SourceCodeInfoParamaterValueElementStrage(SourceCodeInfoFactoryCallMethodVBDotNet.GetCodeInfoCallMethod(paramSourceCode, 
                        new StringRange(rangeParam.IndexStart, rangeParam.IndexEnd, rangeParam.SpilitSeparatorStart, ""))));
                }

                if (startIndex < sourceCodeString.Length)
                {
                    var paramValueSourceCodeString = sourceCodeString.Substring(startIndex);
                    var paramSourceCode = new SourceCode(paramValueSourceCodeString);

                    var range = new StringRange(0, paramValueSourceCodeString.Length - 1, "", "", paramValueSourceCodeString);

                    var elementst = new SourceCodeInfoParamaterValueElementStrage(new SourceCodeInfoParamaterValueElementCallMethod(
                        paramSourceCode,
                        new SourceCodePartsFactoryParamater(paramSourceCode),
                        range,
                        0,
                        groupCount,
                        hierarchyCount));

                    elementst.BefLinkValue = retList[retList.Count - 1];
                    retList[retList.Count - 1].AefLinkValue = elementst;

                    retList.Add(elementst);
                }


                if (retList[retList.Count - 1].Value is SourceCodeInfoParamaterValueElement)
                {
                    ((SourceCodeInfoParamaterValueElement)retList[retList.Count - 1].Value).Range.SpilitSeparatorEnd = endSeparator;
                }
                else if (retList[retList.Count - 1].Value is SourceCodeInfoCallMethod)
                {
                    ((SourceCodeInfoCallMethod)retList[retList.Count - 1].Value).Range.SpilitSeparatorEnd = endSeparator;
                }
                else 
                {
                    int a = 1;
                }
            }
            else
            {
                retList.Add(new SourceCodeInfoParamaterValueElementStrage(new SourceCodeInfoParamaterValueElement(sourceCode, new SourceCodePartsFactoryParamater(sourceCode), rangeParam,
                    parammaterName, groupCount, hierarchyCount)));
            }

            return retList.ToArray();
        }

        

        #endregion

        #region Virtual

        public virtual SourceCodeInfoParamater GetSourceCodeInfoParamater(SourceCodePartsfactory factory, int hierarchyCount, StringRange range)
        {
            var retList = new List<SourceCodeInfoParamaterValue>();

            var codeparts = factory.GetCodeParts();
            var codeRanges = factory.GetCodePartsRanges();

            for (int index = 0; index < codeparts.Length; index++)
            {
                retList.Add(this.GetSourceCodeInfoParamaterValue(codeparts[index], hierarchyCount, index, codeRanges[index]));
            }

            if (retList.Count > 0)
            { 
                // 最後のパラメータにセパレータはつけない
                retList[retList.Count - 1].Separator = string.Empty;
            }

            return new SourceCodeInfoParamater(retList.ToArray());
        }

        #endregion

        #region Abstract


        protected abstract SourceCodeInfoParamaterValueElementStrage[] GetSourceCodeInfoParamaterValueLogic
            (SourceCode sourceCode,
            SourceCodePartsfactory fac,
            StringRange rangeParam,
            int groupCount,
            int hierarchyCount);

        protected abstract TParamaterValueFactory GetParamaterValueFactory(string paramaterString);
        protected abstract TParamaterElementFactory GetParamaterElementFactory(string paramaterString);

        #endregion

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodeInfoParamaterFactory<TParamaterValue, TParamater, TFactory>
        where TParamaterValue : SourceCodeInfo
        where TParamater : SourceCodeInfoParamater
        where TFactory : SourceCodePartsfactory
    {
        #region InstanceVal

        private int _parentIndex = -1;

        private StringRange _range = null;

        #endregion

        #region Constructor

        public SourceCodeInfoParamaterFactory(
            int parentIndex,
            StringRange range)
        {
            this._parentIndex = parentIndex;
            this._range = range;
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

        #endregion

        #region Method

        #region Public

        public TParamater GetSourceCodeInfoParamater(SourceCodePartsfactory factory, int hierarchyCount, StringRange range)
        {
            var retList = new List<TParamaterValue>();
            
            var codeparts = factory.GetCodeParts();
            var codeRanges = factory.GetCodePartsRanges();

            for (int index = 0; index < codeparts.Length; index++)
            {
                retList.AddRange(this.GetSourceCodeInfoParamaterValue(codeparts[index], hierarchyCount, index, codeRanges[index]));
            }

            return this.GetSourceCodeInfoParamater(retList.ToArray());
        }

        public TParamater GetSourceCodeInfoParamater()
        {
            return GetSourceCodeInfoParamater(this.GetFactory(this.Range.GetStringSpilited()), 1, this.Range);
        }

        #endregion

        #region Private

        #endregion

        #region Protected

        protected TParamaterValue[] GetSourceCodeInfoParamaterValue(
            string paramaterValueString, 
            int hierarchyCount,
            int groupCount, 
            StringRange range)
        {
            var sourceCode = new SourceCode(paramaterValueString);
            var fac = this.GetSourceCodePartsFactoryParamaterValue(sourceCode);
            string paramaterString = string.Empty;
            int paramaterStringIndex = 0;
            StringRange paramaterRange = null;

            var retValue = this.GetSourceCodeInfoParamaterValueLogic(
                sourceCode, 
                fac, 
                range, 
                groupCount,  
                hierarchyCount);

            return retValue;
        }

        protected SourceCodeInfo[] GetSourceCodeInfoParamaterValueLogicForhasReturnValue(
           SourceCode sourceCode,
           SourceCodePartsfactory fac,
           StringRange rangeParam,
           int groupCount,
           int hierarchyCount)
        {
            int parammaterName = 0;

            var paramaterStrings = fac.GetNestedCodeParts("(", ")");

            //var innerFacParam = new SourceCodePartsFactoryVBDotNetIfValue(sourceCode);

            //if (innerFacParam.GetCodePartsLength() >= 2)
            //{
                
            //}
                
            //var innerParamRange = new StringRange()

            var retList = new List<SourceCodeInfo>();

            // Exist Paramater
            if (paramaterStrings != null && paramaterStrings.Length > 0 && !string.IsNullOrEmpty(paramaterStrings[0]) && !paramaterStrings[0].StartsWith("("))
            {
                var startIndex = 0;
                var sourceCodeString = sourceCode.CodeString.Trim();

                foreach (var param in paramaterStrings)
                {
                    var paramKakko = "(" + param + ")";

                    var paramIndex = sourceCodeString.IndexOf(paramKakko, startIndex);
                    var endIndex = paramIndex + paramKakko.Length;
                    var paramSourceCode =
                        new SourceCode(sourceCodeString.Substring(startIndex, endIndex - startIndex));
                    var range = new StringRange(startIndex, endIndex, "", "", sourceCodeString);
                    startIndex = endIndex;
                    retList.Add(SourceCodeInfoFactoryCallMethodVBDotNet.GetCodeInfoCallMethod(paramSourceCode, rangeParam));
                }

                if (startIndex < sourceCodeString.Length)
                {
                    var paramValueSourceCodeString = sourceCodeString.Substring(startIndex);
                    var paramSourceCode = new SourceCode(paramValueSourceCodeString);

                    var range = new StringRange(0, paramValueSourceCodeString.Length - 1, "", "", paramValueSourceCodeString);
                    retList.Add(new SourceCodeInfoParamaterValueCallMethod(
                        paramSourceCode,
                        new SourceCodePartsFactoryParamater(paramSourceCode),
                        range,
                        0,
                        groupCount, 
                        hierarchyCount));
                }
            }
            else
            {
                retList.Add(new SourceCodeInfoParamaterValueCallMethod(sourceCode, new SourceCodePartsFactoryParamater(sourceCode), rangeParam,
                    parammaterName, groupCount, hierarchyCount));
            }

            return retList.ToArray();
        }

        

        #endregion



        #region Abstract

        protected abstract TParamaterValue[] GetSourceCodeInfoParamaterValueLogic
            (SourceCode sourceCode,
            SourceCodePartsfactory fac,
            StringRange rangeParam,
            int groupCount,
            int hierarchyCount);
        protected abstract TParamater GetSourceCodeInfoParamater(TParamaterValue[] values);
        protected abstract TFactory GetFactory(string paramaterString);
        // protected abstract TParamater GetChildParamater(int codepartIndex, TParamaterValue[] values);
        protected abstract SourceCodePartsfactory GetSourceCodePartsFactoryParamaterValue(SourceCode sourceCode);

        #endregion

        #endregion
    }
}

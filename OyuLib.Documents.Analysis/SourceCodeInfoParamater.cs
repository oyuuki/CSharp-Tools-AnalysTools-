using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamater
    {
        #region instanceVal

        private SourceCodeInfo[] _sourceCodeInfoParamaterValues = null;


        #endregion

        #region Constructor

        public SourceCodeInfoParamater(
            SourceCodeInfo[] sourceCodeInfoParamaterValues)
        {
            this._sourceCodeInfoParamaterValues = sourceCodeInfoParamaterValues;
        }

        #endregion

        #region Property

        public SourceCodeInfo[] ParamaterValues
        {
            get { return this._sourceCodeInfoParamaterValues; }
        }

        public bool HasParamater
        {
            get { return this.ParamaterValues != null && this.ParamaterValues.Length > 0; }
        }

        #endregion


        #region Method

        #region Public

        public void ChangeParamaterIndex(int index1, int index2)
        {
            var index1Paramater = this.ParamaterValues[index1];

            this.ParamaterValues[index1] = this.ParamaterValues[index2];
            this.ParamaterValues[index2] = index1Paramater;
        }

        public SourceCodeInfoParamaterValue[] GetSourceCodeInfoParamaterValue()
        {
            return this.GetSourceCodeInfoParamaterValue(this.ParamaterValues);
        }

        public SourceCodeInfo[] GetAllSourceCodeInfos()
        {
            return this.GetAllSourceCodeInfos(this.ParamaterValues);
        }

        private SourceCodeInfo[] GetAllSourceCodeInfos(SourceCodeInfo[] paramaterValues)
        {
            var retList = new List<SourceCodeInfo>();

            foreach (var value in paramaterValues)
            {
                if (value is SourceCodeInfoParamaterValue)
                {
                    retList.Add((SourceCodeInfo)value);
                }
                else if (value is IParamater)
                {
                    var iparaVal = value;
                    retList.Add(iparaVal);
                    retList.AddRange(this.GetAllSourceCodeInfos(((IParamater)iparaVal).GetSourceCodeInfoParamater().ParamaterValues));
                }
            }

            return retList.ToArray();
        }

        private SourceCodeInfoParamaterValue[] GetSourceCodeInfoParamaterValue(SourceCodeInfo[] paramaterValues)
        {
            var retList = new List<SourceCodeInfoParamaterValue>();

            foreach (var value in paramaterValues)
            {
                if (value is SourceCodeInfoParamaterValue)
                {
                    retList.Add((SourceCodeInfoParamaterValue)value);
                }
                else if (value is IParamater)
                {
                    var iparaVal = (IParamater)value;
                    retList.AddRange(this.GetSourceCodeInfoParamaterValue(iparaVal.GetSourceCodeInfoParamater().ParamaterValues));
                } 
            }

            return retList.ToArray();
        }

        public StringRange[] GetStringRange()
        {
            return this.GetStringRange(this.ParamaterValues);
        }

        private StringRange[] GetStringRange(SourceCodeInfo[] paramaters)
        {
            var retList = new List<StringRange>();

            foreach (var val in paramaters)
            {
                if (val is SourceCodeInfoParamaterValue)
                {
                    var range = ((SourceCodeInfoParamaterValue) val).Range;
                    range.Childs = val.GetCodeRanges();

                    retList.Add(range);
                }
                else if (val is IParamater)
                {
                    var iparaVal = (IParamater) val;
                    var range = iparaVal.Range;
                    range.Childs = this.GetStringRange(iparaVal.GetSourceCodeInfoParamater().ParamaterValues);
                }
            }

            return retList.ToArray();
        }


        public NestIndex[] GetNestIndex()
        {
            var retList = new List<NestIndex>();

            foreach (var val in ParamaterValues)
            {
                NestIndex paramValuesHead = new NestIndex(-1);
                paramValuesHead.Childs = val.GetNestIndices();

                retList.Add(paramValuesHead);
            }

            return retList.ToArray();
        }

        private SourceCodeInfoParamaterValue[] GetParamaterValue(string paramaterString,
            SourceCodeInfoParamater paramater)
        {
            var retList = new List<SourceCodeInfoParamaterValue>();

            if (!paramater.HasParamater)
            {
                return null;    
            }

            foreach (var value in paramater.ParamaterValues)
            {
                if (value is SourceCodeInfoParamaterValue)
                {
                    var paramValue = (SourceCodeInfoParamaterValue)value;

                    if (paramValue.ParamaterName.Equals(paramaterString))
                    {
                        retList.Add(paramValue);
                    }    
                }
                else if (value is IParamater)
                {
                    var valueHaveparam = (IParamater)value;

                    var param = valueHaveparam.GetSourceCodeInfoParamater();

                    if (param.HasParamater)
                    {
                        retList.AddRange(this.GetParamaterValue(paramaterString, param));
                    }
                }
            }

            return retList.ToArray();
        }

        public SourceCodeInfoParamaterValue[] GetParamaterValue(string paramaterString)
        {
            return this.GetParamaterValue(paramaterString, this);
        }

        #endregion

        public string GetParamaterOverWriteValues()
        {
            return this.GetParamaterOverWriteValues(this.ParamaterValues);
        }

        private string GetParamaterOverWriteValues(SourceCodeInfo[] ParamaterValues)
        {
            var strBu = new StringBuilder();

            foreach (var value in ParamaterValues)
            {
                if (value is SourceCodeInfoParamaterValue)
                {
                    var paramValue = (SourceCodeInfoParamaterValue)value;
                    strBu.Append(paramValue.Range.SpilitSeparatorStart);
                    strBu.Append(value.GetCodePartsOverWriteValues());
                    strBu.Append(paramValue.Range.SpilitSeparatorEnd);
                }
                else if (value is IParamater)
                {
                    var range = ((IParamater) value).Range;

                    strBu.Append(range.SpilitSeparatorStart);
                    strBu.Append(value.GetCodePartsOverWriteValues());
                    strBu.Append(range.SpilitSeparatorEnd);
                }
            }

            return strBu.ToString();
        }
    

    #endregion
    }
}

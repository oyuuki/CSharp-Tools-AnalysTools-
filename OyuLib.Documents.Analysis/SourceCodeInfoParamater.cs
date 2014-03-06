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

        private SourceCodeInfoParamaterValue[] _sourceCodeInfoParamaterValues = null;


        #endregion

        #region Constructor

        public SourceCodeInfoParamater(
            SourceCodeInfoParamaterValue[] sourceCodeInfoParamaterValues)
        {
            this._sourceCodeInfoParamaterValues = sourceCodeInfoParamaterValues;
        }

        #endregion

        #region Property

        public SourceCodeInfoParamaterValue[] ParamaterValues
        {
            get { return this._sourceCodeInfoParamaterValues; }
            set { this._sourceCodeInfoParamaterValues = value ; }
        }

        public bool HasParamater
        {
            get { return this.ParamaterValues != null && this.ParamaterValues.Length > 0; }
        }

        #endregion


        #region Method

        #region Public

        public int ParamaterLength()
        {
            if(this.ParamaterValues == null)
            {
                return 0;
            }

            return this.ParamaterValues.Length;
        }

        public void ChangeParamaterIndex(int index1, int index2)
        {
            try
            {
                var index1separator = this.ParamaterValues[index1].Separator;
                var index2separator = this.ParamaterValues[index2].Separator;
                var index1Paramater = this.ParamaterValues[index1];

                this.ParamaterValues[index1] = this.ParamaterValues[index2];
                this.ParamaterValues[index2] = index1Paramater;

                this.ParamaterValues[index1].Separator = index1separator;
                this.ParamaterValues[index2].Separator = index2separator;
            }
            catch(IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException("Indexに存在しない要素を指定しています。");
            }
        }

        public SourceCodeInfoParamaterValueElement[] GetSourceCodeInfoParamaterValue()
        {
            return this.GetSourceCodeInfoParamaterValue(this.ParamaterValues);
        }

        public SourceCodeInfo[] GetAllSourceCodeInfos()
        {
            return this.GetAllSourceCodeInfos(this.ParamaterValues);
        }

        private SourceCodeInfo[] GetAllSourceCodeInfos(SourceCodeInfoParamaterValue[] paramaterValues)
        {
            var retList = new List<SourceCodeInfo>();

            foreach (var value in paramaterValues)
            {
                foreach (var element in value.ElementStrages)
                {
                    var elementValue = element.Value;

                    if (elementValue is SourceCodeInfoParamaterValueElement)
                    {
                        retList.Add((SourceCodeInfo)elementValue);
                    }
                    else if (elementValue is IParamater)
                    {
                        var iparaVal = elementValue;
                        retList.Add(iparaVal);

                        foreach (var param in ((IParamater)iparaVal).GetSourceCodeInfoParamaters())
                        {
                            retList.AddRange(this.GetAllSourceCodeInfos(param.ParamaterValues));
                        }
                    }
                }
            }

            return retList.ToArray();
        }

        private SourceCodeInfoParamaterValueElement[] GetSourceCodeInfoParamaterValue(SourceCodeInfoParamaterValue[] paramaterValues)
        {
            var retList = new List<SourceCodeInfoParamaterValueElement>();

            foreach (var value in paramaterValues)
            {
                foreach (var element in value.ElementStrages)
                {
                    var elementValue = element.Value;

                    if (elementValue is SourceCodeInfoParamaterValueElement)
                    {
                        retList.Add((SourceCodeInfoParamaterValueElement)elementValue);
                    }
                    else if (elementValue is IParamater)
                    {
                        var iparaVal = (IParamater)elementValue;

                        foreach (var param in iparaVal.GetSourceCodeInfoParamaters())
                        {
                            retList.AddRange(this.GetSourceCodeInfoParamaterValue(param.ParamaterValues));
                        }
                    }
                }
            }

            return retList.ToArray();
        }

        public StringRange[] GetStringRange()
        {
            return this.GetStringRange(this.ParamaterValues);
        }

        private StringRange[] GetStringRange(SourceCodeInfoParamaterValue[] paramaters)
        {
            var retList = new List<StringRange>();

            foreach (var val in paramaters)
            {
                foreach (var element in val.ElementStrages)
                {
                    var elementValue = element.Value;

                    if (elementValue is SourceCodeInfoParamaterValueElement)
                    {
                        var range = ((SourceCodeInfoParamaterValueElement)elementValue).Range;
                        range.Childs = elementValue.GetCodeRanges();

                        retList.Add(range);
                    }
                    else if (elementValue is IParamater)
                    {
                        var iparaVal = (IParamater)elementValue;
                        var range = iparaVal.Range;

                        foreach (var param in iparaVal.GetSourceCodeInfoParamaters())
                        {
                            range.Childs = this.GetStringRange(param.ParamaterValues);
                        }
                    }
                }
            }

            return retList.ToArray();
        }


        public NestIndex[] GetNestIndex()
        {
            var retList = new List<NestIndex>();

            foreach (var val in this.ParamaterValues)
            {
                foreach (var elemental in val.ElementStrages)
                {
                    var elementalValue = elemental.Value;

                    NestIndex paramValuesHead = new NestIndex(-1);
                    paramValuesHead.Childs = elementalValue.GetNestIndices();

                    retList.Add(paramValuesHead);
                }
            }

            return retList.ToArray();
        }

        private SourceCodeInfoParamaterValueElement[] GetParamaterValue(string paramaterString,
            SourceCodeInfoParamater paramater)
        {
            var retList = new List<SourceCodeInfoParamaterValueElement>();

            if (!paramater.HasParamater)
            {
                return null;    
            }

            foreach (var value in paramater.ParamaterValues)
            {
                foreach (var element in value.ElementStrages)
                {
                    var elementValue = element.Value;

                    if (elementValue is SourceCodeInfoParamaterValueElement)
                    {
                        var paramValue = (SourceCodeInfoParamaterValueElement)elementValue;

                        if (paramValue.ParamaterName.Equals(paramaterString))
                        {
                            retList.Add(paramValue);
                        }
                    }
                    else if (elementValue is IParamater)
                    {
                        var valueHaveparam = (IParamater)elementValue;


                        foreach (var param in valueHaveparam.GetSourceCodeInfoParamaters())
                        {
                            if (param.HasParamater)
                            {
                                retList.AddRange(this.GetParamaterValue(paramaterString, param));
                            }
                        }
                    }
                }
            }

            return retList.ToArray();
        }

        public SourceCodeInfoParamaterValueElement[] GetParamaterValue(string paramaterString)
        {
            return this.GetParamaterValue(paramaterString, this);
        }

        #endregion

        public string GetParamaterOverWriteValues()
        {
            return this.GetParamaterOverWriteValues(this.ParamaterValues);
        }

        private string GetParamaterOverWriteValues(SourceCodeInfoParamaterValue[] ParamaterValues)
        {
            var strBu = new StringBuilder();

            foreach (var value in ParamaterValues)
            {
                foreach(var element in value.ElementStrages)
                {
                    var elementValue = element.Value;

                    if (elementValue is SourceCodeInfoParamaterValueElement)
                    {
                        var paramValue = (SourceCodeInfoParamaterValueElement)elementValue;
                        strBu.Append(paramValue.Range.SpilitSeparatorStart);
                        strBu.Append(elementValue.GetCodePartsOverWriteValues());
                        strBu.Append(paramValue.Range.SpilitSeparatorEnd);
                    }
                    else if (elementValue is IParamater)
                    {
                        var range = ((IParamater)elementValue).Range;

                        strBu.Append(range.SpilitSeparatorStart);
                        strBu.Append(elementValue.GetCodePartsOverWriteValues());
                        strBu.Append(range.SpilitSeparatorEnd);
                    }
                }

                strBu.Append(value.Separator);
            }

            return strBu.ToString();
        }
    

    #endregion
    }
}

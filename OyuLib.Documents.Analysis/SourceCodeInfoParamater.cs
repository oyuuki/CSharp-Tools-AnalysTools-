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

        private StringRange _range = null;
        

        #endregion

        #region Constructor

        public SourceCodeInfoParamater(
            SourceCodeInfoParamaterValue[] sourceCodeInfoParamaterValues,
            StringRange range)
        {
            this._sourceCodeInfoParamaterValues = sourceCodeInfoParamaterValues;
            this._range = range;
        }

        #endregion

        #region Property

        public SourceCodeInfoParamaterValue[] ParamaterValues
        {
            get { return this._sourceCodeInfoParamaterValues; }
            set { this._sourceCodeInfoParamaterValues = value; }
        }

        public bool HasParamater
        {
            get { return this.ParamaterValues != null && this.ParamaterValues.Length > 0; }
        }

        #endregion


        #region Method

        public StringRange[] GetStringRange()
        {
            var retList = new List<StringRange>();

            foreach (var val in this.ParamaterValues)
            {
                var range = val.Range;
                range.Childs = val.GetCodeRanges();

                retList.Add(range);                
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

        private SourceCodeInfoParamaterValue[] GetParamaterValue(string paramaterString, SourceCodeInfoParamater paramater)
        {
            var retList = new List<SourceCodeInfoParamaterValue>();

            if (!paramater.HasParamater)
            {
                return null;    
            }

            foreach (var value in paramater.ParamaterValues)
            {
                if (value.ParammaterName.Equals(paramaterString))
                {
                    retList.Add(value);
                }

                if (value.hasChild)
                {
                    retList.AddRange(this.GetParamaterValue(paramaterString, value.ChildParamater));
                }
            }

            return retList.ToArray();
        }

        public SourceCodeInfoParamaterValue[] GetParamaterValue(string paramaterString)
        {
            return this.GetParamaterValue(paramaterString, this);
        }

        #endregion
    }
}

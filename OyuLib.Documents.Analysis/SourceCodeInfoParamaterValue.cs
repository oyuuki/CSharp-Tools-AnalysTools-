using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterValue
    {
        #region InstanceVal

        private SourceCodeInfoParamaterValueElementStrage[] _elementStrages = null;

        private string _separator = string.Empty;

        #endregion

        #region Constructor

        public SourceCodeInfoParamaterValue(
            SourceCodeInfoParamaterValueElementStrage[] elementStrages,
            string separator)
        {
            this._elementStrages = elementStrages;
            this._separator = separator;
        }

        #endregion

        #region Property

        public SourceCodeInfoParamaterValueElementStrage[] ElementStrages
        {
            get { return this._elementStrages; }
        }

        public string Separator
        {
            get { return this._separator; }
            set { this._separator = value; }
        }

        #endregion

        #region Method

        #region Public

        public string GetCodeString()
        {
            return this.GetCodeString(this.ElementStrages);
        }

        public void ReSetElementStrages(SourceCodeInfoParamaterValueElementStrage[] value)
        {
            this._elementStrages = value;
        }

        #endregion

        #region Private

        public string GetCodeString(SourceCodeInfoParamaterValueElementStrage[] elementStrages)
        {
            StringBuilder strBu = new StringBuilder();

            foreach (var element in elementStrages)
            {
                string separatorStart = string.Empty;
                string separatorEnd = string.Empty;

                if (element.Value is SourceCodeInfoParamaterValueElement)
                {
                    separatorStart = ((SourceCodeInfoParamaterValueElement)element.Value).BefSymbol;
                    separatorEnd = ((SourceCodeInfoParamaterValueElement)element.Value).AetSymbol;
                }
                strBu.Append(separatorStart);                
                strBu.Append(element.Value.GetCodeString());      
                strBu.Append(separatorEnd);                
            }

            return strBu.ToString();
        }

        #endregion

        #endregion
    }
}

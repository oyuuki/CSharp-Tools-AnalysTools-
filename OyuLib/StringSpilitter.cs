using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib
{
    public class StringSpilitter
    {
        #region instanceVal

        private string _targetString = string.Empty;

        #endregion

        #region constructor

        public StringSpilitter(string targetString)
        {
            this._targetString = targetString;
        }

        #endregion

        #region Property

        public string TargetString
        {
            get { return this._targetString; }
            set { this._targetString = value; }
        }

        #endregion

        #region Method

        public string[] GetSpilitStringSomeNested(string strSeparator, NestingString nStr)
        {
            var retlist = new List<string>();
            var startIndex = 0;
            var indexPareArray = nStr.GetIndexPareArray(this.TargetString);
            var nStrIndex = 0;

            for (int index = 0; index < this.TargetString.Length; index++)
            {
                var indexPare = indexPareArray[nStrIndex];

                if (indexPare.IndexStart == index)
                {
                    if (startIndex != indexPare.IndexStart)
                    {
                        retlist.Add(this.TargetString.Substring(startIndex, indexPare.IndexStart - startIndex));                        
                    }

                    retlist.Add(this.TargetString.Substring(indexPare.IndexStart, indexPare.IndexEnd - indexPare.IndexStart));
                    startIndex = index + 1;
                    index = indexPare.IndexEnd;
                }
                else if (this.TargetString[index].ToString().Equals(strSeparator))
                {
                    retlist.Add(this.TargetString.Substring(startIndex, index - startIndex));
                    startIndex = index + 1;                    
                }
            }

            return retlist.ToArray();
        }

        #endregion

    }
}

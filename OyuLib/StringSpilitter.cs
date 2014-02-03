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

        public string[] GetSpilitStringNoChilds(string strSeparator, ManagerStringNested nStr)
        {
            var retList = new List<string>();

            foreach (var range in this.GetStringRangeSpilit(strSeparator, nStr))
            {
                retList.Add(this.TargetString.Substring(range.IndexStart, range.CutStringCount));
            }

            return retList.ToArray();
        }

        public string[] GetSpilitStringNoChilds(ManagerStringNested nStr)
        {
            var retList = new List<string>();

            //foreach (var range in this.GetStringRangeSpilit(nStr.GetStringRangeArray(this.TargetString), strSeparator, nStr, 0, this.TargetString.Length))
            {
              //  retList.Add(this.TargetString.Substring(range.IndexStart, range.CutStringCount));
            }

            return retList.ToArray();
        }

        public StringRange[] GetStringRangeSpilit(string strSeparator, ManagerStringNested nStr)
        {
            return this.GetStringRangeSpilit(
                nStr.GetStringRangeArray(this.TargetString), 
                strSeparator, 
                0,
                this.TargetString.Length - 1);
        }

        public StringRange[] GetStringRangeSpilit(StringRange[] indexPareArray, string strSeparator, int initIndex, int endIndex)
        {
            var retlist = new List<StringRange>();
            var startIndex = initIndex;
            var nStrIndex = 0;

            for (int index = initIndex; index <= endIndex; index++)
            {
                if (indexPareArray.Length > nStrIndex && indexPareArray[nStrIndex].IndexStart == index)
                {
                    var stringRange = indexPareArray[nStrIndex];

                    if (startIndex != stringRange.IndexStart)
                    {
                        retlist.Add(new StringRange(startIndex, stringRange.IndexStart - 1, stringRange.SpilitStrings));
                        // retlist.Add(this.TargetString.Substring(startIndex, indexPare.IndexStart - startIndex));                        
                    }

                    retlist.Add(new StringRange(stringRange.IndexStart + 1, stringRange.IndexEnd - 1));

                    if (stringRange.Childs != null)
                    {
                        retlist[retlist.Count - 1].Childs = GetStringRangeSpilit(stringRange.Childs, strSeparator, index + 1, stringRange.IndexEnd - 1);
                    }

                    // retlist.Add(this.TargetString.Substring(indexPare.IndexStart, indexPare.IndexEnd - indexPare.IndexStart + 1));
                    index = stringRange.IndexEnd;
                    startIndex = index + 1;
                    nStrIndex++;
                }
                else if (this.TargetString[index].ToString().Equals(strSeparator))
                {
                    retlist.Add(new StringRange(startIndex, index - 1, strSeparator));
                    // retlist.Add(this.TargetString.Substring(startIndex, index - startIndex));
                    startIndex = index + 1;                    
                }
            }


            if (startIndex < endIndex)
            {
                retlist.Add(new StringRange(startIndex, endIndex));
                //retlist.Add(this.TargetString.Substring(startIndex, this.TargetString.Length - startIndex));
            }

            return retlist.ToArray();
        }

        #endregion

    }
}

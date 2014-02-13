using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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



        public StringRange[] GetHierarchicalStringWithRangeSpilit(string strSeparator, ManagerStringNested nStr)
        {
            return this.GetHierarchicalStringWithRangeSpilit(
                nStr.GetStringRangeArray(this.TargetString), 
                strSeparator, 
                0,
                this.TargetString.Length - 1);
        }

        public StringRange[] GetHierarchicalStringWithRangeSpilit(StringRange[] indexPareArray, string strSeparator, int initIndex, int endIndex)
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
                        retlist.Add(new StringRange(startIndex, stringRange.IndexStart - 1, string.Empty, strSeparator, this.TargetString));
                        // retlist.Add(this.TargetString.Substring(startIndex, indexPare.IndexStart - startIndex));                        
                    }

                    if (retlist.Count > 0)
                    {
                        List<StringRange> childList = null;

                        if (retlist[retlist.Count - 1].Childs != null)
                        {
                            childList = new List<StringRange>(retlist[retlist.Count - 1].Childs);                            
                        }
                        else
                        {
                            childList = new List<StringRange>();                            
                        }

                        childList.Add(new StringRange(stringRange.IndexStart + 1, stringRange.IndexEnd - 1, stringRange.SpilitSeparatorStart, stringRange.SpilitSeparatorEnd, this.TargetString));
                        retlist[retlist.Count - 1].Childs = childList.ToArray();
                    }
                    else
                    {
                        retlist.Add(new StringRange(stringRange.IndexStart + 1, stringRange.IndexEnd - 1, stringRange.SpilitSeparatorStart, stringRange.SpilitSeparatorEnd, this.TargetString));
                    }


                    if (stringRange.Childs != null)
                    {
                        retlist[retlist.Count - 1].Childs = GetHierarchicalStringWithRangeSpilit(stringRange.Childs, strSeparator, index + 1, stringRange.IndexEnd - 1);
                    }

                    // retlist.Add(this.TargetString.Substring(indexPare.IndexStart, indexPare.IndexEnd - indexPare.IndexStart + 1));
                    index = stringRange.IndexEnd;
                    startIndex = index + 1;
                    nStrIndex++;
                }
                else if (FindSeparatorinTargetString(this.TargetString, index, strSeparator))
                {
                    
                    retlist.Add(new StringRange(startIndex, index - 1, string.Empty, strSeparator, this.TargetString));
                    // retlist.Add(this.TargetString.Substring(startIndex, index - startIndex));
                    startIndex = index + strSeparator.Length + 1;
                    index = startIndex - 1;
                    break;
                }
            }


            if (startIndex < endIndex)
            {
                retlist.Add(new StringRange(startIndex, endIndex, this.TargetString, this.TargetString));
                //retlist.Add(this.TargetString.Substring(startIndex, this.TargetString.Length - startIndex));
            }

            return retlist.ToArray();
        }

        public string[] GetSpilitStringNoChilds(string strSeparator, ManagerStringNested nStr)
        {
            return GetSpilitStringNoChilds(this.GetStringRangeSpilit(strSeparator, nStr));
        }

        public string[] GetSpilitStringNoChilds(StringRange[] ranges)
        {
            var retList = new List<string>();

            foreach (var range in ranges)
            {
                retList.Add(range.GetStringSpilited());
            }

            return retList.ToArray();
        }

        private static bool FindSeparatorinTargetString(string targetString, int index, string strSeparator)
        {
            var targetLength = targetString.Length;
            var separatorLength = strSeparator.Length;

            if (index + separatorLength >= targetLength)
            {
                return false;
            }

            return targetString.Substring(index, strSeparator.Length).ToString().Equals(strSeparator);
        }

        private static int GetMaxLoopValue(string targetString, string strSeparator)
        {
            return targetString.Length - strSeparator.Length;
        }

        public StringRange[] GetStringRangeSpilit(string strSeparator)
        {
            var retlist = new List<StringRange>();
            var startIndex = 0;

            for (int index = 0; index < GetMaxLoopValue(this.TargetString, strSeparator); index++)
            {
                if (FindSeparatorinTargetString(this.TargetString, index, strSeparator))
                {
                    retlist.Add(new StringRange(startIndex, index - 1, string.Empty, strSeparator, this.TargetString));
                    // retlist.Add(this.TargetString.Substring(startIndex, index - startIndex));
                    startIndex = index + strSeparator.Length;
                    index = startIndex - 1;
                    break;
                }
            }

            if (startIndex < this.TargetString.Length)
            {
                retlist.Add(new StringRange(startIndex, this.TargetString.Length - 1, string.Empty, string.Empty, this.TargetString));
                //retlist.Add(this.TargetString.Substring(startIndex, this.TargetString.Length - startIndex));
            }

            return retlist.ToArray();
        }

        public static StringRange[] GetStringRangeSpilit(StringRange range, string strSeparator)
        {
            var retlist = new List<StringRange>();
            var startIndex = range.IndexStart;
            var maxLength = range.IndexEnd;

            if (range.IndexEnd == range.TargetString.Length - 1)
            {
                maxLength = GetMaxLoopValue(range.TargetString, strSeparator);
            }

            for (int index = startIndex; index < maxLength; index++)
            {
                if (FindSeparatorinTargetString(range.TargetString, index, strSeparator))
                {
                    retlist.Add(new StringRange(startIndex, index - 1, string.Empty, strSeparator, range.TargetString));
                    // retlist.Add(this.TargetString.Substring(startIndex, index - startIndex));
                    startIndex = index + strSeparator.Length;
                    index = startIndex - 1;
                    break;
                }
            }

            if (startIndex < range.TargetString.Length)
            {
                retlist.Add(new StringRange(startIndex, range.TargetString.Length - 1, string.Empty, string.Empty, range.TargetString));
                //retlist.Add(this.TargetString.Substring(startIndex, this.TargetString.Length - startIndex));
            }

            return retlist.ToArray();
        }

        public StringRange[] GetStringRangeSpilitIncludeNestedString(string strSeparator, ManagerStringNested nStr)
        {
            return GetStringRangeSpilitIncludeNestedString(new string[] {strSeparator}, nStr);
        }

        public StringRange[] GetStringRangeSpilitIncludeNestedString(string[] strSeparators, ManagerStringNested nStr)
        {
            var retlist = new List<StringRange>();
            var startIndex = 0;
            var indexPareArray = nStr.GetStringRangeArray(this.TargetString);
            var nStrIndex = 0;

            for (int index = 0; index < this.TargetString.Length; index++)
            {
                if (indexPareArray.Length > nStrIndex &&
                    indexPareArray[nStrIndex].IndexEnd < index)
                {
                    nStrIndex++;
                }
                foreach (var strSeparator in strSeparators)
                {
                    if (FindSeparatorinTargetString(this.TargetString, index, strSeparator))
                    {

                        if (indexPareArray.Length > nStrIndex &&
                            indexPareArray[nStrIndex].IndexStart <= index &&
                            indexPareArray[nStrIndex].IndexEnd >= index)
                        {
                            continue;
                        }
                        retlist.Add(new StringRange(startIndex, index - 1, string.Empty, strSeparator, this.TargetString));

                        // retlist.Add(this.TargetString.Substring(startIndex, index - startIndex));
                        startIndex = index + strSeparator.Length;
                        index = startIndex - 1;
                        break;
                    }
                }
            }


            if (startIndex < this.TargetString.Length)
            {
                retlist.Add(new StringRange(startIndex, this.TargetString.Length - 1, string.Empty, string.Empty, this.TargetString));

                
                //retlist.Add(this.TargetString.Substring(startIndex, this.TargetString.Length - startIndex));
            }

            return retlist.ToArray();
        }


        private StringRange[] GetStringRangeSpilitLogic(string[] strSeparatores, StringRange[] stringRanges)
        {
            var retlist = new List<StringRange>();
            var startIndex = 0;
            var indexPareArray = stringRanges;
            var nStrIndex = 0;

            for (int index = 0; index < this.TargetString.Length; index++)
            {
                if (indexPareArray.Length > nStrIndex && indexPareArray[nStrIndex].IndexStart == index)
                {
                    var stringRange = indexPareArray[nStrIndex];

                    if (startIndex != stringRange.IndexStart)
                    {
                        retlist.Add(new StringRange(startIndex, stringRange.IndexStart - 2, string.Empty, string.Empty, this.TargetString));
                        // retlist.Add(this.TargetString.Substring(startIndex, indexPare.IndexStart - startIndex));                        
                    }


                    retlist.Add(new StringRange(stringRange));
                    // retlist.Add(this.TargetString.Substring(indexPare.IndexStart, indexPare.IndexEnd - indexPare.IndexStart + 1));
                    index = stringRange.IndexEnd + 1;
                    startIndex = index + 1;
                    nStrIndex++;
                }
                else
                {


                    foreach (var strSeparator in strSeparatores)
                    {
                        if (FindSeparatorinTargetString(this.TargetString, index, strSeparator))
                        {
                            retlist.Add(new StringRange(startIndex, index - 1, string.Empty, strSeparator, this.TargetString));
                            // retlist.Add(this.TargetString.Substring(startIndex, index - startIndex));
                            startIndex = index + strSeparator.Length;
                            index = startIndex - 1;
                            break;
                        }
                    }
                }
            }


            if (startIndex < this.TargetString.Length)
            {
                retlist.Add(new StringRange(startIndex, this.TargetString.Length - 1, string.Empty, string.Empty, this.TargetString));
                //retlist.Add(this.TargetString.Substring(startIndex, this.TargetString.Length - startIndex));
            }

            return retlist.ToArray();
        }

        public StringRange[] GetStringRangeSpilit(string strSeparator, ManagerStringNested nStr)
        {
            return this.GetStringRangeSpilitLogic(new string[] { strSeparator }, nStr.GetStringRangeArray(this.TargetString));
        }

        public StringRange[] GetStringRangeSpilit(string[] strSeparators, ManagerStringNested nStr)
        {
            return this.GetStringRangeSpilitLogic(strSeparators, nStr.GetStringRangeArray(this.TargetString));
        }

        public StringRange[] GetStringRangeSpilitIgnoreNestedString(string[] strSeparators, ManagerStringNested nStr, ManagerStringNested IgnoreNestedString)
        {
            return this.GetStringRangeSpilitLogic(strSeparators, nStr.GetStringRangeIgnoreNestedString(this.TargetString, IgnoreNestedString));
        }

        public StringRange[] GetStringRangeSpilitIgnoreNestedString(string strSeparator, ManagerStringNested nStr, ManagerStringNested IgnoreNestedString)
        {
            return this.GetStringRangeSpilitLogic(new string[] { strSeparator }, nStr.GetStringRangeIgnoreNestedString(this.TargetString, IgnoreNestedString));
        }

        public StringRange[] GetStringRangeSpilitIgnoreNestedString(string[] strSeparators, ManagerStringNested nStr, ManagerStringNested[] IgnoreNestedStrings)
        {
            return this.GetStringRangeSpilitLogic(strSeparators, nStr.GetStringRangeIgnoreNestedString(this.TargetString, IgnoreNestedStrings));
        }

        public StringRange[] GetStringRangeSpilitIgnoreNestedString(string strSeparator, ManagerStringNested nStr, ManagerStringNested[] IgnoreNestedStrings)
        {
            return this.GetStringRangeSpilitLogic(new string[] { strSeparator }, nStr.GetStringRangeIgnoreNestedString(this.TargetString, IgnoreNestedStrings));
        }


        #endregion

    }
}

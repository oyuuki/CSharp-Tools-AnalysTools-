using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms.PropertyGridInternal;

namespace OyuLib
{
    public class ManagerStringNested
    {
        #region InstanceVal

        private string _nestStartString = string.Empty;

        private string _nestEndtString = string.Empty;

        #endregion

        #region Constructor

        public ManagerStringNested(
            string nestStartString,
            string nestEndtString)
        {
            this._nestStartString = nestStartString;
            this._nestEndtString = nestEndtString;
        }

        #endregion

        #region Property

        public string NestStartString
        {
            get { return this._nestStartString; }
        }

        public string NestEndtString
        {
            get { return this._nestEndtString; }
        }

        #endregion

        #region Method

        #region Public

        public StringRange[] GetStringRangeArray(string str)
        {
            int index = 0;
            return this.GetStringRangeLogic(ref index, str);
        }

        private StringRange[] GetStringRangeLogic(ref int index, string str)
        {
            var retlist = new List<StringRange>();
            var isParentSwitch = false;

            var isStart = true;

            for (; index < str.Length; index++)
            {
                if ((!this.NestStartString.Equals(this.NestEndtString) &&
                        str[index].ToString().Equals(this.NestStartString) ||
                     this.NestStartString.Equals(this.NestEndtString) && 
                    (str[index].ToString().Equals(this.NestStartString) && isStart)))
                {
                    if (isParentSwitch)
                    {
                        retlist[retlist.Count - 1].Childs = this.GetStringRangeLogic(ref index, str);
                    }
                    else
                    {
                        var pare = new StringRange(index + 1, this.NestStartString, string.Empty, str);
                        retlist.Add(pare);
                        isParentSwitch = true;
                    }

                    isStart = false;
                }
                else if (str[index].ToString().Equals(this.NestEndtString))
                {
                    if (!isParentSwitch)
                    {
                        index -= 1;
                        return retlist.ToArray();
                    }

                    isParentSwitch = false;
                    retlist[retlist.Count - 1].IndexEnd = index - 1;
                    retlist[retlist.Count - 1].SpilitSeparatorEnd = this.NestEndtString;

                    isStart = true;
                }

            }

            if (str.IndexOf("plStrSQL = plStrSQL & \"" + "WHERE \"" + " & " + "\"" + "((mstTokuiSaki.[区分] <> 0 AND mstTokuiSaki.[グループ] <> 0)") >= 0)
            {
                var stra = string.Empty;

                foreach(var a in retlist)
                {
                    
                    if(a.IndexEnd < 0 || a.IndexStart < 0)
                    {
                        stra += "   !!!!!マイナス";
                    }

                    stra += a.GetStringSpilited();

                    stra += "\n";
                }

                stra = stra;
            }

            return retlist.ToArray();   
        }

        public StringRange[] GetStringRangeIgnoreNestedString(string str, ManagerStringNested nestedString)
        {
            int index = 0;
            return this.GetStringRangeIgnoreStringRangesLogic(ref index, str, nestedString.GetStringRangeArray(str));
        }

        public StringRange[] GetStringRangeIgnoreNestedString(string str, ManagerStringNested[] nestedStrings)
        {
            int index = 0;

            var nestStringRangeList = new  List<StringRange>();

            foreach (var nestedString in nestedStrings)
            {
                nestStringRangeList.AddRange(nestedString.GetStringRangeArray(str));
            }

            return this.GetStringRangeIgnoreStringRangesLogic(ref index, str, nestStringRangeList.ToArray());
        }

        private StringRange[] GetStringRangeIgnoreStringRangesLogic(ref int index, string str, StringRange[] ranges)
        {
            var retlist = new List<StringRange>();
            var isParentSwitch = false;

            var rangesIndex = 0;

            for (; index < str.Length; index++)
            {
                
                if (ranges != null &&
                    ranges.Length > rangesIndex &&
                    ranges[rangesIndex].IndexEnd < index)
                {
                    rangesIndex++;
                }
                if (ranges != null &&
                    ranges.Length > rangesIndex &&
                    ranges[rangesIndex].IndexStart <= index && ranges[rangesIndex].IndexEnd >= index)
                {
                    continue;
                }
                

                if (str[index].ToString().Equals(this.NestStartString))
                {
                    if (isParentSwitch)
                    {
                        retlist[retlist.Count - 1].Childs = this.GetStringRangeIgnoreStringRangesLogic(ref index, str, ranges);
                    }
                    else
                    {
                        var pare = new StringRange(index + 1, this.NestStartString, string.Empty, str);
                        retlist.Add(pare);
                        isParentSwitch = true;
                    }
                }
                else if (str[index].ToString().Equals(this.NestEndtString))
                {
                    if (!isParentSwitch)
                    {
                        index -= 1;
                        return retlist.ToArray();
                    }

                    isParentSwitch = false;
                    retlist[retlist.Count - 1].IndexEnd = index - 1;
                    retlist[retlist.Count - 1].SpilitSeparatorEnd = this.NestEndtString;
                }
            }

            return retlist.ToArray();
        }

      

        #endregion

        #endregion

    }
}

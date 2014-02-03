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

            for (; index < str.Length; index++)
            {
                if (str[index].ToString().Equals(this.NestStartString))
                {
                    if (isParentSwitch)
                    {
                        retlist[retlist.Count - 1].Childs = this.GetStringRangeLogic(ref index, str);
                    }
                    else
                    {
                        var pare = new StringRange(index, str);
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
                    retlist[retlist.Count - 1].IndexEnd = index;
                    retlist[retlist.Count - 1].SpilitStrings = new string[]{this.NestStartString, this.NestEndtString} ; 
                }
            }

            return retlist.ToArray();
        }

        #endregion

        #endregion

    }
}

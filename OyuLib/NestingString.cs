using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms.PropertyGridInternal;

namespace OyuLib
{
    public class NestingString
    {
        #region InstanceVal

        private string _nestStartString = string.Empty;

        private string _nestEndtString = string.Empty;

        #endregion

        #region Constructor

        public NestingString(
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

        public NestingStringIndexPare[] GetIndexPareArray(string str)
        {
            int index = 0;
            return this.GetIndexPareArrayLogic(ref index, str);
        }

        private NestingStringIndexPare[] GetIndexPareArrayLogic(ref int index, string str)
        {
            var retlist = new List<NestingStringIndexPare>();
            var isParentSwitch = false;

            for (; index < str.Length; index++)
            {
                if (str[index].ToString().Equals(this.NestStartString))
                {
                    if (isParentSwitch)
                    {
                        retlist[retlist.Count - 1].Childs = this.GetIndexPareArrayLogic(ref index, str);
                    }
                    else
                    {
                        var pare = new NestingStringIndexPare(index);
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
                }
            }

            return retlist.ToArray();
        }

        #endregion

        #endregion

    }
}

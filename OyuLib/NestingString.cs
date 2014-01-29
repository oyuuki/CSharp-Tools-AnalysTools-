using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Return Nested text that most inner 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetMostInnerNestedText(string str)
        {
            int[] startIndexArray = this.GetStartStringIndexArray(str);
            int[] endIndexArray = this.GetEndStringIndexArray(str);

            int startIndex = startIndexArray[startIndexArray.Length - 1];
            int endIndex = endIndexArray[endIndexArray.Length - 1];

            return str.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// Return Nested text that most outer
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetMostOuterNestedText(string str)
        {
            int[] startIndexArray = this.GetStartStringIndexArray(str);
            int[] endIndexArray = this.GetEndStringIndexArray(str);

            int startIndex = startIndexArray[0];
            int endIndex = endIndexArray[0];

            return str.Substring(startIndex, endIndex - startIndex);
        }

        private int[] GetStartStringIndexArray(string str)
        {
            List<int> retList = new List<int>();

            int index = -1;
            int startIndex = 0;

            while ((index = str.LastIndexOf(this.NestEndtString, startIndex)) >= 0)
            {
                retList.Add(index);
                startIndex = index;
            }

            return retList.ToArray();
        }

        private int[] GetEndStringIndexArray(string str)
        {
            List<int> retList = new List<int>();

            int index = -1;
            int startIndex = 0;

            while ((index = str.LastIndexOf(this.NestStartString, startIndex)) >= 0)
            {
                retList.Add(index);
                startIndex = index;
            }

            return retList.ToArray();
        }

        #endregion

        #endregion

    }
}

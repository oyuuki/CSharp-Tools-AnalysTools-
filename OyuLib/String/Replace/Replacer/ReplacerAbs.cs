using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.String.Replace.ReplaceLogic;
using OyuLib.String.Text;
using OyuLib;

namespace OyuLib.String.Replace.Replacer
{
    public abstract class ReplacerAbs<T>
        where T : ReplaceAbs, new()
    {
        #region instanceVal

        private OyuText _text = null;

        /// <summary>
        /// Prove that String Either include regex or not
        /// </summary>
        private bool _isRegexincludePettern = false;

        /// <summary>
        /// Prove that String Either include regex or not
        /// </summary>
        private object[] _objArray = null;

        #endregion

        #region constructor

        public ReplacerAbs(OyuText text, object[] objArray)
        {
            this._text = text;
            this._objArray = objArray;
        }

        #endregion

        #region property

        protected bool IsRegexincludePettern
        {
            get { return this._isRegexincludePettern; }
            set { this._isRegexincludePettern = value; }
        }

        #endregion

        #region method

        public T GetReplaceClass(object[] objArray)
        {
            T rep = Util.GetInstance<T>(objArray);
            rep.IsRegexincludePettern = this.IsRegexincludePettern;

            return rep;
        }

        /// <summary>
        /// Replace text that exchanged to the Array
        /// </summary>
        /// <returns></returns>
        public string GetReplacedText(string stringReplacing, string stringWillBeReplace)
        {
            T rep = this.GetReplaceClass(new object[] {stringReplacing, stringWillBeReplace});

            var retList = this._text.GetLineArray().Select(str => rep.GetReplacedText(str)).ToList();

            return string.Join(this._text.LineCode.GetCharCodeString(), retList.ToArray());
        }

        public abstract string[] ReplaceProc();

        #endregion
    }
}

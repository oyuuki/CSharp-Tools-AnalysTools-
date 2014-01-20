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
        where T : ReplaceLogicAbs, new()
    {
        #region instanceVal

        protected OyuText _text = null;

        /// <summary>
        /// Prove that String Either include regex or not
        /// </summary>
        protected bool _isRegexincludePettern = false;

        /// <summary>
        /// Prove that String Either include regex or not
        /// </summary>
        protected object[] _objArray = null;

        #endregion

        #region constructor

        public ReplacerAbs(string textString, object[] objArray)
        {
            this._text = new OyuText(textString);
            this._objArray = objArray;
        }

        public ReplacerAbs(OyuText text, object[] objArray)
        {
            this._text = text;
            this._objArray = objArray;
        }

        #endregion

        #region property

        public bool IsRegexincludePettern
        {
            get { return this._isRegexincludePettern; }
            set { this._isRegexincludePettern = value; }
        }

        #endregion

        #region method

        public T GetReplaceClass()
        {
            T rep = Util.GetInstance<T>(this._objArray);
            rep.IsRegexincludePettern = this.IsRegexincludePettern;

            return rep;
        }

        /// <summary>
        /// Replace text that exchanged to the Array
        /// </summary>
        /// <returns></returns>
        public string GetReplacedText()
        {
            T rep = this.GetReplaceClass();
            var retArray = this.ReplaceProc(rep);
            return string.Join(this._text.LineCode.GetCharCodeString(), retArray);
        }

        public abstract string[] ReplaceProc(T rep);

        #endregion
    }
}

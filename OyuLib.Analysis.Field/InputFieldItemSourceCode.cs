using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace OyuLib.Analysis.Source.Field
{
    public abstract class InputFieldItemSourceCode : InputFieldItem
    {
        #region instance

        protected List<InputFieldItemSourceCode> _childparts = null;

        #endregion

        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        public InputFieldItemSourceCode()
        {

        }

        /// <summary>
        /// constractor
        /// </summary>
        public InputFieldItemSourceCode(string sourceText, int hierarchyIndex, string itemSignature)
            : base(sourceText, hierarchyIndex, itemSignature)
        {
            this._childparts = new List<InputFieldItemSourceCode>();
            this._itemSignature = itemSignature + "." + this.GetHashCode().ToString();
            this.Init();
        }

        #endregion

        #region method

        #region public

        public string GetSourceText()
        {
            return this._sourceText;
        }

        public int GethierarchyIndex()
        {
            return this._hierarchyIndex;
        }

        public string GetItemSignature()
        {
            return this._itemSignature;
        }

        public InputFieldItemSourceCode[] GetPartArray()
        {
            List<InputFieldItemSourceCode> retList = new List<InputFieldItemSourceCode>();
            retList.Add(this);
            List<InputFieldItemSourceCode> childList = new List<InputFieldItemSourceCode>(this.GetChildParts());

            foreach (InputFieldItemSourceCode part in childList.ToArray())
            {
                retList.Add(part);
            }

            return retList.ToArray();
        }

        #endregion

        #region private

        private void Init()
        {
            while (this.CreateChild()) ;
        }

        #endregion

        #region protected

        protected InputFieldItemSourceCode[] GetChildparts()
        {
            return this._childparts.ToArray<InputFieldItemSourceCode>();
        }

        public string[] GetTextArray()
        {
            List<string> retList = new List<string>();
            retList.Add(this.GetSourcePartText());
            retList.AddRange(this.GetChildPartsTextArray());
            return retList.ToArray();
        }


        protected string[] GetChildPartsTextArray()
        {
            List<InputFieldItemSourceCode> childList = new List<InputFieldItemSourceCode>(this.GetChildParts());
            List<string> retList = new List<string>();

            foreach (InputFieldItemSourceCode part in childList.ToArray())
            {
                retList.Add(part.GetSourcePartText());
            }

            return retList.ToArray();
        }

        protected InputFieldItemSourceCode[] GetChildParts()
        {
            List<InputFieldItemSourceCode> retList = new List<InputFieldItemSourceCode>();

            foreach (InputFieldItemSourceCode part in this._childparts)
            {
                if (!part.GetIshaveChild())
                {
                    retList.Add(part);
                }
                else
                {
                    retList.AddRange(part.GetChildParts());
                }
            }

            return retList.ToArray();
        
        }

        protected string GetChildPartsText()
        {
            return string.Join("", this.GetChildPartsTextArray());
        }

        protected bool GetIshaveChild()
        {
            return this._childparts.Count > 0;
        }

        protected string GetSourcePartText()
        {
            return this._sourceText;
        }

        protected T AddChild<T>(string text)
            where T : InputFieldItemSourceCode, new()
        {
            Type type = typeof(T);
            ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(string), typeof(int), typeof(string) });

            if (ctor == null)
                throw new NotSupportedException("コンストラクタが定義されていません。");

            this._childparts.Add((T)ctor.Invoke(new object[] { text, this._hierarchyIndex + 1, this._itemSignature }));


            return (T)this._childparts[this._childparts.Count - 1];
        }

        #endregion

        #region 

        public abstract bool CreateChild();

        #endregion

        #endregion
    }
}

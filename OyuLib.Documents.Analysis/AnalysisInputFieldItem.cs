using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace OyuLib.Documents.Analysis
{
    public abstract class AnalysisInputFieldItem : InputFieldItem
    {
        #region instance

        protected List<AnalysisInputFieldItem> _childInputFieldItems = null;

        #endregion

        #region constractor

        /// <summary>
        /// 
        /// constractor
        /// </summary>
        protected AnalysisInputFieldItem()
        {

        }

        /// <summary>
        /// constractor
        /// </summary>
        protected AnalysisInputFieldItem(string sourceText, int hierarchyIndex, string itemSignature)
            : base(sourceText, hierarchyIndex, itemSignature)
        {
            this._childInputFieldItems = new List<AnalysisInputFieldItem>();
            this.ItemSignature = itemSignature + "." + this.GetHashCode().ToString();
            this.Init();
        }

        #endregion

        #region method

        #region public

        public string GetSourceText()
        {
            return this.SourceText;
        }

        public int GethierarchyIndex()
        {
            return this.HierarchyIndex;
        }

        public string GetItemSignature()
        {
            return this.ItemSignature;
        }

        public AnalysisInputFieldItem[] GetPartArray()
        {
            List<AnalysisInputFieldItem> retList = new List<AnalysisInputFieldItem>();
            retList.Add(this);
            List<AnalysisInputFieldItem> childList = new List<AnalysisInputFieldItem>(this.GetChildParts());

            foreach (AnalysisInputFieldItem part in childList.ToArray())
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

        protected AnalysisInputFieldItem[] GetChildparts()
        {
            return this._childInputFieldItems.ToArray<AnalysisInputFieldItem>();
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
            List<AnalysisInputFieldItem> childList = new List<AnalysisInputFieldItem>(this.GetChildParts());
            List<string> retList = new List<string>();

            foreach (AnalysisInputFieldItem part in childList.ToArray())
            {
                retList.Add(part.GetSourcePartText());
            }

            return retList.ToArray();
        }

        protected AnalysisInputFieldItem[] GetChildParts()
        {
            List<AnalysisInputFieldItem> retList = new List<AnalysisInputFieldItem>();

            foreach (AnalysisInputFieldItem part in this._childInputFieldItems)
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
            return this._childInputFieldItems.Count > 0;
        }

        protected string GetSourcePartText()
        {
            return this.SourceText;
        }

        protected S AddChild<S>(string text)
            where S : AnalysisInputFieldItem, new()
        {
            Type type = typeof(S);
            ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(string), typeof(int), typeof(string) });

            if (ctor == null)
                throw new NotSupportedException("コンストラクタが定義されていません。");

            this._childInputFieldItems.Add((S)ctor.Invoke(new object[] { text, this.HierarchyIndex + 1, this.ItemSignature }));


            return (S)this._childInputFieldItems[this._childInputFieldItems.Count - 1];
        }

        #endregion

        #region 

        public abstract bool CreateChild();

        #endregion

        #endregion
    }
}

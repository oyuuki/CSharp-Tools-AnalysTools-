using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class AnalyzerInputFieldItem : InputField
    {
        #region instance

        protected List<AnalyzerInputFieldItem> _childInputFieldItems = null;

        #endregion

        #region constractor

        /// <summary>
        /// 
        /// constractor
        /// </summary>
        protected AnalyzerInputFieldItem()
        {

        }

        /// <summary>
        /// constractor
        /// </summary>
        protected AnalyzerInputFieldItem(string sourceText, int hierarchyIndex, string itemSignature)
            : base(sourceText, hierarchyIndex, itemSignature)
        {
            this._childInputFieldItems = new List<AnalyzerInputFieldItem>();
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

        public AnalyzerInputFieldItem[] GetPartArray()
        {
            List<AnalyzerInputFieldItem> retList = new List<AnalyzerInputFieldItem>();
            retList.Add(this);
            List<AnalyzerInputFieldItem> childList = new List<AnalyzerInputFieldItem>(this.GetChildParts());

            foreach (AnalyzerInputFieldItem part in childList.ToArray())
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

        protected AnalyzerInputFieldItem[] GetChildparts()
        {
            return this._childInputFieldItems.ToArray<AnalyzerInputFieldItem>();
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
            List<AnalyzerInputFieldItem> childList = new List<AnalyzerInputFieldItem>(this.GetChildParts());
            List<string> retList = new List<string>();

            foreach (AnalyzerInputFieldItem part in childList.ToArray())
            {
                retList.Add(part.GetSourcePartText());
            }

            return retList.ToArray();
        }

        protected AnalyzerInputFieldItem[] GetChildParts()
        {
            List<AnalyzerInputFieldItem> retList = new List<AnalyzerInputFieldItem>();

            foreach (AnalyzerInputFieldItem part in this._childInputFieldItems)
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
            where S : AnalyzerInputFieldItem, new()
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

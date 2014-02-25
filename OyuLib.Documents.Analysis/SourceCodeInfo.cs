using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodeInfo
    {
        #region instanceVal

        private SourceCode _code = null;

        private SourceCodePartsfactory _coFac = null;

        private Hashtable _overwriteValues = null;

        private string _allOverWriteString = string.Empty;

        private string _commentString = string.Empty;

        #endregion

        #region Constructor

        protected SourceCodeInfo()
        {
            _overwriteValues = new Hashtable();   
        }

        protected SourceCodeInfo(
            SourceCode code,
            SourceCodePartsfactory coFac)
            : this()
        {
            this._code = code;
            this._coFac = coFac;
        }

        #endregion

        #region Property

        private Hashtable OverwriteValues
        {
            get { return this._overwriteValues; }
        }

        public string AllOverWriteString
        {
            get { return this._allOverWriteString; }
        }

        public bool IsAllOverWriteString
        {
            get { return !string.IsNullOrEmpty(this.AllOverWriteString); } 
        }

        public string CommentString
        {
            get { return this._commentString; }
            set { this._commentString = value; }
        }

        public bool IsChangeComment
        {
            get { return !string.IsNullOrEmpty(this.CommentString); } 
        }


        #endregion

        #region Method

        #region Protected

        protected void SetOverwriteValue(int index, string value)
        {
            if (this.OverwriteValues.ContainsKey(index))
            {
                this.OverwriteValues[index] = value;
            }
            else
            {
                this.OverwriteValues.Add(index, value);
            }
        }

        protected string GetCodePartsString(int index)
        {
            var codeParts = this._coFac.GetCodeParts();

            if (index < 0 || codeParts.Length <= index)
            {
                return string.Empty;
            }

            if(this.OverwriteValues.ContainsKey(index))
            {
                return (string)this.OverwriteValues[index];
            }

            return this._coFac.GetCodeParts()[index];
        }

        #endregion

        #region Public

        public bool IsOverWrite()
        {
            return this.OverwriteValues.Keys.Count != 0 ||
                this.IsAllOverWriteString;
        }

        public void SetAllOverWriteString(string value, string commentSeparator, string comment)
        { 
            this._allOverWriteString = value + commentSeparator + comment; 
        }

        public string GetComment()
        {
            return this._coFac.GetComment();
        }

        public string GetCodeWithOutComment()
        {
            return this._coFac.GetStringWithOutComment();
        }

        public string GetTabString()
        {
            return this._coFac.GetTabString();
        }

        public string GetCodeString()
        {
            return this._code.CodeString;
        }

        public int CodePartsLength
        {
            get { return this.GetCodeParts().Length; }
        }

        public int GetCodeLineNumber()
        {
            return this._code.CodeLineNumber;
        }

        public string GetTemplateString()
        {
            return new SourceCodeTemplateFactory(
                this.GetNestIndices(),
                this.GetCodeRanges(),
                GetCodeString()).GetTemplateString();
        }

        public string[] GetCodeParts()
        {
            return this._coFac.GetCodeParts();
        }     

        #endregion

        #region Override

        public override string ToString()
        {
            return this.GetCodeText();
        }

        #endregion

        #region Virtual

        public virtual string GetCodePartsOverWriteValues()
        {
            StringRange[] codeRanges = this.GetCodeRanges();
            StringBuilder strBr = new StringBuilder();

            if (this.IsChangeComment)
            {
                return this.CommentString + this.GetCodeString() + "★このコードは置換ツールによってコメント化されました。";
            }
            else if (this.IsAllOverWriteString)
            {
                return this.AllOverWriteString;
            }

            for (int index = 0; index < codeRanges.Length; index++)
            {
                var range = codeRanges[index];

                strBr.Append(range.SpilitSeparatorStart);

                if (GetParamaterOverWriteValues(index, ref strBr))
                {
                    strBr.Append(range.SpilitSeparatorEnd);
                    continue;
                }


                if (this.OverwriteValues.ContainsKey(index))
                {
                    strBr.Append((string)this.OverwriteValues[index]);
                }
                else
                {
                    strBr.Append(range.GetStringSpilited());
                }

                strBr.Append(range.SpilitSeparatorEnd);
            }

            return strBr.ToString();
        }

        protected internal virtual StringRange[] GetCodeRanges()
        {
            return this._coFac.GetCodePartsRanges();
        }

        public virtual bool GetParamaterOverWriteValues(int index, ref StringBuilder strBu)
        {
            return false;
        }

        #endregion

        #region Abstract

        protected abstract string GetCodeText();

        public abstract NestIndex[] GetNestIndices();


        #endregion

        #endregion

    }
}

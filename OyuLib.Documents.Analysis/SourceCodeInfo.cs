﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        #endregion


        #region Method

        #region Public

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

        protected string GetCodePartsString(int index)
        {
            if (index < 0)
            {
                return "(None)";
            }

            return this._coFac.GetCodeParts()[index];
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

        public string GetCodePartsOverWriteValues()
        {
            StringRange[] codeRanges = this.GetCodeRanges();
            StringBuilder strBr = new StringBuilder();


            for (int index = 0; index < codeRanges.Length; index++)
            {
                var range = codeRanges[index];

                strBr.Append(range.SpilitSeparatorStart);

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

        #endregion

        #region Override

        public override string ToString()
        {
            return this.GetCodeText();
        }

        #endregion

        #region Virtual

        protected internal virtual StringRange[] GetCodeRanges()
        {
            return this._coFac.GetCodePartsRanges();
        }

        #endregion

        #region Abstract

        protected abstract string GetCodeText();

        public abstract NestIndex[] GetNestIndices();


        #endregion

        #endregion

    }
}

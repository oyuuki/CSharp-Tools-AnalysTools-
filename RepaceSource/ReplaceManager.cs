using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    public abstract class ReplaceManager<T>
        where T : SourceCodeInfo
    {
        #region instanceVal

        private T _sourceCodeInfo = null;

        private string _comment = null;

        private string _commentSeparator = null;

        private string _valiableName = string.Empty;

        private int _lineIndex = 00;

        #endregion

        #region Constructor

        public ReplaceManager(
            T sourceCodeInfo, 
            string comment, 
            string commentSeparator,
            string valiableName,
            int lineIndex)
        {
            this._sourceCodeInfo = sourceCodeInfo;
            this._commentSeparator = commentSeparator;
            this._comment = comment;
            this._valiableName = valiableName;
            this._lineIndex = lineIndex;
        }

        #endregion

        #region Property

        public T SourceCodeInfo
        {
            get { return this._sourceCodeInfo; }
        }

        public string Comment
        {
            get { return this._comment; }
        }

        public string CommentSeparator
        {
            get { return this._commentSeparator; }
        }

        public string ValiableName
        {
            get { return this._valiableName; }
            set { this._valiableName = value; }
        }

        public int LineIndex
        {
            get { return this._lineIndex; }
        }

        #endregion


        #region Method

        #region Protected


        protected ReplaceItem GetReplaceItem(string targetString)
        {
            foreach (var value in this.GetReplaceItems())
            {
                if (value.TargetString.Equals(targetString))
                {
                    return value;
                }
            }

            return null;
        }

        protected bool IsExistReplaceItem(string targetString)
        {
            return this.GetReplaceItem(targetString) != null;
        }

        #endregion

        #region Abstract

        public abstract ReplaceItem[] GetReplaceItems();

        public abstract void Replace();

        #endregion

        #endregion
    }


}

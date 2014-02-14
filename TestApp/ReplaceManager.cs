using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace TestApp
{
    public abstract class ReplaceManager<T>
        where T : SourceCodeInfo
    {
        #region instanceVal

        private T _sourceCodeInfo = null;

        #endregion

        #region Constructor

        public ReplaceManager(T sourceCodeInfo)
        {
            this._sourceCodeInfo = sourceCodeInfo;
        }

        #endregion

        #region Property

        public T SourceCodeInfo
        {
            get { return this._sourceCodeInfo; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources;
using OyuLib.Documents.Sources.Analysis;

namespace TestApp
{
    public abstract class ReplaceManagerHaveParamaterValue
    {
        #region InstanceVal

        private IParamater _codeinfohaveParamater = null;

        #endregion

        #region Constructor

        public ReplaceManagerHaveParamaterValue(IParamater codeinfohaveParamater)
        {
            _codeinfohaveParamater = codeinfohaveParamater;
        }

        #endregion

        #region property


        public IParamater CodeinfohaveParamater
        {
            get { return this._codeinfohaveParamater; }
        }

        #endregion

        #region Method

        #region Public

        public void Replace(IParamater paramater)
        {
            if (!paramater.GetSourceCodeInfoParamater().HasParamater)
            {
                return;
            }

            foreach (var codeInfo in paramater.GetSourceCodeInfoParamater().ParamaterValues)
            {
                if(codeInfo is IParamater)
                {
                     this.ReplaceIParamater((IParamater)codeInfo);
                     this.Replace((IParamater)codeInfo);
                }
                else
                {
                    this.ReplaceProc((SourceCodeInfoParamaterValue)codeInfo);
                }
            }
        }

        public void Replace()
        {
            if (!this.CodeinfohaveParamater.GetSourceCodeInfoParamater().HasParamater)
            {
                return;
            }

            this.Replace(this.CodeinfohaveParamater);
        }

        #endregion

        #region Private

        private void ReplaceProc(SourceCodeInfoParamaterValue codeinfo)
        {
            foreach (var replaceItem in this.GetReplaceItems())
            {
                if (codeinfo.ParamaterName.Equals(replaceItem.TargetString))
                {
                    codeinfo.ParamaterName = replaceItem.ReplaceString;
                    break;
                }
            }
        }

        #endregion

        #region Abstract

        public abstract void ReplaceIParamater(IParamater paramater);

        public abstract ReplaceItem[] GetReplaceItems();

        #endregion

        #endregion
    }
}

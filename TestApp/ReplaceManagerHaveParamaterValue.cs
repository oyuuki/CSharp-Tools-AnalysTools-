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

        public void Replace()
        {
            if (!this.CodeinfohaveParamater.GetSourceCodeInfoParamater().HasParamater)
            {
                return;
            }

            foreach (var replaceItem in this.GetReplaceItems())
            {
                this.ReplaceProc(replaceItem);
            }
        }

        #endregion

        #region Private

        private void ReplaceProc(ReplaceItem item)
        {
            foreach (var paramValue in this.CodeinfohaveParamater.GetSourceCodeInfoParamater().GetParamaterValue(item.TargetString))
            {
                paramValue.ParamaterName = item.ReplaceString;
            }

        }

        #endregion

        #region Abstract

        public abstract ReplaceItem[] GetReplaceItems();

        #endregion

        #endregion
    }
}

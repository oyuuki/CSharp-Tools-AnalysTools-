﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    public abstract class ReplaceManagerHaveParamaterValue
    {
        #region InstanceVal

        private IParamater _codeinfohaveParamater = null;

        private string _valiableName = string.Empty;

        #endregion

        #region Constructor

        public ReplaceManagerHaveParamaterValue(
            IParamater codeinfohaveParamater,
            string valiableName)
        {
            this._codeinfohaveParamater = codeinfohaveParamater;
            this._valiableName = valiableName;
        }

        #endregion

        #region property

        public IParamater CodeinfohaveParamater
        {
            get { return this._codeinfohaveParamater; }
        }

        public string ValiableName
        {
            get { return this._valiableName; }
        }

        #endregion

        #region Method

        #region Public

        public void Replace(IParamater paramater)
        {
            foreach (var param in paramater.GetSourceCodeInfoParamaters())
            {
                if (!param.HasParamater)
                {
                    return;
                }

                foreach (var value in param.ParamaterValues)
                {
                    foreach (var element in value.ElementStrages)
                    {
                        var elementValue = element.Value;

                        if (elementValue is IParamater)
                        {
                            this.ReplaceIParamater(element);
                            this.Replace((IParamater)elementValue);
                        }
                        else
                        {
                            this.ReplaceProc(element);
                        }
                    }
                }
            }
        }

        public void Replace()
        {
            this.Replace(this.CodeinfohaveParamater);
        }

        #endregion

        #region Private

        protected virtual void ReplaceProc(SourceCodeInfoParamaterValueElementStrage element)
        {
            foreach (var replaceItem in this.GetReplaceItems())
            {
                var codeInfo = (SourceCodeInfoParamaterValueElement)element.Value;

                if (codeInfo.ParamaterName.Equals(replaceItem.TargetString))
                {
                    codeInfo.ParamaterName = replaceItem.ReplaceString;
                    break;
                }
            }
        }

        #endregion

        #region Abstract

        public abstract void ReplaceIParamater(SourceCodeInfoParamaterValueElementStrage paramaterStrage);

        public abstract ReplaceItem[] GetReplaceItems();

        #endregion

        #endregion
    }
}

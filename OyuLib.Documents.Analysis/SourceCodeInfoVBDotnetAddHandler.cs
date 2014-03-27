using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoVBDotnetAddHandler : SourceCodeInfo
    {
        #region instanceVal

        /// <summary>
        /// calling Method Name
        /// </summary>
        private int _addhandlerObject = -1;
        private int _addressofObject = -1;

        #endregion

        #region Constructor

        public SourceCodeInfoVBDotnetAddHandler()
            : base()
        {
            
        }

        public SourceCodeInfoVBDotnetAddHandler(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int addhandlerObject,
            int addressofObject)
            : base(code, coFac)
        {
            this._addhandlerObject = addhandlerObject;
            this._addressofObject = addressofObject;            
        }

        #endregion

        #region property

        public string AddhandlerObject
        {
            get { return this.GetCodePartsString(this._addhandlerObject); }
            set { this.SetOverwriteValue(this._addhandlerObject, value); }
        }

        public string AddressofObject
        {
            get { return this.GetCodePartsString(this._addressofObject); }
            set { this.SetOverwriteValue(this._addressofObject, value); }
        }

        #endregion

        #region Method

        #region override

        public string GetEventName()
        {
            var spt =  this.AddhandlerObject.Split('.');
            return spt[spt.Length - 1];
        }

        public string GetObjectName()
        {
            var spt = this.AddhandlerObject.Split('.');
            return spt[spt.Length - 1];
        }

        public override NestIndex[] GetNestIndices()
        {
            return new NestIndex[]
            {
                new NestIndex(this._addhandlerObject),
                new NestIndex(this._addressofObject)
            };
        }

        protected override string GetCodeText()
        {
            return "AddHandler：" + this.AddhandlerObject + " Addressof" + this.AddressofObject;
        }

        #endregion

        #endregion
    }
}

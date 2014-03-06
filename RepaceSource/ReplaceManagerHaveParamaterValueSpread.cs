using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    public class ReplaceManagerHaveParamaterValueSpread : ReplaceManagerHaveParamaterValue
    {
        #region InstanceVal

        private string _rowString = string.Empty;
        private string _colString = string.Empty;

        #endregion

        #region Constructor

        public ReplaceManagerHaveParamaterValueSpread(
            string rowString, 
            string colString, 
            string valiableName,
            IParamater value)
            : base(value, valiableName)
        {
            this._rowString = rowString;
            this._colString = colString;
        }

        #endregion

        #region Property

        protected string RowString
        {
            get { return this._rowString; }
            set { this._rowString = value; }
        }

        protected string ColString
        {
            get { return this._colString; }
            set { this._colString = value; }
        }

        public string RowStringMinusOne
        {
            get { return this._rowString + " - 1"; }
        }

        public string ColStringMinusOne
        {
            get { return this._colString + " - 1"; }
        }

        #endregion

        #region Method

        #region Override

        public override ReplaceItem[] GetReplaceItems()
        {
            return CommonSpreadPlaceItemManager.GetPropertyReplaceItems(this.RowStringMinusOne, this.ColStringMinusOne, this.ValiableName);
        }

        public override void ReplaceIParamater(SourceCodeInfoParamaterValueElementStrage paramater)
        {
            if (paramater.Value is SourceCodeInfoCallMethod)
            {
                new ReplaceManagerSpreadCallMethod(
                    this.RowString,
                    this.ColString,
                    this.ValiableName,
                    "",
                    "",
                    (SourceCodeInfoCallMethod)paramater.Value).ReplaceWithOutParam();                
            }
        }

        protected override void ReplaceProc(SourceCodeInfoParamaterValueElementStrage element)
        {
            foreach (var replaceItem in this.GetReplaceItems())
            {
                var codeInfo = (SourceCodeInfoParamaterValueElement)element.Value;

                if (codeInfo.ParamaterName.Equals(replaceItem.TargetString)
                    && !element.IsBefExistLinkValue())
                {
                    codeInfo.ParamaterName = replaceItem.ReplaceString;
                    break;
                }
            }
        }

        #endregion

        #endregion
    }
}

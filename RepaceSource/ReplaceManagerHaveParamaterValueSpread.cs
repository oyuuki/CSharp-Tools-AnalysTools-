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

        private string _spreadValiableName = string.Empty;

        #endregion

        #region Constructor

        public ReplaceManagerHaveParamaterValueSpread(
            string rowString, 
            string colString, 
            string spreadValiableName,
            IParamater value)
            : base(value)
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

        public string SpreadValiableName
        {
            get { return this._spreadValiableName; }
            set { this._spreadValiableName = value; }
        }

        #endregion

        #region Method

        #region Override

        public override ReplaceItem[] GetReplaceItems()
        {
            return CommonPlaceitemManager.GetSpreadPropertyReplaceItems(this.RowStringMinusOne, this.ColStringMinusOne, this.SpreadValiableName);
        }

        public override void ReplaceIParamater(IParamater paramater)
        {
            if (paramater is SourceCodeInfoCallMethod)
            {
                new ReplaceManagerSpreadCallMethod(
                    this.RowString,
                    this.ColString,
                    this.SpreadValiableName,
                    "★[]★置換ツールにより置換",
                    "'",
                    (SourceCodeInfoCallMethod)paramater).ReplaceWithOutParam();                
            }
        }

        #endregion

        #endregion
    }
}

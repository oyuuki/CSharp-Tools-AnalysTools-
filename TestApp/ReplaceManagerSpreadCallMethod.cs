using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace TestApp
{
    class ReplaceManagerSpreadCallMethod : ReplaceManagerSpread<SourceCodeInfoCallMethod>
    {
        #region Constructor

        public ReplaceManagerSpreadCallMethod(
            string rowString, 
            string colString,
            SourceCodeInfoCallMethod value)
            : base(rowString, colString, value)
        {
            
        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            var retList = new List<ReplaceItem>();
            return retList.ToArray();
        }

        public override void Replace()
        {
            var subCodeInfo = this.SourceCodeInfo;
            var paramater = subCodeInfo.GetSourceCodeInfoParamater();

            new ReplaceManagerHaveParamaterValueSpread(this.RowString, this.ColString, subCodeInfo).Replace();
            new ReplaceManagerSpreadGetCallMethod(this.RowString, this.ColString, subCodeInfo).Replace();
            new ReplaceManagerSpreadSetCallMethod(this.RowString, this.ColString, subCodeInfo).Replace();
        }
    
    }
}

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
            string comment,
            string commentSeparator,
            SourceCodeInfoCallMethod value)
            : base(rowString, colString, comment, commentSeparator, value)
        {
            
        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            var retList = new List<ReplaceItem>();

            retList.Add(new ReplaceItem("set_RowHeight", "ActiveSheet.SetRowHeight"));
            retList.Add(new ReplaceItem("SetActiveCell", "ActiveSheet.SetActiveCell"));
            retList.Add(new ReplaceItem("set_ColWidth", "ActiveSheet.SetColumnWidth"));
            retList.Add(new ReplaceItem("DeleteRows", "ActiveSheet.RemoveRows"));
            retList.Add(new ReplaceItem("Note", "ActiveSheet.Cells(" + this.RowStringMinusOne + ", " + this.ColStringMinusOne + ").Note"));

            return retList.ToArray();
        }

        public override void Replace()
        {
            var subCodeInfo = this.SourceCodeInfo;
            var paramater = subCodeInfo.GetSourceCodeInfoParamater();

            new ReplaceManagerHaveParamaterValueSpread(this.RowString, this.ColString, subCodeInfo).Replace();
            new ReplaceManagerSpreadGetCallMethod(
                this.RowString, 
                this.ColString,
                "★[]★置換ツールにより置換",
                "'",
                subCodeInfo).Replace();
            new ReplaceManagerSpreadSetCallMethod(
                this.RowString,
                this.ColString,
                "★[]★置換ツールにより置換",
                "'",
                subCodeInfo).Replace();

            foreach (var replaceItem in GetReplaceItems())
            {
                ReplaceProc(replaceItem);
            }
        }


        public void ReplaceProc(ReplaceItem item)
        {
            if (!item.TargetString.Equals(this.SourceCodeInfo.CallmethodName))
            {
                return;
            }

            this.SourceCodeInfo.CallmethodName = item.ReplaceString;
        }
    
    }
}

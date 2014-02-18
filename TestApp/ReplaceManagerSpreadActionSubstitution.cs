using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace TestApp
{
    public class ReplaceManagerSpreadActionSubstitution : ReplaceManagerSpread<SourceCodeInfoSubstitution>
    {
        #region Constructor

        public ReplaceManagerSpreadActionSubstitution(
            string rowString, 
            string colString, 
            string comment,
            string commentSeparator,
            SourceCodeInfoSubstitution value)
            : base(rowString, colString, comment, commentSeparator, value)
        {
            
        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            var retList = new List<ReplaceItem>();

            retList.Add(new ReplaceItem("FPSpread.ActionConstants.ActionActiveCell", ".ActiveSheet.SetActiveCell(" + this.RowStringMinusOne + ", " + this.ColStringMinusOne + ")"));
            retList.Add(new ReplaceItem("FPSpread.ActionConstants.ActionSetCellBorder", ""));
            retList.Add(new ReplaceItem("FPSpread.ActionConstants.ActionInsertRow", ".ActiveSheet.ActiveRow.Add()"));
            retList.Add(new ReplaceItem("FPSpread.ActionConstants.ActionDeleteRow", ".ActiveSheet.ActiveRow.Remove()"));
            retList.Add(new ReplaceItem("FPSpread.ActionConstants.ActionSort", ""));
            retList.Add(new ReplaceItem("FPSpread.ActionConstants.ActionGotoCell", ""));

            return retList.ToArray();
        }

        public override void Replace()
        {
            this.SourceCodeInfo.SetAllOverWriteString(this.GetReplaceItem(this.SourceCodeInfo.RightHandSide).ReplaceString, this.CommentSeparator, this.Comment);
        }

    }
}

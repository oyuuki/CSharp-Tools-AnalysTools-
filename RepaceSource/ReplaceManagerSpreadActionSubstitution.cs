using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    public class ReplaceManagerSpreadActionSubstitution : ReplaceManagerSpread<SourceCodeInfoSubstitution>
    {
        #region Constructor

        public ReplaceManagerSpreadActionSubstitution(
            string rowString, 
            string colString,
            string spreadValiableName,
            string comment,
            string commentSeparator,
            SourceCodeInfoSubstitution value,
            int lineIndex)
            : base(rowString, colString, spreadValiableName, comment, commentSeparator, value, lineIndex)
        {
            
        }

        public ReplaceManagerSpreadActionSubstitution(
            string rowString,
            string colString,
            string spreadValiableName,
            string comment,
            string commentSeparator,
            SourceCodeInfoSubstitution value)
            : base(rowString, colString, spreadValiableName, comment, commentSeparator, value, value.GetCodeLineNumber())
        {

        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            var retList = new List<ReplaceItem>();

            retList.Add(new ReplaceItem("FPSpread.ActionConstants.ActionActiveCell", this.ValiableName + ".ActiveSheet.SetActiveCell(" + this.RowStringMinusOne + ", " + this.ColStringMinusOne + ")"));
            retList.Add(new ReplaceItem("FPSpread.ActionConstants.ActionSetCellBorder", ""));
            retList.Add(new ReplaceItem("FPSpread.ActionConstants.ActionInsertRow", this.ValiableName + ".ActiveSheet.ActiveRow.Add()"));
            retList.Add(new ReplaceItem("FPSpread.ActionConstants.ActionDeleteRow", this.ValiableName + ".ActiveSheet.ActiveRow.Remove()"));
            retList.Add(new ReplaceItem("FPSpread.ActionConstants.ActionSort", ""));
            retList.Add(new ReplaceItem("FPSpread.ActionConstants.ActionGotoCell", this.ValiableName + ".ShowCell(0, 0, 0, 0, FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left)"));

            return retList.ToArray();
        }

        public override void Replace()
        {
            this.SourceCodeInfo.SetAllOverWriteString(this.GetReplaceItem(this.SourceCodeInfo.RightHandSide).ReplaceString, this.CommentSeparator, this.Comment);
        }

    }
}

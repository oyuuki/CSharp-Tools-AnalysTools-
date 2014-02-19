using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    static class CommonPlaceitemManager
    {
        public static ReplaceItem[] GetSpreadPropertyReplaceItems(string rowString, string colString)
        {
            var replaceRowString = rowString;
            var replaceColString = colString;

            var retList = new List<ReplaceItem>();

            retList.Add(new ReplaceItem(".Row", replaceRowString));
            retList.Add(new ReplaceItem(".Col", replaceColString));
            retList.Add(new ReplaceItem(".eventArgs.Row", replaceColString));
            retList.Add(new ReplaceItem(".eventArgs.Col", replaceColString));

            retList.Add(new ReplaceItem("eventArgs.Col", "eventArgs.Column"));
            retList.Add(new ReplaceItem("eventArgs.Row", "eventArgs.Row"));
            retList.Add(new ReplaceItem("eventArgs.MultiLine", "eventArgs.WrapText"));
            retList.Add(new ReplaceItem("eventArgs.NewCol", "eventArgs.NewColumn"));
            retList.Add(new ReplaceItem("eventArgs.NewRow", "eventArgs.NewRow"));
            retList.Add(new ReplaceItem("Row", "eventArgs.Row"));
            retList.Add(new ReplaceItem("Col", "eventArgs.Column"));
            retList.Add(new ReplaceItem("IsFetchCellNote", "eventArgs.FetchCellNote"));
            retList.Add(new ReplaceItem(".IsFetchCellNote", "eventArgs.FetchCellNote"));

            retList.Add(new ReplaceItem(".MaxRows", ".ActiveSheet.RowCount"));
            retList.Add(new ReplaceItem(".MaxCols", ".ActiveSheet.ColumnCount"));
            retList.Add(new ReplaceItem(".Value", ".ActiveSheet.Cells(" + replaceRowString + "," + replaceColString + ").Value"));
            retList.Add(new ReplaceItem(".ActiveRow", ".ActiveSheet.ActiveRowIndex"));
            retList.Add(new ReplaceItem(".ActiveCol", ".ActiveSheet.ActiveColumnIndex"));
            retList.Add(new ReplaceItem(".ColHidden", ".ActiveSheet.Columns(" + replaceColString + ").Visible"));
            retList.Add(new ReplaceItem(".SelBlockRow", ".ActiveSheet.GetSelection(0).Row"));
            retList.Add(new ReplaceItem(".SelBlockRow2", ".ActiveSheet.GetSelection(0).Row + .ActiveSheet.GetSelection(0).RowCount"));
            retList.Add(new ReplaceItem(".BackColor", ".ActiveSheet.Cells(" + rowString + "," + colString + ", eventArgs.Column).BackColor"));
            retList.Add(new ReplaceItem(".ForeColor", ".ActiveSheet.Cells(" + rowString + "," + colString + ").ForeColor"));
            //retList.Add(new ReplaceItem(".set_ColWidth", ".ActiveSheet..SetColumnWidth(" + colString + ", .ActiveSheet.Columns(" + colString +").GetPreferredWidth())""));
            retList.Add(new ReplaceItem(".Formula", ".ActiveSheet.Cells(" + rowString + ", " + colString + ").Formula"));
            retList.Add(new ReplaceItem(".Lock", ".ActiveSheet.Cells(" + rowString + ", " + colString + ").Locked"));
            retList.Add(new ReplaceItem(".CellNote", ".ActiveSheet.Cells(" + rowString + ", " + colString + ").Note"));
            retList.Add(new ReplaceItem(".Font", ".ActiveSheet.Cells(" + rowString + ", " + colString + ").Font"));
            retList.Add(new ReplaceItem(".TextTip", ".TextTipPolicy"));
            retList.Add(new ReplaceItem("FPSpread.TextTipConstants.TextTipFixedFocusOnly", "FarPoint.Win.Spread.TextTipPolicy.FixedFocusOnly"));
            retList.Add(new ReplaceItem(".ColsFrozen", ".FrozenColumnCount"));
            
            return retList.ToArray();
        }
    }
}

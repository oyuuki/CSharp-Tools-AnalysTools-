using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepaceSource
{
    static class CommonPlaceitemManager
    {
        public static ReplaceItem[] GetSpreadPropertyReplaceItems(string rowString, string colString, string spreadValibleName)
        {
            var replaceRowString = rowString;
            var replaceColString = colString;

            var retList = new List<ReplaceItem>();

            retList.Add(new ReplaceItem(spreadValibleName + ".Row", replaceRowString));
            retList.Add(new ReplaceItem(spreadValibleName + ".Col", replaceColString));
            retList.Add(new ReplaceItem(spreadValibleName + ".eventArgs.Row", replaceColString));
            retList.Add(new ReplaceItem(spreadValibleName + ".eventArgs.Col", replaceColString));

            retList.Add(new ReplaceItem("eventArgs.Col", "eventArgs.Column"));
            retList.Add(new ReplaceItem("eventArgs.Row", "eventArgs.Row"));
            retList.Add(new ReplaceItem("eventArgs.MultiLine", "eventArgs.WrapText"));
            retList.Add(new ReplaceItem("eventArgs.NewCol", "eventArgs.NewColumn"));
            retList.Add(new ReplaceItem("eventArgs.NewRow", "eventArgs.NewRow"));
            retList.Add(new ReplaceItem("eventArgs.ButtonDown", ".ActiveSheet.Cells(eventArgs.Row, eventArgs.Column).Value"));

            retList.Add(new ReplaceItem("Row", "eventArgs.Row"));
            retList.Add(new ReplaceItem("Col", "eventArgs.Column"));
            retList.Add(new ReplaceItem("IsFetchCellNote", "eventArgs.FetchCellNote"));
            retList.Add(new ReplaceItem(spreadValibleName + ".IsFetchCellNote", "eventArgs.FetchCellNote"));

            retList.Add(new ReplaceItem(spreadValibleName + ".Columns", spreadValibleName + ".ActiveSheet.Columns"));
            retList.Add(new ReplaceItem(spreadValibleName + ".Rows", spreadValibleName + ".ActiveSheet.Rows"));
            

            retList.Add(new ReplaceItem(spreadValibleName + ".MaxRows", spreadValibleName + ".ActiveSheet.RowCount"));
            retList.Add(new ReplaceItem(spreadValibleName + ".MaxCols", spreadValibleName + ".ActiveSheet.ColumnCount"));
            retList.Add(new ReplaceItem(spreadValibleName + ".Value", spreadValibleName + ".ActiveSheet.Cells(" + replaceRowString + "," + replaceColString + ").Value"));
            retList.Add(new ReplaceItem(spreadValibleName + ".ActiveRow", spreadValibleName + ".ActiveSheet.ActiveRowIndex"));
            retList.Add(new ReplaceItem(spreadValibleName + ".ActiveCol", spreadValibleName + ".ActiveSheet.ActiveColumnIndex"));
            retList.Add(new ReplaceItem(spreadValibleName + ".ColHidden", spreadValibleName + ".ActiveSheet.Columns(" + replaceColString + ").Visible"));
            retList.Add(new ReplaceItem(spreadValibleName + ".RowHidden", spreadValibleName + ".ActiveSheet.Rows(" + replaceRowString + ").Visible"));

            retList.Add(new ReplaceItem(spreadValibleName + ".SelBlockRow", spreadValibleName + ".ActiveSheet.GetSelection(0).Row"));
            retList.Add(new ReplaceItem(spreadValibleName + ".SelBlockRow2", spreadValibleName + ".ActiveSheet.GetSelection(0).Row + .ActiveSheet.GetSelection(0).RowCount"));
            retList.Add(new ReplaceItem(spreadValibleName + ".BackColor", spreadValibleName + ".ActiveSheet.Cells(" + rowString + "," + colString + ", eventArgs.Column).BackColor"));
            retList.Add(new ReplaceItem(spreadValibleName + ".ForeColor", spreadValibleName + ".ActiveSheet.Cells(" + rowString + "," + colString + ").ForeColor"));
            //retList.Add(new ReplaceItem(".set_ColWidth", ".ActiveSheet..SetColumnWidth(" + colString + ", .ActiveSheet.Columns(" + colString +").GetPreferredWidth())""));
            retList.Add(new ReplaceItem(spreadValibleName + ".Formula", spreadValibleName + ".ActiveSheet.Cells(" + rowString + ", " + colString + ").Formula"));
            retList.Add(new ReplaceItem(spreadValibleName + ".Lock", spreadValibleName + ".ActiveSheet.Cells(" + rowString + ", " + colString + ").Locked"));
            retList.Add(new ReplaceItem(spreadValibleName + ".CellNote", spreadValibleName + ".ActiveSheet.Cells(" + rowString + ", " + colString + ").Note"));
            retList.Add(new ReplaceItem(spreadValibleName + ".Font", spreadValibleName + ".ActiveSheet.Cells(" + rowString + ", " + colString + ").Font"));
            retList.Add(new ReplaceItem(spreadValibleName + ".TextTip", spreadValibleName + ".TextTipPolicy"));
            retList.Add(new ReplaceItem("FPSpread.TextTipConstants.TextTipFixedFocusOnly", "FarPoint.Win.Spread.TextTipPolicy.FixedFocusOnly"));
            retList.Add(new ReplaceItem(spreadValibleName + ".ColsFrozen", spreadValibleName + ".FrozenColumnCount"));
            retList.Add(new ReplaceItem(spreadValibleName + ".SelectionCount", spreadValibleName + ".ActiveSheet.SelectionCount"));

            
            
            return retList.ToArray();
        }
    }
}

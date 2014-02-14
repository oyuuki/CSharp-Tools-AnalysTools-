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
            var replaceRowString = rowString + " - 1";
            var replaceColString = colString + " - 1";

            var retList = new List<ReplaceItem>();

            retList.Add(new ReplaceItem(".Row", replaceRowString));
            retList.Add(new ReplaceItem(".Cow", replaceColString));
            retList.Add(new ReplaceItem(".MaxRows", ".ActiveSheet.RowCount"));
            retList.Add(new ReplaceItem(".MaxCols", ".ActiveSheet.ColumnCount"));
            retList.Add(new ReplaceItem(".Value", ".ActiveSheet.Cell(" + replaceRowString + "," + replaceColString + ").Value"));
            retList.Add(new ReplaceItem(".ActiveRow", ".ActiveSheet.ActiveRowIndex"));
            retList.Add(new ReplaceItem(".ColHidden", ".ActiveSheet.Columns(" + replaceColString + " - 1).Visible"));
            retList.Add(new ReplaceItem(".SelBlockRow", ".ActiveSheet.GetSelection(0).Row"));
            retList.Add(new ReplaceItem(".SelBlockRow2", ".ActiveSheet.GetSelection(0).Row + .ActiveSheet.GetSelection(0).RowCount - 1"));
            retList.Add(new ReplaceItem(".BackColor", ".ActiveSheet.Cells(" + rowString + "," + colString + ", eventArgs.Column).BackColor"));
            retList.Add(new ReplaceItem(".ForeColor", ".ActiveSheet.Cells(1, 1).ForeColor"));
            

            return retList.ToArray();
        }
    }
}

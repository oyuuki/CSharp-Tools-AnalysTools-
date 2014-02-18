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
            retList.Add(new ReplaceItem(".Cow", replaceColString));
            retList.Add(new ReplaceItem(".eventArgs.Row", replaceColString));
            retList.Add(new ReplaceItem(".eventArgs.Cow", replaceColString));
            retList.Add(new ReplaceItem(".MaxRows", ".ActiveSheet.RowCount"));
            retList.Add(new ReplaceItem(".MaxCols", ".ActiveSheet.ColumnCount"));
            retList.Add(new ReplaceItem(".Value", ".ActiveSheet.Cells(" + replaceRowString + "," + replaceColString + ").Value"));
            retList.Add(new ReplaceItem(".ActiveRow", ".ActiveSheet.ActiveRowIndex"));
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

            

            return retList.ToArray();
        }
    }
}

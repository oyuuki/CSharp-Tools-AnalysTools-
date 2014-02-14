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
            retList.Add(new ReplaceItem(".ActiveRow", "ActiveSheet.ActiveRowIndex"));
            retList.Add(new ReplaceItem(".ColHidden", ".ActiveSheet.Columns(" + replaceColString + " - 1).Visible"));

            return retList.ToArray();
        }
    }
}

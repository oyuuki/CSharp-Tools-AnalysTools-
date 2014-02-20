using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepaceSource
{
    static class CommonGcDatePlaceItemManager
    {
        public static ReplaceItem[] GetPropertyReplaceItems(string gcDateValibleName)
        {
            var retList = new List<ReplaceItem>();

            retList.Add(new ReplaceItem(gcDateValibleName + ".Year", gcDateValibleName + ".Value.Value.Year"));
            retList.Add(new ReplaceItem(gcDateValibleName + ".Month", gcDateValibleName + ".Value.Value.Month"));
            retList.Add(new ReplaceItem(gcDateValibleName + ".Day", gcDateValibleName + ".Value.Value.Day"));
            
            return retList.ToArray();
        }
    }
}

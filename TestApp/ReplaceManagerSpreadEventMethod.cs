using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace TestApp
{
    public class ReplaceManagerSpreadEventMethod : ReplaceManager<SourceCodeInfoBlockBeginEventMethod>
    {
        #region Constructor

        public ReplaceManagerSpreadEventMethod(
            SourceCodeInfoBlockBeginEventMethod value,
            string comment,
            string commentSeparator)
            : base(value, comment, commentSeparator)
        {
            
        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            var retList = new List<ReplaceItem>();

            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_TextTipFetchEvent", new string[] { "FarPoint.Win.Spread.TextTipFetchEventArgs", "TextTipFetch" }));
            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_RightClickEvent", new string[] { "MouseEventArgs", "MouseDown" }));
            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_LeaveCellEvent", new string[] { "FarPoint.Win.Spread.LeaveCellEventArgs", "LeaveCell" }));
            // retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_EditModeEvent", new string[] { "FarPoint.Win.Spread.TextTipFetchEventArgs", "TextTipFetch" }));
            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_DblClickEvent", new string[] { "FarPoint.Win.Spread.CellClickEventArgs", "CellDoubleClick" }));
            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_ButtonClickedEvent", new string[] { "FarPoint.Win.Spread.EditorNotifyEventArgs", "ButtonClicked" }));

            return retList.ToArray();
        }

        public override void Replace()
        {
            foreach (var replaceItem in GetReplaceItems())
            {
                ReplaceProc(replaceItem);
            }
        }


        public void ReplaceProc(ReplaceItem item)
        {
            var subCodeInfo = this.SourceCodeInfo;

            var paramater = this.SourceCodeInfo.GetSourceCodeInfoParamater();
            var paramVal = paramater.GetParamaterValue(item.TargetString);

            if(paramVal != null && paramVal.Length > 0)
            {
                paramVal[0].ParamaterName = item.ReplaceStrings[0];
                subCodeInfo.EventName = item.ReplaceStrings[1];
            }
        }
    }
}

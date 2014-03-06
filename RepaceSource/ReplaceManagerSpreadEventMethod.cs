using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    public class ReplaceManagerSpreadEventMethod : ReplaceManager<SourceCodeInfoBlockBeginEventMethod>
    {
        #region Constructor

        public ReplaceManagerSpreadEventMethod(
            SourceCodeInfoBlockBeginEventMethod value,
            string comment,
            string commentSeparator)
            : base(value, comment, commentSeparator, string.Empty)
        {
            
        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            var retList = new List<ReplaceItem>();

            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_TextTipFetchEvent", new string[] { "FarPoint.Win.Spread.TextTipFetchEventArgs", "TextTipFetch" }));
            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_RightClickEvent", new string[] { "FarPoint.Win.Spread.CellClickEventArgs", "CellClick" }));
            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_LeaveCellEvent", new string[] { "FarPoint.Win.Spread.LeaveCellEventArgs", "LeaveCell" }));
            // retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_EditModeEvent", new string[] { "FarPoint.Win.Spread.TextTipFetchEventArgs", "TextTipFetch" }));
            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_DblClickEvent", new string[] { "FarPoint.Win.Spread.CellClickEventArgs", "CellDoubleClick" }));
            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_ButtonClickedEvent", new string[] { "FarPoint.Win.Spread.EditorNotifyEventArgs", "ButtonClicked" }));
            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_ClickEvent", new string[] { "FarPoint.Win.Spread.CellClickEventArgs", "ButtonClicked" }));
            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_TopLeftChangeEvent", new string[] { "FarPoint.Win.Spread.LeftChangeEventArgs", "LeftChange" }));
            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_KeyDownEvent", new string[] { "KeyEventArgs", "KeyDown" }));
            retList.Add(new ReplaceItem("AxFPSpread._DSpreadEvents_KeyPressEvent", new string[] { "KeyPressEventArgs", "KeyPress" }));

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
            var codeInfo = this.SourceCodeInfo;

            foreach (var paramater in this.SourceCodeInfo.GetSourceCodeInfoParamaters())
            {
                foreach (var paramValue in paramater.ParamaterValues)
                {
                    foreach (var element in paramValue.ElementStrages)
                    {
                        var elementValue = element.Value;

                        if (((SourceCodeInfoParamaterValueElementMethod)elementValue).TypeName.Equals(item.TargetString))
                        {
                            ((SourceCodeInfoParamaterValueElementMethod)elementValue).TypeName = item.ReplaceStrings[0];
                            codeInfo.EventName = item.ReplaceStrings[1];
                            break;
                        }
                    }
                }
            }
        }
    }
}

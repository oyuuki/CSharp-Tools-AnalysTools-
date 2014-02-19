using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    class ReplaceManagerSpreadCallMethod : ReplaceManagerSpread<SourceCodeInfoCallMethod>
    {
        #region Constructor

        public ReplaceManagerSpreadCallMethod(
            string rowString, 
            string colString,
            string spreadValiableName,
            string comment,
            string commentSeparator,
            SourceCodeInfoCallMethod value)
            : base(rowString, colString, spreadValiableName, comment, commentSeparator, value)
        {
            
        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            var retList = new List<ReplaceItem>();

            string spreadName = this.GetSpreadName();

            retList.Add(new ReplaceItem(spreadName + "set_RowHeight", spreadName + "ActiveSheet.SetRowHeight"));
            retList.Add(new ReplaceItem(spreadName + "SetActiveCell", spreadName + "ActiveSheet.SetActiveCell"));
            retList.Add(new ReplaceItem(spreadName + "set_ColWidth", spreadName + "ActiveSheet.SetColumnWidth"));
            retList.Add(new ReplaceItem(spreadName + "DeleteRows", spreadName + "ActiveSheet.RemoveRows"));
            retList.Add(new ReplaceItem(spreadName + "Note", spreadName + "ActiveSheet.Cells(" + this.RowStringMinusOne + ", " + this.ColStringMinusOne + ").Note"));            

            return retList.ToArray();
        }

        public override void Replace()
        {
            var subCodeInfo = this.SourceCodeInfo;
            var paramater = subCodeInfo.GetSourceCodeInfoParamater();

            new ReplaceManagerHaveParamaterValueSpread(this.RowString, this.ColString, this.SpreadValiableName,  subCodeInfo).Replace();
            this.ReplaceWithOutParam();
        }

        public void ReplaceWithOutParam()
        {
            var subCodeInfo = this.SourceCodeInfo;

            string spreadName = this.GetSpreadName();

            new ReplaceManagerSpreadGetCallMethod(
                this.RowString,
                this.ColString,
                this.SpreadValiableName,
                "★[]★置換ツールにより置換",
                "'",
                subCodeInfo).Replace();
            new ReplaceManagerSpreadSetCallMethod(
                this.RowString,
                this.ColString,
                this.SpreadValiableName,
                "★[]★置換ツールにより置換",
                "'",
                subCodeInfo).Replace();

            if (subCodeInfo.CallmethodName.Equals(spreadName + "get_MaxTextColWidth"))
            {
                subCodeInfo.SetAllOverWriteString(
                    spreadName + ".ActiveSheet.Columns(" + subCodeInfo.GetSourceCodeInfoParamater().GetSourceCodeInfoParamaterValue()[0].ParamaterName +
                    ").GetPreferredWidth())",
                    "'",
                    "★[]★置換ツールにより置換");
            }
            if (subCodeInfo.CallmethodName.Equals(spreadName + "get_MaxTextRowHeight"))
            {
                subCodeInfo.SetAllOverWriteString(
                    spreadName + ".ActiveSheet.Rows(" + subCodeInfo.GetSourceCodeInfoParamater().GetSourceCodeInfoParamaterValue()[0].ParamaterName +
                    ").GetPreferredHeight())",
                    "'",
                    "★[]★置換ツールにより置換");
            }
            else
            {

                foreach (var replaceItem in GetReplaceItems())
                {
                    ReplaceProc(replaceItem);
                }
            }
        }


        public void ReplaceProc(ReplaceItem item)
        {
            if (!item.TargetString.Equals(this.SourceCodeInfo.CallmethodName))
            {
                return;
            }

            this.SourceCodeInfo.CallmethodName = item.ReplaceString;
        }
    
    }
}

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
            SourceCodeInfoCallMethod value,
            int lineIndex)
            : base(rowString, colString, spreadValiableName, comment, commentSeparator, value, lineIndex)
        {
            
        }

        public ReplaceManagerSpreadCallMethod(
            string rowString,
            string colString,
            string spreadValiableName,
            string comment,
            string commentSeparator,
            SourceCodeInfoCallMethod value)
            : base(rowString, colString, spreadValiableName, comment, commentSeparator, value, value.GetCodeLineNumber())
        {

        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            var retList = new List<ReplaceItem>();

            string spreadName = this.GetSpreadName();

            retList.Add(new ReplaceItem("set_RowHeight", "ActiveSheet.SetRowHeight"));
            retList.Add(new ReplaceItem("SetActiveCell", "ActiveSheet.SetActiveCell"));
            retList.Add(new ReplaceItem("set_ColWidth", "ActiveSheet.SetColumnWidth"));
            retList.Add(new ReplaceItem("DeleteRows", "ActiveSheet.RemoveRows"));
            retList.Add(new ReplaceItem("Note", "ActiveSheet.Cells(" + this.RowStringMinusOne + ", " + this.ColStringMinusOne + ").Note"));            

            return retList.ToArray();
        }

        public override void Replace()
        {
            var subCodeInfo = this.SourceCodeInfo;
            var paramater = subCodeInfo.GetSourceCodeInfoParamaters();

            new ReplaceManagerHaveParamaterValueSpread(this.RowString, this.ColString, this.ValiableName, subCodeInfo).Replace();
            this.ReplaceWithOutParam();
        }

        public void ReplaceWithOutParam()
        {
            var subCodeInfo = this.SourceCodeInfo;

            string spreadName = this.GetSpreadName();

            new ReplaceManagerSpreadGetCallMethod(
                this.RowString,
                this.ColString,
                this.ValiableName,
                "",
                "",
                subCodeInfo,
                subCodeInfo.GetCodeLineNumber()).Replace();
            new ReplaceManagerSpreadSetCallMethod(
                this.RowString,
                this.ColString,
                this.ValiableName,
                "",
                "",
                subCodeInfo,
                subCodeInfo.GetCodeLineNumber()).Replace();

            if (subCodeInfo.CallmethodName.Equals("get_MaxTextColWidth")
                && this.SourceCodeInfo.ObjName.Equals(this.ValiableName))
            {
                subCodeInfo.SetAllOverWriteString(
                    spreadName + ".ActiveSheet.Columns(" + subCodeInfo.GetSourceCodeInfoParamaters()[0].GetSourceCodeInfoParamaterValue()[0].ParamaterName +
                    ").GetPreferredWidth())",
                    "",
                    "");
            }
            if (subCodeInfo.CallmethodName.Equals("get_MaxTextRowHeight")
                && this.SourceCodeInfo.ObjName.Equals(this.ValiableName))
            {
                subCodeInfo.SetAllOverWriteString(
                    spreadName + ".ActiveSheet.Rows(" + subCodeInfo.GetSourceCodeInfoParamaters()[0].GetSourceCodeInfoParamaterValue()[0].ParamaterName +
                    ").GetPreferredHeight())",
                    "",
                    "");
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
            if (!item.TargetString.Equals(this.SourceCodeInfo.CallmethodName)
                || !this.SourceCodeInfo.ObjName.Equals(this.ValiableName))
            {
                return;
            }

            this.SourceCodeInfo.CallmethodName = item.ReplaceString;
        }
    
    }
}

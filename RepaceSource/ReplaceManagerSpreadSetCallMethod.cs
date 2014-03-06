using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    class ReplaceManagerSpreadSetCallMethod : ReplaceManagerSpread<SourceCodeInfoCallMethod>
    {
        #region Constructor

        public ReplaceManagerSpreadSetCallMethod(
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
            var paramaterValues = this.SourceCodeInfo.GetSourceCodeInfoParamaters()[0].GetSourceCodeInfoParamaterValue();

            string spreadName = this.GetSpreadName();


            retList.Add(new ReplaceItem("SetInteger", "ActiveSheet.SetValue"));
            retList.Add(new ReplaceItem("SetFloat", "ActiveSheet.SetValue"));
            retList.Add(new ReplaceItem("SetText", "ActiveSheet.SetText"));

            return retList.ToArray();
        }

        public override void Replace()
        {
            var codeInfo = this.SourceCodeInfo;

            if (this.IsExistReplaceItem(codeInfo.CallmethodName)
                && codeInfo.ObjName.Equals(this.ValiableName))
            {
                var paramater = this.SourceCodeInfo.GetSourceCodeInfoParamaters();
                paramater[0].ChangeParamaterIndex(0, 1);

                var paramaterValues = paramater[0].GetSourceCodeInfoParamaterValue();

                paramaterValues[0].ParamaterName = this.GetAddMinusValue(paramaterValues[0].ParamaterName);
                paramaterValues[1].ParamaterName = this.GetAddMinusValue(paramaterValues[1].ParamaterName);

                codeInfo.CallmethodName = this.GetReplaceItem(codeInfo.CallmethodName).ReplaceString;
            }
        }
    }
}

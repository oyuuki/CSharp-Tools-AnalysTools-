using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace TestApp
{
    class ReplaceManagerSpreadSetCallMethod : ReplaceManagerSpread<SourceCodeInfoCallMethod>
    {
        #region Constructor

        public ReplaceManagerSpreadSetCallMethod(
            string rowString, 
            string colString,
            SourceCodeInfoCallMethod value)
            : base(rowString, colString, value)
        {
            
        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            var retList = new List<ReplaceItem>();
            var paramaterValues = this.SourceCodeInfo.GetSourceCodeInfoParamater().GetSourceCodeInfoParamaterValue();

            retList.Add(new ReplaceItem("SetInteger", "ActiveSheet.SetValue"));
            retList.Add(new ReplaceItem("SetFloat", "ActiveSheet.SetValue"));
            retList.Add(new ReplaceItem("SetText", "ActiveSheet.SetText"));

            return retList.ToArray();
        }

        public override void Replace()
        {
            var codeInfo = this.SourceCodeInfo;

            if (this.IsExistReplaceItem(codeInfo.CallmethodName))
            {
                var paramater = this.SourceCodeInfo.GetSourceCodeInfoParamater();


                var paramaterValues = paramater.GetSourceCodeInfoParamaterValue();
                var list = new List<SourceCodeInfo>();

                list.Add(paramaterValues[1]);
                list.Add(paramaterValues[0]);
                list.Add(paramaterValues[2]);
                paramater.ParamaterValues = list.ToArray();

                codeInfo.CallmethodName = this.GetReplaceItem(codeInfo.CallmethodName).ReplaceString;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    public class ReplaceManagerSpreadGetCallMethod : ReplaceManagerSpread<SourceCodeInfoCallMethod>
    {
        #region Constructor

        public ReplaceManagerSpreadGetCallMethod(
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
            var paramaterValues = this.SourceCodeInfo.GetSourceCodeInfoParamater().GetSourceCodeInfoParamaterValue();

            string spreadName = this.GetSpreadName();

            retList.Add(new ReplaceItem(spreadName + "GetInteger", "GetValue"));
            retList.Add(new ReplaceItem(spreadName + "GetFloat", "GetValue"));
            retList.Add(new ReplaceItem(spreadName + "GetText", "GetText"));

            return retList.ToArray();
        }

        private string GetMethodCode(string replaceMethodName)
        {
            var paramaterValues = this.SourceCodeInfo.GetSourceCodeInfoParamater().GetSourceCodeInfoParamaterValue();

            paramaterValues[1].ParamaterName = this.GetAddMinusValue(paramaterValues[1].ParamaterName);
            paramaterValues[0].ParamaterName = this.GetAddMinusValue(paramaterValues[0].ParamaterName);

            string spreadName = this.GetSpreadName();

            return paramaterValues[2].ParamaterName + " = " + spreadName + ".ActiveSheet." +
                   replaceMethodName + "(" + paramaterValues[1].ParamaterName + ", " +
                   paramaterValues[0].ParamaterName + ")";
        }

        

        public override void Replace()
        {
            var codeInfo = this.SourceCodeInfo;

            if (this.IsExistReplaceItem(codeInfo.CallmethodName))
            {
                codeInfo.SetAllOverWriteString(this.GetMethodCode(this.GetReplaceItem(this.SourceCodeInfo.CallmethodName).ReplaceString), this.CommentSeparator, this.Comment);
            }
        }   
    }
}

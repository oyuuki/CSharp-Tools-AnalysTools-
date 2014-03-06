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
            var paramaterValues = this.SourceCodeInfo.GetSourceCodeInfoParamaters()[0].GetSourceCodeInfoParamaterValue();

            retList.Add(new ReplaceItem("GetInteger", "GetValue"));
            retList.Add(new ReplaceItem("GetFloat", "GetValue"));
            retList.Add(new ReplaceItem("GetText", "GetText"));

            return retList.ToArray();
        }

        private string GetMethodCode(string replaceMethodName)
        {
            var paramaterValues = this.SourceCodeInfo.GetSourceCodeInfoParamaters()[0].GetSourceCodeInfoParamaterValue();

            paramaterValues[1].ParamaterName = this.GetAddMinusValue(paramaterValues[1].ParamaterName);
            paramaterValues[0].ParamaterName = this.GetAddMinusValue(paramaterValues[0].ParamaterName);

            return paramaterValues[2].ParamaterName + " = " + this.SourceCodeInfo.ObjName + ".ActiveSheet." +
                   replaceMethodName + "(" + paramaterValues[1].ParamaterName + ", " +
                   paramaterValues[0].ParamaterName + ")";
        }

        

        public override void Replace()
        {
            var codeInfo = this.SourceCodeInfo;

            if (this.IsExistReplaceItem(codeInfo.CallmethodName)
                && codeInfo.ObjName.Equals(this.ValiableName))
            {
                codeInfo.SetAllOverWriteString(this.GetMethodCode(this.GetReplaceItem(this.SourceCodeInfo.CallmethodName).ReplaceString), this.CommentSeparator, this.Comment);
            }
        }   
    }
}

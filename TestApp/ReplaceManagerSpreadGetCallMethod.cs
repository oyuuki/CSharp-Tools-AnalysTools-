﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace TestApp
{
    public class ReplaceManagerSpreadGetCallMethod : ReplaceManagerSpread<SourceCodeInfoCallMethod>
    {
        #region Constructor

        public ReplaceManagerSpreadGetCallMethod(
            string rowString, 
            string colString,
            string comment,
            string commentSeparator,
            SourceCodeInfoCallMethod value)
            : base(rowString, colString, comment, commentSeparator, value)
        {
            
        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            var retList = new List<ReplaceItem>();
            var paramaterValues = this.SourceCodeInfo.GetSourceCodeInfoParamater().GetSourceCodeInfoParamaterValue();

            retList.Add(new ReplaceItem("GetInteger", "GetValue"));
            retList.Add(new ReplaceItem("GetFloat", "GetValue"));
            retList.Add(new ReplaceItem("GetText", "GetText"));

            return retList.ToArray();
        }

        private string GetMethodCode(string replaceMethodName)
        {
            var paramaterValues = this.SourceCodeInfo.GetSourceCodeInfoParamater().GetSourceCodeInfoParamaterValue();

            return paramaterValues[2].ParamaterName + " = .ActiveSheet." +
                   replaceMethodName + "(" + paramaterValues[1].ParamaterName + "," +
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

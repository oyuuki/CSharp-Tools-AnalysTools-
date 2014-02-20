using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    public class ReplaceManagerAdoDatasetCallMethod : ReplaceManager<SourceCodeInfoCallMethod>
    {
        #region Constructor

        public ReplaceManagerAdoDatasetCallMethod(
            string valiableName,
            string comment,
            string commentSeparator,
            SourceCodeInfoCallMethod value)
            : base(value,  comment, commentSeparator, valiableName)
        {
            
        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            var retList = new List<ReplaceItem>();

            return retList.ToArray();
        }

        public override void Replace()
        {
            var subCodeInfo = this.SourceCodeInfo;
            var paramater = subCodeInfo.GetSourceCodeInfoParamater();

            new ReplaceManagerHaveParamaterValueAdoDataset(this.ValiableName, subCodeInfo).Replace();
            this.ReplaceWithOutParam();
        }

        public void ReplaceWithOutParam()
        {
            var subCodeInfo = this.SourceCodeInfo;

            if (subCodeInfo.CallmethodName.Equals("Fields")
                && this.SourceCodeInfo.ObjName.Equals(this.ValiableName))
            {
                subCodeInfo.SetAllOverWriteString(
                    this.SourceCodeInfo.ObjName + "." + subCodeInfo.CallmethodName + subCodeInfo.GetSourceCodeInfoParamater().GetSourceCodeInfoParamaterValue()[0] + ".Value",
                    "",
                    "");
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

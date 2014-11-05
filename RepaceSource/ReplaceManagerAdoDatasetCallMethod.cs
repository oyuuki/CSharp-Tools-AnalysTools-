using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyuLib.Documents.Sources.Analysis;
using OyuLib.IO;

namespace RepaceSource
{
    public class ReplaceManagerAdoDatasetCallMethod : ReplaceManager<SourceCodeInfoCallMethod>
    {
        #region instranceVal

        private SourceCodeInfoParamaterValueElementStrage _elementStrage = null;

        #endregion

        #region Constructor

        public ReplaceManagerAdoDatasetCallMethod(
            string valiableName,
            string comment,
            string commentSeparator,
            SourceCodeInfoCallMethod value,
            SourceCodeInfoParamaterValueElementStrage elementStrage)
            : base(value, comment, commentSeparator, valiableName, value.GetCodeLineNumber())
        {
            this._elementStrage = elementStrage;            
        }

        public ReplaceManagerAdoDatasetCallMethod(
            string valiableName,
            string comment,
            string commentSeparator,
            SourceCodeInfoCallMethod value)
            : base(value, comment, commentSeparator, valiableName, value.GetCodeLineNumber())
        {
            
        }

        #endregion

        #region Property

        public SourceCodeInfoParamaterValueElementStrage ElementStrage
        {
            get{ return this._elementStrage; }
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
            var paramater = subCodeInfo.GetSourceCodeInfoParamaters();

            new ReplaceManagerHaveParamaterValueAdoDataset(this.ValiableName, subCodeInfo).Replace();
            this.ReplaceWithOutParam();
        }

        public void ReplaceWithOutParam()
        {
            var subCodeInfo = this.SourceCodeInfo;  
             

            if (subCodeInfo.CallmethodName.Equals("Fields")
                && this.SourceCodeInfo.ObjName.Equals(this.ValiableName))
            {
                if (this.ElementStrage == null
                    || this.ElementStrage.AefLinkValue == null)
                {
                    LogOut.WriteTraceLog(".Value置換開始 " + this.LineIndex.ToString() + " " + subCodeInfo.GetCodeString());
                    subCodeInfo.SetAllOverWriteString(
                        this.SourceCodeInfo.ObjName + "." + subCodeInfo.CallmethodName + "(" +
                            subCodeInfo.GetSourceCodeInfoParamaters()[0].GetSourceCodeInfoParamaterValue()[0].ParamaterName + ")" + ".Value"
                            ,
                        "",
                        "");
                }
                else if(this.ElementStrage.AefLinkValue.Value is SourceCodeInfoParamaterValueElement)
                {
                    var aftElementValue = (SourceCodeInfoParamaterValueElement)this.ElementStrage.AefLinkValue.Value;


                    // すでに置換済みのコードは処理しない
                    if(aftElementValue.ParamaterName.Equals(".Value"))
                    {
                        return;
                    }

                    // 他のメソッド、またはプロパティﾒﾝﾊﾞ変数を参照している場合もしない
                    if (aftElementValue.ParamaterName.StartsWith("."))
                    {
                        return;
                    }

                    LogOut.WriteTraceLog(".Value置換開始 " + this.LineIndex.ToString() + " " + subCodeInfo.GetCodeString());

                    var replacedAftElementParamaterName = aftElementValue.ParamaterName.Replace(".Value", string.Empty);

                    aftElementValue.ParamaterName = replacedAftElementParamaterName;

                    var valueString = ".Value";

                    if(!string.IsNullOrEmpty(aftElementValue.ParamaterName))
                    {
                        valueString = string.Empty;    
                    }
                    

                    subCodeInfo.SetAllOverWriteString(
                        this.SourceCodeInfo.ObjName + "." + subCodeInfo.CallmethodName + "(" +
                            subCodeInfo.GetSourceCodeInfoParamaters()[0].GetSourceCodeInfoParamaterValue()[0].ParamaterName + ")" + valueString
                            ,
                        "",
                        "");
                }
                else if(this.ElementStrage.AefLinkValue.Value is SourceCodeInfoCallMethod)
                {
                    var aftElementValue = (SourceCodeInfoCallMethod)this.ElementStrage.AefLinkValue.Value;

                    if (aftElementValue.CallmethodName.IndexOf("Cells") >= 0)
                    {
                        aftElementValue.SetAllOverWriteStringBlank();
                    }

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

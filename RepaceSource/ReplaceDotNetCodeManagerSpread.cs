using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    class ReplaceDotNetCodeManagerSpread : ReplaceManager<SourceCodeInfoCallMethod>
    {
        #region instranceVal

        private SourceCodeInfoParamaterValueElementStrage _elementStrage = null;

        #endregion

        #region Constructor

        public ReplaceDotNetCodeManagerSpread(
            string comment,
            string commentSeparator,
            SourceCodeInfoCallMethod value,
            SourceCodeInfoParamaterValueElementStrage elementStrage)
            : base(value, comment, commentSeparator, string.Empty)
        {
            this._elementStrage = elementStrage;            
        }

        public ReplaceDotNetCodeManagerSpread(
            string comment,
            string commentSeparator,
            SourceCodeInfoCallMethod value)
            : base(value, comment, commentSeparator, string.Empty)
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

            if ((subCodeInfo.CallmethodName.Equals("Cells")
                || subCodeInfo.CallmethodName.Equals("SetValue")
                || subCodeInfo.CallmethodName.Equals("SetText")
                || subCodeInfo.CallmethodName.Equals("GetText")
                || subCodeInfo.CallmethodName.Equals("GetValue"))
                && this.SourceCodeInfo.ObjName.Equals("ActiveSheet"))
            {
                var paramValues = this.SourceCodeInfo.GetSourceCodeInfoParamaters()[0].ParamaterValues;

                string eventArgsRowString = "eventArgs.Row";
                string eventArgsNewRowString = "eventArgs.NewRow";
                string eventArgsColumnString = "eventArgs.Column";
                string eventArgsNewColumnString = "eventArgs.NewColumn";
                string activeRowIndexString = ".ActiveSheet.ActiveRowIndex";
                string activeColumnIndexString = ".ActiveSheet.ActiveColumnIndex";

                this.DeleteMinusParams(0, eventArgsRowString);
                this.DeleteMinusParams(1, eventArgsRowString);

                this.DeleteMinusParams(0, eventArgsNewRowString);
                this.DeleteMinusParams(1, eventArgsNewRowString);

                this.DeleteMinusParams(0, eventArgsColumnString);
                this.DeleteMinusParams(1, eventArgsColumnString);

                this.DeleteMinusParams(0, eventArgsNewColumnString);
                this.DeleteMinusParams(1, eventArgsNewColumnString);

                this.DeleteMinusParams(0, activeRowIndexString);
                this.DeleteMinusParams(1, activeRowIndexString);

                this.DeleteMinusParams(0, activeColumnIndexString);
                this.DeleteMinusParams(1, activeColumnIndexString);

                if (subCodeInfo.CallmethodName.Equals("Cells"))
                {
                    var isMinusRow = this.IsHaveSearchStringTwoParams(paramValues[0], "-1 - 1");
                    var isMinusColumn = this.IsHaveSearchStringTwoParams(paramValues[1], "-1 - 1");

                    if (isMinusRow && isMinusColumn)
                    {
                        return;
                    }

                    if (isMinusRow)
                    {
                        subCodeInfo.CallmethodName = "Columns";
                        this.SourceCodeInfo.GetSourceCodeInfoParamaters()[0].ParamaterValues = new SourceCodeInfoParamaterValue[] { paramValues[1] };
                    }
                    else if (isMinusColumn)
                    {
                        paramValues[0].Separator = string.Empty;
                        subCodeInfo.CallmethodName = "Rows";
                        this.SourceCodeInfo.GetSourceCodeInfoParamaters()[0].ParamaterValues = new SourceCodeInfoParamaterValue[] { paramValues[0] };
                    }
                }
            }
            else if (subCodeInfo.CallmethodName.Equals("SetActiveCell")
                && this.SourceCodeInfo.ObjName.Equals("ActiveSheet"))
            {
                if(subCodeInfo.GetCodeString().IndexOf("元コード：.SetActiveCell") >= 0)
                {
                    subCodeInfo.CallmethodName = "SetActiveCell";
                    this.SourceCodeInfo.GetSourceCodeInfoParamaters()[0].ChangeParamaterIndex(0, 1);
                }
            }
        }


        private void DeleteMinusParams(int paramaterIndex, string searchString)
        {
            var paramValues = this.SourceCodeInfo.GetSourceCodeInfoParamaters()[0].ParamaterValues;

            if(paramValues.Length < 2)
            {
                return;
            }

            var paramValue = paramValues[paramaterIndex];

            var locSearchString = searchString + " - 1";

            var isfind = this.IsHaveSearchStringTwoParams(paramValue, locSearchString);

            if(isfind)
            {
                
                var list = new List<SourceCodeInfoParamaterValueElementStrage>();

                list.AddRange(this.SourceCodeInfo.GetSourceCodeInfoParamaters()[0].ParamaterValues[paramaterIndex].ElementStrages);
                list.RemoveAt(1);
                if (list.Count == 1)
                {
                    ((SourceCodeInfoParamaterValueElement)list[0].Value).DeleteAftSymbol();
                }

                ((SourceCodeInfoParamaterValueElement)paramValue.ElementStrages[0].Value).ParamaterName = ((SourceCodeInfoParamaterValueElement)paramValue.ElementStrages[0].Value).ParamaterName;
                this.SourceCodeInfo.GetSourceCodeInfoParamaters()[0].ParamaterValues[paramaterIndex].ReSetElementStrages(list.ToArray() );
                
            }
        }

        private bool IsHaveSearchStringTwoParams(SourceCodeInfoParamaterValue paramValue, string searchString)
        {
            if (paramValue.ElementStrages.Count() >= 2)
            {
                if (paramValue.ElementStrages[0].Value is SourceCodeInfoParamaterValueElement
                    && paramValue.ElementStrages[1].Value is SourceCodeInfoParamaterValueElement)
                {
                    var element1 = (SourceCodeInfoParamaterValueElement)paramValue.ElementStrages[0].Value;
                    var element2 = (SourceCodeInfoParamaterValueElement)paramValue.ElementStrages[1].Value;

                    if (paramValue.GetCodeString().Trim().IndexOf(searchString) >= 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public void ReplaceProc(ReplaceItem item)
        {
            return;
        }
    }
}

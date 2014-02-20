using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    public class ReplaceManagerSpreadSubstitution : ReplaceManagerSpread<SourceCodeInfoSubstitution>
    {
        #region Constructor

        public ReplaceManagerSpreadSubstitution(
            string rowString, 
            string colString,
            string spreadValiableName,
            string comment,
            string commentSeparator,
            SourceCodeInfoSubstitution value)
            : base(rowString, colString, spreadValiableName, comment, commentSeparator, value)
        {
            
        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            return CommonSpreadPlaceItemManager.GetPropertyReplaceItems(this.RowStringMinusOne, this.ColStringMinusOne, this.ValiableName);
        }

        public override void Replace()
        {
            var subCodeInfo = this.SourceCodeInfo;

            string spreadName = this.ValiableName;

            if (subCodeInfo.LeftHandSide.Equals(spreadName + ".Row")
                || subCodeInfo.LeftHandSide.Equals(spreadName + ".eventArgs.Row"))
            {
                var item = this.GetReplaceItem(subCodeInfo.RightHandSide);

                if (item != null)
                {
                    subCodeInfo.RightHandSide = item.ReplaceString;
                }

                this.RowString = subCodeInfo.RightHandSide;
                subCodeInfo.CommentString = "' ★置換ツールによりコメント化";
            }
            else if (subCodeInfo.LeftHandSide.Equals(spreadName + ".Col")
                || subCodeInfo.LeftHandSide.Equals(spreadName + ".eventArgs.Col"))
            {
                var item = this.GetReplaceItem(subCodeInfo.RightHandSide);

                if (item != null)
                {
                    subCodeInfo.RightHandSide = item.ReplaceString;
                }

                this.ColString = subCodeInfo.RightHandSide;
                subCodeInfo.CommentString = "' ★置換ツールによりコメント化";
            }
            else if (subCodeInfo.RightHandSide.Equals(spreadName + ".Row"))
            {
              //  subCodeInfo.RightHandSide = this.RowString;
            }
            else if (subCodeInfo.RightHandSide.Equals(spreadName + ".Col"))
            {
              //  subCodeInfo.RightHandSide = this.ColString;
            }
            else if (subCodeInfo.LeftHandSide.Equals(spreadName + ".Action"))
            {
                new ReplaceManagerSpreadActionSubstitution(
                    this.RowString, 
                    this.ColString,
                    this.ValiableName,
                    "",
                    "",
                    this.SourceCodeInfo).Replace();
            }
            else if (subCodeInfo.LeftHandSide.Equals(spreadName + ".ReDraw"))
            {
                var redrowMethodName = string.Empty;

                if (subCodeInfo.RightHandSide.Trim().Equals(spreadName + "True"))
                {
                    redrowMethodName = spreadName + ".ResumeLayout()";                                     
                }
                else
                {
                    redrowMethodName = spreadName + ".SuspendLayout()";
                }

                subCodeInfo.SetAllOverWriteString(
                    redrowMethodName, 
                    "", 
                    "");
            }
            else if (subCodeInfo.LeftHandSide.Equals(spreadName + ".Text"))
            {
                subCodeInfo.SetAllOverWriteString(spreadName + ".ActiveSheet.SetText(" + this.RowString + " - 1" + ", " + this.ColString + " - 1" + ", " + subCodeInfo.RightHandSide + ")", "'", "★[]★置換ツールにより置換");
            }
            else if (subCodeInfo.LeftHandSide.Equals(spreadName + ".NewLeft"))
            {
                subCodeInfo.SetAllOverWriteString(spreadName + ".SetViewportLeftColumn(0, " + subCodeInfo.RightHandSide + ")", "'", "★[]★置換ツールにより置換");
            }
            else if (subCodeInfo.RightHandSide.StartsWith(spreadName + ".SearchCol"))
            {
                var codeInfoCallMethod  = (SourceCodeInfoCallMethod)subCodeInfo.GetSourceCodeInfoParamater().ParamaterValues[0];
                var paramValues = codeInfoCallMethod.GetSourceCodeInfoParamater().ParamaterValues;

                subCodeInfo.SetAllOverWriteString(
                    "Dim col As Integer　 '見つかった列    ★[]★置換ツールにより追加したコード col\n" +
                    spreadName + ".Search(0, " + "\"" + "TEST" + "\"" + ", False, True, True, False, " + 
                    paramValues[1].GetCodeString() + ", " +
                    paramValues[0].GetCodeString() + ", " +
                    paramValues[3].GetCodeString() + ", " +
                    paramValues[2].GetCodeString() + ", " +
                    subCodeInfo.LeftHandSide + ", " +
                    "col" + ") ",
                    "",
                    "");
            }
            else if (subCodeInfo.LeftHandSide.Equals(spreadName + ".TypeCurrencySymbol"))
            {
                var currencyCellValiableName = spreadName + "currencyCell" + subCodeInfo.LeftHandSide;

                subCodeInfo.SetAllOverWriteString(
                    "Dim " + currencyCellValiableName + " As New FarPoint.Win.Spread.CellType.CurrencyCellType '★[]★置換ツールにより追加\n" +
                    currencyCellValiableName + ".CurrencySymbol = " + "\"" + "\\" +  "\"" + "'★[]★置換ツールにより追加\n" +
                    spreadName + ".ActiveSheet.Cells(" + this.RowStringMinusOne + ", " + this.ColStringMinusOne + ").CellType = currencyCell",
                    "", 
                    "");

            }
            else if (subCodeInfo.LeftHandSide.Equals(spreadName + ".TypeHAlign"))
            {
                subCodeInfo.LeftHandSide = spreadName + ".ActiveSheet.Cells(" + this.RowStringMinusOne + ", " + this.ColStringMinusOne + ").HorizontalAlignment";

                if(subCodeInfo.RightHandSide.Equals("FPSpread.TypeHAlignConstants.TypeHAlignCenter"))
                {
                    subCodeInfo.RightHandSide = "FarPoint.Win.Spread.CellHorizontalAlignment.Center";
                }
                else if(subCodeInfo.RightHandSide.Equals("FPSpread.TypeHAlignConstants.TypeHAlignLeft"))
                {
                    subCodeInfo.RightHandSide = "FarPoint.Win.Spread.CellHorizontalAlignment.Left";
                }
                else if(subCodeInfo.RightHandSide.Equals("FPSpread.TypeHAlignConstants.TypeHAlignRight"))
                {
                    subCodeInfo.RightHandSide = "FarPoint.Win.Spread.CellHorizontalAlignment.Right";
                }
            }
            else if (subCodeInfo.LeftHandSide.Equals(spreadName + ".Clip"))
            {
                subCodeInfo.LeftHandSide = spreadName + ".SetClip";
                subCodeInfo.RightHandSide = "(" + this.RowStringMinusOne + ", " + this.ColStringMinusOne + ", " + subCodeInfo.RightHandSide + ")";
            }
            else if (subCodeInfo.RightHandSide.Equals(spreadName + ".Clip"))
            {
                subCodeInfo.RightHandSide = spreadName + ".GetClip(" + this.RowStringMinusOne + ", 1, 1, " + this.ColStringMinusOne + ")";
            }
            else
            {
                foreach (var replaceItem in this.GetReplaceItems())
                {
                    this.SetSubstitutionValue(subCodeInfo, replaceItem.TargetString);
                }
            }
        }

        private bool SetSubstitutionValue(
            SourceCodeInfoSubstitution codeinfo,
            string targetString)
        {
            var replaceItem = this.GetReplaceItem(targetString);

            if (codeinfo.LeftHandSide.Equals(replaceItem.TargetString))
            {
                codeinfo.LeftHandSide = replaceItem.ReplaceString;
                return true;
            }
            else if (codeinfo.RightHandSide.Equals(replaceItem.TargetString))
            {
               // codeinfo.RightHandSide = replaceItem.ReplaceString;
               // return true;
            }

            return false;
        }
    }
}

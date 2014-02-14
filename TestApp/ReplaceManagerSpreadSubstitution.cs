using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace TestApp
{
    public class ReplaceManagerSpreadSubstitution : ReplaceManagerSpread<SourceCodeInfoSubstitution>
    {
        #region Constructor

        public ReplaceManagerSpreadSubstitution(
            string rowString, 
            string colString, 
            SourceCodeInfoSubstitution value)
            : base(rowString, colString, value)
        {
            
        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            return CommonPlaceitemManager.GetSpreadPropertyReplaceItems(this.RowString, this.ColString);
        }

        public override void Replace()
        {
            var subCodeInfo = this.SourceCodeInfo;

            if (subCodeInfo.LeftHandSide.Equals(".Row"))
            {
                this.RowString = subCodeInfo.RightHandSide + " -1";
                subCodeInfo.CommentString = "' 置換ツールによりコメント化";
            }
            else if (subCodeInfo.LeftHandSide.Equals(".Col"))
            {
                this.ColString = subCodeInfo.RightHandSide + " -1";
                subCodeInfo.CommentString = "' 置換ツールによりコメント化";
            }
            else if (subCodeInfo.RightHandSide.Equals(".Row"))
            {
                subCodeInfo.RightHandSide = this.RowString;
            }
            else if (subCodeInfo.RightHandSide.Equals(".Col"))
            {
                subCodeInfo.RightHandSide = this.ColString;
            }
            else if (subCodeInfo.LeftHandSide.Equals(".Action"))
            {
                new ReplaceManagerSpreadActionSubstitution(this.RowString, this.ColString, this.SourceCodeInfo).Replace();
            }
            else if (subCodeInfo.LeftHandSide.Equals(".ReDraw"))
            {
                var redrowMethodName = string.Empty;

                if (subCodeInfo.RightHandSide.Trim().Equals("True"))
                {
                    redrowMethodName = ".ResumeLayout()";                                     
                }
                else
                {
                    redrowMethodName = ".SuspendLayout()";
                }

                subCodeInfo.AllOverWriteString = redrowMethodName;
            }
            else if (subCodeInfo.LeftHandSide.Equals(".Text"))
            {
                subCodeInfo.AllOverWriteString = ".ActiveSheet.SetText(" + this.RowString + ", " + this.ColString + ", " + subCodeInfo.RightHandSide + ")";
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
                codeinfo.RightHandSide = replaceItem.ReplaceString;
                return true;
            }

            return false;
        }
    }
}

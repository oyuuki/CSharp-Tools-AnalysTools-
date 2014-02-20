using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    public class ReplaceManagerGcDateSubstitution : ReplaceManager<SourceCodeInfoSubstitution>
    {
        #region Constructor

        public ReplaceManagerGcDateSubstitution(
            string valiableName,
            string comment,
            string commentSeparator,
            SourceCodeInfoSubstitution value)
            : base(value, comment, commentSeparator, valiableName)
        {
            
        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            return CommonGcDatePlaceItemManager.GetPropertyReplaceItems(this.ValiableName);
        }

        public override void Replace()
        {
            this.SourceCodeInfo.SetAllOverWriteString(this.GetReplaceItem(this.SourceCodeInfo.RightHandSide).ReplaceString, this.CommentSeparator, this.Comment);
        }
    }
}

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
            : base(value, comment, commentSeparator, valiableName, value.GetCodeLineNumber())
        {
            
        }

        #endregion

        public override ReplaceItem[] GetReplaceItems()
        {
            return CommonGcDatePlaceItemManager.GetPropertyReplaceItems(this.ValiableName);
        }

        public override void Replace()
        {
            var replaceItem = this.GetReplaceItem(this.SourceCodeInfo.LeftHandSide);

            if (replaceItem != null)
            {
                this.SourceCodeInfo.LeftHandSide = replaceItem.ReplaceString;
            }
        }
    }
}

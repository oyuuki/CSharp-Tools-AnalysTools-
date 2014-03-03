using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyuLib.Documents.Sources;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    public class ReplaceManagerHaveParamaterValueGcDate : ReplaceManagerHaveParamaterValue
    {
        #region InstanceVal

        #endregion

        #region Constructor

        public ReplaceManagerHaveParamaterValueGcDate( 
            string valiableName,
            IParamater value)
            : base(value, valiableName)
        {
        }

        #endregion

        #region Method

        #region Override

        public override ReplaceItem[] GetReplaceItems()
        {
            return CommonGcDatePlaceItemManager.GetPropertyReplaceItems(this.ValiableName);
        }

        public override void ReplaceIParamater(SourceCodeInfoParamaterValueElementStrage paramater)
        {
            return;
        }

        #endregion

        #endregion
    }
}

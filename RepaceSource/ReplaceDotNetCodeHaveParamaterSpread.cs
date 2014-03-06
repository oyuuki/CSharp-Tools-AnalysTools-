using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyuLib.Documents.Sources;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    class ReplaceDotNetCodeHaveParamaterSpread
        : ReplaceManagerHaveParamaterValue
    {
        #region InstanceVal

        #endregion

        #region Constructor

        public ReplaceDotNetCodeHaveParamaterSpread( 
            IParamater value)
            : base(value, string.Empty)
        {
        }

        #endregion

        #region Method

        #region Override

        public override ReplaceItem[] GetReplaceItems()
        {
            return new List<ReplaceItem>().ToArray();
        }

        public override void ReplaceIParamater(SourceCodeInfoParamaterValueElementStrage paramater)
        {
            if (paramater.Value is SourceCodeInfoCallMethod)
            {
                

                new ReplaceDotNetCodeManagerSpread(
                    "",
                    "",
                    (SourceCodeInfoCallMethod)paramater.Value,
                    paramater).ReplaceWithOutParam();
            }
        }

        #endregion

        #endregion
    }
}

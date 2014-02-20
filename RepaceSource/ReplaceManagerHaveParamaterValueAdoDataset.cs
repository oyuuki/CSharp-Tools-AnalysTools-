using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyuLib.Documents.Sources;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    public class ReplaceManagerHaveParamaterValueAdoDataset : ReplaceManagerHaveParamaterValue
    {
        #region InstanceVal

        #endregion

        #region Constructor

        public ReplaceManagerHaveParamaterValueAdoDataset( 
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
            return new List<ReplaceItem>().ToArray();
        }

        public override void ReplaceIParamater(IParamater paramater)
        {
            if (paramater is SourceCodeInfoCallMethod)
            {
                new ReplaceManagerAdoDatasetCallMethod(
                    this.ValiableName,
                    "",
                    "",
                    (SourceCodeInfoCallMethod)paramater).ReplaceWithOutParam();
            }
        }

        #endregion

        #endregion
    }
}

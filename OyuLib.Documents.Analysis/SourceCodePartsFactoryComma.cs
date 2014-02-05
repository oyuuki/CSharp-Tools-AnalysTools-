using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsFactoryCommat : SourceCodePartsfactoryNocomment
    {
        #region Constructor

        public SourceCodePartsFactoryCommat(
            SourceCode code)
            : base(code, ",")
        {
            
        }

        #endregion        
    }
}

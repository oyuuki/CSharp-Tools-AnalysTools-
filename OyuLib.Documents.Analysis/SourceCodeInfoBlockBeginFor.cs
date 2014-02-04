using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockBeginFor : SourceCodeInfoBlockBegin
    {
        #region Constructor

        public SourceCodeInfoBlockBeginFor(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
            
        }

        public SourceCodeInfoBlockBeginFor(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement,
            int statementObject)
            : base(code, coFac, statement, statementObject)
        {
            
        }

        #endregion

        #region Method

        #region OverRide

        public override Type GetCodeInfoBlockEndType()
        {
            return typeof (SourceCodeInfoBlockEndFor);
        }

        #endregion

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockBeginDoWhile : SourceCodeInfoBlockBegin
    {
        #region Constructor

        public SourceCodeInfoBlockBeginDoWhile(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
            
        }

        public SourceCodeInfoBlockBeginDoWhile(
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
            return typeof(SourceCodeInfoBlockEndDoWhile);
        }

        #endregion

        #endregion
    }
}

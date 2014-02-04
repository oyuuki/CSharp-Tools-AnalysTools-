using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockBeginCaseFormula : SourceCodeInfoBlockBegin
    {
        #region Constructor

        public SourceCodeInfoBlockBeginCaseFormula(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
            
        }

        public SourceCodeInfoBlockBeginCaseFormula(
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
            return typeof(SourceCodeInfoBlockEndCaseFormula);
        }

        #endregion

        #endregion
    }
}

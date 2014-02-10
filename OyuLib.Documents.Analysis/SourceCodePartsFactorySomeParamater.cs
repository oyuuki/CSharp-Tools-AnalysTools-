using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsFactorySomeParamater  : SourceCodePartsfactoryNocomment
    {
       #region Constructor

        public SourceCodePartsFactorySomeParamater(
            SourceCode code,
            string[] codeDelimiters)
            : this(code, codeDelimiters, true)
        {
            
        }

        public SourceCodePartsFactorySomeParamater(
            SourceCode code,
            string[] codeDelimiters,
            bool doTrim)
            : base(code, codeDelimiters, doTrim)
        {

        }

        #endregion

        #region Method

        #region OverRide

        protected override StringRange[] GetCodePartsRanges(string withOutComment)
        {
            return
                new StringSpilitter(withOutComment).GetStringRangeSpilitIgnoreNestedString(
                    this.CodeDelimiters, 
                    new ManagerStringNested("(", ")"),
                    new ManagerStringNested("\"", "\""));
        }

        #endregion

        #endregion

    }
}

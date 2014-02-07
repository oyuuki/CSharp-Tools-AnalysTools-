using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsFactoryParamater : SourceCodePartsfactoryNocomment
    {
        #region Constructor

        public SourceCodePartsFactoryParamater(
            SourceCode code)
            : this(code, true)
        {
            
        }

        public SourceCodePartsFactoryParamater(
            SourceCode code,
            bool doTrim)
            : base(code, " ", doTrim)
        {

        }

        #endregion

        #region Method

        #region OverRide

        protected override StringRange[] GetCodePartsRanges(string withOutComment)
        {
            return
                new StringSpilitter(withOutComment).GetStringRangeSpilit(
                    new CharCode(this.CodeDelimiter).GetCharCodeString(), new ManagerStringNested("(", ")"));
        }

        #endregion

        #endregion

    }
}

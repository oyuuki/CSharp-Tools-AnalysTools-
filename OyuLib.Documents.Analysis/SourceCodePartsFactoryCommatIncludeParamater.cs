using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsFactoryCommatIncludeParamater : SourceCodePartsFactoryCommat
    {
        #region Constructor

        public SourceCodePartsFactoryCommatIncludeParamater(
            SourceCode code)
            : base(code)
        {
            
        }

        public SourceCodePartsFactoryCommatIncludeParamater(
            SourceCode code,
            string codeDelimiter)
            : base(code, codeDelimiter)
        {

        }

        #endregion

        #region Method

        #region Override

        protected override StringRange[] GetCodePartsRanges(string withOutComment)
        {
            return
                new StringSpilitter(withOutComment).GetStringRangeSpilitIncludeNestedString(
                    new CharCode(this.CodeDelimiter).GetCharCodeString(), new ManagerStringNested("(", ")"));
        }


        #endregion

        #endregion
    }
}

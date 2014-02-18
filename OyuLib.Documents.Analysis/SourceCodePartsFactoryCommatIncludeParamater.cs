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

        public SourceCodePartsFactoryCommatIncludeParamater(
            SourceCode code,
            string[] codeDelimiters)
            : base(code, codeDelimiters)
        {

        }

        #endregion

        #region Method

        #region Override

        protected override StringRange[] GetCodePartsRanges(string withOutComment)
        {
            return
                //new StringSpilitter(withOutComment).GetStringRangeSpilitIncludeNestedString(
                new StringSpilitter(withOutComment).GetStringRangeSpilitIgnoreNestedStringAndSeparator(
                    this.CodeDelimiters, new ManagerStringNested("(", ")"), new ManagerStringNested("\"", "\""));
            
        }


        #endregion

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsFactoryVBDotNetAddHandler : SourceCodePartsfactoryNocomment
    {
        #region Constructor

        public SourceCodePartsFactoryVBDotNetAddHandler(SourceCode code)
            : base(code, " ")
        {

        }

        #endregion

        #region Method

        #region Override

        protected override StringRange[] GetCodePartsRanges(string withOutComment)
        {
            return
                new StringSpilitter(withOutComment).GetStringRangeSpilitIgnoreNestedString(
                    new string[] { new CharCode(" ").GetCharCodeString(), new CharCode(",").GetCharCodeString() },
                    new ManagerStringNested("(!#$%%&", "(!#$%%&"),
                    new ManagerStringNested[] { new ManagerStringNested("(", ")"), new ManagerStringNested("\"", "\"") });
        }


        #endregion

        #endregion

    }
}

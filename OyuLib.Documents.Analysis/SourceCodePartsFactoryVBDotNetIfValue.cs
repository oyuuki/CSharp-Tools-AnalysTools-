using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsFactoryVBDotNetIfValue : SourceCodePartsfactoryNocomment
    {
        #region Constructor

        public SourceCodePartsFactoryVBDotNetIfValue(
            SourceCode code)
            : base(code, new string[] { " And ", " Or ", " Not ", "Not ", " <> ", " >= ", " <= ", " = ", " < ", " > ", " + ", " - ", " * ", " / ", " Is ", " & "})
        {

        }

        #endregion

        #region Method

        #region Override

        protected override StringRange[] GetCodePartsRanges(string withOutComment)
        {
            return
                new StringSpilitter(withOutComment).GetStringRangeSpilitIncludeNestedString(
                    this.CodeDelimiters, 
                    new ManagerStringNested("(", ")"));
        }


        #endregion

        #endregion
    }
}

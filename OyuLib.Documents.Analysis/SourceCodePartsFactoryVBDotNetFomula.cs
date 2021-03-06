﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsFactoryVBDotNetFomula : SourceCodePartsfactoryNocomment
    {
        #region Constructor

        public SourceCodePartsFactoryVBDotNetFomula(
            SourceCode code)
            : base(code, new string[] { " And ", " Or ", " Not ", "Not ", " <> ", " >= ", " <= ", " = ", " < ", " > ", " + ", " - ", " * ", " / ", " Is ", " & " })
        {

        }

        #endregion

        #region Method

        #region Override

        protected override StringRange[] GetCodePartsRanges(string withOutComment)
        {
            return
                new StringSpilitter(withOutComment).GetStringRangeSpilitIgnoreSeparator(
                    this.CodeDelimiters,
                    new ManagerStringNested("\"", "\""), 
                    new ManagerStringNested("(", ")"));
        }


        #endregion

        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockBeginFor : CodeInfoBlockBegin<CodeInfoBlockEndFor>
    {
        #region Constructor

        public CodeInfoBlockBeginFor(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
            
        }

        public CodeInfoBlockBeginFor(
            Code code,
            CodePartsFactory coFac,
            int statement,
            int statementObject)
            : base(code, coFac, statement, statementObject)
        {
            
        }

        #endregion
    }
}

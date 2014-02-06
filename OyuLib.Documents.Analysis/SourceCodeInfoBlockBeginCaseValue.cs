using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockBeginCaseValue : SourceCodeInfo
    {
        #region instanceVal

        private int _value = -1;

        #endregion

        #region Constructor

        public SourceCodeInfoBlockBeginCaseValue(int value)
            : base()
        {
            this._value = value;
        }

        public SourceCodeInfoBlockBeginCaseValue(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int value)
            : base(code, coFac)
        {
            this._value = value;
        }

        #endregion

        protected override string GetCodeText()
        {
            return "CASE：";
            
        }

        public override NestIndex[] GetNestIndices()
        {
            return new NestIndex[] {new NestIndex(this._value)};
        }                        
    }
}

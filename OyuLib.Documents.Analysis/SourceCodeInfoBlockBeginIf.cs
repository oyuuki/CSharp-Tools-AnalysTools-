using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockBeginIf : SourceCodeInfoBlockBegin, IParamater
    {
        #region instanceVaｌ

        private SourceCodeInfoParamater _sourceCodeInfoParamaterValueMethod = null;

        private StringRange _range = null;

        #endregion

        #region Constructor

        public SourceCodeInfoBlockBeginIf(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
               
        }

        public SourceCodeInfoBlockBeginIf(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement,
            int statementObject,
            SourceCodeInfoParamater sourceCodeInfoParamaterValueMethod)
            : base(code, coFac, statement, statementObject)
        {
            this._sourceCodeInfoParamaterValueMethod = sourceCodeInfoParamaterValueMethod;
        }

        #endregion

        #region Property

        public SourceCodeInfoParamater Paramater
        {
            get { return this._sourceCodeInfoParamaterValueMethod; }
        }

        public StringRange Range
        {
            get { return this._range; }
            set { this._range = value; }
        }

        #endregion

        #region Method

        #region OverRide

        public override Type GetCodeInfoBlockEndType()
        {
            return typeof(SourceCodeInfoBlockEndIf);
        }

        public SourceCodeInfoParamater GetSourceCodeInfoParamater()
        {
            return this._sourceCodeInfoParamaterValueMethod;
        }

        public override bool GetParamaterOverWriteValues(int index, ref StringBuilder strBu)
        {
            if (index == this.StatementObjectindex)
            {
                strBu.Append(this.GetSourceCodeInfoParamater().GetParamaterOverWriteValues());
                return true;
            }

            return false;
        }

        #endregion

        #endregion
    }
}

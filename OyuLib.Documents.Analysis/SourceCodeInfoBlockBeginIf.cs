using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockBeginIf : SourceCodeInfoBlockBegin
    {
        #region instanceVaｌ

        private SourceCodeInfoParamater _sourceCodeInfoParamaterValueMethod = null;

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

        #endregion

        #region Method

        #region OverRide

        public override Type GetCodeInfoBlockEndType()
        {
            return typeof(SourceCodeInfoBlockEndIf);
        }

        public override bool GetParamaterOverWriteValues(int index, ref StringBuilder strBu)
        {
            if (index == this.StatementObjectindex)
            {
                foreach (var value in this.Paramater.ParamaterValues)
                {
                    strBu.Append(value.Range.SpilitSeparatorStart);
                    strBu.Append(value.GetCodePartsOverWriteValues());
                    strBu.Append(value.Range.SpilitSeparatorEnd);
                }

                return true;
            }

            return false;
        }

        #endregion

        #region Public

       

        #endregion

        #endregion
    }
}

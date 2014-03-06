using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockBeginFor : SourceCodeInfoBlockBegin, IParamater
    {
        #region instanceVal

        private SourceCodeInfoParamater _sourceCodeInfoParamaterValueMethod = null;

        private StringRange _range = null;

        private int _evaluationFormula = -1;

        #endregion

        #region Constructor

        public SourceCodeInfoBlockBeginFor(
            int statement,
            int statementObject,
            int evaluationFormula)
            : base(statement, statementObject)
        {
            this._evaluationFormula = evaluationFormula;
        }

        public SourceCodeInfoBlockBeginFor(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement,
            int statementObject,
            int evaluationFormula,
            SourceCodeInfoParamater sourceCodeInfoParamaterValueMethod)
            : base(code, coFac, statement, statementObject)
        {
            this._evaluationFormula = evaluationFormula;
            this._sourceCodeInfoParamaterValueMethod = sourceCodeInfoParamaterValueMethod;
        }

        #endregion


        #region Property

        public StringRange Range
        {
            get { return this._range; }
            set { this._range = value; }
        }

        #endregion

        #region Method

        #region OverRide

        public bool GetIsOverWriteParamater()
        {
            foreach (var param in this.GetSourceCodeInfoParamaters())
            {
                foreach (var codeinfo in param.GetAllSourceCodeInfos())
                {
                    if (codeinfo.IsOverWrite())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public SourceCodeInfoParamater[] GetSourceCodeInfoParamaters()
        {
            return new SourceCodeInfoParamater[] { this._sourceCodeInfoParamaterValueMethod };
        }

        public override Type GetCodeInfoBlockEndType()
        {
            return typeof (SourceCodeInfoBlockEndFor);
        }

        public override bool GetParamaterOverWriteValues(int index, ref StringBuilder strBu)
        {
            if (index == this._evaluationFormula)
            {
                strBu.Append(this.GetSourceCodeInfoParamaters()[0].GetParamaterOverWriteValues());
                return true;
            }

            return false;
        }

        #endregion

        #endregion
    }
}

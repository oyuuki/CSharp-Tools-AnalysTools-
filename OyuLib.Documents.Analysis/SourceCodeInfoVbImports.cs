using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoVbImports : SourceCodeInfo
    {
        #region instanceVal

        private int _importNameSpace = -1;

        #endregion

        #region Constructor

        public SourceCodeInfoVbImports(int importNameSpace)
            : base()
        {
            this._importNameSpace = importNameSpace;
        }

        public SourceCodeInfoVbImports(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int importNameSpace)
            : base(code, coFac)
        {
            this._importNameSpace = importNameSpace;
        }

        #endregion

        #region property        

        public string ImportNameSpace
        {
            get { return this.GetCodePartsString(this._importNameSpace); }
            set { this.SetOverwriteValue(this._importNameSpace, value); }
        }

        #endregion

        #region Method

        #region override

        protected override string GetCodeText()
        {           
            return "Importステートメント：名前空間名" + this.ImportNameSpace;
        }

        #endregion

        public override NestIndex[] GetNestIndices()
        {
            return new NestIndex[]
            {
                new NestIndex(this._importNameSpace),
            };
        }

        #endregion
    }
}

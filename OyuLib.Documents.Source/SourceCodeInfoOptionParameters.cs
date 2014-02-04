using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources
{
    public class SourceCodeInfoOptionParameters
    {
        #region instanceVal

        private SourceCodeInfo[] _codeInfos = null;

        private readonly int _startIndex = 0;

        #endregion

        #region Constructor

        public SourceCodeInfoOptionParameters(
            SourceCodeInfo[] codeInfos,
            int startIndex)
        {
            this._startIndex = startIndex;
        }

        public SourceCodeInfoOptionParameters(
            SourceCodeInfo[] codeInfos)
            : this(codeInfos, 0)
        {
            
        }

        #endregion

        #region Property

        protected SourceCodeInfo[] CodeInfos
        {
            get { return this._codeInfos; }
            set { this._codeInfos = value; }
        }

        protected int StartIndex
        {
            get { return this._startIndex; }
        }

        #endregion

        #region Method

        

        #endregion

    }
}

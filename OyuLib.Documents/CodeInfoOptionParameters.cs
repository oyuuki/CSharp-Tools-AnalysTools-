using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoOptionParameters
    {
        #region instanceVal

        private CodeInfo[] _codeInfos = null;

        private readonly int _startIndex = 0;

        #endregion

        #region Constructor

        public CodeInfoOptionParameters(
            CodeInfo[] codeInfos,
            int startIndex)
        {
            this._startIndex = startIndex;
        }

        public CodeInfoOptionParameters(
            CodeInfo[] codeInfos)
            : this(codeInfos, 0)
        {
            
        }

        #endregion

        #region Property

        protected CodeInfo[] CodeInfos
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

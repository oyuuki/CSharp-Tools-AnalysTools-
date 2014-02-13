using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeblockInfo
    {
        #region instanceVal

        private object[] _codeObjects = null;

        private Range _range = null;

        #endregion

        #region Constructor

        public SourceCodeblockInfo()
        {
            
        }

        public SourceCodeblockInfo(object[] codeObjects, Range range)
        {
            this._codeObjects = codeObjects;
            this._range = range;
        }

        #endregion

        #region Property

        public object[] CodeObjects
        {
            get { return this._codeObjects; }
            set { this._codeObjects = value; }
        }

        public Range EndBlockRange
        {
            get { return this._range; }
            set { this._range = value; }
        }

        #endregion

        #region Method

        public SourceCodeInfoBlockBegin GetSourceCodeInfoBlockBegin()
        {
            return (SourceCodeInfoBlockBegin) this.CodeObjects[0];
        }

       
        #endregion
    }
}

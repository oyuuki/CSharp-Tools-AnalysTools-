using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class SourceBlock
    {
        #region instanceVal

        private object[] _codeObjects = null;

        private Range _range = null;

        #endregion

        #region Constructor

        public SourceBlock(CodeInfo[] codeinfos, int startIndex)
        {
            this._codeObjects = this.GetCodeObjects(codeinfos, startIndex);
        }

        public SourceBlock(CodeInfo[] codeinfos)
            : this(codeinfos, 0)
        {
            
        }

        #endregion

        #region Property

        public object[] CodeObjects
        {
            get { return this._codeObjects; }
        }

        public Range Range
        {
            get { return this._range; }
        }

        #endregion

        #region Method

        public object[] GetCodeObjects(CodeInfo[] codeinfos, int startIndex)
        {
            var objList = new List<object>();
            Range range = null;

            int start = startIndex;
            int end = 0;

            for (int indexLoop = start; indexLoop < codeinfos.Length; indexLoop++)
            {
                var codeInfo = codeinfos[indexLoop];

                // Search The block of head
                if (codeInfo is CodeInfoBlockBegin<CodeInfoBlockEnd>)
                {
                    // Add new Code Object That create New Source Block Instance       
                    var iinerBlockCodeInfo = codeinfos.Skip(indexLoop).Take(
                        this.GetIndexPairCodeBlockEnd(
                            codeinfos,
                            (CodeInfoBlockBegin<CodeInfoBlockEnd>)codeInfo,
                            indexLoop)).ToArray();

                    var innerSourceBlock = new SourceBlock(iinerBlockCodeInfo, indexLoop);
                    objList.Add(innerSourceBlock);
                    indexLoop = innerSourceBlock.Range.IndexEnd;
                }
                else if (!(codeInfo is CodeInfoBlockEnd))
                {
                    // Add CodeInfo
                    objList.Add(codeInfo);
                }
            }

            return objList.ToArray();
        }

        private int GetIndexPairCodeBlockEnd(
            CodeInfo[] codeinfos, 
            CodeInfoBlockBegin<CodeInfoBlockEnd> codeinfoBegin, 
            int startindex)
        {
            int retIndex = -1;
            Type codeInfoEndtype = codeinfoBegin.GetCodeInfoBlockEndType();

            for (int indexLoop = startindex; indexLoop < codeinfos.Length; indexLoop++)
            {
                // Search The block of footer
                if (codeinfos[indexLoop].GetType().Equals(codeInfoEndtype))
                {
                    retIndex = indexLoop;
                    break;
                }
            }

            if (retIndex == -1)
            {
                throw new Exception("Can't Find Pare End Block Code ");
            }

            return retIndex;
        }

        #endregion
    }
}

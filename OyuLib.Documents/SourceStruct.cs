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

        public SourceBlock(CodeInfo[] codeinfos, int startIndex, Type endType)
        {
            this._codeObjects = GetCodeObjects(codeinfos, startIndex, endType);
        }

        public SourceBlock(CodeInfo[] codeinfos, int startIndex)
            : this(codeinfos, startIndex, null)
        {
            
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
            private set { this._range = value; }
        }

        #endregion

        #region Method

        public object[] GetCodeObjects(CodeInfo[] codeinfos, int startIndex, Type endType)
        {
            var objList = new List<object>();
            Range range = null;

            int start = startIndex;

            int end = 0;

            if (startIndex != 0)
            {
                objList.Add(codeinfos[startIndex]);
                start++;
            }

            for (int indexLoop = start; indexLoop < codeinfos.Length; indexLoop++)
            {
                var codeInfo = codeinfos[indexLoop];

                // Search The block of head
                if (codeInfo is CodeInfoBlockBegin)
                {
                    var innerSourceBlock = new SourceBlock(codeinfos, indexLoop, ((CodeInfoBlockBegin)codeInfo).GetCodeInfoBlockEndType());
                    objList.Add(innerSourceBlock);
                    indexLoop = innerSourceBlock.Range.IndexEnd;
                }
                else if ((codeInfo is CodeInfoBlockEnd) && endType != null && endType.Equals(codeInfo.GetType()))
                {
                    objList.Add(codeInfo);
                    this.Range = new Range(startIndex, indexLoop);
                    break;
                }
                else
                {
                    // Add CodeInfo
                    objList.Add(codeInfo);
                }
            }

            return objList.ToArray();
        }

        private int GetIndexPairCodeBlockEnd(
            CodeInfo[] codeinfos, 
            CodeInfoBlockBegin codeinfoBegin, 
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

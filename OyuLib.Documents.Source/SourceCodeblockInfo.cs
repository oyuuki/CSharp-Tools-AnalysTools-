using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources
{
    public class SourceCodeblockInfo
    {
        #region instanceVal

        private object[] _infoObjects = null;

        private Range _range = null;

        #endregion

        #region Constructor

        public SourceCodeblockInfo(SourceCodeInfo[] codeinfos, int startIndex, Type endType)
        {
            this._infoObjects = GetCodeObjects(codeinfos, startIndex, endType);
        }

        public SourceCodeblockInfo(SourceCodeInfo[] codeinfos, int startIndex)
            : this(codeinfos, startIndex, null)
        {
            
        }

        public SourceCodeblockInfo(SourceCodeInfo[] codeinfos)
            : this(codeinfos, 0)
        {
            
        }

        #endregion

        #region Property

        public object[] CodeObjects
        {
            get { return this._infoObjects; }
        }

        public Range Range
        {
            get { return this._range; }
            private set { this._range = value; }
        }

        #endregion

        #region Method

        public object[] GetCodeObjects(SourceCodeInfo[] codeinfos, int startIndex, Type endType)
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
                if (codeInfo is SourceCodeInfoBlockBegin)
                {
                    var innerSourceBlock = new SourceCodeblockInfo(codeinfos, indexLoop, ((SourceCodeInfoBlockBegin)codeInfo).GetCodeInfoBlockEndType());
                    objList.Add(innerSourceBlock);
                    indexLoop = innerSourceBlock.Range.IndexEnd;
                }
                else if ((codeInfo is SourceCodeInfoBlockEnd) && endType != null && endType.Equals(codeInfo.GetType()))
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
            SourceCodeInfo[] codeinfos, 
            SourceCodeInfoBlockBegin codeinfoBegin, 
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
                throw new Exception("Can't Find The Code of Pare with End Block Code ");
            }

            return retIndex;
        }

        #endregion
    }
}

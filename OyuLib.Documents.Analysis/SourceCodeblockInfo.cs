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

        public SourceCodeInfo[] GetSourceCodeInfos()
        {
            var retList = new List<SourceCodeInfo>();

            foreach (var codeInfo in this.CodeObjects)
            {
                if (codeInfo is SourceCodeInfo)
                {
                    retList.Add((SourceCodeInfo)codeInfo);
                }
                else if(codeInfo is SourceCodeblockInfo)
                {
                    retList.AddRange(((SourceCodeblockInfo)codeInfo).GetSourceCodeInfos());
                }
            }

            return retList.ToArray();
        }

        public SourceCodeInfo[] GetSourceCodeInfosNotIncludeInnerBlock()
        {
            var retList = new List<SourceCodeInfo>();

            foreach(var codeInfo in this.CodeObjects)
            {
                if(codeInfo is SourceCodeInfo)
                {
                    retList.Add((SourceCodeInfo)codeInfo);
                }
            }

            return retList.ToArray();
        }

        public SourceCodeInfo[] GetSourceCodeInfosNotIncludeAppointBlock<T>()
           where T : SourceCodeInfoBlockBegin
        {
            return this.GetSourceCodeInfosNotIncludeAppointBlock<T>(this.CodeObjects);
        }

        public SourceCodeInfo[] GetSourceCodeInfosNotIncludeAppointBlock<T>(object[] codeObjects)
            where T : SourceCodeInfoBlockBegin
        {
            var retList = new List<SourceCodeInfo>();

            foreach (var codeInfo in codeObjects)
            {
                if (codeInfo is SourceCodeInfo)
                {
                    retList.Add((SourceCodeInfo)codeInfo);
                }
                else if(codeInfo is SourceCodeblockInfo)
                {
                    if(!(((SourceCodeblockInfo)codeInfo).GetSourceCodeInfoBlockBegin is T))
                    {
                        retList.AddRange(this.GetSourceCodeInfosNotIncludeAppointBlock<T>(((SourceCodeblockInfo)codeInfo).CodeObjects));
                    }
                }
            }

            return retList.ToArray();
        }

       
        #endregion
    }
}

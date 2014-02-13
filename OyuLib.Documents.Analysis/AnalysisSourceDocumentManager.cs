using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

using OyuLib.Documents;
using OyuLib.IO;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class AnalysisSourceDocumentManager
    {
        #region Instance

        /// <summary>
        /// source text
        /// </summary>
        private object[] _codeObjects = null;

        private SourceDocument _sourcedocument = null;

        #endregion

        #region Property

        protected object[] CodeObjects
        {
            get { return this._codeObjects; }
            private set { this._codeObjects = value; }
        }

        public SourceDocument Sourcedocument
        {
            get { return this._sourcedocument; }
            protected set { this._sourcedocument = value; }
        }

        #endregion

        #region Delegate

        protected delegate bool CheckWithKey<T>(string keyName, T codeInfo)
            where T : SourceCodeInfo;

        #endregion

        #region InnerClass

        protected class CodeObject
        {
            #region instanceVal

            private object[] _codeobjects = null;

            private Range _range = null;

            #endregion

            #region Constructor

            public CodeObject(object[] codeobjects, Range range)
            {
                this._codeobjects = codeobjects;
                this._range = range;
            }

            #endregion

            #region Property

            public object[] CodeObjects 
            {
                get { return this._codeobjects; }
                set { this._codeobjects = value; }
            }

            public Range Range
            {
                get { return this._range; }
                protected set { this._range = value; }
            }

            #endregion
        }

        #endregion

        #region Method

        #region Private

        private SourceCodeInfoBlockBegin GetSourceCodeInfoBlockBegin(SourceCodeblockInfo blockInfo)
        {
            return (SourceCodeInfoBlockBegin) blockInfo.CodeObjects[0];
        }

        #region CodeObjects

        private void SetCodeObjects()
        {
            CodeObject obj = this.GetCodeObjects(this.GetSourceCodeAnalysis(), 0, null);
            this.CodeObjects = obj.CodeObjects;
        }

        private CodeObject GetCodeObjects(SourceCodeInfo[] codeinfos, int startIndex, Type endType)
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
                    var codeObject = this.GetCodeObjects(codeinfos, indexLoop,
                        ((SourceCodeInfoBlockBegin)codeInfo).GetCodeInfoBlockEndType());
                    var innerSourceBlock = new SourceCodeblockInfo(codeObject.CodeObjects, codeObject.Range);

                    objList.Add(innerSourceBlock);
                    indexLoop = innerSourceBlock.EndBlockRange.IndexEnd;
                }
                else if ((codeInfo is SourceCodeInfoBlockEnd) && endType != null && endType.Equals(codeInfo.GetType()))
                {
                    objList.Add(codeInfo);
                    range = new Range(startIndex, indexLoop);
                    break;
                }
                else
                {
                    // Add CodeInfo
                    objList.Add(codeInfo);
                }
            }

            return new CodeObject(objList.ToArray(), range);
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

        private SourceCodeInfoCallMethod GetConditionalValuesCallMethod(string name, SourceCodeInfo[] codeInfos)
        {
            foreach (var value in codeInfos)
            {
                if (!(value is SourceCodeInfoCallMethod))
                {
                    continue;

                }

                var codeInfoCallMethod = (SourceCodeInfoCallMethod)value;

                if (codeInfoCallMethod.CallmethodName.Equals(name))
                {
                    return codeInfoCallMethod;
                }
            }

            return null;
        }

        private SourceCodeInfoParamaterValueCallMethod[] GetConditionalValuesMethodParamaters(string name, SourceCodeInfo[] codeInfos)
        {
            var retList = new List<SourceCodeInfoParamaterValueCallMethod>();

            foreach (var value in codeInfos)
            {
                if (!(value is SourceCodeInfoParamaterValueCallMethod))
                {
                    continue;

                }

                var codeInfoCallMethod = (SourceCodeInfoParamaterValueCallMethod)value;

                if (codeInfoCallMethod.ParamaterName.Equals(name))
                {
                    retList.Add(codeInfoCallMethod);
                }
            }

            return retList.ToArray();
        }

        private SourceCodeInfoSubstitution GetConditionalValuesSubstitutionRight(string rightName, SourceCodeInfo[] codeInfos)
        {
            foreach (var value in codeInfos)
            {
                if (!(value is SourceCodeInfoSubstitution))
                {
                    continue;

                }

                var codeInfoCallMethod = (SourceCodeInfoSubstitution)value;

                if (codeInfoCallMethod.RightHandSide.Equals(rightName))
                {
                    return codeInfoCallMethod;
                }
            }

            return null;
        }

        private SourceCodeInfoSubstitution GetConditionalValuesSubstitutionLeft(string leftName, SourceCodeInfo[] codeInfos)
        {
            foreach (var value in codeInfos)
            {
                if (!(value is SourceCodeInfoSubstitution))
                {
                    continue;

                }

                var codeInfoCallMethod = (SourceCodeInfoSubstitution)value;

                if (codeInfoCallMethod.LeftHandSide.Equals(leftName))
                {
                    return codeInfoCallMethod;
                }
            }

            return null;
        }

        #endregion

        #endregion

        #region Protected

        #region Common

        protected TBlock[] GetSourceCodeInfoblockBegin<TBlock>()
            where TBlock : SourceCodeInfoBlockBegin
        {
            var retList = new List<TBlock>();

            foreach (var codeBlock in this.GetSourceCodeblockInfo<TBlock>())
            {
                retList.Add((TBlock)codeBlock.GetSourceCodeInfoBlockBegin());
            }

            return retList.ToArray();
        }

        protected T[] GetSourceCodeInfos<T>(object[] codeobjects)
        {
            var retList = new List<T>();

            foreach (var codeInfo in codeobjects)
            {
                if (codeInfo is SourceCodeblockInfo)
                {
                    retList.AddRange(GetSourceCodeInfos<T>(((SourceCodeblockInfo)codeInfo).CodeObjects));
                }
                else if (codeInfo is T)
                {
                    retList.Add((T)codeInfo);
                }
            }

            return retList.ToArray();
        }

        protected SourceCodeblockInfo[] GetSourceCodeblockInfo(object[] codeobjects)
        {
            var retList = new List<SourceCodeblockInfo>();

            foreach (var codeInfo in codeobjects)
            {
                if (codeInfo is SourceCodeblockInfo)
                {
                    retList.Add((SourceCodeblockInfo)codeInfo);
                    retList.AddRange(GetSourceCodeblockInfo(((SourceCodeblockInfo)codeInfo).CodeObjects));
                }
            }

            return retList.ToArray();
        }

        protected T[] GetSourceCodeInfos<T>()
        {
            return this.GetSourceCodeInfos<T>(this.CodeObjects);
        }

        protected T[] GetCodeInfoWithKeyName<T>(string keyName, CheckWithKey<T> checkMethod)
            where T : SourceCodeInfo
        {
            return this.GetCodeInfoWithKeyName(keyName, this.CodeObjects, checkMethod);
        }
        
        protected T[] GetCodeInfoWithKeyName<T>(
            string keyName, SourceCodeblockInfo block, CheckWithKey<T> checkMethod)
            where T : SourceCodeInfo
        {
            return this.GetCodeInfoWithKeyName(keyName, block.CodeObjects, checkMethod);
        }

        protected T[] GetCodeInfoWithKeyName<T>(
            string keyName, object[] codeObjects, CheckWithKey<T> checkMethod)
            where T : SourceCodeInfo
        {
            var retList = new List<T>();

            foreach (var codeInfo in this.GetSourceCodeInfos<T>(codeObjects))
            {
                if (checkMethod == null)
                {
                    retList.Add(codeInfo);
                }
                else if (checkMethod(keyName, codeInfo))
                {
                    retList.Add(codeInfo);
                }
            }

            return retList.ToArray();
        }

        #endregion

        #region Round Block Common

        protected SourceCodeblockInfo[] GetSourceCodeblockInfo<TBlock>()
            where TBlock : SourceCodeInfoBlockBegin
        {
            return this.GetSourceCodeblockInfo<TBlock>(this.CodeObjects);
        }

        protected SourceCodeblockInfo[] GetSourceCodeblockInfo<TBlock>(SourceCodeblockInfo blockInfo)
            where TBlock : SourceCodeInfoBlockBegin
        {
            return this.GetSourceCodeblockInfo<TBlock>(blockInfo.CodeObjects);
        }

        protected SourceCodeblockInfo[] GetSourceCodeblockInfo<TBlock>(object[] codeObjects)
            where TBlock : SourceCodeInfoBlockBegin
        {
            var blockList = new List<SourceCodeblockInfo>();

            foreach (var block in this.GetSourceCodeblockInfo(codeObjects))
            {
                var sourceCodeInfoBlockBegin = this.GetSourceCodeInfoBlockBegin(block);

                if (sourceCodeInfoBlockBegin is TBlock)
                {
                    blockList.Add(block);
                }
            }

            return blockList.ToArray();
        }

        
        protected T[] GetCodeInfoWithKeyNameRangeBlock<T, TBlock>(
            string keyName, 
            CheckWithKey<T> checkMethod,
            string blockName,
            CheckWithKey<TBlock> checkBlockMethod)
            where T : SourceCodeInfo

            where TBlock : SourceCodeInfoBlockBegin
        {
            return GetCodeInfoWithKeyNameRangeBlock<T, TBlock>(this.CodeObjects, keyName, checkMethod, blockName, checkBlockMethod);
        }

        protected T[] GetCodeInfoWithKeyNameRangeBlock<T, TBlock>(
            SourceCodeblockInfo blockInfo,
            string keyName,
            CheckWithKey<T> checkMethod,
            string blockName,
            CheckWithKey<TBlock> checkBlockMethod)
            where T : SourceCodeInfo
            where TBlock : SourceCodeInfoBlockBegin
        {
            return GetCodeInfoWithKeyNameRangeBlock<T, TBlock>(blockInfo.CodeObjects, keyName, checkMethod, blockName, checkBlockMethod);
        }

        protected T[] GetCodeInfoWithKeyNameRangeBlock<T, TBlock>(
            object[] codeObjects,
            string keyName, 
            CheckWithKey<T> checkMethod,
            string blockName, 
            CheckWithKey<TBlock> checkBlockMethod)
            where T : SourceCodeInfo
            where TBlock : SourceCodeInfoBlockBegin
        {
            var retList = new List<T>();

            foreach (var block in this.GetSourceCodeblockInfo<TBlock>(codeObjects))
            {
                if (checkBlockMethod(blockName, (TBlock) block.CodeObjects[0]))
                {
                    retList.AddRange(this.GetCodeInfoWithKeyName<T>(
                keyName,
                block,
                checkMethod
                ));    
                }
            }

            return retList.ToArray();
        }

        #endregion

        protected void Init()
        {
            this.SetCodeObjects();
        }

        #endregion

        #region Public

        //        １．左辺式が○○である式コードのコレクションを取得
        public SourceCodeInfoSubstitution[] GetCodeInfoSubstitutions(string keyName)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoSubstitution>(
                keyName, 
                delegate(string lockeyName, SourceCodeInfoSubstitution info)
                {
                    return info.LeftHandSide.Equals(keyName);
                }    
                );
        }

        //２．○○というオブジェクトに関連するイベントメソッドのコレクションを取得
        public SourceCodeInfoBlockBeginEventMethod[] GetSourceCodeInfoBlockBeginEventMethodSuggestObjectName(string objectName)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoBlockBeginEventMethod>(
                objectName,
                delegate(string lockeyName, SourceCodeInfoBlockBeginEventMethod info)
                {
                    return info.EventObjectName.Equals(lockeyName);
                }
                );
        }

        //３．○○というオブジェクトに関連するコールメソッドのコレクションを取得
        public SourceCodeInfoCallMethod[] GetSourceCodeInfoCallMethodSuggestObjectName(string objectName)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoCallMethod>(
                objectName,
                delegate(string lockeyName, SourceCodeInfoCallMethod info)
                {
                    return info.ObjName.Equals(lockeyName);
                }
                );
        }

        //３．○○というオブジェクトに関連するコールメソッドのコレクションを取得
        public SourceCodeInfoCallMethod[] GetSourceCodeInfoCallMethod(string methodName)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoCallMethod>(
                methodName,
                delegate(string lockeyName, SourceCodeInfoCallMethod info)
                {
                    return info.CallmethodName.Equals(methodName);
                }
                );
        }

       /// <summary>
       /// Get ValiableInfo By TypeName
       /// </summary>
       /// <param name="typeName">TypeName</param>
        /// <returns>ValiableInfo</returns>
        public SourceCodeInfoMemberVariable[] GetSourceCodeInfoMemberVariableByType(string typeName)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoMemberVariable>(
                typeName,
                delegate(string lockeyName, SourceCodeInfoMemberVariable info)
                {
                    return info.TypeName.Equals(typeName);
                }
                );
        }

        /// <summary>
        /// Get ValiableInfo By Name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>ValiableInfo</returns>
        public SourceCodeInfoMemberVariable[] GetSourceCodeInfoMemberVariableByName(string name)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoMemberVariable>(
                name,
                delegate(string lockeyName, SourceCodeInfoMemberVariable info)
                {
                    return info.Name.Equals(name);
                }
                );
        }

        private SourceCodeInfo[] GetSourceCodeInfo(object[] codeObjects)
        {
            var retList = new List<SourceCodeInfo>();

            foreach (var codeobject in codeObjects)
            {
                if (codeobject is SourceCodeblockInfo)
                {
                    retList.AddRange(this.GetSourceCodeInfo(((SourceCodeblockInfo)codeobject).CodeObjects));
                }
                else
                {
                    retList.Add((SourceCodeInfo)codeobject);
                }
            }

            return retList.ToArray();
        }

        public void CreateAnalysisSourceFile(string filePath)
        {
            using (var file = new TextFile(filePath))
            {
                file.OpenFileForse();

                foreach (var codeinfo in this.GetSourceCodeInfo(this.CodeObjects))
                {
                    file.WriteLine(codeinfo.GetCodePartsOverWriteValues());
                }
            }
        }

        

        #endregion



        //     式コードを取得
        //     コールメソッドコードを取得
      
//４．右辺式に○○オブジェクトが含まれる

//     式コードを取得
//     コールメソッドコードを取得
     
//     ※ 再起処理が必要?
     
//５．○○というオブジェクトが使用されている箇所を抽出
//    コールメソッドの引数
//    IF文の中身
//    Whileの中身

        #region Abstract

        /// <summary>
        /// Analys Code to item
        /// </summary>
        public abstract SourceCodeInfo[] GetSourceCodeAnalysis();

        #endregion

        #endregion
    }
}

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

using System.Text.RegularExpressions;

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
            set { this._codeObjects = value; }
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

            if (startIndex != 0 && codeinfos[startIndex - 1] is SourceCodeInfoBlockBegin)
            {
                objList.Add(codeinfos[startIndex - 1]);
            }

            for (int indexLoop = start; indexLoop < codeinfos.Length; indexLoop++)
            {
                var codeInfo = codeinfos[indexLoop];

                // Search The block of head
                if (codeInfo is SourceCodeInfoBlockBegin)
                {
                    var codeObject = this.GetCodeObjects(codeinfos, indexLoop + 1,
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

        private SourceCodeInfoParamaterValueElementCallMethod[] GetConditionalValuesMethodParamaters(string name, SourceCodeInfo[] codeInfos)
        {
            var retList = new List<SourceCodeInfoParamaterValueElementCallMethod>();

            foreach (var value in codeInfos)
            {
                if (!(value is SourceCodeInfoParamaterValueElementCallMethod))
                {
                    continue;

                }

                var codeInfoCallMethod = (SourceCodeInfoParamaterValueElementCallMethod)value;

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

        protected T[] GetSourceCodeInfosNotRequiredInnerBlock<T>(object[] codeobjects)
        {
            var retList = new List<T>();

            foreach (var codeInfo in codeobjects)
            {
                if (!(codeInfo is SourceCodeblockInfo))
                {
                    retList.Add((T)codeInfo);
                }
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

        protected bool FindCodeInfo(SourceCodeblockInfo block, SourceCodeInfo targetCodeInfo)
        {
            foreach (var codeInfo in block.CodeObjects)
            {
                if (codeInfo is SourceCodeblockInfo)
                {
                    bool isFind = this.FindCodeInfo((SourceCodeblockInfo)codeInfo, targetCodeInfo);

                    if(isFind)
                    {
                        return true;
                    }
                }
                else if (codeInfo is SourceCodeInfo)
                {
                    var sourceCodeInfo = (SourceCodeInfo)codeInfo;

                    if(targetCodeInfo.GetCodeLineNumber() == sourceCodeInfo.GetCodeLineNumber())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected T[] GetSourceCodeInfosNotRequiredInnerBlock<T>()
        {
            return this.GetSourceCodeInfosNotRequiredInnerBlock<T>(this.CodeObjects);
        }

        protected T[] GetSourceCodeInfos<T>()
        {
            return this.GetSourceCodeInfos<T>(this.CodeObjects);
        }

        protected T[] GetCodeInfoWithKeyName<T>(string keyName, CheckWithKey<T> checkWithKey)
            where T : SourceCodeInfo
        {
            return this.GetCodeInfoWithKeyName(keyName, this.CodeObjects, checkWithKey);
        }
        
        protected T[] GetCodeInfoWithKeyName<T>(
            string keyName, SourceCodeblockInfo block, CheckWithKey<T> checkWithKey)
            where T : SourceCodeInfo
        {
            return this.GetCodeInfoWithKeyName(keyName, block.CodeObjects, checkWithKey);
        }

        protected T[] GetCodeInfoWithKeyName<T>(
            string keyName, object[] codeObjects, CheckWithKey<T> checkWithKey)
            where T : SourceCodeInfo
        {
            var retList = new List<T>();

            foreach (var codeInfo in this.GetSourceCodeInfos<T>(codeObjects))
            {
                if (checkWithKey == null)
                {
                    retList.Add(codeInfo);
                }
                else if (checkWithKey(keyName, codeInfo))
                {
                    retList.Add(codeInfo);
                }
            }

            return retList.ToArray();
        }

        protected T[] GetCodeInfoWithKeyName<T>(string[] keyNames, CheckWithKey<T> checkWithKey)
           where T : SourceCodeInfo
        {
            return this.GetCodeInfoWithKeyName(keyNames, this.CodeObjects, checkWithKey);
        }

        protected T[] GetCodeInfoWithKeyName<T>(
            string[] keyNames, SourceCodeblockInfo block, CheckWithKey<T> checkWithKey)
            where T : SourceCodeInfo
        {
            return this.GetCodeInfoWithKeyName(keyNames, block.CodeObjects, checkWithKey);
        }

        protected T[] GetCodeInfoWithKeyName<T>(
            string[] keyNames, object[] codeObjects, CheckWithKey<T> checkWithKey)
            where T : SourceCodeInfo
        {
            var retList = new List<T>();

            foreach (var codeInfo in this.GetSourceCodeInfos<T>(codeObjects))
            {
                if (checkWithKey == null)
                {
                    retList.Add(codeInfo);
                }
                else 
                {

                   var isAdd = true;

                   foreach(var keyName in keyNames)
                   {
                       if (!checkWithKey(keyName, codeInfo))
                       {
                           isAdd = false;
                           break;
                       }
                   }

                   if (isAdd)
                   {
                       retList.Add(codeInfo);
                   }
                }
            }

            return retList.ToArray();
        }

        protected T[] GetCodeInfoWithKeyNameNotRequiredInnerBlock<T>(string keyName, CheckWithKey<T> checkWithKey)
            where T : SourceCodeInfo
        {
            return this.GetCodeInfoWithKeyNameNotRequiredInnerBlock(keyName, this.CodeObjects, checkWithKey);
        }

        protected T[] GetCodeInfoWithKeyNameNotRequiredInnerBlock<T>(
            string keyName, SourceCodeblockInfo block, CheckWithKey<T> checkWithKey)
            where T : SourceCodeInfo
        {
            return this.GetCodeInfoWithKeyNameNotRequiredInnerBlock(keyName, block.CodeObjects, checkWithKey);
        }

        protected T[] GetCodeInfoWithKeyNameNotRequiredInnerBlock<T>(
            string keyName, object[] codeObjects, CheckWithKey<T> checkWithKey)
            where T : SourceCodeInfo
        {
            var retList = new List<T>();

            foreach (var codeInfo in this.GetSourceCodeInfosNotRequiredInnerBlock<T>(codeObjects))
            {
                if (checkWithKey == null)
                {
                    retList.Add(codeInfo);
                }
                else if (checkWithKey(keyName, codeInfo))
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

        protected SourceCodeblockInfo[] GetCodeBlockInfoWithBlockName<TBlock>(
            object[] codeObjects,
            string blockName,
            CheckWithKey<TBlock> checkBlockMethod)
            where TBlock : SourceCodeInfoBlockBegin
        {
            var retList = new List<SourceCodeblockInfo>();

            foreach (var block in this.GetSourceCodeblockInfo<TBlock>(codeObjects))
            {
                if (checkBlockMethod(blockName, (TBlock)block.CodeObjects[0]))
                {
                    retList.Add(block);    
                }
            }

            return retList.ToArray();
        }

        protected T[] GetCodeInfoWithKeyNameRangeBlockNotRequiredInnerBlock<T, TBlock>(
            string keyName, 
            CheckWithKey<T> checkMethod,
            string blockName,
            CheckWithKey<TBlock> checkBlockMethod)
            where T : SourceCodeInfo

            where TBlock : SourceCodeInfoBlockBegin
        {
            return GetCodeInfoWithKeyNameRangeBlockNotRequiredInnerBlock<T, TBlock>(this.CodeObjects, keyName, checkMethod, blockName, checkBlockMethod);
        }

        protected T[] GetCodeInfoWithKeyNameRangeBlockNotRequiredInnerBlock<T, TBlock>(
            SourceCodeblockInfo blockInfo,
            string keyName,
            CheckWithKey<T> checkMethod,
            string blockName,
            CheckWithKey<TBlock> checkBlockMethod)
            where T : SourceCodeInfo
            where TBlock : SourceCodeInfoBlockBegin
        {
            return GetCodeInfoWithKeyNameRangeBlockNotRequiredInnerBlock<T, TBlock>(blockInfo.CodeObjects, keyName, checkMethod, blockName, checkBlockMethod);
        }

        protected T[] GetCodeInfoWithKeyNameRangeBlockNotRequiredInnerBlock<T, TBlock>(
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
                    retList.AddRange(this.GetCodeInfoWithKeyNameNotRequiredInnerBlock<T>(
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

        /// <summary>
        /// 指定したメソッドブロック内のコードを全て取得する
        /// </summary>
        /// <param name="blockName"></param>
        /// <returns></returns>
        public void AddSourceCodeInfoMethod(string methodName, string[] addingStrings, string ObjName, string callMethodName)
        {
            var block = this.GetCodeBlockInfoWithBlockName<SourceCodeInfoBlockBeginMethod>(
                this.CodeObjects, 
                methodName, 
                delegate(string lockeyName, SourceCodeInfoBlockBeginMethod info)
                {
                    return info.Name.Equals(lockeyName);
                });

            int index = 0;

            foreach(var codeObject in block[0].CodeObjects)
            {
                

                if(codeObject is SourceCodeInfoCallMethod)
                {
                    var callMethod = (SourceCodeInfoCallMethod)codeObject;

                    if(callMethod.CallmethodName.Equals(callMethodName)
                        && callMethod.ObjName.Equals(ObjName))
                    {
                        break;
                    }

                    
                }
                index++;
            }

            
            var list = new List<SourceCodeInfoOther>();

            foreach(var strVal in addingStrings)
            {
                int locindex = -1;

                if ((locindex = strVal.IndexOf("SetFieldsAddRange")) >= 0)
                {
                    bool isAppend = true;

                    foreach (var codeobj in block[0].CodeObjects)
                    {
                        if (codeobj is SourceCodeInfo)
                        {
                            var info = (SourceCodeInfo)codeobj;

                            if (info.GetCodeString().IndexOf(strVal.Substring(0, locindex - 1).Trim() + ".Fields.AddRange") >= 0)
                            {
                                isAppend = false;
                                break;
                            }
                        }
                    }

                    if(isAppend)
                    {
                        list.Add(new SourceCodeInfoOther(new SourceCode(strVal)));
                    }
                }
                else
                {
                    list.Add(new SourceCodeInfoOther(new SourceCode(strVal)));
                }
            }

            block[0].CodeObjects = this.GetAddedCodeInfo(list.ToArray(), block[0].CodeObjects, index);
        }

        //        １．左辺式が○○である式コードのコレクションを取得
        public SourceCodeInfo[] GetAllCodeInfos()
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfo>(
                string.Empty,
                delegate(string lockeyName, SourceCodeInfo info)
                {
                    return true;
                }
                );
        }

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

        public SourceCodeInfoVBDotnetAddHandler[] GetSourceCodeInfoVBDotnetAddHandleresForMiglation(string objectName, string thisName)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoVBDotnetAddHandler>(
                objectName,
                delegate(string lockeyName, SourceCodeInfoVBDotnetAddHandler info)
                {
                    string addhandlerObj = info.AddhandlerObject;
                    string locObjectName = "_" + addhandlerObj.Replace(thisName + ".", string.Empty).Replace("(", "_").Replace(")", string.Empty).Trim();

                    int dotIndex = locObjectName.LastIndexOf(".");

                    if (dotIndex >= 0)
                    {
                        locObjectName = locObjectName.Substring(0, locObjectName.LastIndexOf("."));
                    }
                    else
                    {
                        locObjectName = thisName;
                    }

                    if (locObjectName.EndsWith(","))
                    {
                        locObjectName = locObjectName.Substring(0, locObjectName.Length - 1);
                    }

                    return locObjectName.Equals(lockeyName);
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

        
        public SourceCodeInfoCallMethod[] GetSourceCodeInfoCallMethod(string methodName, string objName)
        {
            return this.GetSourceCodeInfoCallMethod(methodName, new string[] { objName });
        }

        
        public SourceCodeInfoCallMethod[] GetSourceCodeInfoCallMethod(string methodName, string[] objNames)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoCallMethod>(
                methodName,
                delegate(string lockeyName, SourceCodeInfoCallMethod info)
                {
                    bool isFindSameObjName = false;

                    foreach (var objName in objNames)
                    {
                        if(objName.Equals(info.ObjName))
                        {
                            isFindSameObjName = true;
                        }
                    }

                    return isFindSameObjName ? info.CallmethodName.Equals(methodName) : false;
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

        public SourceCodeInfoCallMethod[] GetSourceCodeInfoCallMethod()
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoCallMethod>(
                string.Empty,
                delegate(string lockeyName, SourceCodeInfoCallMethod info)
                {
                    return true;
                }                                        
                );
        }


        // 指定したブロックのブロックInfoを全てを取得する
        public SourceCodeblockInfo[] GetAllCodeBlocks<T>()
            where T : SourceCodeInfoBlockBegin
        {
            var retCodeBlockList = new List<SourceCodeblockInfo>();

            foreach (var block in this.GetSourceCodeblockInfo<T>(this.CodeObjects))
            {
                retCodeBlockList.Add(block);
            }

            return retCodeBlockList.ToArray();
        }

        // メソッドブロックを取得する
        public SourceCodeblockInfo[] GetCodeMethodBlocks()
        {
            return this.GetAllCodeBlocks<SourceCodeInfoBlockBeginMethod>();
        }

        // Eventブロックを取得する
        public SourceCodeblockInfo[] GetCodeEventMethodBlocks()
        {
            return this.GetAllCodeBlocks<SourceCodeInfoBlockBeginEventMethod>();
        }

        
        /// <summary>
        /// 工事中
        /// </summary>
        /// <param name="usedCodeinfo"></param>
        /// <param name="addHandledMethodNames"></param>
        /// <returns></returns>
        private SourceCodeInfoBlockBeginMethod[] GetSourceCodeInfoBlockEventMethodUsedCodeinfo(SourceCodeInfo usedCodeinfo, string[] addHandledMethodNames)
        {
            var retList = new List<SourceCodeInfoBlockBeginMethod>();

            foreach (var eventBlock in this.GetCodeEventMethodBlocks())
            {
                if (this.FindCodeInfo(eventBlock, usedCodeinfo))
                {
                    retList.Add((SourceCodeInfoBlockBeginEventMethod)eventBlock.GetSourceCodeInfoBlockBegin());
                }
            }

            foreach(var methodBlock in this.GetCodeMethodBlocks())
            {
                if(this.FindCodeInfo(methodBlock, usedCodeinfo))
                {
                    foreach (string methodName in addHandledMethodNames)
                    {
                        if(((SourceCodeInfoBlockBeginMethod)methodBlock.GetSourceCodeInfoBlockBegin()).Name.Equals(methodName))
                        {                            
                        }
                    }
                }
            }

            return retList.ToArray();
        }

        public void test(SourceCodeInfo sourceCodeInfo)
        {



            // １．印刷関数を呼び出している関数、またはイベント関数を探す        FindCodeInfo
            // ２－１．イベント関数が見つかった場合、それをトリガー関数として保持
            // ２－２．関数が見つかった場合、それが動的に割り当てられたイベント関数か確認する
            // ２－２－１．イベント関数であった場合は２－１と同じ処理を行う
            // ２－２－２．それ以外は２－１から繰り返す 　※ この時関数名をマッピングオブジェクトとして保持する

        }

        /// <summary>
        /// Get ValiableInfo By TypeName
        /// </summary>
        /// <param name="typeName">TypeName</param>
        /// <returns>ValiableInfo</returns>
        public SourceCodeInfoValiable[] GetSourceCodeInfoVariableByType(string typeName)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoValiable>(
                typeName,
                delegate(string lockeyName, SourceCodeInfoValiable info)
                {
                    return info.TypeName.Equals(typeName);
                }
                );
        }

        /// <summary>
        /// Get ValiableInfo By TypeName
        /// </summary>
        /// <param name="typeName">TypeName</param>
        /// <returns>ValiableInfo</returns>
        public SourceCodeInfoValiable[] GetSourceCodeInfoVariableByTypeLike(string typeName)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoValiable>(
                typeName,
                delegate(string lockeyName, SourceCodeInfoValiable info)
                {
                    return info.TypeName.IndexOf(typeName) >= 0;
                }
                );
        }

        public SourceCodeInfoMemberVariable[] GetSourceCodeInfoMemberVariableByType(string typeName)
        {
            return this.GetSourceCodeInfoMemberVariableByType(typeName, true);
        }

        /// <summary>
        /// Get ValiableInfo By TypeName
        /// </summary>
        /// <param name="typeName">TypeName</param>
        /// <returns>ValiableInfo</returns>
        public SourceCodeInfoMemberVariable[] GetSourceCodeInfoMemberVariableByType(string typeName, bool isMatch)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoMemberVariable>(
                typeName,
                delegate(string lockeyName, SourceCodeInfoMemberVariable info)
                {
                    return isMatch == info.TypeName.Equals(typeName);
                }
                );
        }

        /// <summary>
        /// Get ValiableInfo By TypeName
        /// </summary>
        /// <param name="typeName">TypeName</param>
        /// <returns>ValiableInfo</returns>
        public SourceCodeInfoMemberVariable[] GetSourceCodeInfoMemberVariableByNotType(string[] typeName)
        {
            return this.GetSourceCodeInfoMemberVariableByType(typeName, false);
        }

        public SourceCodeInfoMemberVariable[] GetSourceCodeInfoMemberVariableByType(string[] typeName)
        {
            return this.GetSourceCodeInfoMemberVariableByType(typeName, true);
        }

        /// <summary>
        /// Get ValiableInfo By TypeName
        /// </summary>
        /// <param name="typeName">TypeName</param>
        /// <returns>ValiableInfo</returns>
        public SourceCodeInfoMemberVariable[] GetSourceCodeInfoMemberVariableByType(string[] typeName, bool isMatch)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoMemberVariable>(
                typeName,
                delegate(string lockeyName, SourceCodeInfoMemberVariable info)
                {
                    return isMatch == info.TypeName.Equals(lockeyName);
                }
                );
        }

        /// <summary>
        /// Get ValiableInfo By TypeName
        /// </summary>
        /// <param name="typeName">TypeName</param>
        /// <returns>ValiableInfo</returns>
        public SourceCodeInfoMemberVariable[] GetSourceCodeInfoMemberVariableByNotType(string typeName)
        {
            return this.GetSourceCodeInfoMemberVariableByType(typeName, false);
        }

        /// <summary>
        /// Get ValiableInfo By TypeName
        /// </summary>
        /// <param name="typeName">TypeName</param>
        /// <returns>ValiableInfo</returns>
        public SourceCodeInfoMemberVariable[] GetSourceCodeInfoMemberVariableByTypeLike(string typeName)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoMemberVariable>(
                typeName,
                delegate(string lockeyName, SourceCodeInfoMemberVariable info)
                {
                    return info.TypeName.IndexOf(typeName) >= 0;
                }
                );
        }


        /// <summary>
        /// Get ValiableInfo By Name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>ValiableInfo</returns>
        public string[] GetValiableNameCollectionElse(string elseTypeName)
        {
            return this.GetValiableNameCollection(elseTypeName, false, false);
        }

        /// <summary>
        /// Get ValiableInfo By Name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>ValiableInfo</returns>
        public string[] GetValiableNameCollection(string typeName)
        {
            return this.GetValiableNameCollection(typeName, true, false);
        }

        /// <summary>
        /// Get ValiableInfo By Name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>ValiableInfo</returns>
        public string[] GetValiableNameCollectionElseLike(string elseTypeName)
        {
            return this.GetValiableNameCollection(elseTypeName, false, true);
        }

        /// <summary>
        /// Get ValiableInfo By Name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>ValiableInfo</returns>
        public string[] GetValiableNameCollectionLike(string typeName)
        {
            return this.GetValiableNameCollection(typeName, true, true);
        }

        /// <summary>
        /// Get ValiableInfo By Name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>ValiableInfo</returns>
        private string[] GetValiableNameCollection(string typeName, bool isMatch, bool isLike)
        {
            var valiableList = this.GetCodeInfoWithKeyName<SourceCodeInfoValiable>(
                typeName,
                delegate(string lockeyName, SourceCodeInfoValiable info)
                {
                    if(isLike)
                    {
                        return isMatch == (info.TypeName.IndexOf(typeName) >= 0);
                    }
                    else
                    {
                        return isMatch == info.TypeName.Equals(typeName);
                    }
                    
                }
                );



            var methodList = this.GetCodeInfoWithKeyName<SourceCodeInfoBlockBeginMethod>(
                string.Empty,
                delegate(string lockeyName, SourceCodeInfoBlockBeginMethod info)
                {
                    return true;
                }
                );

            var eventMethodList = this.GetCodeInfoWithKeyName<SourceCodeInfoBlockBeginEventMethod>(
                string.Empty,
                delegate(string lockeyName, SourceCodeInfoBlockBeginEventMethod info)
                {
                    return true;
                }
                );

            var retList = new List<string>();

            foreach(var valIinfo in valiableList)
            {
                retList.Add(valIinfo.Name);
            }

            foreach (var methodIinfo in methodList)
            {
                foreach (var param in methodIinfo.GetSourceCodeInfoParamaters())
                {
                    if (param.HasParamater)
                    {
                        foreach (var paramValue in param.GetSourceCodeInfoParamaterValue())
                        {
                            var paramValueMethod = (SourceCodeInfoParamaterValueElementMethod)paramValue;

                            if (paramValueMethod.TypeName.Equals(typeName))
                            {
                                retList.Add(paramValueMethod.ParamaterName);
                            }
                        }
                    }
                }
            }

            foreach (var eventMethodIinfo in eventMethodList)
            {
                foreach (var param in eventMethodIinfo.GetSourceCodeInfoParamaters())
                {
                    if (param.HasParamater)
                    {
                        foreach (var paramValue in param.GetSourceCodeInfoParamaterValue())
                        {
                            var paramValueMethod = (SourceCodeInfoParamaterValueElementMethod)paramValue;

                            if (paramValueMethod.TypeName.Equals(typeName))
                            {
                                retList.Add(paramValueMethod.ParamaterName);
                            }
                        }
                    }
                }
            }

            return retList.ToArray();
        }

        /// <summary>
        /// Get ValiableInfo By Name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>ValiableInfo</returns>
        public SourceCodeInfoMemberVariable[] GetSourceCodeInfoMemberVariableRegex(string regEndWithName)
        {
            return this.GetCodeInfoWithKeyName<SourceCodeInfoMemberVariable>(
                regEndWithName,
                delegate(string lockeyName, SourceCodeInfoMemberVariable info)
                {   
                    Regex reg = new Regex(regEndWithName);
                    return reg.IsMatch(info.Name);
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
                    string motoCode = string.Empty;
                    bool isOverWrite = false;

                    if (codeinfo is IParamater)
                    {
                        if (codeinfo.IsOverWrite() || ((IParamater)codeinfo).GetIsOverWriteParamater())
                        {
                            motoCode = "'★[]★置換ツールにより置換   元コード：" + codeinfo.GetCodeWithOutComment();
                            isOverWrite = true;
                        }                        
                    }
                    else
                    {
                        if (codeinfo.IsOverWrite())
                        {
                            motoCode = "'★[]★置換ツールにより置換   元コード：" + codeinfo.GetCodeWithOutComment();
                            isOverWrite = true;
                        }
                    }

                    if(isOverWrite)
                    {
                        string writeString = codeinfo.GetTabString() + codeinfo.GetCodePartsOverWriteValues() + motoCode + codeinfo.GetComment();
                        file.WriteLine(writeString);
                    }
                    else 
                    {
                        string str = codeinfo.GetCodeString();
                        file.WriteLine(str);
                    }
                }
            }
        }

        protected object[] GetAddedCodeInfo(SourceCodeInfoOther[] codeInfos, object[] codeObjects, int startAddIndex)
        {
            if(startAddIndex < 0)
            {
                throw new ArgumentException("無効な引数が渡されました。開始Indexがマイナス値です。");
            }

            var replaceCodeObject = new List<object>();

            for (int index = 0; index <= startAddIndex - 1; index++)
            {
                replaceCodeObject.Add(codeObjects[index]);
            }

            foreach (var codeInfo in codeInfos)
            {
                replaceCodeObject.Add(codeInfo);
            }

            for (int index = startAddIndex; index < codeObjects.Length; index++)
            {
                replaceCodeObject.Add(codeObjects[index]);
            }

            return replaceCodeObject.ToArray();
        }

        protected object[] GetAddedCodeInnerBlock(SourceCodeInfoOther[] codeInfos, object[] codeObjects)
        {
            return this.GetAddedCodeInfo(codeInfos, codeObjects, 1);
        }

        public void AddValiableMemberCode(SourceCodeInfoOther[] codeInfos)
        {
            int index = 0;
            var codeObjects = this.GetSourceCodeblockInfo<SourceCodeInfoBlockBeginClass>()[0].CodeObjects;
            var replaceCodeObject = new List<object>();
           

            foreach(var codeobject in codeObjects)
            {
               if (codeobject is SourceCodeblockInfo)
               {
                   if (codeInfos != null)
                   {
                       foreach (var codeInfo in codeInfos)
                       {
                           replaceCodeObject.Add(codeInfo);
                       }

                       codeInfos = null;
                   }
               }

               replaceCodeObject.Add(codeobject);

               index++;
            }

            this.GetSourceCodeblockInfo<SourceCodeInfoBlockBeginClass>()[0].CodeObjects = replaceCodeObject.ToArray();
        }

        public void AddOtherCodeToEventMethod(SourceCodeInfoOther[] codeInfos, string eventName)
        {
            int index = 0;
            object[] codeObjects = null;
            var replaceCodeObject = new List<object>();

            SourceCodeblockInfo blockObj = null;

            foreach(var block in  this.GetSourceCodeblockInfo<SourceCodeInfoBlockBeginEventMethod>())
            {
                var blockBeginInfo = (SourceCodeInfoBlockBeginEventMethod)block.GetSourceCodeInfoBlockBegin();

                if(blockBeginInfo.EventName.Equals(eventName))
                {
                    blockObj = block;
                    break;
                }   
            }

            blockObj.CodeObjects = this.GetAddedCodeInnerBlock(codeInfos, blockObj.CodeObjects);
        }
        

        #endregion

        #region Abstract

        /// <summary>
        /// Analys Code to item
        /// </summary>
        public abstract SourceCodeInfo[] GetSourceCodeAnalysis();

        public abstract SourceCodeInfoVBDotnetAddHandler[] GetSourceCodeInfoVBDotnetAddHandleresForMiglation(string objectName);
        

        #endregion

        #endregion
    }
}

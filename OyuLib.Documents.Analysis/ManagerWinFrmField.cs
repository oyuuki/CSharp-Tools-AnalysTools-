﻿using System;
using System.Collections.Generic;

using System.Reflection;

namespace OyuLib.Documents.Sources.Analysis
{
    /// <summary>
    /// class is All Sourcecode parent
    /// </summary>
    public abstract class ManagerWinFrmField
    {
        #region Instance

        /// <summary>
        /// SourceText
        /// </summary>
        protected string _sourceText = null;

        #endregion

        #region Constructor

        protected ManagerWinFrmField(string sourceText)
        {
            this._sourceText = sourceText;
        }

        protected ManagerWinFrmField()
        {

        }

        #endregion

        #region method

        /// <summary>
        /// 入力項目情報を取得する
        /// </summary>
        /// <returns></returns>
        public WinFrmInputField[] GetWinFrmFields<T>()
            where T : ExtractorWinFrmInputField, new()
        {

            AnalyzerInputFieldItem[] partArray = this.GetSourceCodePart().GetPartArray();
            List<WinFrmInputField> retList = new List<WinFrmInputField>();

            foreach (AnalyzerInputFieldItem part in partArray)
            {
                T inputItemgene = ConstructItemInput<T>(part);

                retList.Add(inputItemgene.GetWinFrmField());
            }

            return retList.ToArray();
        }

        private static T ConstructItemInput<T>(AnalyzerInputFieldItem part)
            where T : ExtractorWinFrmInputField, new()
        {
            Type type = typeof(T);
            ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(string), typeof(int), typeof(string) });

            if (ctor == null)
                throw new NotSupportedException("コンストラクタが定義されていません。");

            return (T)ctor.Invoke(new object[] { part.GetSourceText(), part.GethierarchyIndex(), part.GetItemSignature() });
        }

        #region abstract

        protected abstract AnalyzerInputFieldItem GetSourceCodePart();

        #endregion

        #endregion
    }
}

﻿using System;
using System.Collections.Generic;

using System.Reflection;
using OyuLib.OyuIO.OyuFile.OyuTextFile;

namespace AnalysisSourceCode.Field.WindowsForm
{
    /// <summary>
    /// class is All Sourcecode parent
    /// </summary>
    abstract class WinFrmFieldItemCodeGeneraterFromSource
    {
        #region Instance

        /// <summary>
        /// SourceText
        /// </summary>
        protected string _sourceText = null;

        #endregion

        #region Constructor

        protected WinFrmFieldItemCodeGeneraterFromSource(string sourceText)
        {
            this._sourceText = sourceText;
        }

        protected WinFrmFieldItemCodeGeneraterFromSource()
        {

        }

        #endregion

        #region method

        #region static

        #region getInstance

        public static T GetInstanceOfFile<T>(string filePath)
           where T : WinFrmFieldItemCodeGeneraterFromSource, new()
        {
            TextFile tFile = new TextFile(filePath);

            if (!tFile.IsExist())
            {
                return null;
            }

            return Construct<T>(tFile.GetAllReadText());
        }

        private static T Construct<T>(string arg)
            where T : WinFrmFieldItemCodeGeneraterFromSource, new()
        {
            Type type = typeof(T);
            ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(string) });

            if (ctor == null)
                throw new NotSupportedException("コンストラクタが定義されていません。");

            return (T)ctor.Invoke(new object[] { arg });
        }

        #endregion

        #endregion

        /// <summary>
        /// 入力項目情報を取得する
        /// </summary>
        /// <returns></returns>
        public WindowsFormFieldItem[] GetItemInfos<T>()
            where T : WinFrmFieldGenerater, new()
        {
            SourceCodePart[] partArray = this.GetSourceCodePart().GetPartArray();
            List<WindowsFormFieldItem> retList = new List<WindowsFormFieldItem>();

            foreach (SourceCodePart part in partArray)
            {
                T inputItemgene = ConstructItemInput<T>(part);

                retList.Add(inputItemgene.GetInputItem());
            }

            return retList.ToArray();
        }

        private static T ConstructItemInput<T>(SourceCodePart part)
            where T : WinFrmFieldGenerater, new()
        {
            Type type = typeof(T);
            ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(string), typeof(int), typeof(string) });

            if (ctor == null)
                throw new NotSupportedException("コンストラクタが定義されていません。");

            return (T)ctor.Invoke(new object[] { part.GetSourceText(), part.GethierarchyIndex(), part.GetItemSignature() });
        }

        #region abstract

        protected abstract SourceCodePart GetSourceCodePart();

        #endregion

        #endregion

    }
}

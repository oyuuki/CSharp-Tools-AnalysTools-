using System;
using System.Collections.Generic;

using System.Reflection;

namespace OyuLib.Documents.Analysis.Sources.ScreenField
{
    /// <summary>
    /// class is All Sourcecode parent
    /// </summary>
    abstract class WinFrmFieldManager
    {
        #region Instance

        /// <summary>
        /// SourceText
        /// </summary>
        protected string _sourceText = null;

        #endregion

        #region Constructor

        protected WinFrmFieldManager(string sourceText)
        {
            this._sourceText = sourceText;
        }

        protected WinFrmFieldManager()
        {

        }

        #endregion

        #region method

        #region static

        #region getInstance

        public static T GetInstanceOfFile<T>(string sourceText)
           where T : WinFrmFieldManager, new()
        {
            return Construct<T>(sourceText);
        }

        private static T Construct<T>(string arg)
            where T : WinFrmFieldManager, new()
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
        public WinFrmField[] GetWinFrmFields<T>()
            where T : WinFrmFieldExtractor, new()
        {
            InputFieldItemSourceCode[] partArray = this.GetSourceCodePart().GetPartArray();
            List<WinFrmField> retList = new List<WinFrmField>();

            foreach (InputFieldItemSourceCode part in partArray)
            {
                T inputItemgene = ConstructItemInput<T>(part);

                retList.Add(inputItemgene.GetWinFrmField());
            }

            return retList.ToArray();
        }

        private static T ConstructItemInput<T>(InputFieldItemSourceCode part)
            where T : WinFrmFieldExtractor, new()
        {
            Type type = typeof(T);
            ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(string), typeof(int), typeof(string) });

            if (ctor == null)
                throw new NotSupportedException("コンストラクタが定義されていません。");

            return (T)ctor.Invoke(new object[] { part.GetSourceText(), part.GethierarchyIndex(), part.GetItemSignature() });
        }

        #region abstract

        protected abstract InputFieldItemSourceCode GetSourceCodePart();

        #endregion

        #endregion

    }
}

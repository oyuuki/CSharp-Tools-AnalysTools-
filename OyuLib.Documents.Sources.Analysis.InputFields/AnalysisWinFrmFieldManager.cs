using System;
using System.Collections.Generic;

using System.Reflection;

namespace OyuLib.Documents.Sources.Analysis.InputFields
{
    /// <summary>
    /// class is All Sourcecode parent
    /// </summary>
    public abstract class AnalysisWinFrmFieldManager
    {
        #region Instance

        /// <summary>
        /// SourceText
        /// </summary>
        protected string _sourceText = null;

        #endregion

        #region Constructor

        protected AnalysisWinFrmFieldManager(string sourceText)
        {
            this._sourceText = sourceText;
        }

        protected AnalysisWinFrmFieldManager()
        {

        }

        #endregion

        #region method

        /// <summary>
        /// 入力項目情報を取得する
        /// </summary>
        /// <returns></returns>
        public WinFrmInputField[] GetWinFrmFields<T>()
            where T : WinFrmInputFieldExtractor, new()
        {

            InputFieldItemAnalyzer[] partArray = this.GetInputFieldItemAnalyzer().GetPartArray();
            List<WinFrmInputField> retList = new List<WinFrmInputField>();

            foreach (InputFieldItemAnalyzer part in partArray)
            {
                T inputItemgene = ConstructItemInput<T>(part);

                retList.Add(inputItemgene.GetWinFrmField());
            }

            return retList.ToArray();
        }

        private static T ConstructItemInput<T>(InputFieldItemAnalyzer part)
            where T : WinFrmInputFieldExtractor, new()
        {
            Type type = typeof(T);
            ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(string), typeof(int), typeof(string) });

            if (ctor == null)
                throw new NotSupportedException("コンストラクタが定義されていません。");

            return (T)ctor.Invoke(new object[] { part.GetSourceText(), part.GethierarchyIndex(), part.GetItemSignature() });
        }

        #region abstract

        protected abstract InputFieldItemAnalyzer GetInputFieldItemAnalyzer();

        #endregion

        #endregion
    }
}

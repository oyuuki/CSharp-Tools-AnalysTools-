using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AnalysSourceCode.Generate;
using OyuLib.OyuFile;


namespace AnalysSourceCode
{
    /// <summary>
    /// Manage to analys VBCode
    /// </summary>
    public class AnalysSourceCodeManager
    {
        #region Instance

        /// <summary>
        /// source text
        /// </summary>
        protected string _filePath = null;

        #endregion

        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="source"></param>
        public AnalysSourceCodeManager(string filePath)
        {
            this._filePath = filePath;
        }

        #endregion

        #region Method

        /// <summary>
        /// Analys Code to item
        /// </summary>
        public InputItem[] ExecAnalysToInputItemInfos()
        {
            if (FileUtil.IsExistFileCheck(this._filePath))
            {
                InputItemCodeGeneraterFromVBSource gene = InputItemCodeGeneraterFromSource.GetInstanceOfFile<InputItemCodeGeneraterFromVBSource>(this._filePath);
                InputItem[] array = gene.GetItemInfos<InputItemVBSourceGenerater>();
                return array;
            }

            return null;
        }

        #endregion
    }
}

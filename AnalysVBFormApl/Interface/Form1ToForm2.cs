using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalysisVBFormApl.Interface
{
    public class Form1ToForm2
    {
        /// <summary>
        /// 行番号
        /// </summary>
        private string _lineNumber = null;


        /// <summary>
        /// 行文字列
        /// </summary>
        private string _lineString = null;


        public Form1ToForm2(string lineNumber, string lineString)
        {
            this._lineNumber = lineNumber;
            this._lineString = lineString;
        }

        public string GetLineNumber()
        {
            return this._lineNumber;
        }

        public string GetLineString()
        {
            return this._lineString;
        }
    }
}

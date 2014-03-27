using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateTestMatrix
{
    class PartialClass
    {
        #region instanceVal

        private string _bussinessClassFilePath = string.Empty;

        private string _desinerClassFilePath = string.Empty;

        #endregion

        #region Constructor

        public PartialClass(
            string bussinessClassFilePath,
            string desinerClassFilePath)
        {
            this._bussinessClassFilePath = bussinessClassFilePath;
            this._desinerClassFilePath = desinerClassFilePath;
        }

        #endregion

        #region Property

        public string BussinessClassFilePath
        {
            get { return this._bussinessClassFilePath; }
            set { this._bussinessClassFilePath = value; }
        }

        public string DesinerClassFilePath
        {
            get { return this._desinerClassFilePath; }
            set { this._desinerClassFilePath = value; }
        }

        #endregion

    }
}

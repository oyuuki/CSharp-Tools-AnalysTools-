using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalysVBFormApl
{
    public class DBCRUD
    {
        #region const

        private const string CONST_CRUD_C = "C";
        private const string CONST_CRUD_R = "R";
        private const string CONST_CRUD_U = "U";
        private const string CONST_CRUD_D = "D";

        #endregion

        #region instance

        /// <summary>
        /// db's name
        /// </summary>
        private string _dbname = null;

        /// <summary>
        /// crud string
        /// </summary>
        private string _crudStr = null;

        #endregion

        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="dbnameStr"></param>
        /// <param name="crudStr"></param>
        public DBCRUD(string dbnameStr, string crudStr)
        {
            this._dbname = dbnameStr;
            this._crudStr = crudStr.ToUpper();
        }

        #endregion

        #region method

        #region GetDbName

        public string GetDbName()
        {
            return this._dbname;
        }

        #endregion

        #region GetIsDBCrudC

        public bool GetIsDBCrudC()
        {
            return this.GetisAnyCrud(CONST_CRUD_C);
        }

        #endregion

        #region GetIsDBCrudR

        public bool GetIsDBCrudR()
        {
            return this.GetisAnyCrud(CONST_CRUD_R);
        }

        #endregion

        #region GetIsDBCrudU

        public bool GetIsDBCrudU()
        {
            return this.GetisAnyCrud(CONST_CRUD_U);
        }

        #endregion

        #region GetIsDBCrudD

        public bool GetIsDBCrudD()
        {
            return this.GetisAnyCrud(CONST_CRUD_D);
        }

        #endregion

        #region MargeCrud

        public void MargeCrud(DBCRUD crud)
        {
            string crudStr = string.Empty;

            if (this.GetIsDBCrudC() || crud.GetIsDBCrudC())
            {
                crudStr += "C";
            }

            if (this.GetIsDBCrudR() || crud.GetIsDBCrudR())
            {
                crudStr += "R";
            }

            if (this.GetIsDBCrudU() || crud.GetIsDBCrudU())
            {
                crudStr += "U";
            }

            if (this.GetIsDBCrudD() || crud.GetIsDBCrudD())
            {
                crudStr += "D";
            }

            this._crudStr = crudStr;
        }

        #endregion

        #region GetisAnyCrud

        private bool GetisAnyCrud(string crudValue)
        {
            return _crudStr.IndexOf(crudValue) >= 0;   
        }
    
        #endregion

        #endregion

    }
}

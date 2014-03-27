using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace OyuLib.interop.COM
{
    public class ExcelManager : IDisposable
    {
        #region instanceVal

        private string _filePath = string.Empty;

        private ApplicationClass _appExcel = null;

        private Workbook _excelBook = null;

        private Workbooks _oBooks = null;

        #endregion

        #region Constructor

        private ExcelManager(string filePath)
        {
            this._filePath = filePath;
            this.Initialize();
        }

        #endregion

        #region Method


        private void Initialize()
        {
            this._appExcel = new ApplicationClass();
            this._appExcel.Visible = false;
            this._oBooks = this._appExcel.Workbooks;
            this._excelBook = this._oBooks.Open(this._filePath);
        }

        public static ExcelManager GetInstaqnce(string filePath)
        {
            return new ExcelManager(filePath);
        }

        public void ExecuteMethodSub(string methodName, string moduleName, string param1, string param2)
        {
            this._appExcel.Run(this.GetFileName() + "!" + moduleName + "." + methodName,
                param1,
                param2,
                Missing.Value, 
                Missing.Value, 
                Missing.Value, 
                Missing.Value, 
                Missing.Value, 
                Missing.Value, 
                Missing.Value, 
                Missing.Value, 
                Missing.Value, 
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value); 
        }

        private string GetFileName()
        {
            return Path.GetFileName(this._filePath);
        }


        #endregion

        #region Interface

        #region IDispose

        public void Dispose()
        {
            this._excelBook.Close(false);
　　        System.Runtime.InteropServices.Marshal.ReleaseComObject(this._excelBook);
　　        this._excelBook = null;
            _oBooks.Close();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(this._oBooks);
            this._oBooks = null;
　　        System.Runtime.InteropServices.Marshal.ReleaseComObject(this._excelBook);
　　        this._excelBook = null;
　　        this._appExcel.Quit();
　　        System.Runtime.InteropServices.Marshal.ReleaseComObject(this._appExcel);
            this._appExcel = null;
        }

        #endregion

        #endregion

    }
}

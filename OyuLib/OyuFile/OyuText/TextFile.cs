using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ConstAttribute;
using OyuLib.OyuFile.CharSet;

namespace OyuLib.OyuFile.OyuText
{
    public class TextFile : FileAbs, IDisposable
    {
        #region InstanceVal

        private StreamWriter _sw = null;

        private EnumCharSet _cSet = EnumCharSet.ShiftJis;

        #endregion

        #region constructor

        public TextFile(string filePath)
            : base(filePath)
        {
            this._sw = 
            new System.IO.StreamWriter(
                filePath,
                true,
                System.Text.Encoding.GetEncoding(ConstAttributeManager<EnumCharSet>.GetValueByEnumValue(_cSet)));
        }

        #endregion

        #region Property

        public EnumCharSet CharSet
        {
            get { return this._cSet;  }
            set { this._cSet = value; }
        }   

        #endregion

        #region Method

        #region Override

        public void Dispose()
        {
            this.Close();
        }

        #endregion

        #region Private

        private void Close()
        {
            this._sw.Close();
            this._sw.Dispose();
        }

        #endregion

        #region Public

        public void Write(string text)
        {
            this._sw.Write(text);
        }

        public void WriteLine(string text)
        {
            this._sw.WriteLine(text);
        }

        #endregion

        #endregion
    }
}

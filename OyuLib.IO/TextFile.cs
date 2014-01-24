using System;
using System.IO;
using System.Text;


namespace OyuLib.IO
{
    public class TextFile : FileAbs, IDisposable
    {
        #region InstanceVal

        private StreamWriter _sw = null;

        private CharSet _cSet = CharSet.ShiftJis;

        #endregion

        #region constructor

        public TextFile(string filePath)
            : base(filePath)
        {
            
        }

        public TextFile(string filePath, bool isAppendMode)
            : base(filePath, isAppendMode)
        {

        }

        public TextFile(string filePath, bool isAppendMode, CharSet cSet)
            : base(filePath, isAppendMode)
        {
            this._cSet = cSet;
        }

        public TextFile(string filePath, CharSet cSet)
            : base(filePath)
        {
            this._cSet = cSet;
        }

        #endregion

        #region Property

        public CharSet CharSet
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

        #region protected virtual


        protected virtual void OpenStream()
        {
            this._sw =
            new System.IO.StreamWriter(
                this.FilePath,
                this.IsAppendMode,
                this.GetEncoding());
        }

        public virtual void Write(string text)
        {
            this._sw.Write(text);
        }

        public virtual void WriteLine(string text)
        {
            this._sw.WriteLine(text);
        }

        #endregion

        #region Private

        private Encoding GetEncoding()
        {
            return Encoding.GetEncoding(ConstAttributeManager<CharSet>.GetValueByEnumValue(_cSet));
        }

        #endregion

        #region Public

        public void OpenExistsFile()
        {
            if (!this.IsExist())
            {
                this.ThrowExNotExistFile();
            }

            this.OpenStream();
        }

        public void OpenCreateFile()
        {
            if (this.IsExist())
            {
                this.ThrowExAlreadyExistFile();
            }

            this.CreateNewFile();
            this.OpenStream();
        }

        public void OpenFileForse()
        {
            if (!this.IsExist())
            {
                this.CreateNewFile();
            }

            this.OpenStream();
        }

        /// <summary>
        /// Get All Text using encode shift_jis From TextFile 
        /// </summary>
        public string GetAllReadText()
        {
            return System.IO.File.ReadAllText(this.FilePath, this.GetEncoding());
        }

        public void Close()
        {
            this._sw.Close();
            this._sw.Dispose();
        }

        #endregion

        #endregion
    }
}

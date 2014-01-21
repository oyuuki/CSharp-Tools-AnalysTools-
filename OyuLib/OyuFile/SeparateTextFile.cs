using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.OyuChar;

namespace OyuLib.OyuFile
{
    public class SeparateTextFile : TextFile
    {
        #region instanceVal

        /// <summary>
        /// ヘッダ文字列を記述
        /// </summary>
        private string[] _headStrings = null;

        /// <summary>
        /// ヘッダ文字列を記述
        /// </summary>
        private CharCode _separate = null;

        #endregion

        #region constructor

        public SeparateTextFile(string filePath, CharCode separate)
            : base(filePath)
        {
            this._separate = separate;
        }

        public SeparateTextFile(string filePath, CharCodeKind cKind)
            : this(filePath, new CharCode(cKind))
        {

        }

        #endregion

        #region Property 

        public string[] HeadStrings
        {
            get { return this.HeadStrings; }
        }

        #endregion

        #region Method

        #region OverRide

        protected override void OpenStream()
        {
            base.OpenStream();

            if (this.IsAppendMode && ArrayUtil.IsNullOrNoLength(this.HeadStrings))
            {
                this.WriteLine(string.Join(this._separate.GetCharCodeString(), this.HeadStrings));
            }
        }

        public void WriteLine(string[] array)
        {
            this.WriteLine(GetStringSeparatedArray(array));
        }

        private new void Write(string text)
        {
            base.Write(text);
        }

        private new void WriteLine(string text)
        {
            base.WriteLine(text);
        }

        private string GetStringSeparatedArray(string[] stringArray)
        {
            return string.Join(this._separate.GetCharCodeString(), stringArray);
        }

        #endregion

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources
{
    public class SourceStringItem
    {
        #region InstanceVal

        private string _basicSource = string.Empty;
        private string _nonModifySource = string.Empty;

        #endregion

        #region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SourceStringItem(
            string basicSource,
            string nonModifySource)
        {
            this._basicSource = basicSource;
            this._nonModifySource = nonModifySource;
        }

        #endregion

        #region property

        public string BasicSource
        {
            get{ return this._basicSource;  }
            set { this._basicSource = value; }
        }

        public string NonModifySource
        {
            get{ return this._nonModifySource;  }
            set { this._nonModifySource = value; }
        }

        #endregion
    }
}

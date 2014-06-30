using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateTestMatrix
{
    class IfState
    {
        private bool _isElse = false;

        private bool _isExistRow = false;

        private bool _isExistCol = false;

        public IfState(bool isElse, bool isExistRow, bool isExistCol)
        {
            this._isElse = isElse;
            this._isExistRow = isExistRow;
            this._isExistCol = isExistCol;
        }

        public IfState()
            : this(false, false, false)
        {
        }

        public bool IsElse
        {
            get { return this._isElse; }
            set { this._isElse = value; }
        }

        public bool IsExistRow
        {
            get { return this._isExistRow; }
            set { this._isExistRow = value; }
        }

        public bool IsExistCol
        {
            get { return this._isExistCol; }
            set { this._isExistCol = value; }
        }
    }
}

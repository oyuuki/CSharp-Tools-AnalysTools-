using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class SourceBlock
    {
        #region instanceVal

        private object[] _codeObjects = null;

        #endregion

        #region Constructor

        public SourceBlock(CodeInfo[] codeinfos)
        {
            _codeObjects = this.GetCodeObjects(codeinfos);
        }

        #endregion

        #region Method

        public object[] GetCodeObjects(CodeInfo[] codeinfos)
        {
            foreach (var codeinfo in codeinfos)
            {
                


            }

            // Search The block of head

            // Search The block of footer

            // Add new Code Object That create New Source Block Instance




            return null;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoEventMethod : CodeInfoMethod
    {
        #region instanceVal

        private string _eventName = string.Empty;

        private string _objNamesuggestEvent = string.Empty;
        
        #endregion

        #region Constructor

        public CodeInfoEventMethod()
            : base()
        {
            
        }

        public CodeInfoEventMethod(
            string codeLine,
            string accessModifier,
            string name,
            string returnTypeName,
            string methodBody,
            CodeInfoValiable[] paramValiable,
            string eventName,
            string objNamesuggestEvent)
            : base(codeLine, accessModifier, name, returnTypeName, methodBody, paramValiable)
        {
            this._eventName = eventName;
            this._objNamesuggestEvent = objNamesuggestEvent;
        }

        #endregion

    }
}

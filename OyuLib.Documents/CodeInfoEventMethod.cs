using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoEventMethod : CodeInfoMethod
    {
        #region instanceVal

        private readonly int _eventName = -1;

        private readonly int _objNamesuggestEvent = -1;
        
        #endregion

        #region Constructor

        public CodeInfoEventMethod()
            : base()
        {
            
        }

        public CodeInfoEventMethod(
            string codeLine,
            string codeDelimiter,
            int accessModifier,
            int name,
            int returnTypeName,
            CodeInfoValiable[] paramValiable,
            int eventName,
            int objNamesuggestEvent)
            : base(codeLine, codeDelimiter, accessModifier, name, returnTypeName, paramValiable)
        {
            this._eventName = eventName;
            this._objNamesuggestEvent = objNamesuggestEvent;
        }

        #endregion

        #region Property

        public string EventName
        {
            get { return this.CodeParts[this._eventName]; }
        }

        public string ObjNamesuggestEvent
        {
            get { return this.CodeParts[this._objNamesuggestEvent]; }
        }

        #endregion

    }
}

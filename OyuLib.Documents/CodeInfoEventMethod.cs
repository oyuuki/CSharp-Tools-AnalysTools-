using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoEventMethod : CodeInfoMethod
    {
        #region instanceVal

        private readonly int _eve = -1;

        #endregion

        #region Constructor

        public CodeInfoEventMethod()
            : base()
        {
            
        }

        public CodeInfoEventMethod(
            Code code,
            int accessModifier,
            int name,
            int returnTypeName,
            CodeInfoValiable[] paramValiable,
            int eve)
            : base(code, accessModifier, name, returnTypeName, paramValiable)
        {
            this._eve = eve;
        }

        public CodeInfoEventMethod(
            string codeLine,
            string codeDelimiter,
            int accessModifier,
            int name,
            int returnTypeName,
            CodeInfoValiable[] paramValiable,
            int eve)
            : base(codeLine, codeDelimiter, accessModifier, name, returnTypeName, paramValiable)
        {
            this._eve = eve;
        }

        #endregion

        #region Property

        public string ObjNamesuggestEventName
        {
            get { return this.GetEventString()[0]; }
        }

        public string EventName
        {
            get { return this.GetEventString()[1]; }
        }

        #endregion

        #region Method


        private string[] GetEventString()
        {
            return
                new CharCodeManager(new CharCode(".")).GetSpilitString(
                    this.Code.CodeParts()[this._eve]);
        }

        #region override

        public override string GetCodeText()
        {
            return "イベントメソッド名：" + this.Name + "アクセス修飾子" + this.AccessModifier + "イベント名：" + this.EventName +
                   "イベント発生オブジェクト名：" + this.ObjNamesuggestEventName  + this.Code.CodeString;
        }

        #endregion

        #endregion

    }
}

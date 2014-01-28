using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class CodeInfoParameterValue : CodeInfo
    {
        #region instanceVal

        private int _name = -1;

        private int _typeName = -1;

        private int _passedType = -1;

        #endregion

        #region Constructor

        public CodeInfoParameterValue()
        {
               
        }

        public CodeInfoParameterValue(
            Code code,
            int name,
            int typeName,
            int passedType)
            : base(code)
        {
            this._name = name;
            this._typeName = typeName;
            this._passedType = passedType;
        }

        public CodeInfoParameterValue(
            string codeString, 
            string codeDelimiter,
            int name,
            int typeName,
            int passedType)
            : base(codeString, codeDelimiter)
        {
            this._name = name;
            this._typeName = typeName;
            this._passedType = passedType;
        }

        #endregion

        #region Property

        public string Name
        {
            get { return this.GetCodePartsString(this._name); }   
        }

        public string TypeName
        {
            get { return this.GetCodePartsString(this._typeName); }
        }

        public string PassedType
        {
            get { return this.GetCodePartsString(this._passedType); }
        }

        #endregion

        #region Method

        #region Override

        public override string GetCodeText()
        {
            return "その他コード：" + this.Code.CodeString;
        }

        public override CodeInfo GetCodeInfo()
        {
            throw new NotImplementedException();
        }

        public override bool IsCodeInfo()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}

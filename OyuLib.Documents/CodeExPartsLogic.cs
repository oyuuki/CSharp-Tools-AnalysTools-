using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeExPartsLogic : Code
    {
        #region Constructor

        public CodeExPartsLogic()
            : base()
        {
            
        }

        public CodeExPartsLogic(Code code)
            : base(code)
        {
            
        }

        public CodeExPartsLogic(string codeLine, string codeDelimiter)
            : base(codeLine, codeDelimiter)
        {
            
        }

        #endregion

        #region Method

        #region Override

        public override string[] CodeParts()
        {
            return
                new StringSpilitter(this.CodeString).GetSpilitStringSomeNested(
                    new CharCode(this.CodeDelimiter).GetCharCodeString(), new NestingString("(", ")"));
        }

        #endregion

        #endregion
    }
}

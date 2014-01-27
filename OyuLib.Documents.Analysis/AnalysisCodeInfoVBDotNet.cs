using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class AnalysisCodeInfoVBDotNet : AnalysisCodeInfo
    {
        
        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        public AnalysisCodeInfoVBDotNet()
            : base()
        {
        }

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="code"></param>
        public AnalysisCodeInfoVBDotNet(Code code)
            : base(code)
        {
            
        }

        #endregion

        #region Method

        #region Override

        public override CodeInfo GetCodeInfo()
        {
            CodeInfo retValue = null;

            if (IsMethod(out retValue))
            {
                return retValue;
            }

            return retValue;
        }

        
        private bool IsMethod(out CodeInfo outCodeInfo)
        {
            outCodeInfo = null;
            string[] codeParts = this.Code.GetSpilitByDelimiter();

            if (this.IsIncludeStringInCode(new string[] { "Function", "Sub" }))
            {
                


                if (this.IsIncludeStringInCode(new string[] { "Handles" }))
                {
                    outCodeInfo = new CodeInfoEventMethod();
                }
                else
                {
                    outCodeInfo = new CodeInfoMethod();
                }
            }



            return false;
        }


        

        #endregion

        #endregion

    }
}

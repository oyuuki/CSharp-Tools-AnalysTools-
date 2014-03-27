using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class ProfileAnalysisMember : ProfileAnalysis
    {
        #region instanceVal

        private string _eventObjectTypeName = string.Empty;

        #endregion

        #region Property

        private string EventObjectTypeName
        {
            get { return this._eventObjectTypeName; }
            set { this._eventObjectTypeName = value; }
        }

        #endregion

        #region Constructor

        public ProfileAnalysisMember(string name,
            AnalysisSourceDocumentManager businessManager,
            AnalysisSourceDocumentManager designManager)
            : base(name, businessManager, designManager)
        {

        }

        #endregion


        #region Method

        public SourceCodeInfoMemberVariable[] GetMemberValiables()
        {                         
            //"FarPoint.Win.Spread.FpSpread"
            return this.GetMemberValiables(this.EventObjectTypeName);
        }

        #endregion  
    }
}

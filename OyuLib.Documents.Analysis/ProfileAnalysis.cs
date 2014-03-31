using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class ProfileAnalysis : Profile
    {
        #region instanceVal

        /// <summary>
        /// The Instance of Analysis business logic Manager
        /// </summary>
        private AnalysisSourceDocumentManager _businessManager = null;

        /// <summary>
        /// The Instance of Anarisis Desiner logic Manager
        /// </summary>
        private AnalysisSourceDocumentManager _designManager = null;

        #endregion

        #region Property

        protected AnalysisSourceDocumentManager BusinessManager
        {
            get { return this._businessManager; }
        }

        protected AnalysisSourceDocumentManager DesignManager
        {
            get { return this._designManager; }
        }

        #endregion

        #region Constructor

        public ProfileAnalysis(
            string name, 
            AnalysisSourceDocumentManager businessManager,
            AnalysisSourceDocumentManager designManager)
            : base(name)
        {
            this._businessManager = businessManager;
            this._designManager = designManager;
        }

        #endregion

        #region Method

        public SourceCodeInfoMemberVariable[] GetMemberValiables(string eventObjectTypeName)
        {
            //"FarPoint.Win.Spread.FpSpread"
            return this.DesignManager.GetSourceCodeInfoMemberVariableByType(eventObjectTypeName);
        }

        public SourceCodeInfoMemberVariable[] GetMemberValiablesNotType(string eventObjectTypeName)
        {
            //"FarPoint.Win.Spread.FpSpread"
            return this.DesignManager.GetSourceCodeInfoMemberVariableByNotType(eventObjectTypeName);
        }

        public SourceCodeInfoMemberVariable[] GetMemberValiables(string[] eventObjectTypeNames)
        {
            //"FarPoint.Win.Spread.FpSpread"
            return this.DesignManager.GetSourceCodeInfoMemberVariableByType(eventObjectTypeNames);
        }

        public SourceCodeInfoMemberVariable[] GetMemberValiablesNotType(string[] eventObjectTypeNames)
        {
            //"FarPoint.Win.Spread.FpSpread"
            return this.DesignManager.GetSourceCodeInfoMemberVariableByNotType(eventObjectTypeNames);
        }

        #endregion
    }
}

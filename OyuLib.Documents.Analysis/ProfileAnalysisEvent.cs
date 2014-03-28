using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class ProfileAnalysisEvent : ProfileAnalysis
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

        public ProfileAnalysisEvent(string name,
            string eventObjectTypeName,
            AnalysisSourceDocumentManager businessManager,
            AnalysisSourceDocumentManager designManager)
            : base(name, businessManager, designManager)
        {
            this._eventObjectTypeName = eventObjectTypeName;
        }

        #endregion


        #region Method

        public SourceCodeInfoMemberVariable[] GetMemberValiables()
        {                         
            return this.GetMemberValiables(this.EventObjectTypeName);
        }

        public ProfileEventItem[] GetImplementEventName()
        {
            var retValues = new List<ProfileEventItem>();

            foreach(var member in this.GetMemberValiables())
            {
                foreach(var handler in this.BusinessManager.GetSourceCodeInfoVBDotnetAddHandleresForMiglation(member.Name))
                {
                    retValues.Add(new ProfileEventItem(member.Name, handler.GetEventName()));
                }

                foreach(var eventMethod in  this.BusinessManager.GetSourceCodeInfoBlockBeginEventMethodSuggestObjectName(member.Name))
                {
                    retValues.Add(new ProfileEventItem(eventMethod.EventObjectName, eventMethod.EventName));
                }
            }

            return retValues.ToArray();
        }

        public Dictionary<string, ProfileEventItem[]> GetImplementEventNameByMember()
        {
            var retValues = new Dictionary<string, ProfileEventItem[]>();

            foreach (var member in this.GetMemberValiables())
            {
                var proftValues = new List<ProfileEventItem>();

                foreach (var handler in this.BusinessManager.GetSourceCodeInfoVBDotnetAddHandleresForMiglation(member.Name))
                {
                    proftValues.Add(new ProfileEventItem(member.Name, handler.GetEventName()));
                }

                foreach (var eventMethod in this.BusinessManager.GetSourceCodeInfoBlockBeginEventMethodSuggestObjectName(member.Name))
                {
                    proftValues.Add(new ProfileEventItem(eventMethod.EventObjectName, eventMethod.EventName));
                }

                retValues.Add(member.Name, proftValues.ToArray());
            }

            return retValues;
        }

        public class ProfileEventItem
        {
            #region instanceVal

            private string _eventObject = string.Empty;
            
            private string _eventName = string.Empty;

            #endregion


            #region Property

            public string EventObject
            {
                get { return this._eventObject; }
            }

            public string EventName
            {
                get { return this._eventName; }
            }

            #endregion

            #region Constructor

            public ProfileEventItem(string eventObject, string eventName)
            {
                this._eventName = eventName;
                this._eventObject = eventObject;
            }

            #endregion

        }

        #endregion
    }
}

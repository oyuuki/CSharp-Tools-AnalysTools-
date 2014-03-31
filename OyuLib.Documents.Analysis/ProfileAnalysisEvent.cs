using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class ProfileAnalysisEvent : ProfileAnalysis
    {
        #region instanceVal

        private string[] _eventObjectTypeName = null;

        #endregion

        #region Property

        private string[] EventObjectTypeNames
        {
            get { return this._eventObjectTypeName; }
            set { this._eventObjectTypeName = value; }
        }

        #endregion

        #region Constructor

        public ProfileAnalysisEvent(string name,
            string eventObjectTypeName,
            AnalysisSourceDocumentManagerVBDotNet businessManager,
            AnalysisSourceDocumentManagerVBDotNet designManager)
            : base(name, businessManager, designManager)
        {
            this._eventObjectTypeName = new string[]{eventObjectTypeName};
        }

        public ProfileAnalysisEvent(string name,
            string[] eventObjectTypeNames,
            AnalysisSourceDocumentManagerVBDotNet businessManager,
            AnalysisSourceDocumentManagerVBDotNet designManager)
            : base(name, businessManager, designManager)
        {
            this._eventObjectTypeName = eventObjectTypeNames;
        }

        #endregion


        #region Method

        public SourceCodeInfoMemberVariable[] GetMemberValiables()
        {                         
            return this.GetMemberValiables(this.EventObjectTypeNames);
        }

        public SourceCodeInfoMemberVariable[] GetMemberValiablesNotType()
        {
            return this.GetMemberValiablesNotType(this.EventObjectTypeNames);
        }

        public ProfileEventItem[] GetImplementEventName()
        {
            return this.GetImplementEventName(true);
        }

        public ProfileEventItem[] GetImplementEventName(bool isMatch)
        {
            var retValues = new List<ProfileEventItem>();
            SourceCodeInfoMemberVariable[] memberArray = null;

            if(isMatch)
            {
                memberArray = this.GetMemberValiables();
            }
            else
            {
                memberArray = this.GetMemberValiablesNotType();
            }

            foreach (var member in memberArray)
            {
                foreach (var handler in this.BusinessManager.GetSourceCodeInfoVBDotnetAddHandleresForMiglation(member.Name))
                {
                    retValues.Add(new ProfileEventItem(member.Name, handler.GetEventName()));
                }

                foreach(var eventMethod in  this.BusinessManager.GetSourceCodeInfoBlockBeginEventMethodSuggestObjectName(member.Name))
                {
                    retValues.Add(new ProfileEventItem(member.Name, eventMethod.EventName));
                }
            }

            return retValues.ToArray();
        }

        public ProfileEventItem[] GetImplementEventNameNotTypeName()
        {
            return this.GetImplementEventName(false);
        }

        public ProfileEventItem[] GetImplementEventNameMemberCaption()
        {
            var retValues = new List<ProfileEventItem>();

            foreach (var member in this.GetMemberValiables())
            {
                var subCodeInfo = this.DesignManager.GetCodeInfoSubstitutions("Me." + member.Name + ".Text");

                var captionName = member.Name;

                if(subCodeInfo != null && subCodeInfo.Length > 0)
                {
                    captionName = subCodeInfo[0].RightHandSide.Replace("\"", string.Empty);
                }
                

                foreach (var handler in this.BusinessManager.GetSourceCodeInfoVBDotnetAddHandleresForMiglation(member.Name))
                {
                    retValues.Add(new ProfileEventItem(captionName, handler.GetEventName()));
                }

                foreach (var eventMethod in this.BusinessManager.GetSourceCodeInfoBlockBeginEventMethodSuggestObjectName(member.Name))
                {
                    retValues.Add(new ProfileEventItem(captionName, eventMethod.EventName));
                }
            }

            return retValues.ToArray();
        }

        public Dictionary<string, ProfileEventItem[]> GetImplementEventNameByMemberNotType()
        {
            return this.GetImplementEventNameByMember(false);
        }

        public Dictionary<string, ProfileEventItem[]> GetImplementEventNameByMember()
        {
            return this.GetImplementEventNameByMember(true);
        }

        public Dictionary<string, ProfileEventItem[]> GetImplementEventNameByMember(bool isMatch)
        {
            var retValues = new Dictionary<string, ProfileEventItem[]>();

            SourceCodeInfoMemberVariable[] memberArray = null;

            if (isMatch)
            {
                memberArray = this.GetMemberValiables();
            }
            else
            {
                memberArray = this.GetMemberValiablesNotType();
            }

            foreach (var member in memberArray)
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

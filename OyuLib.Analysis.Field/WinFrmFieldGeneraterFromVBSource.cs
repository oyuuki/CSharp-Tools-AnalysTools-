using System;
using OyuLib.Analysis.Source.Field;

namespace OyuLib.Analysis.Source.Field
{
    class WinFrmFieldGeneraterFromVBSource : WinFrmFieldGenerater
    {
        #region constractor

        public WinFrmFieldGeneraterFromVBSource()
        {

        }

        public WinFrmFieldGeneraterFromVBSource(string sourceText, int hierarchyIndex, string itemSignature)
            : base(sourceText, hierarchyIndex, itemSignature)
        {

        }


        #endregion

        #region Method

        private string GetNameFromBegin()
        {
            return GetBeginValue(0);
        }

        private string GetExTypeFromBegin()
        {
            return GetBeginValue(1);
        }

        private string GetBeginValue(int minusIndex)
        {
            string[] array = this.GetBegin().Split(' ');

            int index = array.Length - 1 - minusIndex;

            if (index < 0)
            {
                return string.Empty;
            }

            return array[index];
        }

        private string GetBegin()
        {
            string[] spilitedSourcebyKai = this._sourceText.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            foreach (string text in spilitedSourcebyKai)
            {
                if (text.IndexOf("Begin ") >= 0)
                {
                    return text.Trim();
                }
            }

            return string.Empty;
        }

        #region override

        #region GetId

        /// <summary>
        /// GetId From Source
        /// </summary>
        /// <returns></returns>
        protected override string GetId()
        {
            string retValue = string.Empty;

            return this.GetNameFromBegin();
        }

        #endregion

        #region Getname

        /// <summary>
        /// getName From Source
        /// </summary>
        /// <returns></returns>
        protected override string GetName()
        {
            string retValue = string.Empty;

            if (_sourceText.IndexOf("Begin im") < 0)
            {
                if (!(retValue = GetFieldValue("Caption")).Equals(string.Empty))
                {
                    return retValue;
                }
            }

            return this.GetNameFromBegin();            
        }

        #endregion

        #region GetFormat

        protected override string GetFormat()
        {
            string retValue = string.Empty;

            if (!(retValue = GetFieldValue(" Format")).Equals(string.Empty))
            {
                string min = string.Empty;

                if (!(min = GetFieldValue("MinValue")).Equals(string.Empty))
                {
                    if (Convert.ToDecimal(min) < 0)
                    {
                        retValue = "-" + retValue;
                    }
                }

                return retValue;
            }

            if (this.GetExType().IndexOf("imPostal") >= 0)
            {
                return "000-0000";
            }

            return string.Empty;
        }

        #endregion

        #region GetType

        protected override string GetExType()
        {
            return this.GetExTypeFromBegin();
        }

        #endregion

        #region GetBeam

        protected override string GetBeam()
        {
            string retValue = string.Empty;

            if (!(retValue = this.GetFormat()).Equals(string.Empty))
            {
                if (this.GetExType().IndexOf("imDate") >= 0
                    || this.GetExType().IndexOf("imNumber") >= 0)
                {
                    return retValue.Length.ToString();
                }
            }

            if (!(retValue = GetFieldValue("MaxValue")).Equals(string.Empty))
            {
                return retValue.Length.ToString();
            }

            if (!(retValue = GetFieldValue("MaxLength")).Equals(string.Empty))
            {
                return retValue.ToString();
            }

            if (!(retValue = GetFieldValue("imPostal")).Equals(string.Empty))
            {
                return this.GetFormat().Length.ToString();
            }

            return string.Empty;
        }

        #endregion

        #region GetTabIndex

        protected override string GetTabIndex()
        {
            string retValue = string.Empty;

            if (!(retValue = GetFieldValue("TabIndex")).Equals(string.Empty))
            {
                return retValue;
            }

            return string.Empty;
        }

        #endregion

        #region GetReadOnly

        protected override string GetReadOnly()
        {
            string retValue = string.Empty;

            if (!(retValue = GetFieldValue("ReadOnly")).Equals(string.Empty))
            {
                return retValue;
            }

            return string.Empty;
        }

        #endregion

        #region GetImeMode

        protected override string GetImeMode()
        {
            string retValue = string.Empty;
            if (this.GetExType().IndexOf("imDate") >= 0
                    || this.GetExType().IndexOf("imNumber") >= 0)
            {
                return ConstAttributeManager<KindImeMode>.GetConstByEnumValue(KindImeMode.Off);
            }

            if (!(retValue = GetFieldValue("IMEMode")).Equals(string.Empty))
            {
                return retValue;
            }

            return string.Empty;
        }

        #endregion

        #endregion

        #endregion
    }
}

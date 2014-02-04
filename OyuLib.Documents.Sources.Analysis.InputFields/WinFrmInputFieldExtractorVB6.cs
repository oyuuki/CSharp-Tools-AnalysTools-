using System;

namespace OyuLib.Documents.Sources.Analysis.InputFields
{
    internal class WinFrmInputFieldExtractorVB6 : WinFrmInputFieldExtractor
    {
        #region constractor

        public WinFrmInputFieldExtractorVB6()
        {

        }

        public WinFrmInputFieldExtractorVB6(string sourceText, int hierarchyIndex, string itemSignature)
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
            string[] spilitedSourcebyKai = this.SourceText.Split(new string[] { "\r\n" }, StringSplitOptions.None);

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

            if (this.SourceText.IndexOf("Begin im") < 0)
            {
                if (!(retValue = this.GetWinFrmFieldPropertyValue("Caption")).Equals(string.Empty))
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

            if (!(retValue = this.GetWinFrmFieldPropertyValue(" Format")).Equals(string.Empty))
            {
                string min = string.Empty;

                if (!(min = this.GetWinFrmFieldPropertyValue("MinValue")).Equals(string.Empty))
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

            if (!(retValue = this.GetWinFrmFieldPropertyValue("MaxValue")).Equals(string.Empty))
            {
                return retValue.Length.ToString();
            }

            if (!(retValue = this.GetWinFrmFieldPropertyValue("MaxLength")).Equals(string.Empty))
            {
                return retValue.ToString();
            }

            if (!(retValue = this.GetWinFrmFieldPropertyValue("imPostal")).Equals(string.Empty))
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

            if (!(retValue = this.GetWinFrmFieldPropertyValue("TabIndex")).Equals(string.Empty))
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

            if (!(retValue = this.GetWinFrmFieldPropertyValue("ReadOnly")).Equals(string.Empty))
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
                return ConstAttributeManager<FieldsImeMode>.GetConstByEnumValue(FieldsImeMode.Off);
            }

            if (!(retValue = this.GetWinFrmFieldPropertyValue("IMEMode")).Equals(string.Empty))
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

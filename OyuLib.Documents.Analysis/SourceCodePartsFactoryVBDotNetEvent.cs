using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodePartsFactoryVBDotNetEvent : SourceCodePartsFactoryVBDotNetMethod
    {
        #region Const

        private const string const_Dot = ".";

        #endregion

        #region Constructor

        public SourceCodePartsFactoryVBDotNetEvent(
            SourceCode code)
            : base(code)
        {
            
        }

        #endregion

        #region Method

        #region OverRide

        protected override StringRange[] GetCodePartsRanges(string withOutComment)
        {
            StringRange[] ranges = base.GetCodePartsRanges(withOutComment);

            var margeList = new List<StringRange>();

            for (int index = 0; index + 1 < ranges.Length; index++)
            {
                margeList.Add(ranges[index]);    
            }


            var eventRange =
                StringSpilitter.GetStringRangeSpilit(
                    ranges[ranges.Length - 1],
                    new CharCode(const_Dot).GetCharCodeString());

            margeList.Add(eventRange[0]);
            margeList.Add(eventRange[1]);

            return margeList.ToArray();

        }

        #endregion

        #endregion
    }
}

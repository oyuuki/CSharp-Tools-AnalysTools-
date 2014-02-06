using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeTemplateFactory
    {
        #region instanceVal

        private NestIndex[] _nestcodeIndecis = null;

        private StringRange[] _codeRnges = null;

        #endregion

        #region Constructor

        public SourceCodeTemplateFactory(
            NestIndex[] codeIndex,
            StringRange[] codeRnges)
        {
            this._nestcodeIndecis = codeIndex;
            this._codeRnges = codeRnges;
        }

        #endregion

        #region Property

        public NestIndex[] NestcodeIndex
        {
            get { return this._nestcodeIndecis; }
        }
        public StringRange[] CodeRnges
        {
            get { return this._codeRnges; }
        }

        #endregion

        #region Method

        public string GetTemplateString(StringRange[] ranges, NestIndex[] nestcodeIndecis)
        {
            StringBuilder strBu = new StringBuilder();

            for (int index = 0; index < ranges.Length; index++)
            {
                StringRange range = ranges[index];
                bool isParts = false;

                strBu.Append(range.SpilitSeparatorStart);

                foreach (var nestIndex in nestcodeIndecis)
                {
                    if (nestIndex.Index < 0 && nestIndex.HasChild)
                    {
                        strBu.Append(this.GetTemplateString(range.Childs, nestIndex.Childs));
                        isParts = true;
                        break;
                    }
                    else if (nestIndex.Index == index)
                    {
                        if (range.HasChild)
                        {
                            strBu.Append(this.GetTemplateString(range.Childs, nestIndex.Childs));
                        }
                        else
                        {
                            strBu.Append(this.GetTemplateValue(nestIndex));
                        }

                        isParts = true;
                    }
                    
                }

                if (!isParts)
                {
                    strBu.Append(ranges[index].GetStringSpilited());
                }

                strBu.Append(ranges[index].SpilitSeparatorEnd);
            }

            return strBu.ToString();
        }

        public string GetTemplateString()
        {
            return this.GetTemplateString(this.CodeRnges, this.NestcodeIndex);
        }

        private string GetTemplateValue(NestIndex codepartsIndex)
        {
            return "{<<<" + codepartsIndex.ParentIndex + "_" + codepartsIndex.HierarchyCount + "_" + codepartsIndex.Index + ">>>}";
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace OyuLib.Documents.Sources
{
    public interface IParamater
    {
        SourceCodeInfoParamater GetSourceCodeInfoParamater();
        StringRange Range { get; set; }
        bool GetIsOverWriteParamater();
    }

}

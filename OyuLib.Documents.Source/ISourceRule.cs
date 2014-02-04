using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OyuLib.Documents.Sources
{
    public interface ISourceRule
    {
        SourceDocumentRule GetSourceRule();
    }
}

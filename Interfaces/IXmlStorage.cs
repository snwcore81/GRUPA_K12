using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GRUPA_K12.Interfaces
{
    public interface IXmlStorage
    {
        bool FromXml(Stream Stream);
        MemoryStream ToXml();
    }
}

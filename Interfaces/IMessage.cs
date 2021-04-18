using System;
using System.Collections.Generic;
using System.Text;
using GRUPA_K12.Classes;

namespace GRUPA_K12.Interfaces
{
    public interface IMessage
    {
        IMessage ProcessRequest(StateObject a_oStateObject);
        IMessage ProcessResponse(StateObject a_oStateObject);
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GRUPA_K12.Classes.BusinessLogic
{
    [DataContract]
    public class User : FileXmlStorage<User> 
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int Permission { get; set; }
        [DataMember]
        public Response Response { get; set; }
        public User()
        {
            this.BaseObject = this;
        }

        public override string ToString()
        {
            return $"[Login={Login}|Password=???|Permission={Permission}|Response={Response}]";
        }
    }
}

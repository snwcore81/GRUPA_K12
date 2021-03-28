using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GRUPA_K12.Classes.BusinessLogic
{
    [DataContract]
    public class User : XmlStorage<User> 
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }

        public User()
        {
            this.BaseObject = this;
        }
        
        public override bool InitializeFromObject(User Object)
        {
            this.Login = Object.Login;
            this.Password = Object.Password;

            return true;
        }
    }
}

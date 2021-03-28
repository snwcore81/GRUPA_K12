using System;
using System.IO;
using System.Text;
using GRUPA_K12.Classes;
using GRUPA_K12.Classes.BusinessLogic;

namespace GRUPA_K12
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlStorageTypes.Register<User>();

            string _sXML = @"<User xmlns=""http://schemas.datacontract.org/2004/07/GRUPA_K12.Classes.BusinessLogic"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><Login>jacek</Login><Password>12jacek34</Password></User>" ;

            Console.WriteLine(_sXML);

            User _oUser = new User();

            _oUser.FromXml(new MemoryStream(Encoding.UTF8.GetBytes(_sXML)));

            Console.WriteLine($"Login={_oUser.Login} Password={_oUser.Password}");

            /*
            User _oUser = new User
            {
                Login = "jacek",
                Password = "12jacek34"
            };
            
            string _sXML = Encoding.UTF8.GetString(_oUser.ToXml().ToArray());
            */

            
        }
    }
}

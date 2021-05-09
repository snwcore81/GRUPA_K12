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
            /*
            User _oUser = new User
            {
                Login = "jkuzmicz",
                Password = "12pwd34",
                Permission = 1,
                Response = new Response(100,new Exception("test"))
            };

            try
            {
                _oUser.ExportToFile("user.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            */
         
            
            User _oUser = new User();

            try
            {
                if (_oUser.ImportFromFile("user.xml"))
                {
                    Console.WriteLine(_oUser);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

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

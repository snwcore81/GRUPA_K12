using System;
using System.IO;
using System.Text;
using GRUPA_K12.Classes;
using GRUPA_K12.Classes.BusinessLogic;
using GRUPA_K12.Classes.Messages;

namespace GRUPA_K12
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageFactory.Instance.Register<LoginMessage>();
            MessageFactory.Instance.Register<TextMessage>();

            Console.Write("Wybierz tryb uruchomienia programu (1-klient,2-serwer):");

            switch (Console.ReadLine())
            {
                case "1":
                    new TestClient().Run();
                    break;

                case "2":
                    new TestServer().Run();
                    break;
            }

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
         
            /*
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
            */
            
        }
    }
}

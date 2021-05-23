using System;
using System.IO;
using System.Text;
using GRUPA_K12.Classes;
using GRUPA_K12.Classes.BusinessLogic;
using GRUPA_K12.Classes.Database;
using GRUPA_K12.Classes.Messages;
using GRUPA_K12.Classes.System;

namespace GRUPA_K12
{
    class Program
    {
        static void Main(string[] args)
        {
            using var _log = Log.DEB("Program", "Main");

            XmlStorageTypes.Initialize();

            var _db = new MySqlSource
            {
                Host = "127.0.0.1",
                Port = 3306,
                Login = "admin",
                Password = "mydatabase1234",
                Schema = "mydatabase"
            };

            _db.Connect();

            LoginDbObject _nowyLogin = new LoginDbObject
            {
                Login = "jacek",
                Password = "12test34",
                LastUpdate = DateTime.Now
            };

            try
            {
                _db.TransactionStart();
                _nowyLogin.Insert(_db);
                _db.TransactionCommit();
            }
            catch (Exception e)
            {
                _log.PR_DEB($"Wyjątek! {e.Message}");

                _db.TransactionRollback();
            }

            /*
            foreach (var _oLogin in _db.ExecuteReader<LoginDbObject>())
            {
                try
                {
                    _db.TransactionStart();

                    Console.WriteLine(_oLogin);

                    Console.Write($"Podaj nowe hasło dla użytkownika <{_oLogin.Login}>:");
                    _oLogin.Password = Console.ReadLine();

                    if (_oLogin.IsChanged)
                    {
                        _oLogin.LastUpdate = DateTime.Now;
                        _oLogin.Update(_db);
                    }

                    _db.TransactionCommit();

                }
                catch (Exception e)
                {
                    _log.PR_DEB($"Wyjątek! {e.Message}");

                    _db.TransactionRollback();
                }
            }
            */


            _db.Disconnect();

            /*
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
            */

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

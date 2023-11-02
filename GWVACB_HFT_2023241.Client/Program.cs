using System;
using ConsoleTools;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Client
{
    internal class Program
    {
        private static RestService _rest;


        private static void Main(string[] args)
        {
            _rest = new RestService("http://localhost:5005/", "Author");

            var mainMenu = new ConsoleMenu(args, 0)
                .Add("Login", () => Login())
                //.Add("Register", () => Register())
                .Add("DevMode", () => DevMode())
                .Add("Exit", ConsoleMenu.Close);
            mainMenu.Show();
        }

        private static void DevMode()
        {
            new ConsoleMenu()
                .Add("Author", () => CrudMenu<Author>.Show(_rest))
                .Add("Quote", () => CrudMenu<Quote>.Show(_rest))
                .Add("Comment", () => CrudMenu<Quote>.Show(_rest))
                .Add("Back", ConsoleMenu.Close)
                .Show();
        }

        private static void Register()
        {
            throw new NotImplementedException();
        }

        private static void Login()
        {
            Console.Clear();
            Console.Write("Username: ");
            var uname = Console.ReadLine()?.Trim();
            try{
                var response = _rest.Get<Author>($"Author/{uname}");
            }
            catch (RestExceptionInfo e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
    }
}
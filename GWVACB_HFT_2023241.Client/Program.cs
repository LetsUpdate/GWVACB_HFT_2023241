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
            _rest = new RestService("http://localhost:5005/", "User");

            var mainMenu = new ConsoleMenu(args, 0)
                //.Add("Login", () => Login())
                //.Add("Register", () => Register())
                .Add("DevMode", () => DevMode())
                .Add("Exit", ConsoleMenu.Close);
            mainMenu.Show();
        }

        private static void DevMode()
        {
            new ConsoleMenu()
                .Add("User", () => CrudMenu<User>.Show(_rest))
                .Add("Note", () => CrudMenu<Note>.Show(_rest))
                .Add("Location", () => CrudMenu<Note>.Show(_rest))
                .Add("Back", ConsoleMenu.Close)
                .Show();
        }

        private static void Register()
        {
            throw new NotImplementedException();
        }

        private static void Login()
        {
            Console.Write("Username: ");
            var uname = Console.ReadLine()?.Trim();
            // var response = rest.Get<User>($"User/{uname}");
        }
    }
}
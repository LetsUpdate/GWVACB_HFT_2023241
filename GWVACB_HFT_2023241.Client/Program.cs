using GWVACB_HFT_2023241.Models;
using GWVACB_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net.Http;
using ConsoleTools;
using GWVACB_HFT_2023241.Logic;

namespace GWVACB_HFT_2023241.Client
{
    internal class Program
    {
        private static RestService rest;
        static void Main(string[] args)
        {
            rest = new RestService("localhost:5005/","User");

            var mainMenu = new ConsoleMenu(args, level: 0)
                .Add("Login", () => Login())
                .Add("Register", () => Register())
                .Add("DevMode", () => DevMode())
                .Add("Exit", ConsoleMenu.Close);
            mainMenu.Show();

        }

        private static void DevMode()
        {
            throw new NotImplementedException();
        }

        private static void Register()
        {
            throw new NotImplementedException();
        }

        private static void Login()
        {
            throw new NotImplementedException();
        }
    }
}

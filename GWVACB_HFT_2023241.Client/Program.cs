using System;
using System.Collections;
using System.Collections.Generic;
using ConsoleTools;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Client
{
    internal class Program
    {
        private static RestService _rest;

        private static void WriteLineAndWait(object s)
        {
            if(s as IEnumerable == null)
                Console.WriteLine(s);
            else
            {
                foreach (var element in s as IEnumerable)
                {
                    Console.WriteLine(element);
                }
            }
                
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void WriteLineAndWait(List<object> s)
        {
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        private static void Main(string[] args)
        {
            _rest = new RestService("http://localhost:5005/", "Author");

            var nonCrudMenu = new ConsoleMenu(args, 1)
                .Add("GetMostPopularQuote",
                    () => WriteLineAndWait(_rest.GetSingle<NameValue>("QuoteStat/GetMostPopularQuote")))
                .Add("GetQuoteCountByAuthor", () =>
                    WriteLineAndWait(_rest.Get<NameValue>("AuthorStat/GetQuoteCountByAuthor")))
                .Add("GetOldestAuthorQuotes",()=>
                    WriteLineAndWait(_rest.Get<Quote>("AuthorStat/GetOldestAuthorQuotes")))
                .Add("GetAuthorWithMostWords",()=>
                    WriteLineAndWait(_rest.GetSingle<Author>("AuthorStat/GetAuthorWithMostWords")))
                .Add("GetAvgQuoteLengthByAuthor",()=>
                    WriteLineAndWait(_rest.Get<NameValue>("AuthorStat/GetAvgQuoteLengthByAuthor")))
                .Add("Exit",ConsoleMenu.Close);

            var mainMenu = new ConsoleMenu(args, 0)
                .Add("NonCrud", nonCrudMenu.Show)
                .Add("DevMode", DevMode)
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


    }
}
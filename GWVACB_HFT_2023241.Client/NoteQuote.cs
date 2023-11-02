using System;
using System.Linq;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Client
{
    public class QuoteQuote
    {
        private Author _author;
        private RestService _service;
        private QuoteQuote(RestService service, Author author)
        {
            _service = service;
            _author = author;
        }

        public static void LogIn(RestService service)
        {
            Console.WriteLine("Ad meg a neved: ");
            string name = Console.ReadLine();
            var author = service.GetSingle<Author>("Quotebook/login/" + name);
        }
    }
}
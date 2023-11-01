using System;
using System.Linq;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Client
{
    public class NoteClient
    {
        private User _user;
        private RestService _service;
        private NoteClient(RestService service, User user)
        {
            _service = service;
            _user = user;
        }

        public static void LogIn(RestService service)
        {
            Console.WriteLine("Ad meg a neved: ");
            string name = Console.ReadLine();
            var user = service.GetSingle<User>("notebook/login/" + name);
        }
    }
}
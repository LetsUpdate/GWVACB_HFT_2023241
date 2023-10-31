using GWVACB_HFT_2023241.Models;
using GWVACB_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using GWVACB_HFT_2023241.Logic;

namespace GWVACB_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            INoteLogic logic = new NoteLogic(new NoteRepository(new NoteDbContext()));

        
        }
    }
}

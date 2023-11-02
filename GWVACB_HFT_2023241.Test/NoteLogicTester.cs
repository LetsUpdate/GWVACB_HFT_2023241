using System.Collections.Generic;
using System.Linq;
using GWVACB_HFT_2023241.Logic;
using GWVACB_HFT_2023241.Models;
using GWVACB_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;

namespace GWVACB_HFT_2023241.Test
{
    [TestFixture]
    public class QuoteLogicTester
    {
        [SetUp]
        public void Init()
        {
            mockQuoteRepo = new Mock<IRepository<Quote>>();

            var Quotes = new List<Quote>
            {

            };

            mockQuoteRepo.Setup(x => x.GetAll()).Returns(Quotes.AsQueryable());


            logic = new QuoteLogic(mockQuoteRepo.Object);
        }

        private IQuoteLogic logic;
        private Mock<IRepository<Quote>> mockQuoteRepo;


    }
}
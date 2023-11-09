using System;
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
        private IQuoteLogic logic;
        private Mock<IRepository<Quote>> mockQuoteRepo;
        
        [SetUp]
        public void Init()
        {
            mockQuoteRepo = new Mock<IRepository<Quote>>();
            
            mockQuoteRepo.Setup(x =>
                x.GetAll()).Returns(Helper.GetMocDataset().quotes.AsQueryable());
            
            logic = new QuoteLogic(mockQuoteRepo.Object);
        }
        

        [TestCase("Test", "")]
        [TestCase("", "asdasdasdadsasdasd")]
        [TestCase("123456789asdfghjkl", null)]
        [TestCase(null, null)]
        public void CreateTest(string title, string content)
        {
            var quote = new Quote()
            {
                Title = title,
                AuthorId = 2,
                Content = content
            };
            try
            {
                logic.Create(quote);
            }
            catch (Exception e)
            {
                // ignored
            }

            mockQuoteRepo.Verify(x => x.Create(quote), Times.Never);
        }
        
        [Test]
        public void GetQuoteCountByAuthorTest()
        {
            var result = logic.GetQuoteCountByAuthor();
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(2, result.FirstOrDefault(x => x.Name == "Marcus Aurelius")?.Value);
            Assert.AreEqual(2, result.FirstOrDefault(x => x.Name == "Epictetus")?.Value);
        }
        [Test]
        public void ListQuotesByAuthorTest()
        {
            var result = logic.ListQuotesByAuthor(1);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Marcus Aurelius", result.FirstOrDefault()?.Author.Name);
        }
        [Test]
        public void GetMostPopularQuoteTest()
        {
            var result = logic.GetMostPopularQuote();
            Assert.AreEqual("On Time", result.Name);
        }

    }
}
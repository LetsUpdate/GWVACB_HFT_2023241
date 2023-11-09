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
    public class authorLogicTester
    {
        private IauthorLogic ul;
        private Mock<IRepository<Author>> mockauthorRepo;

        [SetUp]
        public void Init()
        {
            mockauthorRepo = new Mock<IRepository<Author>>();
            var mockDataSet = Helper.GetMocDataset();
            
            mockauthorRepo.Setup(x => x.GetAll()).Returns(mockDataSet.authors.AsQueryable);

            ul = new AuthorLogic(mockauthorRepo.Object);
        }
        
        [Test]
        public void GetQuoteCountByAuthorTest()
        {
            var result = ul.GetQuoteCountByAuthor();
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(2, result.FirstOrDefault(x => x.Name == "Marcus Aurelius")?.Value);
            Assert.AreEqual(0, result.FirstOrDefault(x => x.Name == "Epictetus")?.Value);

        }
        [Test]
        public void GetOldestAuthorQuotesTest()
        {
            var result = ul.GetOldestAuthorQuotes();
            Assert.AreNotEqual(0, result.Count());
            Assert.AreEqual("Epictetus", result.FirstOrDefault()?.Author.Name);
        }
        [Test]
        public void GetAuthorWithMostWordsTest()
        {
            var result = ul.GetAuthorWithMostWords();
            Assert.AreEqual("Seneca", result.Name);
        }
        //Multiple TestCase
       [TestCase("Test", 20, "H")]
       [TestCase("Test", 20, "123456789asdfghjkl")]
       [TestCase("Test", 4, "Budapest")]
       [TestCase("Test", 130, "Budapest")]
       [TestCase("A", 20, "Budapest")]
       [TestCase("123456789asdfghjkl", 20, "Budapest")]
        public void CreateTest(string name, int age, string country)
        {
            var author = new Author()
            {
                Name = name,
                Age = age,
                Country = country
            };
            try
            {
                ul.Create(author);
            }catch(ArgumentException e)
            { 
            }catch(Exception e)
            {
               // Assert.Fail();
            }

            mockauthorRepo.Verify(x => x.Create(author), Times.Never);
        }

        [TestCase("Marcus Aurelius")]
        [TestCase("Seneca")]
        [TestCase("Epictetus")]
        public void TestCreateExisting(string name)
        {
            var author = new Author()
            {
                Name = name,
                Age = 51,
                Country = "country"
            };
            try
            {
                ul.Create(author);
            }
            catch (ArgumentException e)
            {
            }
            mockauthorRepo.Verify(x => x.Create(author), Times.Never);
        }

        [Test]
        public void CreateValidAuthor()
        {
            var author=new Author()
            {
                Name = "UniqueName",
                Age = 25,
                Country = "Budapest"
            };
            try
            {
                ul.Create(author);
            }
            catch (ArgumentException e)
            {
                Assert.Fail();
            }
            mockauthorRepo.Verify(x => x.Create(author), Times.Once);
        }

       

    }
}
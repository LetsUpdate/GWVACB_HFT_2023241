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
        [SetUp]
        public void Init()
        {
            mockauthorRepo = new Mock<IRepository<Author>>();
            var inputdata = new List<Author>
            {

            };
            mockauthorRepo.Setup(x => x.GetAll()).Returns(inputdata.AsQueryable());


            ul = new AuthorLogic(mockauthorRepo.Object);
        }

        private IauthorLogic ul;
        private Mock<IRepository<Author>> mockauthorRepo;


    }
}
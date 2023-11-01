using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using GWVACB_HFT_2023241.Logic;
using GWVACB_HFT_2023241.Models;
using GWVACB_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;

namespace GWVACB_HFT_2023241.Test
{
    
    [TestFixture]
    public class UserLogicTester
    {
        private IUserLogic ul;
        private Mock<IRepository<User>> mockUserRepo;

        [SetUp]
        public void Init()
        {
            mockUserRepo = new Mock<IRepository<User>>();
            var inputdata = new List<User>()
            {
                new User { Id = 1, Username = "admin", Age = 10, School = "BME", Country = "Hungary" },
                new User { Id = 2, Username = "red", Age = 20, School = "OE", Country = "Hungary" },
                new User { Id = 3, Username = "Jozsi", Age = 21, School = "SOTE", Country = "Hungary" }
            };
            mockUserRepo.Setup(x => x.GetAll()).Returns(inputdata.AsQueryable());
            
            
            ul = new UserLogic(mockUserRepo.Object);
        }
        
        [Test]
        public void CreateExistingUserTest()
        {
            var user = new User { Id = 4, Username = "Jozsi", Age = 21, School = "SOTE", Country = "Hungary" };
            Assert.Throws<ArgumentException>(() => ul.Create(user));
            
        }

        [Test]
        public void CreateNewUser()
        {
            var user = new User {  Username = "Pisti", Age = 21, School = "SOTE", Country = "Hungary" };
            ul.Create(user);
            mockUserRepo.Verify(m=>m.Create(user), Times.Once);
        }
        [Test]
        public void CreateUserWithShortName()
        {
            var user = new User { Username = "Pi", Age = 21, School = "SOTE", Country = "Hungary" };
            Assert.Throws<ArgumentException>(() => ul.Create(user));
        }

        [Test]
        public void CreateUserWithDifrentCases()
        {
            var user =new User { Id = 1, Username = "aDMIn", Age = 10, School = "BME", Country = "Hungary" };
            Assert.Throws<ArgumentException>(() => ul.Create(user));
        }
        [Test]
        public void GetByNameTest()
        {
            var user = ul.GetByName("admin");
            Assert.AreEqual(user.Username, "admin");
        }
        
        




    }
}

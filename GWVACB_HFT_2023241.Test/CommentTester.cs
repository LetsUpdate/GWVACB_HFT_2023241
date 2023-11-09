using System;
using System.Collections;
using System.Linq;
using GWVACB_HFT_2023241.Logic;
using GWVACB_HFT_2023241.Models;
using GWVACB_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;

namespace GWVACB_HFT_2023241.Test
{
    [TestFixture]
    public class CommentTester
    {
        private ICommentLogic _logic;
        private Mock<IRepository<Comment>> _mock;

        [SetUp]
        public void Init()
        {
            _mock = new Mock<IRepository<Comment>>();

            _mock.Setup(x => x.GetAll()).Returns(Helper.GetMocDataset().comments.AsQueryable());
            _logic = new CommentLogic(_mock.Object);

        }

        [Test]
        public void CreateTest()
        {
            try
            {
             _logic.Create(new Comment("", 1));
            _logic.Create(new Comment(new string(Enumerable.Repeat('X', 21).ToArray()), 1));
            }
            catch (Exception e)
            {
                // ignored
            }
            _mock.Verify(x => x.Create(It.IsAny<Comment>()), Times.Never);
           
        }
        
    }
}
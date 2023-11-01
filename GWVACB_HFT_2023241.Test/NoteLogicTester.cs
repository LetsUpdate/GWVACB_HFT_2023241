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
    public class NoteLogicTester
    {
        [SetUp]
        public void Init()
        {
            mockNoteRepo = new Mock<IRepository<Note>>();

            var notes = new List<Note>
            {
                new(1, 1, "Belief in Inner Peace",
                    "The belief in inner peace is the true wealth of life. External things may come and go, but one's inner composure and peace endure.",
                    1),
                new(2, 1, "Acceptance of Loss",
                    "Accepting the loss of things and living in the spirit of acceptance is a sign of human strength and wisdom. Just as Tommy lost his puppy but accepted it with peace, so does Stoic philosophy teach the importance of acceptance.",
                    2),
                new(3, 2, "Resilience and Wisdom",
                    "Resistance and hardships teach us wisdom and resilience. Tommy's struggle with his lost dog and the joy of finding it reflects the Stoic principle of the strength in resistance and learning.",
                    3),
                new(4, 2, "Control over Fate",
                    "Having control over fate and external circumstances is the source of human freedom. Just as Tommy didn't give up the search, Stoic philosophy teaches us to control our reactions and decisions.",
                    4),
                new(5, 3, "Happiness in Inner Harmony",
                    "Happiness is a state of inner harmony and balance. Just as Tommy and Fido found each other, so does a person seek inner harmony and tranquility in life.",
                    5)
            };

            mockNoteRepo.Setup(x => x.GetAll()).Returns(notes.AsQueryable());


            logic = new NoteLogic(mockNoteRepo.Object);
        }

        private INoteLogic logic;
        private Mock<IRepository<Note>> mockNoteRepo;

        [Test]
        public void CreateNote()
        {
            var note = new Note(1, 1, "Test", "Test", 1);
            logic.Create(note);
            mockNoteRepo.Verify(m => m.Create(note), Times.Once);
        }
    }
}
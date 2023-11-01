using GWVACB_HFT_2023241.Models;
using GWVACB_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace GWVACB_HFT_2023241.Repository
{
    public class NoteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Location> Locations { get; set; }

        public NoteDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (builder.IsConfigured == false)
            {
                builder.UseLazyLoadingProxies().UseInMemoryDatabase("NoteDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany<Note>(Note => Note.Notes)
                .WithOne(User => User.User)
                .HasForeignKey(Note => Note.NoteId);

            modelBuilder.Entity<Note>().HasOne<User>(User => User.User)
                .WithMany(Note => Note.Notes)
                .HasForeignKey(User => User.UserId);

            modelBuilder.Entity<Note>().HasOne<Location>(note => note.Location)
                .WithMany(location => location.Notes)
                .HasForeignKey(note => note.LocationId);
            modelBuilder.Entity<Location>().HasMany<Note>(location => location.Notes)
                .WithOne(note => note.Location)
                .HasForeignKey(note => note.NoteId);

            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { UserId = 1, Username = "Jani", Age = 10, School = "OE", Country = "Hungary" },
                new User { UserId = 2, Username = "Jozsi", Age = 25, School = "MIT", Country = "USA" },
                new User { UserId = 3, Username = "Laci", Age = 30, School = "Oxford", Country = "UK" },
                new User { UserId = 4, Username = "Robs", Age = 18, School = "Harvard", Country = "USA" },
                new User { UserId = 5, Username = "Bibor", Age = 22, School = "Stanford", Country = "USA" }
            });
            //kreatív Jegyzetek kereatív nevekkel
            modelBuilder.Entity<Note>().HasData(new Note[]
            {
                new Note(1, 1, "Belief in Inner Peace",
                    "The belief in inner peace is the true wealth of life. External things may come and go, but one's inner composure and peace endure.",
                    1),
                new Note(2, 1, "Acceptance of Loss",
                    "Accepting the loss of things and living in the spirit of acceptance is a sign of human strength and wisdom. Just as Tommy lost his puppy but accepted it with peace, so does Stoic philosophy teach the importance of acceptance.",
                    2),
                new Note(3, 2, "Resilience and Wisdom",
                    "Resistance and hardships teach us wisdom and resilience. Tommy's struggle with his lost dog and the joy of finding it reflects the Stoic principle of the strength in resistance and learning.",
                    3),
                new Note(4, 2, "Control over Fate",
                    "Having control over fate and external circumstances is the source of human freedom. Just as Tommy didn't give up the search, Stoic philosophy teaches us to control our reactions and decisions.",
                    4),
                new Note(5, 3, "Happiness in Inner Harmony",
                    "Happiness is a state of inner harmony and balance. Just as Tommy and Fido found each other, so does a person seek inner harmony and tranquility in life.",
                    5),
                new Note(6, 3, "Appreciating the Moment",
                    "The vicissitudes and transience of life teach us to appreciate the moment. Stoic philosophy teaches that acceptance and living in the present moment are the true values of life.",
                    6),
                new Note(7, 3, "Inner State vs. External Circumstances",
                    "External circumstances do not determine one's internal state. Tommy and Fido's story is about how one can resist external challenges with internal composure and strength.",
                    7),
                new Note(8, 3, "Love and Acceptance",
                    "Love and acceptance are the true joy of life. Just as Tommy and Fido's love binds them, so does a person seek love and acceptance in life.",
                    8),
                new Note(9, 4, "Acceptance and Facing Life's Surprises",
                    "Acceptance and facing life's surprises without resistance are virtues of Stoicism. It teaches that accepting the situation can lead to inner peace.",
                    9),
                new Note(10, 4, "Human Perseverance and Inner Strength",
                    "Human perseverance and inner strength are capable of overcoming lost things. Tommy and Fido's story is about how inner strength and resources help a person to overcome everything.",
                    10),
                new Note(11, 1, "Opportunities in Life",
                    "Every moment in life is an opportunity to learn and grow. Just as Tommy and Fido found each other, so does a person seek opportunities for growth in life's every challenge.",
                    11),
                new Note(12, 1, "Inner Peace and Acceptance",
                    "Inner peace and acceptance are crucial to a happy life. Tommy and Fido's story is about how inner peace and acceptance can help bridge difficulties and find happiness.",
                    12),
                new Note(13, 1, "Acceptance: Key to Life's Surprises",
                    "Acceptance is the key to life's unexpected events. As Tommy lost his puppy but accepted the situation, Stoic philosophy teaches the power of acceptance in all aspects of life.",
                    13),
                new Note(14, 4, "Life's Transience and Appreciating the Moment",
                    "Life and experiences change from moment to moment. Stoic philosophy teaches us to value the present moment and learn from the past without burdening our souls with fear of the future.",
                    14),
                new Note(15, 5, "Balance between Destiny and Choices",
                    "Tommy and Fido's story is about the harmony and acceptance between destiny and human choices, which is important in life.",
                    15),
                new Note(16, 2, "Inner Strength and Perseverance",
                    "Inner strength and perseverance are the foundation of a successful life. Just as Tommy and Fido didn't give up, Stoic philosophy teaches that with inner resources, every difficulty can be overcome.",
                    16),
                new Note(17, 3, "Acceptance and Inner Peace in Turbulent Times",
                    "Tommy and Fido's story illustrates how acceptance and inner peace can be a source of help in life's difficult moments.",
                    17),
                new Note(18, 3, "The Complexity and Flux of Human Life",
                    "Stoic principles teach us to seek balance and inner peace amid life's variability and changes.",
                    18),
                new Note(19, 3, "Happiness in Inner Balance and Acceptance",
                    "Just as Tommy and Fido found each other, so does a person seek inner peace and acceptance in every aspect of life.",
                    19),
                new Note(20, 3, "Acceptance and Navigating Life's Variability",
                    "The Stoic principle instructs us to accept change and transience in life without losing our inner peace.",
                    20)
            });
            modelBuilder.Entity<Location>().HasData(new Location[]
            {
                new Location(1, "Hungary", "Kossuth Street", 20.5, "Historical street in downtown"),
                new Location(2, "USA", "Broadway", 18.9, "Famous entertainment avenue"),
                new Location(3, "France", "Champs-Élysées", 22.0, "Iconic avenue in Paris"),
                new Location(4, "Japan", "Shibuya Crossing", 24.5, "Busy intersection in Tokyo"),
                new Location(5, "Italy", "Via Condotti", 19.8, "Exclusive shopping street in Rome"),
                new Location(6, "Germany", "Unter den Linden", 16.2, "Historical boulevard in Berlin"),
                new Location(7, "Spain", "La Rambla", 23.5, "Vibrant street in Barcelona"),
                new Location(8, "UK", "Abbey Road", 15.5, "Famous location of the Beatles' album cover"),
                new Location(9, "Australia", "Sydney Harbour Bridge", 25.0, "Iconic bridge in Sydney"),
                new Location(10, "Brazil", "Avenida Paulista", 21.3, "Financial center in São Paulo"),
                new Location(11, "Canada", "Rideau Canal", 17.8, "Historical waterway in Ottawa"),
                new Location(12, "China", "Nanjing Road", 26.1, "Busiest shopping street in Shanghai"),
                new Location(13, "India", "Chandni Chowk", 27.6, "Old market area in Delhi"),
                new Location(14, "Mexico", "Paseo de la Reforma", 24.0, "Major avenue in Mexico City"),
                new Location(15, "Russia", "Nevsky Prospect", 14.7, "Vibrant boulevard in Saint Petersburg"),
                new Location(16, "South Africa", "Long Street", 18.5, "Popular nightlife area in Cape Town"),
                new Location(17, "Sweden", "Drottninggatan", 16.9, "Main shopping street in Stockholm"),
                new Location(18, "Switzerland", "Bahnhofstrasse", 21.8, "Exclusive shopping avenue in Zurich"),
                new Location(19, "Turkey", "Istiklal Avenue", 23.4, "Prominent street in Istanbul"),
                new Location(20, "Argentina", "Avenida 9 de Julio", 19.6, "Widest avenue in Buenos Aires"),
                new Location(21, "Austria", "Kärntner Straße", 20.2, "Major shopping street in Vienna"),
                new Location(22, "Belgium", "Grand Place", 18.3, "Historic square in Brussels"),
                new Location(23, "Chile", "Alameda", 22.8, "Main avenue in Santiago"),
                new Location(24, "Czech Republic", "Charles Bridge", 17.1, "Iconic bridge in Prague"),
                new Location(25, "Denmark", "Strøget", 15.9, "Pedestrian shopping street in Copenhagen"),
                new Location(26, "Egypt", "Corniche", 26.5, "Scenic promenade in Alexandria"),
                new Location(27, "Finland", "Esplanadi", 13.6, "Park boulevard in Helsinki"),
                new Location(28, "Greece", "Ermou Street", 24.9, "Major shopping street in Athens"),
                new Location(29, "Ireland", "Grafton Street", 18.7, "Popular pedestrian street in Dublin"),
                new Location(30, "Netherlands", "Dam Square", 20.1, "Historical center in Amsterdam")
            });
        }
    }
}
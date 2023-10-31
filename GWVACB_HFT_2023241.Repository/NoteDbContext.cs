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
                new Note(1, 1,
                    "A hűség és a belső béke az egyetlen valódi vagyon az életben. A külső dolgok jöhetnek és menhetnek, de az emberi belső tartás és békesség marad.",
                    1),
                new Note(2, 1,
                    "Az elveszett dolgok elvesztésének elfogadása és az elfogadás szellemében való élés az emberi erő és bölcsesség jele. Ahogy Tommy elveszítette kiskutyáját, de békével fogadta, úgy tanít a stoikus filozófia az elfogadás fontosságára.",
                    2),
                new Note(3, 2,
                    "Az ellenállás és a nehézségek megtanítanak bölcsességre és tartásra. Tommy küzdelme az elveszett kutyájával és a megtalálás utáni öröm a stoikus elvet tükrözi az ellenállás és a tanulás erejéről.",
                    3),
                new Note(4, 2,
                    "A sors és a külső körülmények felett való kontroll az emberi szabadság forrása. Ahogy Tommy nem adta fel a keresést, úgy tanít minket a stoikus filozófia, hogy nekünk is uralnunk kell reakcióinkat és döntéseinket.",
                    4),
                new Note(5, 3,
                    "A boldogság a belső harmónia és egyensúly állapota. Ahogy Tommy és Fickó megtalálták egymást, úgy keresi az ember a belső harmóniát és nyugalmat az életben.",
                    5),
                new Note(6, 3,
                    "Az élet változékonysága és múlandósága arra tanít, hogy értékeljük a pillanatot. A stoikus elv azt tanítja, hogy az elfogadás és a jelen pillanatban való élés az élet igazi értéke.",
                    6),
                new Note(7, 4,
                    "A külső körülmények nem határozzák meg az ember belső állapotát. Tommy és Fickó története arról szól, hogy az ember a belső tartásával és erővel képes ellenállni a külső kihívásoknak.",
                    7),
                new Note(8, 4,
                    "A szeretet és az elfogadás az élet igazi öröme. Ahogyan Tommy és Fickó szeretete köti össze őket, úgy keres az ember is szeretetet és elfogadást az életben.",
                    8),
                new Note(9, 4,
                    "Az elfogadás és az ellenállás nélküli szembenézés az élet váratlan dolgaival a stoikus erény egyik jele. Azt tanítja, hogy elfogadva a helyzetet, belső békére lelhetünk.",
                    9),
                new Note(10, 5,
                    "Az emberi kitartás és belső erő az, ami képes áthidalni az elvesztett dolgokat. Tommy és Fickó története arról szól, hogy a belső tartás és erőforrások segítségével az ember mindent legyőzhet.",
                    10),
                new Note(11, 5,
                    "Az élet minden pillanata egy lehetőség arra, hogy tanuljunk és fejlődjünk. Ahogy Tommy és Fickó megtalálták egymást, úgy keres az ember is lehetőséget a fejlődésre az élet minden kihívásában.",
                    11),
                new Note(12, 5,
                    "A belső béke és az elfogadás kulcsfontosságú a boldog élethez. Tommy és Fickó története arról szól, hogy a belső béke és elfogadás segíthet áthidalni a nehézségeket és boldogságot találni.",
                    12),
                new Note(13, 5,
                    "Az elfogadás az élet váratlan dolgainak kulcsa. Ahogy Tommy elveszítette kiskutyáját, de elfogadta a helyzetet, úgy tanítja a stoikus elv az elfogadás erejét az élet minden területén.",
                    13),
                new Note(14, 1,
                    "Az élet és az élmények pillanatról pillanatra változnak. A stoikus filozófia arra tanít, hogy értékeljük a jelen pillanatot és tanuljunk a múltból anélkül, hogy az jövőtől való félelem terhelné lelkünket.",
                    14),
                new Note(15, 1,
                    "A sorsunk és a választásaink közötti egyensúly az élet kulcsa. Tommy és Fickó története arról szól, hogy a sors és az emberi választások közötti harmónia és elfogadás fontos az életben.",
                    15),
                new Note(16, 2,
                    "A belső erő és kitartás a sikeres élet alapja. Ahogyan Tommy és Fickó nem adták fel, úgy tanít minket a stoikus filozófia, hogy a belső erőforrások segítségével minden nehézséget leküzdhetünk.",
                    16),
                new Note(17, 2,
                    "Az elfogadás és a belső béke olyan eszközök, amelyek segítenek az élet viharos helyzeteiben. Tommy és Fickó története arról szól, hogy az elfogadás és a belső béke az élet súlyos pillanataiban is segítségünkre lehet.",
                    17),
                new Note(18, 3,
                    "Az emberi élet összetett és változékony. A stoikus elvek arra tanítanak, hogy az élet változékonysága közepette keresni kell az egyensúlyt és a belső békét.",
                    18),
                new Note(19, 3,
                    "A boldogság a belső tartás és elfogadás állapota. Ahogyan Tommy és Fickó megtalálták egymást, úgy keresi az ember is belső béke és elfogadás állapotát az élet minden területén.",
                    19),
                new Note(20, 3,
                    "Az elfogadás és az ellenállás nélküli szembenézés az élet változékonyságának tanítása. A stoikus elv arra tanít, hogy elfogadjuk a változást és a múlandóságot, anélkül hogy belső békénket veszítenénk.",
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
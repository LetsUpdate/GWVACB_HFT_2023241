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
        public DbSet<Comment> Comments { get; set; }

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
            modelBuilder.Entity<User>()
                .HasMany<Comment>(Comment => Comment.Comments)
                .WithOne(User => User.User)
                .HasForeignKey(Comment => Comment.CommentId);
            modelBuilder.Entity<User>().HasMany<Note>(Note => Note.Notes)
                .WithOne(User => User.User)
                .HasForeignKey(Note => Note.NoteId);

            modelBuilder.Entity<Note>().HasOne<User>(User => User.User)
                .WithMany(Note => Note.Notes)
                .HasForeignKey(User => User.UserId);
            modelBuilder.Entity<Note>().HasMany<Comment>(Comment => Comment.Comments)
                .WithOne(Note => Note.Note)
                .HasForeignKey(Comment => Comment.CommentId);

            modelBuilder.Entity<Comment>().HasOne<User>(User => User.User)
                .WithMany(Comment => Comment.Comments)
                .HasForeignKey(User => User.UserId);
            modelBuilder.Entity<Comment>().HasOne<Note>(Note => Note.Note)
                .WithMany(Comment => Comment.Comments)
                .HasForeignKey(Note => Note.NoteId);

            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { UserId = 1, Username = "admin", Age = 10, School = "BME", Country = "Hungary"},
                new User { UserId = 2, Username = "red", Age = 20, School = "OE", Country = "Hungary"},
                new User { UserId = 3, Username = "Jozsi", Age  = 21, School = "SOTE", Country = "Hungary"}
            });
            //kreatív Jegyzetek kereatív nevekkel
            modelBuilder.Entity<Note>().HasData(new Note[]
            {
                new Note { UserId = 1, NoteId = 1, Content = "Az elveszett kiskutya kalandja: Egyszer egy kisfiú nevű Tommy elveszítette kiskutyáját, Fickót. Tommy szomorú volt, de nem adta fel. Végigkutatta a várost, és kérdéseket tett fel a szomszédoknak. Végül egy kedves idős hölgy segített neki megtalálni Fickót a közeli parkban. Tommy és Fickó boldogan tértek haza, és soha többé nem hagyták el egymás mellett." },
                new Note{ UserId =2, NoteId = 2, Content = "A varázslatos reggel: Egy nap egy kislány, Sophie, egy meglepetésre ébredt. Az egész városot vastag hó takarta be, és minden fa és ház csillogott a fagyott harmattól. Sophie és az apja sítúrára mentek, és a hegy tetejéről a táj gyönyörűségét csodálták. Sophie sosem felejti el ezt a varázslatos reggelt." },
                new Note {UserId=3, NoteId=3, Content="A barátság ereje: Két legjobb barát, Anna és Peter, közösen neveltek egy kis kertet. Az évek során megtanulták, hogyan gondozzák a növényeket, és közben sok időt töltöttek együtt. A kertjükben virágok és zöldségek virágoztak, és ez a közös munka és élmény megerősítette barátságukat. A két barát mindig emlékezni fog erre az időszakra, és arra, hogy a barátság minden nehézséget legyőz."}
                  
            });
            modelBuilder.Entity<Comment>().HasData(new Comment[]
            {
                new Comment { CommentId = 1, NoteId = 1, UserId = 3, Content = "Szép történetek, amik az élet apró örömeire és értékeire emlékeztetnek minket." },
                new Comment { CommentId = 2, NoteId = 1, UserId = 2, Content = "Ezek a történetek mindannyiunknak üzenetet hordoznak az optimizmusról és a kitartásról." },
                new Comment { CommentId = 3, NoteId = 2, UserId = 3, Content = "EAz ilyen történetek mindig jó emlékeztetői annak, hogy az életben mindig akadnak csodák és megható pillanatok." },
                new Comment { CommentId = 4, NoteId = 2, UserId = 1, Content = "A történetek egyszerűségükben és őszinteségükben gyönyörűek. Emlékeztetnek minket a kis dolgok fontosságára." },
                new Comment { CommentId = 5, NoteId = 3, UserId = 1, Content = "Ezek a történetek arra ösztönöznek, hogy értékeljük a szeretetet, a természet szépségét és az emberi kapcsolatokat." },
                new Comment { CommentId = 6, NoteId = 3, UserId = 2, Content = "A barátság és a kitartás mindig győzedelmeskedik, ezek a történetek jó példák erre." }
            }); 
        }

    }
}

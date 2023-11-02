using GWVACB_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;

namespace GWVACB_HFT_2023241.Repository
{
    public class QuoteDbContext : DbContext
    {
        public QuoteDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Author> authors { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (builder.IsConfigured == false) builder.UseLazyLoadingProxies().UseInMemoryDatabase("QuoteDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

   
            

            modelBuilder.Entity<Author>().HasData(
                new Author(1, "Marcus Aurelius", 65, "Rome"),
                new Author(2, "Seneca", 60, "Rome"),
                new Author(3, "Epictetus", 89, "Rome"),
                new Author(4, "Cato the Younger", 48, "Rome"),
                new Author(5, "Musonius Rufus", 60, "Rome")
                );
            //kreatív Jegyzetek kereatív nevekkel
            modelBuilder.Entity<Quote>().HasData(
                new Quote(1, 1, "On Life", "The soul becomes dyed with the color of its thoughts."),
                new Quote(2, 2, "On Time", "We suffer more often in imagination than in reality."),
                new Quote(3, 2, "On Happiness", "He is a wise man who does not grieve for the things which he has not, but rejoices for those which he has."),
                new Quote(4, 4, "On Strength", "What really frightens and dismays us is not external events themselves, but the way in which we think about them."),
                new Quote(5, 2, "On Virtue", "No man is free who is not master of himself."),
                new Quote(6, 1, "On the Mind", "You have power over your mind - not outside events. Realize this, and you will find strength."),
                new Quote(7, 2, "On Wisdom", "True happiness is... to enjoy the present, without anxious dependence upon the future."),
                new Quote(8, 2, "On Adversity", "Difficulties strengthen the mind, as labor does the body."),
                new Quote(9, 4, "On Fear", "He who fears death will never do anything worth of a man who is alive."),
                new Quote(10, 5, "On Virtue", "A gem cannot be polished without friction, nor a man perfected without trials."),
                new Quote(11, 1, "On Perception", "The universe is change; our life is what our thoughts make it."),
                new Quote(12, 3, "On Anger", "Anger, if not restrained, is frequently more hurtful to us than the injury that provokes it."),
                new Quote(13, 3, "On Contentment", "We should always be asking ourselves: Is this something that is, or is not, in my control?"),
                new Quote(14, 5, "On Virtue", "Virtue is nothing else than right reason."),
                new Quote(15, 5, "On Philosophy", "Philosophy does not promise to secure anything external for a man, otherwise it would be admitting something that lies beyond its proper subject-matter."));
            modelBuilder.Entity<Comment>().HasData(
                new Comment(1, "This is an insightful quote.", 1),
                new Comment(2, "I truly admire the wisdom in this.", 3),
                new Comment(3, "A timeless piece of philosophy.", 2),
                new Comment(4, "Words to live by.", 4),
                new Comment(5, "Such wisdom is inspiring.", 5),
                new Comment(6, "Absolutely profound!", 6),
                new Comment(7, "These words resonate deeply.", 7),
                new Comment(8, "Such timeless wisdom.", 8),
                new Comment(9, "This is a philosophy to live by.", 9),
                new Comment(10, "Inspiring and thought-provoking.", 10),
                new Comment(11, "This speaks to the core of human existence.", 11),
                new Comment(12, "A philosophy that transcends time.", 12),
                new Comment(13, "These words hold the essence of wisdom.", 13),
                new Comment(14, "Simple yet profound.", 14),
                new Comment(15, "Such insight is rare and precious.", 15),
                new Comment(16, "Words that guide through life's tumultuous journey.", 1),
                new Comment(17, "Stoicism at its finest.", 2),
                new Comment(18, "Timeless wisdom for modern existence.", 3),
                new Comment(19, "Philosophy that resonates across centuries.", 4),
                new Comment(20, "Each word a gem in the sea of knowledge.", 5),
                new Comment(21, "These quotes inspire self-reflection.", 6),
                new Comment(22, "Wise words for navigating the chaos.", 7),
                new Comment(23, "Understanding life through Stoic lenses.", 8),
                new Comment(24, "Philosophy that speaks directly to the soul.", 9),
                new Comment(25, "These words possess an enduring truth.", 10),
                new Comment(26, "Teaching resilience and mental fortitude.", 11),
                new Comment(27, "Wisdom that bridges across time and culture.", 12),
                new Comment(28, "A guiding light in the realm of philosophy.", 13),
                new Comment(29, "Reflections that enrich the mind and spirit.", 14),
                new Comment(30, "Understanding life's intricacies through philosophy.", 15)
                
                );
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Test
{
    public class Helper
    {
        private static bool ValidateObjectByAttributes(object obj)
        {
            var objectType = obj.GetType();
            var properties = objectType.GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes();

                foreach (var attribute in attributes)
                    if (attribute is ValidationAttribute validationAttribute)
                    {
                        var value = property.GetValue(obj);

                        if (!validationAttribute.IsValid(value))
                            return
                                false; // Ha bármely attribútum ellenőrzése nem felel meg, akkor hamis értékkel tér vissza.
                    }
            }

            return true; // Ha az összes attribútum ellenőrzése sikeres volt, akkor igaz értékkel tér vissza.
        }

        private static MockDataSet _dataSet;
        public static MockDataSet GetMocDataset()
        {
            if (_dataSet == null)
            {

                var Authors = new List<Author>
                {
                    new Author(1, "Marcus Aurelius", 65, "Rome"),
                    new Author(2, "Seneca", 60, "Rome"),
                    new Author(3, "Epictetus", 89, "Rome"),
                    new Author(4, "Cato the Younger", 48, "Rome"),
                    new Author(5, "Musonius Rufus", 60, "Rome")
                };
                var Quotes = new List<Quote>
                {
                    new Quote(1, 1, "On Life", "The soul becomes dyed with the color of its thoughts."),
                    new Quote(2, 2, "On Time", "We suffer more often in imagination than in reality."),
                    new Quote(3, 2, "On Happiness",
                        "He is a wise man who does not grieve for the things which he has not, but rejoices for those which he has."),
                    new Quote(4, 4, "On Strength",
                        "What really frightens and dismays us is not external events themselves, but the way in which we think about them."),
                    new Quote(5, 2, "On Virtue", "No man is free who is not master of himself."),
                    new Quote(6, 1, "On the Mind",
                        "You have power over your mind - not outside events. Realize this, and you will find strength."),
                    new Quote(7, 3, "On Wisdom",
                        "True happiness is... to enjoy the present, without anxious dependence upon the future."),
                    new Quote(8, 3, "On Adversity", "Difficulties strengthen the mind, as labor does the body."),
                };
                var Comments = new List<Comment>
                {
                    new Comment(1, "This is an insightful quote.", 1),
                    new Comment(2, "I truly admire the wisdom in this.", 3),
                    new Comment(3, "A timeless piece of philosophy.", 2),
                    new Comment(4, "Words to live by.", 2),
                    new Comment(5, "Such wisdom is inspiring.", 6),
                    new Comment(6, "Absolutely profound!", 6),
                    new Comment(7, "These words resonate deeply.", 7),
                    new Comment(8, "Such timeless wisdom.", 7),
                    new Comment(9, "This is a philosophy to live by.", 8),
                };
                Authors.ForEach(a => a.Quotes = Quotes.Where(q => q.AuthorId == a.Id).ToList());
                Quotes.ForEach(q=>q.Comments=Comments.Where(c=>c.QuoteId==q.Id).ToList());
                Quotes.ForEach(q=>q.Author=Authors.FirstOrDefault(a=>a.Id==q.AuthorId)); 
                Comments.ForEach(c=>c.Quote=Quotes.FirstOrDefault(q=>q.Id==c.QuoteId));
                
                _dataSet = new MockDataSet(Authors, Comments, Quotes);
            }

            return _dataSet.Clone();
        }


        public class MockDataSet
        {
            public List<Author> authors { get; }
            public List<Comment> comments { get; }
            public List<Quote> quotes { get; }

            public MockDataSet(List<Author> authors, List<Comment> comments, List<Quote> quotes)
            {
                this.authors = authors;
                this.comments = comments;
                this.quotes = quotes;
            }

            public MockDataSet Clone()
            {
                return new MockDataSet(authors.ToList(), comments.ToList(), quotes.ToList());
            }
        }
        
    }
    
}
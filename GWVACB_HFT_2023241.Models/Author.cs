using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GWVACB_HFT_2023241.Models
{
    public class Author : IBaseModel
    {
        public Author(int id, string name, int age, string country)
        {
            Id = id;
            Name = name;
            Age = age;
            Country = country;
        }

        public Author()
        {
        }

        [Required]
        [StringLength(16)]
        public string Name { get; set; }

        [Range(5, 128)] public int Age { get; set; }
        
        [StringLength(16)] public string Country { get; set; }

        [JsonIgnore] public virtual ICollection<Quote> Quotes { get; set; }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Age)}: {Age}, {nameof(Country)}: {Country}";
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GWVACB_HFT_2023241.Models
{
    public class User : BaseModel
    {
        public User(int id, string username, int age, string school, string country)
        {
            Id = id;
            Username = username;
            Age = age;
            School = school;
            Country = country;
        }

        public User()
        {
        }

        [Required]
        [StringLength(16, MinimumLength = 3)]
        public string Username { get; set; }

        [Range(5, 128)] public int Age { get; set; }

        [StringLength(64, MinimumLength = 3)] public string School { get; set; }

        [StringLength(16, MinimumLength = 2)] public string Country { get; set; }

        [JsonIgnore] public virtual ICollection<Note> Notes { get; set; }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}, {nameof(Username)}: {Username}, {nameof(Age)}: {Age}, {nameof(School)}: {School}, {nameof(Country)}: {Country}";
        }
    }
}
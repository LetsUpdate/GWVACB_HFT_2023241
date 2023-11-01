using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GWVACB_HFT_2023241.Models
{
    public  class User
    {
        public User(int userId, string username, int age, string school, string country)
        {
            UserId = userId;
            Username = username;
            Age = age;
            School = school;
            Country = country;
        }

        public User()
        {
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        
        [Required]
        [StringLength(16, MinimumLength = 3)]
        public string Username { get; set; }
        
        [Range(5,128)]
        public int Age { get; set; }
        [StringLength(64, MinimumLength = 3)]
        public string School { get; set; }
        [StringLength(16, MinimumLength = 2)]
        public string Country { get; set; }
        [JsonIgnore]
        public virtual ICollection<Note> Notes { get; set; }
        
    }
}

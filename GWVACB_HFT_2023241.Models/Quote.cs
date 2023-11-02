using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GWVACB_HFT_2023241.Models
{
    public class Quote : IBaseModel
    {
        public Quote()
        {
        }

        public Quote(int id, int authorId, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
            AuthorId = authorId;
        }

        [Required]
        [StringLength(500, MinimumLength = 9)]
        public string Content { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Title { get; set; }

        [Required] 
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        
        [JsonIgnore]
        public virtual Author Author { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public override string ToString()
        {
            return "QuoteId: " + Id + ", Content: " + Title + ", AuthorId: " + AuthorId;
        }
    }
}
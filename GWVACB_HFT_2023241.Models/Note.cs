using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWVACB_HFT_2023241.Models
{
    public class Note : BaseModel
    {
        public Note()
        {
        }

        public Note(int id, int userId, string title, string content, int locationId)
        {
            Id = id;
            Title = title;
            Content = content;
            UserId = userId;
            LocationId = locationId;
        }

        [Required]
        [StringLength(500, MinimumLength = 9)]
        public string Content { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Title { get; set; }

        [Required] [ForeignKey(nameof(User))] public int UserId { get; set; }

        public int LocationId { get; set; }
        public virtual User User { get; set; }


        public virtual Location Location { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public override string ToString()
        {
            return "NoteId: " + Id + ", Content: " + Title + ", UserId: " + UserId;
        }
    }
}
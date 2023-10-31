using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWVACB_HFT_2023241.Models
{
    public sealed class Note
    {
        
        public Note()
        {
        }

        public Note(int noteId, int userId,string content,int locationId)
        {
            NoteId = noteId;
            Content = content;
            UserId = userId;
            LocationId = locationId;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 9)]
        public string Content { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public User User { get; set; }

        public Location Location { get; set; }

        public override string ToString()
        {
            return "NoteId: " + NoteId + ", Content: " + Content + ", UserId: " + UserId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Models
{
    public class Comment : IBaseModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(200)]
        public string Content { get; set; }
        
        [ForeignKey(nameof(Quote))]
        [Required]
        public int QuoteId { get; set; }

  
        [JsonIgnore]
        public virtual Quote Quote { get; set; }
        public Comment(int id, string content, int quoteId)
        {
            Id = id;
            Content = content;
            QuoteId = quoteId;
        }

        public Comment(string content, int quoteId)
        {
            Content = content;
            QuoteId = quoteId;
        }

        public Comment()
        {
        }
    

        public override string ToString()
        {
            return "CommentId: " + Id + ", Content: " + Content;
        }
    }
}
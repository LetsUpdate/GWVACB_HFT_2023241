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
    public  class Location
    {
        public Location(int locationId,string country, string street, double avgTemp, string description)
        {
            LocationId = locationId;
            Country = country;
            Street = street;
            AvgTemp = avgTemp;
            Description = description;
        }
        public Location(){}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }
        
        [StringLength(20)]
        public string Country { get; set; }

        [StringLength(30)]
        public string Street { get; set; }
        
        public double AvgTemp { get; set; }
        [StringLength(128)]
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Note> Notes{get;set;}


    }
}

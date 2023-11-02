using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GWVACB_HFT_2023241.Models
{
    public class Location : IBaseModel
    {
        public Location(int id, string country, string street, double avgTemp, string description)
        {
            Id = id;
            Country = country;
            Street = street;
            AvgTemp = avgTemp;
            Description = description;
        }

        public Location()
        {
        }

        [StringLength(20)] public string Country { get; set; }

        [StringLength(30)] public string Street { get; set; }

        public double AvgTemp { get; set; }

        [StringLength(128)] public string Description { get; set; }

        [JsonIgnore]
        public virtual
            ICollection<Note> Notes { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public override string ToString()
        {
            return "LocationId: " + Id + ", Country: " + Country + ", Street: " + Street;
        }
    }
}
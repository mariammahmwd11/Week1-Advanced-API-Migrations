using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{
  public  class Heater
    {
        [Key]
        public int HeaterId { get; set; }
        [ForeignKey("house")]
        public int HouseId { get; set; }
        [Required]
        public string HeaterType { get; set; }
        [Required]
        public int PowerValue { get; set; }
        [JsonIgnore]
        public House house { get; set; }
    }
}

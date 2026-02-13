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
   public class SensorReading
    {
        [Key]
        public int SensorReadingId { get; set; }
        [ForeignKey("heater")]
        public int HeaterId { get; set; }
        public DateTime ReadingDate { get; set; }
        public int WorkingHours { get; set; }
        public double HeaterValue{ get; set; }
        [JsonIgnore]
        public Heater heater { get; set; }
    }
}

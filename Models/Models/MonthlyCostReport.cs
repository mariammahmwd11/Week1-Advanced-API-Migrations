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
   public class MonthlyCostReport
    {
        [Key]
        public int ReportId { get; set; }
        [ForeignKey("house")]
        public int HouseId { get; set; }
        public string ReportMonth { get; set; }
        public int TotalWorkingHours { get; set; }
        public double MedianHeaterValue { get; set; }
        public decimal MonthlyAverageCost { get; set; }
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]

        public House house { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.DTO
{
   public class SensorReaderDTO
    {
        public int HeaterId { get; set; }
        public DateTime ReadingDate { get; set; }
        public int WorkingHours { get; set; }
        public double HeaterValue { get; set; }
    }
}

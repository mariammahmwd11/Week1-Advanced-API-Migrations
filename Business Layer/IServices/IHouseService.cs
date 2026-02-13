using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.IServices
{
   public interface IHouseService
    {
        decimal calculateMonthlyCost(int houseId);
        List<SensorReading> Readings(int houseId);
        int calcultetotalWorkingHours(List<SensorReading> readings);
        double calcultemedianHeatersValue(List<SensorReading> readings);
      
    }
}

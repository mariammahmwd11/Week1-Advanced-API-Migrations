using Business_Layer.IServices;
using Data_Access.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class HouseService : IHouseService
    {
        private readonly ApplicationDbContext context;

        public HouseService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public decimal calculateMonthlyCost(int houseId)
        {
            var readings = Readings(houseId);
            if (readings.IsNullOrEmpty())
            {
                return 0m;
            }
            var Total_working_hours = calcultetotalWorkingHours(readings);
          
            double median_heater_value = calcultemedianHeatersValue(readings);

            var monthlyAverageCost = (decimal)median_heater_value *(decimal) (Total_working_hours / (24m * 30m));
            return monthlyAverageCost;

        }

        public List<SensorReading> Readings(int houseId)
        {

            var readings = context?.sensorReadings.Include(h => h.heater).
                  Where(r => r.heater.HouseId == houseId && r.ReadingDate >= DateTime.Now.AddDays(-30))
                  .ToList();
            return readings;
        }
        public int calcultetotalWorkingHours(List<SensorReading> readings)
        {
            var Total_working_hours = readings.Sum(r => r.WorkingHours);
            return Total_working_hours;
        }
        public double calcultemedianHeatersValue(List<SensorReading> readings)
        {
            var sortedHeaterValues = readings.Select(r => r.HeaterValue).OrderBy(b => b).ToList();
            //لو العدد زوجي هاخد مجموع الاتنين الل فالنص واقسم ع 2 
            //لو فردي العنصر الل ف النص  

            var count = sortedHeaterValues.Count();
            double median_heater_value;
            if (count % 2 == 0)
            {
                median_heater_value = (sortedHeaterValues[count / 2] + sortedHeaterValues[(count / 2) - 1]) / 2.0;
            }
            else
            {
                median_heater_value = sortedHeaterValues[count / 2];

            }
            return median_heater_value;
        }

    }
}

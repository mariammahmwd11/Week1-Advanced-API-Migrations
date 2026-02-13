using Data_Access.Data;
using Models.Models;
using Business_Layer.Services;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Services
{
    
  public  class HouseServiceTest
    {

        [Fact]
        public void Reading_readsinLast30days_listofsensorReadings()
        {
            var heater = new Heater { HeaterId = 1, HouseId = 1 };

            var data = new List<SensorReading>
{
                new SensorReading
                {
                    HeaterId = 1,
                    HeaterValue = 1000,
                    heater = heater,
                    ReadingDate = DateTime.Now.AddDays(-5)
                },
                new SensorReading
                {
                    HeaterId = 1,
                    HeaterValue = 1500,
                    heater = heater,
                    ReadingDate = DateTime.Now.AddDays(-1)
                }
            };
            var mock = new Mock<ApplicationDbContext>();
            mock.Setup(r => r.sensorReadings).ReturnsDbSet(data);
            var service = new HouseService(mock.Object);
            var readings = service.Readings(1);
            Assert.Equal(2, readings.Count);
        }
        [Fact]
        public void calcultetotalWorkingHours_returnTotalWorkHours()
        {
            var readings = new List<SensorReading>
            {
                new SensorReading { WorkingHours = 5 },
                new SensorReading { WorkingHours = 3 },
                new SensorReading { WorkingHours = 2 }
            };
           
            var service = new HouseService(null);
            var result = service.calcultetotalWorkingHours(readings);
            Assert.Equal(10, result);

        }

        [Fact]
        public void calcultemedianHeatersValue_OddCount_ReturnMedianHeate()
        {
            var readingsOdd = new List<SensorReading>
            {
                new SensorReading { HeaterValue = 10 },
                new SensorReading { HeaterValue = 20 },
                new SensorReading { HeaterValue = 30 },
            };
            var service = new HouseService(null);
            var result = service.calcultemedianHeatersValue(readingsOdd);
            Assert.Equal(result, 20);


        }

        [Fact]
        public void calcultemedianHeatersValue_EvenCount_ReturnMedianHeate()
        {
            var readingsOdd = new List<SensorReading>
            {
                new SensorReading { HeaterValue = 10 },
                new SensorReading { HeaterValue = 20 },
                new SensorReading { HeaterValue = 30 },
                new SensorReading { HeaterValue = 40 }
            };
            var service = new HouseService(null);
            var result = service.calcultemedianHeatersValue(readingsOdd);
            Assert.Equal(result, 25);


        }
        [Fact]
        public void calculateMonthlyCost_readingisNull_Return0()
        {
      
            var service = new HouseService(null);
            //return null becouse of there is no id=5
  
            var result = service.calculateMonthlyCost(5);
            Assert.Equal(result, 0m);
            


        }
        [Fact]
        public void calculateMonthlyCost_readingisNotNull_ReturnTotalCost()
        {
            var heater = new Heater { HeaterId = 1, HouseId = 5 };

            var data = new List<SensorReading>
                    {
                        new SensorReading { HeaterId = 1, HeaterValue = 100, WorkingHours = 24, heater = heater, ReadingDate = DateTime.Now.AddDays(-2) },
                        new SensorReading { HeaterId = 1, HeaterValue = 200, WorkingHours = 48, heater = heater, ReadingDate = DateTime.Now.AddDays(-1) },
                        new SensorReading { HeaterId = 1, HeaterValue = 300, WorkingHours = 72, heater = heater, ReadingDate = DateTime.Now }
                    };

            var mock = new Mock<ApplicationDbContext>();
            mock.Setup(r => r.sensorReadings).ReturnsDbSet(data);

            var service = new HouseService(mock.Object);
            var result = service.calculateMonthlyCost(5);
            //return null becouse of there is no id=5


            Assert.Equal(result, 40m);



        }

    }
}

using System;
using System.Collections.Generic;
using TruckTracking.Models;
using TruckTracking.Services;

namespace TruckTracking
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Example data setup
            var driverOne = new Driver("John Smith", new DateTime(1995, 05, 21), new GpsLocation(55.675940, 12.565530));

            
            var positions = new List<GpsLocation>()
            {
                new GpsLocation { timestamp = DateTime.Now, latitude = 55.675940, longitude = 12.565530 },
                new GpsLocation { timestamp = DateTime.Now.AddMinutes(5), latitude = 55.685940, longitude = 8.9721 },
                // Add more positions as needed
            };

            var truckPlan = new TruckPlan(
                driverOne.homeBase,
                new DateTime(1924, 10, 24),
                driverOne,
                Guid.NewGuid()
            );

            var plans = new List<TruckPlan> { truckPlan };

            // Calculate distance for drivers over 50 in Germany
            int age = 50;
            string country = "Germany";
            int month = 2;
            int year = 2024;
            var totalDistance = await TruckPlanReport.DistanceByDrivers(plans, age, country, month, year);
            Console.WriteLine($"Total kilometers driven by drivers over {age} in {country} during {month}-{year}: {totalDistance} km");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using TruckTracking.Models;

namespace TruckTracking.Services
{
    public class TruckPlanReport
    {
        public static async Task<double> DistanceByDrivers(List<TruckPlan> plans, int age, string country, int month, int year)
        {
            //In km
            double totalDistance = 0;

            foreach(TruckPlan truckPlan in plans){
                if(truckPlan.driver.IsOlderThan(age) && truckPlan.planDate.Month == month && truckPlan.planDate.Year == year){
                    GpsLocation lastLocation = new GpsLocation();
                    foreach (GpsLocation position in truckPlan.gpsPings)
                    {
                        if(position == truckPlan.startLocation)
                        {
                            lastLocation = position;
                            continue;
                        }
                        var countryFromLocal = await LocationService.GetLocationCountryAsync(position);
                        
                        if (countryFromLocal == country)
                        {
                            totalDistance += await LocationService.GetDrivingDistanceAsync(lastLocation, position);
                        }
                        lastLocation = position;
                    }
                }
                   
                
            }
            return totalDistance;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.InteropServices;


namespace TruckTracking.Models
{
    public class TruckPlan
    {
        public GpsLocation startLocation { get; set; }
        public GpsLocation endLocation { get; set;}
        public List<GpsLocation> gpsPings{ get; set; } = new List<GpsLocation>();
        public Driver driver{get; set;}
        public DateTime planDate { get; set; }
        public Guid truckId { get; set; }

        // Constructor to initialize all properties
        public TruckPlan(GpsLocation startLocation, 
                        DateTime planDate, 
                        Driver driver,
                        Guid truckId)
        {
            this.startLocation = startLocation;
            this.planDate = planDate;
            this.truckId = truckId;
            this.driver = driver;
        }

        public void AddGpsPing(GpsLocation ping){
            this.gpsPings.Add(ping);
        }

        public void AddGpsPings(List<GpsLocation> pings){
            this.gpsPings.AddRange(pings);
        }

    
    }
}
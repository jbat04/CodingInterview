using System;

namespace TruckTracking.Models
{
    public class GpsLocation
    {
        public DateTime timestamp { get; set; } 
        public double latitude { get; set; }
        public double longitude { get; set; }

        public GpsLocation(){
            //nothing
        }

        public GpsLocation(DateTime timestamp, double latitude, double longitude)
        {
            this.timestamp = timestamp;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public GpsLocation(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}

using System;

namespace TruckTracking.Models
{
    public class Driver
    {
        public string name { get; set; }
        public DateTime birthday { get; set; }
        //where the driver usually start from
        public GpsLocation homeBase { get; set; }

        public Driver(string name, DateTime birthday, GpsLocation homeBase)
        {
            this.name = name;
            this.birthday = birthday;
            this.homeBase = homeBase;
        }

        public bool IsOlderThan(int age)
        {
            return (DateTime.Now.Year - birthday.Year) > age;
        }
    }
}

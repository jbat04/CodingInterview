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
    public class LocationService
    {
        static string GOOGLE_MAPS_API_KEY = Environment.GetEnvironmentVariable("GOOGLE_MAPS_API_KEY");
        public static async Task<string> GetLocationCountryAsync(GpsLocation location)
        {
            string lat = location.latitude.ToString();
            string lng = location.longitude.ToString();
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={lat},{lng}&key={GOOGLE_MAPS_API_KEY}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(jsonResponse);

                    // Extracting the country from the address components
                    var results = json["results"];
                    if (results != null)
                    {
                        foreach (var result in results)
                        {
                            var addressComponents = result["address_components"];
                            if (addressComponents != null)
                            {
                                foreach (var component in addressComponents)
                                {
                                    var types = component["types"];
                                    if (types != null && types.ToString().Contains("country"))
                                    {
                                        return component["long_name"].ToString();  // Extracts the long name of the country
                                    }
                                }
                            }
                        }
                    }
                    return "Country not found";
                }
                else
                {
                    throw new Exception($"Error calling API: {response.StatusCode}");
                }
            }
        }

        public static async Task<double> GetDrivingDistanceAsync(GpsLocation startLocal, GpsLocation endLocal)
        {   
            using (HttpClient client = new HttpClient())
            {
                var url = 
                $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={startLocal.latitude},{startLocal.longitude}&destinations={endLocal.latitude},{endLocal.longitude}&mode=driving&key={GOOGLE_MAPS_API_KEY}";
                
                var response = await client.GetStringAsync(url);
        
                var json = JObject.Parse(response);

                //returns distance in km
                var distanceText = json["rows"]?[0]?["elements"]?[0]?["distance"]?["text"]?.ToString(); 

                return Double.Parse(distanceText);
            }
        }
    }
}
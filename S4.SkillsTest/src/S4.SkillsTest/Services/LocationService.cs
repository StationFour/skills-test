using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StationFour.SkillsTest.MockDomain.Interfaces;
namespace S4.SkillsTest.Services
{
    public class LocationService : ILocationService
    {
        // earth radius in miles
        private const double EARTH_RADIUS = 3959;
        double ILocationService.CalculateDistance(double latA, double longA, double latB, double longB)
        {
            // convert to radians
            double rlatA = latA * (Math.PI / 180);
            double rlongA = longA * (Math.PI / 180);
            double rlatB = latB * (Math.PI / 180);
            double rlongB = longB * (Math.PI / 180);

            // find the difference
            double diffLat = rlatB - rlatA;
            double diffLong = rlongB - rlongA;


            double a = Math.Sin(diffLat / 2) * Math.Sin(diffLat / 2) +
                         Math.Cos(rlatA) * Math.Cos(rlatB) *
                         Math.Sin(diffLong / 2) * Math.Sin(diffLong / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = EARTH_RADIUS * c;

            return distance;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StationFour.SkillsTest.MockDomain.Interfaces;
using S4.SkillsTest.Services;
namespace S4.SkillsTest.ViewModels
{
    public class CustomerDataViewModel
    {
        public static IEnumerable<CityNetWorth> cityNetWorth = CityNetWorth.GetNetWorthPerCity();
        public static IEnumerable<StateDistanceFromCenter> averageDistanceFromCenterState = StateDistanceFromCenter.GetAvgDistanceFromCenter();
        public static int GetNumberOfCustomers()
        {
            return new StationFour.SkillsTest.MockDomain.SkillsContext().Customers.Count();
        }
        public static int GetNumberOfStatesWithCustomers()
        {
            return new StationFour.SkillsTest.MockDomain.SkillsContext().Customers.GroupBy(x => x.StateId).Count();
        }

        public class CityNetWorth
        {
            public string City { get; private set; }
            public string AverageNetWorth { get; private set; }

            public static IEnumerable<CityNetWorth> GetNetWorthPerCity()
            {
                var context = new StationFour.SkillsTest.MockDomain.SkillsContext();
                return from customer in context.Customers
                       group customer by customer.City
                                            into cityGrouping
                       select new CityNetWorth
                       {
                           City = cityGrouping.Select(x => x.City).First(),
                           AverageNetWorth = "$" + String.Format("{0:n2}", cityGrouping.Average(x => x.NetWorth).Value)
                       };
            }
        }
        public class StateDistanceFromCenter
        {
            public string State { get; private set; }
            public string AverageDistanceFromCenter { get; private set; }

            public static IEnumerable<StateDistanceFromCenter> GetAvgDistanceFromCenter()
            {
                var context = new StationFour.SkillsTest.MockDomain.SkillsContext();
                ILocationService location = new LocationService();
                return from cust in context.Customers
                      group cust by cust.State
                      into stateGroup
                      select new StateDistanceFromCenter
                      {
                          State = stateGroup.Key.Name,
                          AverageDistanceFromCenter = Math.Round(location.CalculateDistance(stateGroup.Key.Latitude,
                                                      stateGroup.Key.Longitude, stateGroup.Average(x => x.Latitude),
                                                      stateGroup.Average(x => x.Longitude)), 3).ToString()
                      };
            }
        }
    }
}

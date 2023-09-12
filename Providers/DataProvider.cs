using Airport.Enums;
using Airport.Models;

namespace Airport.Providers
{
    static class DataProvider
    {
        public static List<Route> GetFlights()
        {
            var flights = new List<Route>()
            {
                new Route("WF024", "Oslo", "Amsterdam", new DateTime(2023, 9, 9, 8, 5, 0), new DateTime(2023, 9, 9, 10, 47, 0), "Wideroe", "G3", FlightType.Arrival),
                new Route("SK4111", "Oslo", "Berlin", new DateTime(2023, 9, 9, 6, 7, 0), new DateTime(2023, 9, 9, 8, 30, 0), "SAS", "E2", FlightType.Arrival),
                new Route("DY1432", "Oslo", "Alicante", new DateTime(2023, 9, 9, 10, 23, 0), new DateTime(2023, 9, 9, 12, 55, 0), "Norwegian", "B5", FlightType.Arrival),
                new Route("DY1308", "Oslo", "London", new DateTime(2023, 9, 9, 9, 43, 0), new DateTime(2023, 9, 9, 11, 47, 0), "Norwegian", "D2", FlightType.Arrival),
                new Route("FR7101", "Oslo", "Katowice", new DateTime(2023, 9, 9, 16, 22, 0), new DateTime(2023, 9, 9, 19, 32, 0), "Ryanair", "G2", FlightType.Arrival),
                new Route("WF024", "Amsterdam", "Oslo", new DateTime(2023, 9, 9, 8, 5, 0), new DateTime(2023, 9, 9, 10, 47, 0), "Wideroe", "G3", FlightType.Departure),
                new Route("SK4111", "Berlin", "Oslo", new DateTime(2023, 9, 9, 6, 7, 0), new DateTime(2023, 9, 9, 8, 30, 0), "SAS", "E2", FlightType.Departure),
                new Route("DY1432", "Alicante", "Oslo", new DateTime(2023, 9, 9, 10, 23, 0), new DateTime(2023, 9, 9, 12, 55, 0), "Norwegian", "B5", FlightType.Departure),
                new Route("DY1308", "Berlin", "Oslo", new DateTime(2023, 9, 9, 9, 43, 0), new DateTime(2023, 9, 9, 11, 47, 0), "Norwegian", "D2", FlightType.Departure),
                new Route("FR7101", "Katowice", "Oslo", new DateTime(2023, 9, 9, 16, 22, 0), new DateTime(2023, 9, 9, 19, 32, 0), "Ryanair", "G2", FlightType.Departure)
            };

            flights[3].ChangeStatus(Status.PreparingForLanding);
            flights[1].ChangeStatus(Status.BaggageOnBelt);
            flights[4].ChangeStatus(Status.Delayed);
            flights[0].ChangeStatus(Status.Landed);
            flights[6].ChangeStatus(Status.GateOpened);
            flights[8].ChangeStatus(Status.Delayed);
            flights[5].ChangeStatus(Status.Boarding);
            flights[7].ChangeStatus(Status.Canceled);

            return flights;
        }
    }
}

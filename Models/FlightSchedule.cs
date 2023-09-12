using Airport.Enums;

namespace Airport.Models
{
    static class FlightSchedule
    {
        private static List<Route> _flights;

        static FlightSchedule() => 
            _flights = new();

        public static List<Route> Arrivals { get => _flights.Where(x => x.Type == FlightType.Arrival).ToList(); }
        public static List<Route> Departures { get => _flights.Where(x => x.Type == FlightType.Departure).ToList(); }

        public static void AddFlight(Route flight) =>
            _flights.Add(flight);

        public static void AddFlights(List<Route> flights) =>
            _flights.AddRange(flights);

        public static void RemoveFlight(Route flight) =>
            _flights.Remove(flight);

        public static void UpdateFlight(Route flight)
        {
            var old = _flights.First(x => x.RouteNumber == flight.RouteNumber);
            _flights.Remove(old);
            _flights.Add(flight);
        }

        public static List<Route> FindFlight(string destination) =>
            _flights.Where(x => x.DestinationPort.ToUpper() == destination.ToUpper() && x.Type == FlightType.Departure).ToList();
    }
}

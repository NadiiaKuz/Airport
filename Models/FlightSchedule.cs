using Airport.Enums;

namespace Airport.Models
{
    class FlightSchedule
    {
        private List<Route> _flights;

        public List<Route> Arrivals { get => _flights.Where(x => x.Type == FlightType.Arrival).ToList(); }
        public List<Route> Departures { get => _flights.Where(x => x.Type == FlightType.Departure).ToList(); }
        public DateTime Date { get; private set; }

        public FlightSchedule(List<Route> flights, DateTime date)
        {
            _flights = flights;
            Date = date;
        }

        public void AddFlight(Route flight) =>
            _flights.Add(flight);

        public void RemoveFlight(Route flight) =>
            _flights.Remove(flight);

        public void UpdateFlight(Route flight)
        {
            var old = _flights.First(x => x.RouteNumber == flight.RouteNumber);
            _flights.Remove(old);
            _flights.Add(flight);
        }

        public List<Route> FindFlight(string destination) =>
            _flights.Where(x => x.DestinationPort.ToUpper() == destination.ToUpper() && x.Type == FlightType.Departure).ToList();
    }
}

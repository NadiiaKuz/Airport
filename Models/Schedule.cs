namespace Airport.Models
{
    class Schedule
    {
        private List<Route> _arrivals;
        private List<Route> _departures;
        private DateTime _date;

        public List<Route> Arrivals { get => _arrivals; }
        public List<Route> Departures { get => _departures; }
        public DateTime Date { get => _date; }

        public Schedule(List<Route> arrivals, List<Route> departures, DateTime date)
        {
            _arrivals = arrivals;
            _departures = departures;
            _date = date;
        }

        #region Arrivals
        public void AddArrival(Route arrival) =>
            _arrivals.Add(arrival);

        public void RemoveArrival(Route arrival) =>
            _arrivals.Remove(arrival);

        public void UpdateArrival(Route arrival)
        {
            var old = _arrivals.First(x => x.RouteNumber == arrival.RouteNumber);
            _arrivals.Remove(old);
            _arrivals.Add(arrival);
        }
        #endregion

        #region Departures
        public void AddDeparture(Route departure) =>
            _departures.Add(departure);

        public void RemoveDeparture(Route departure) =>
            _departures.Remove(departure);

        public void UpdateDeparture(Route departure)
        {
            var old = _departures.First(x => x.RouteNumber == departure.RouteNumber);
            _departures.Remove(old);
            _departures.Add(departure);
        }
        #endregion

        public List<Route> FindFlight(string destination) =>
            _departures.Where(x => x.DestinationPort.ToUpper() == destination.ToUpper()).ToList();
    }
}

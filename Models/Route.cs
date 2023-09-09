namespace Airport.Models
{
    class Route
    {
        private string _routeNumber;
        private string _destinationPort;
        private string _departurePort;
        private DateTime _departureTime;
        private DateTime _arrivalTime;
        private string _airline;
        private string _gate;
        private Status _status;
        private Plane _plane;

        public string RouteNumber { get => _routeNumber; }
        public string DestinationPort { get => _destinationPort; }
        public string DeparturePort { get => _departurePort; }
        public DateTime DepartureTime { get => _departureTime; }
        public DateTime ArrivalTime { get => _arrivalTime; }
        public string Airline { get => _airline; }
        public string Gate { get => _gate; }
        public Status Status { get => _status; }
        public Plane Plane { get => _plane; }

        public Route(string routeNumber, string destinationPort, string departurePort, DateTime departureTime, DateTime arrivalTime, string airline, string gate, Plane plane)
        {
            _routeNumber = routeNumber;
            _destinationPort = destinationPort;
            _departurePort = departurePort;
            _departureTime = departureTime;
            _arrivalTime = arrivalTime;
            _airline = airline;
            _gate = gate;
            _status = Status.Planned;
            _plane = plane;
        }

        public void ChangeDepartureTime(DateTime departureTime) =>
            _departureTime = departureTime;

        public void ChangeArrivalTime(DateTime arrivalTime) =>
            _arrivalTime = arrivalTime;

        public void ChangeGate(string gate) => 
            _gate = gate;
        
        public void ChangeStatus(Status status) => 
            _status = status;

        public void ChangePlane(Plane plane) => 
            _plane = plane;

        //public string GetDescription()
        //{

        //}
    }
}

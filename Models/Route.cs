using Airport.Enums;

namespace Airport.Models
{
    class Route
    {
        public string RouteNumber { get; private set; }
        public string DestinationPort { get; private set; }
        public string DeparturePort { get; private set; }
        public DateTime DepartureTime { get; private set; }
        public DateTime ArrivalTime { get; private set; }
        public string Airline { get; private set; }
        public string Gate { get; private set; }
        public Status Status { get; private set; }
        public FlightType Type { get; private set; }

        //Route can be created only with all parameters to avoid errors and exceptions
        public Route(string routeNumber, string destinationPort, string departurePort, DateTime departureTime, DateTime arrivalTime, 
            string airline, string gate, FlightType type)
        {
            RouteNumber = routeNumber;
            DestinationPort = destinationPort;
            DeparturePort = departurePort;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Airline = airline;
            Gate = gate;
            Status = Status.Planned;
            Type = type;
        }

        public void ChangeDepartureTime(DateTime departureTime) =>
            DepartureTime = departureTime;

        public void ChangeArrivalTime(DateTime arrivalTime) =>
            ArrivalTime = arrivalTime;

        public void ChangeGate(string gate) => 
            Gate = gate;
        
        public void ChangeStatus(Status status) => 
            Status = status;
    }
}

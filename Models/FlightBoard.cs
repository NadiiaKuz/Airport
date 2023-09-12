using Airport.Enums;
using System.Globalization;

namespace Airport.Models
{
    //Console.Writeline is used as an abstraction/substitution for real display
    static class FlightBoard
    {
        public static void DisplayDepartures(List<Route> routes, DateTime date)
        {
            routes = routes.OrderBy(x => x.DepartureTime).ToList();

            var header = GetHeader($"Departures ({date.ToShortDateString()})");
            var divider = GetDivider();

            Console.WriteLine(divider);
            Console.WriteLine(header);
            Console.WriteLine(divider);

            foreach (var route in routes)
            {
                GetLineColor(route.Status);
                Console.WriteLine(GetDeparturesRecord(route));
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine(divider);
        }

        private static void GetLineColor(Status status)
        {
            switch (status)
            {
                case Status.Canceled:
                    Console.ForegroundColor= ConsoleColor.Red; 
                    break;
                case Status.Delayed:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Status.Landed:
                case Status.GateOpened:
                case Status.Boarding:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }
        }

        private static string GetDeparturesRecord(Route route) =>
            $"|{GetColumn(route.DepartureTime.ToMyTime(), 16)}|{GetColumn(route.DestinationPort, 16)}|{GetColumn(route.RouteNumber, 10)}|{GetColumn(route.Airline, 14)}|{GetColumn(route.Status.ToString(), 26)}|{GetColumn(route.Gate, 8)}|";

        public static void DisplayArrivals(List<Route> routes, DateTime date)
        {
            routes = routes.OrderBy(x => x.ArrivalTime).ToList();

            var header = GetHeader($"Arrivals ({date.ToShortDateString()})");
            var divider = GetDivider();

            Console.WriteLine(divider);
            Console.WriteLine(header);
            Console.WriteLine(divider);

            foreach (var route in routes)
            {
                GetLineColor(route.Status);
                Console.WriteLine(GetArrivalsRecord(route));
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine(divider);
        }

        private static string GetArrivalsRecord(Route route) =>
            $"|{GetColumn(route.ArrivalTime.ToMyTime(), 16)}|{GetColumn(route.DeparturePort, 16)}|{GetColumn(route.RouteNumber, 10)}|{GetColumn(route.Airline, 14)}|{GetColumn(route.Status.ToString(), 26)}|{GetColumn(route.Gate, 8)}|";

        public static void DisplayFlights(List<Route> routes, DateTime date)
        {
            routes = routes.OrderBy(x => x.ArrivalTime).ToList();

            var header = GetHeader($"Flights  ({date.ToShortDateString()})");
            var divider = GetDivider();

            Console.WriteLine(divider);
            Console.WriteLine(header);
            Console.WriteLine(divider);

            foreach (var route in routes)
            {
                GetLineColor(route.Status);
                Console.WriteLine(GetDeparturesRecord(route));
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine(divider);
        }

        private static string GetColumn(string text, int width)
        {
            var numberSpaces = width - text.Length;
            var leftSpace = new string(' ', (numberSpaces) / 2);
            var rightSpace = new string(' ', (numberSpaces) / 2);

            if (numberSpaces % 2 == 1)
                rightSpace += " ";

            return $"{leftSpace}{text}{rightSpace}";
        }

        private static string GetDivider() =>
            $"|{new string('-', 97 - 2)}|";

        private static string GetHeader(string text)
        {
            var numberSpaces = 97 - text.Length;
            var leftSpace = new string('-', (numberSpaces) / 2 - 1);
            var rightSpace = new string('-', (numberSpaces) / 2 - 1);

            if (numberSpaces % 2 == 1)
                rightSpace += "-";

            return $"|{leftSpace}{text}{rightSpace}|";
        }

        private static string ToMyTime(this DateTime date)
        {
            var result = date.ToString(new CultureInfo("en-GB"));
            return result.Substring(11, 5);
        }
    }
}

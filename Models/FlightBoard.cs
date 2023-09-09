using System.Globalization;

namespace Airport.Models
{
    //Console.Writeline is used as an abstraction/substitution for real display
    static class FlightBoard
    {
        private const int TimeColumn = 16;
        private const int DestinationColumn = 16;
        private const int DepartureColumn = 16;
        private const int RouteNumberColumn = 10;
        private const int AirlineColumn = 14;
        private const int StatusColumn = 26;
        private const int GateColumn = 8;

        private const int Width = 97;

        public static void DisplayDepartures(List<Route> routes, DateTime date)
        {
            routes = routes.OrderBy(x => x.DepartureTime).ToList();

            var header = GetHeader($"Departures ({date.ToMyDate()})");
            var divider = GetDivider();

            Console.WriteLine(divider);
            Console.WriteLine(header);
            Console.WriteLine(divider);

            foreach (var route in routes)
            {
                Console.WriteLine(GetDeparturesRecord(route));
            }

            Console.WriteLine(divider);
        }

        private static string GetDeparturesRecord(Route route)
        {
            var record = "|";
            record += GetColumn(route.DepartureTime.ToMyTime(), TimeColumn);
            record += "|";
            record += GetColumn(route.DestinationPort, DestinationColumn);
            record += "|";
            record += GetColumn(route.RouteNumber, RouteNumberColumn);
            record += "|";
            record += GetColumn(route.Airline, AirlineColumn);
            record += "|";
            record += GetColumn(route.Status.ToString(), StatusColumn);
            record += "|";
            record += GetColumn(route.Gate, GateColumn);
            record += "|";

            return record;
        }

        public static void DisplayArrivals(List<Route> routes, DateTime date)
        {
            routes = routes.OrderBy(x => x.ArrivalTime).ToList();

            var header = GetHeader($"Arrivals ({date.ToMyDate()})");
            var divider = GetDivider();

            Console.WriteLine(divider);
            Console.WriteLine(header);
            Console.WriteLine(divider);

            foreach (var route in routes)
            {
                Console.WriteLine(GetArrivalsRecord(route));
            }

            Console.WriteLine(divider);
        }

        private static string GetArrivalsRecord(Route route)
        {
            var record = "|";
            record += GetColumn(route.ArrivalTime.ToMyTime(), TimeColumn);
            record += "|";
            record += GetColumn(route.DeparturePort, DepartureColumn);
            record += "|";
            record += GetColumn(route.RouteNumber, RouteNumberColumn);
            record += "|";
            record += GetColumn(route.Airline, AirlineColumn);
            record += "|";
            record += GetColumn(route.Status.ToString(), StatusColumn);
            record += "|";
            record += GetColumn(route.Gate, GateColumn);
            record += "|";

            return record;
        }

        public static void DisplayFlights(List<Route> routes, DateTime date)
        {
            routes = routes.OrderBy(x => x.ArrivalTime).ToList();

            var header = GetHeader($"Flights  ({date.ToMyDate()})");
            var divider = GetDivider();

            Console.WriteLine(divider);
            Console.WriteLine(header);
            Console.WriteLine(divider);

            foreach (var route in routes)
            {
                Console.WriteLine(GetDeparturesRecord(route));
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

            return leftSpace + text + rightSpace;
        }

        private static string GetDivider() =>
            "|" + new string('-', Width - 2) + "|";

        private static string GetHeader(string text)
        {
            var numberSpaces = Width - text.Length;
            var leftSpace = new string('-', (numberSpaces) / 2 - 1);
            var rightSpace = new string('-', (numberSpaces) / 2 - 1);

            if (numberSpaces % 2 == 1)
                rightSpace += "-";

            return "|" + leftSpace + text + rightSpace + "|";
        }

        private static string ToMyTime(this DateTime date)
        {
            var result = date.ToString(new CultureInfo("en-GB"));
            return result.Substring(11, 5);
        }

        private static string ToMyDate(this DateTime date) => 
            date.ToShortDateString();
    }
}

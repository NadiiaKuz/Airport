using Airport.Models;
using Airport.Providers;

namespace Airport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string NotFoundResponse = "No flights found";

            var flights = DataProvider.GetFlights();
            FlightSchedule.AddFlights(flights);

            var todayDate = new DateTime(2023, 9, 10);

            while (true)
            {
                Menu.Show();

                int result = Menu.GetMainChoice();

                switch (result)
                {
                    case 1:
                        FlightBoard.DisplayDepartures(FlightSchedule.Departures, todayDate);
                        break;
                    case 2:
                        FlightBoard.DisplayArrivals(FlightSchedule.Arrivals, todayDate);
                        break;
                    case 3:

                        Menu.ShowSubmenu();

                        (var searchWord, result) = Menu.GetSearchWord();
                        var foundFlights = result == 1 ? FlightSchedule.FindFlightByCity(searchWord) : FlightSchedule.FindFlightByNumber(searchWord);

                        if (!foundFlights.Any())
                            Console.WriteLine(NotFoundResponse);
                        else
                            FlightBoard.DisplayFlights(foundFlights, todayDate);
                        
                        break;
                    case 4:
                        return;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
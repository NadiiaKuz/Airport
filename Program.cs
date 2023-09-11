using Airport.Enums;
using Airport.Models;

namespace Airport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var planes = new Plane[]
            {
                new Plane("AX002", "Boeing", "747A", 300, 2012, true),
                new Plane("AX003", "Boeing", "747B", 290, 2013),
                new Plane("AX004", "Boeing", "747C", 310, 2015, true, true),
                new Plane("AX005", "Boeing", "747A", 300, 2012),
                new Plane("AX006", "Boeing", "747B", 290, 2020, isServiced:true),
                new Plane("FG201", "Airbus", "A300", 320, 2010, true),
                new Plane("FG202", "Airbus", "B300", 325, 2015),
                new Plane("FG203", "Airbus", "C300", 340, 2010, true),
                new Plane("FG204", "Airbus", "D300", 400, 2020, true),
                new Plane("FG205", "Airbus", "E300", 600, 2023, true, true)
            };

            var flights = new List<Route>()
            {
                new Route("WF024", "Oslo", "Amsterdam", new DateTime(2023, 9, 9, 8, 5, 0), new DateTime(2023, 9, 9, 10, 47, 0), "Wideroe", "G3", planes[0], FlightType.Arrival),
                new Route("SK4111", "Oslo", "Berlin", new DateTime(2023, 9, 9, 6, 7, 0), new DateTime(2023, 9, 9, 8, 30, 0), "SAS", "E2", planes[1], FlightType.Arrival),
                new Route("DY1432", "Oslo", "Alicante", new DateTime(2023, 9, 9, 10, 23, 0), new DateTime(2023, 9, 9, 12, 55, 0), "Norwegian", "B5", planes[2], FlightType.Arrival),
                new Route("DY1308", "Oslo", "London", new DateTime(2023, 9, 9, 9, 43, 0), new DateTime(2023, 9, 9, 11, 47, 0), "Norwegian", "D2", planes[3], FlightType.Arrival),
                new Route("FR7101", "Oslo", "Katowice", new DateTime(2023, 9, 9, 16, 22, 0), new DateTime(2023, 9, 9, 19, 32, 0), "Ryanair", "G2", planes[4], FlightType.Arrival),
                new Route("WF024", "Amsterdam", "Oslo", new DateTime(2023, 9, 9, 8, 5, 0), new DateTime(2023, 9, 9, 10, 47, 0), "Wideroe", "G3", planes[5], FlightType.Departure),
                new Route("SK4111", "Berlin", "Oslo", new DateTime(2023, 9, 9, 6, 7, 0), new DateTime(2023, 9, 9, 8, 30, 0), "SAS", "E2", planes[6], FlightType.Departure),
                new Route("DY1432", "Alicante", "Oslo", new DateTime(2023, 9, 9, 10, 23, 0), new DateTime(2023, 9, 9, 12, 55, 0), "Norwegian", "B5", planes[7], FlightType.Departure),
                new Route("DY1308", "Berlin", "Oslo", new DateTime(2023, 9, 9, 9, 43, 0), new DateTime(2023, 9, 9, 11, 47, 0), "Norwegian", "D2", planes[8], FlightType.Departure),
                new Route("FR7101", "Katowice", "Oslo", new DateTime(2023, 9, 9, 16, 22, 0), new DateTime(2023, 9, 9, 19, 32, 0), "Ryanair", "G2", planes[9], FlightType.Departure)
            };

            flights[3].ChangeStatus(Status.PreparingForLanding);
            flights[1].ChangeStatus(Status.BaggageOnBelt);
            flights[4].ChangeStatus(Status.Delayed);
            flights[0].ChangeStatus(Status.Landed);
            flights[6].ChangeStatus(Status.GateOpened);
            flights[8].ChangeStatus(Status.Delayed);
            flights[5].ChangeStatus(Status.Boarding);

            var schedule = new Schedule(flights, new DateTime(2023, 9, 10));

            while (true)
            {
                Console.WriteLine("Please choose option:");
                Console.WriteLine("1. Show departures");
                Console.WriteLine("2. Show arrivals");
                Console.WriteLine("3. Find flights");

                int result;

                do
                {                
                    Console.Write("Make your choice: ");
                } while (!Int32.TryParse(Console.ReadLine(), out result));
                
                switch(result)
                {
                    case 1:
                        FlightBoard.DisplayDepartures(schedule.Departures, schedule.Date);
                        break;
                    case 2:
                        FlightBoard.DisplayArrivals(schedule.Arrivals, schedule.Date);
                        break;
                    case 3:
                        Console.Write("Where do you want to flight? ");

                        //test case: Berlin
                        var foundFlights = schedule.FindFlight(Console.ReadLine());

                        if (!foundFlights.Any())
                            Console.WriteLine("No flights found");
                        else
                            FlightBoard.DisplayFlights(foundFlights, schedule.Date);

                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
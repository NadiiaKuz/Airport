namespace Airport.Providers
{
    static class Menu
    {
        public static void Show()
        {
            Console.WriteLine("Please choose option:");
            Console.WriteLine("1. Show departures");
            Console.WriteLine("2. Show arrivals");
            Console.WriteLine("3. Find flights");
            Console.WriteLine("4. Exit");
        }

        public static int GetMainChoice()
        {
            int result;

            do
            {
                Console.Write("Make your choice: ");
            } while (!int.TryParse(Console.ReadLine(), out result));

            return result;
        }

        public static void ShowSubmenu()
        {
            Console.WriteLine("1. Find flight by destination");
            Console.WriteLine("2. Find flight by flight number");
        }

        public static (string, int) GetSearchWord()
        {
            var correctOptions = new int[] { 1, 2 };
            int result;

            do
            {
                Console.Write("Make your choice: ");
            } while (!int.TryParse(Console.ReadLine(), out result) && !correctOptions.Contains(result));

            Console.Write("Search:");
            return (Console.ReadLine(), result);
        }
    }
}

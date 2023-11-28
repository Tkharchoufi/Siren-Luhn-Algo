using SirenApp.Services.Siren;

namespace SirenApp
{
    public class App
    {
        private readonly IAmTheTest _amTheTest;

        public App(IAmTheTest amTheTest)
        {
            _amTheTest = amTheTest;
        }

        public void Run(string[] args)
        {
            ConsoleKeyInfo ch;

            Console.WriteLine("Press the Escape (Esc) key to quit: \n");
            Console.WriteLine("Press the NumPad1 key to validate a Siren : \n");
            Console.WriteLine("Press the NumPad2 key to calculate Siren: \n");

            do
            {
                ch = Console.ReadKey();
                Console.WriteLine("\n");
                if (ch.Key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine("Please enter a Siren code to be validated: \n");

                    string siren = Console.ReadLine();
                    var isValid = _amTheTest.CheckSirenValidity(siren);
                    string response = isValid ? "Siren valid" : "invalid siren";
                    Console.WriteLine(response);
                }
                if (ch.Key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine("Please enter a siren Without Control Number: \n");

                    string sirenWithoutControlNumber = Console.ReadLine();
                    var siren = _amTheTest.ComputeFullSiren(sirenWithoutControlNumber);
                    Console.WriteLine($"Computed Siren: {siren}");
                }

            } while (ch.Key != ConsoleKey.Escape);
        }
    }
}

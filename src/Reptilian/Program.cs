using System;
using System.Threading;
using Reptilian.DataAccess;

namespace Reptilian
{
    class Program
    {
        static void Main(string[] args)
        {
            _display = new Display();

            Database.RunMigrations();

            while (true)
            {
                Console.Clear();
                var choice = _display.GetUserChoice();

                DecideTask(choice);
            }
        }

        static void DecideTask(string option)
        {
            var reptileService = new ReptileService();

            switch (option)
            {
                case "1":
                    _display.Loading();
                    var reptiles = reptileService.GetReptiles();
                    _display.ShowReptiles(reptiles);
                    break;

                case "Q":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("\nInvalid option, try again");
                    Thread.Sleep(750);
                    break;
            }
        }

        private static Display _display;
    }
}

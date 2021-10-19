using System;
using Reptilian.DataAccess;

namespace Reptilian
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.RunMigrations();

            Console.Clear();
            Display.ShowWelcome();

            Display.ShowMenu();
            var choice = Display.GetUserChoice();

            Console.WriteLine("\n");
        }
    }
}

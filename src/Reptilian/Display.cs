using System;

namespace Reptilian
{
    class Display
    {
        public static ConsoleKeyInfo GetUserChoice()
        {
            return Console.ReadKey();
        }

        public static void ShowMenu()
        {
            Console.WriteLine("What would you like to do?");
            // Console.WriteLine("  1. View all reptiles");
            Console.WriteLine("\nPress q to exit.");
        }

        public static void ShowWelcome()
        {
            const string welcome = "Welcome to Reptilian!";
            int bannerLength = (int)Math.Floor((decimal)Console.BufferWidth / 2) - (int)Math.Ceiling((decimal)welcome.Length / 2) - 1;
            var dashBanner = new string('-', bannerLength);
            Console.WriteLine($"{dashBanner} {welcome.ToUpper()} {dashBanner}\n");
        }
    }
}

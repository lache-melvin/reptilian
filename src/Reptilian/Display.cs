using System;
using System.Collections.Generic;

namespace Reptilian
{
    class Display
    {
        public string GetUserChoice()
        {
            var welcome = GetWelcome();
            Console.WriteLine(welcome);

            var menu = GetMenu();
            Console.WriteLine(menu);
            return GetInputKey();
        }

        public void ShowReptiles(List<Reptile> reptiles)
        {
            Console.Clear();
            foreach (var reptile in reptiles)
            {
                Console.WriteLine($"- {reptile.Name} ({reptile.Breed})");
            }

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey(true);
        }

        public void Loading()
        {
            Console.WriteLine("\nLoading... :)");
        }

        public string GetInputKey()
        {
            var keyInfo = Console.ReadKey(true);
            return keyInfo.KeyChar.ToString().ToUpper();
        }

        public string GetMenu()
        {
            // TODO: get task options from service annotations?
            return @"
What would you like to do?
  1. View all reptiles

Press q to exit.";
        }

        public string GetWelcome()
        {
            const string welcome = "Welcome to Reptilian!";
            int bannerLength = (int)Math.Floor((decimal)Console.BufferWidth / 2) - (int)Math.Ceiling((decimal)welcome.Length / 2) - 1;
            var dashBanner = new string('-', bannerLength);
            return $"{dashBanner} {welcome.ToUpper()} {dashBanner}";
        }
    }
}

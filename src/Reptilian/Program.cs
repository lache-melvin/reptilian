using System;
using Reptilian.DataAccess;

namespace Reptilian
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.RunMigrations();
            Console.WriteLine("Hello World!");
        }
    }
}

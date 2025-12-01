using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConfigurationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Build configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

            IConfiguration config = builder.Build();

            Console.WriteLine("--- BASIC READING (IConfiguration) ---");

            //Read simple value
            string capacity = config["KennelCapacity"];
            Console.WriteLine($"Kennel Capacity: {capacity}");

            //Read nested values(:)
            string catName = config["Animals:Cat:Name"];
            string dogColor = config["Animals:Dog:Color"];

            Console.WriteLine($"Cat Name: {catName}");
            Console.WriteLine($"Dog Color: {dogColor}");

            //Default animal name
            string defaultName = config["Animals:DefaultAnimalName"];
            Console.WriteLine($"Default Name: {defaultName}");
        }
    }
}
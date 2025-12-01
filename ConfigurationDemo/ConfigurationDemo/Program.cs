using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace ConfigurationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //configuration (builder)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

            IConfiguration config = builder.Build();

            //setup container di (services)
            var services = new ServiceCollection();

            //register options pattern
            services.AddOptions();

            //configurate class AnimalsSettings taking data from "Animals" section and JSON
            services.Configure<AnimalsSettings>(config.GetSection("Animals"));

            //build service provider
            var serviceProvider = services.BuildServiceProvider();

            //use options pattern
            Console.WriteLine("\n--- OPTIONS PATTERN (IOptions) ---");

            //taking IOptions<AnimalsSettings> from service provider
            var animalsOptions = serviceProvider.GetService<IOptions<AnimalsSettings>>();

            //to get the actual settings, we access the Value property
            AnimalsSettings settings = animalsOptions.Value;

            //now we can use the settings
            Console.WriteLine($"Default Name: {settings.DefaultAnimalName}");

            Console.WriteLine("\n--- CAT DETAILS ---");
            Console.WriteLine($"Name: {settings.Cat.Name}");
            Console.WriteLine($"Color: {settings.Cat.Color}");
            Console.WriteLine($"Vaccinated: {settings.Cat.IsVaccinated}");
            Console.WriteLine($"Food: {settings.Cat.DailyFoodGrams}g");

            Console.WriteLine("\n--- DOG DETAILS ---");
            Console.WriteLine($"Name: {settings.Dog.Name}");
            Console.WriteLine($"Color: {settings.Dog.Color}");

            //We can also read a simple value outside the Animals section manually
            int kennelCapacity = config.GetValue<int>("KennelCapacity");
            Console.WriteLine($"\nGlobal Kennel Capacity: {kennelCapacity}");

            Console.ReadKey();
        }
    }
}
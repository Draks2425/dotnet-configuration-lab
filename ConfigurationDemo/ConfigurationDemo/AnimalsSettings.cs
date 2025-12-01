using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationDemo
{
    public class AnimalsSettings
    {
        //Section "Animals"in JSON
        public AnimalDetail Cat { get; set; }
        public AnimalDetail Dog { get; set; }
        public string DefaultAnimalName { get; set; }
    }

    public class AnimalDetail
    {
        //This fits the property inside "Cat" and "Dog"
        public string Name { get; set; }
        public string Color { get; set; }
        public bool IsVaccinated { get; set; }
        public int DailyFoodGrams { get; set; }
    }
}

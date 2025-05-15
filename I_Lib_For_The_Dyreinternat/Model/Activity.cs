using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    internal class Activity : Event
    {
        public Activity (string name, string description, int costumerCap, int animalCap, List<Costumer> costumers, List<Animal> animals, List<Worker> workers, string location, DateTime start, DateTime stop)
        {
            Name = name;
            Description = description;
            CostumerCap = costumerCap;
            AnimalCap = animalCap;
            CostumerCap = costumerCap;
            Animals = animals;
            Workers = workers;
            Location = location;
            Start = start;
            Stop = stop;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public class Activity : Event
    {
        
        public Activity()
        {

        }

        public Activity (string name, string description, int costumerCap, int animalCap, string location, DateTime start, DateTime stop, List<Worker> workers, List<Animal> animals, List<Costumer> costumers, int id=0)
        {
            Name = name;
            Description = description;
            CostumerCap = costumerCap;
            AnimalCap = animalCap;
            Location = location;
            Start = start;
            Stop = stop;
            Workers = workers;
            ID = id;

        }

        public override string ToString()
        {
            return $"Name: {Name}  Description: {Description}  CostumerCap: {CostumerCap}  AnimalCap: {AnimalCap}  Location: {Location} Time start: {Start} time stop: {Stop} Costumers: {Costumers} Animals: {Animals} Workers: {Workers}";
        }
    }
}


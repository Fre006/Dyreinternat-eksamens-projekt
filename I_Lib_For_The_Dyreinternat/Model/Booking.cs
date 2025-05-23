using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lib.Model
{
    public class Booking : Event
    {
        public Booking(string name, string description, int costumerCap, int animalCap, List<Costumer> costumers, List<Animal> animals, List<Worker> workers, string location, DateTime start, DateTime stop, int id=0)
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
            Animals = animals;
            Costumers = costumers;
        }
        public override string ToString()
        {
            return $"Name: {Name}  Description: {Description}  CostumerCap: {CostumerCap}  AnimalCap: {AnimalCap}  Costumers: {Costumers} Animals: {Animals} Workers: {Workers} Location: {Location} Time start: {Start} time stop: {Stop}";
        }
    }
}

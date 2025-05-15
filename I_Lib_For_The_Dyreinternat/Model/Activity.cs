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
        public Activity (string name, string description, int costumerCap, int animalCap, List<Costumer> costumers, List<Animal> animals, List<Worker> workers, string location, DateTime start, DateTime stop)
        {
        }
        public override string ToString()
        {
            return $"Name: {Name}  Description: {Description}  CostumerCap: {CostumerCap}  AnimalCap: {AnimalCap}  Costumers: {Costumers} Animals: {Animals} Workers: {Workers} Location: {Location} Time start: {Start} time stop: {Stop}";
        }
    }
}


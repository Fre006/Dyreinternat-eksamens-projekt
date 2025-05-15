using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lib.Model
{
    internal class Booking : Event
    {
        public Booking(string name, string description, int costumerCap, int animalCap, List<Costumer> costumers, List<Animal> animals, List<Worker> workers, string location, DateTime start, DateTime stop)
        {
        }
        public override string ToString()
        {
            return $"Name: {Name}  Description: {Description}  CostumerCap: {CostumerCap}  AnimalCap: {AnimalCap}  Costumers: {Costumers} Animals: {Animals} Workers: {Workers} Location: {Location} Time start: {Start} time stop: {Stop}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    internal class Event
    {
        public string _name;
        public string _description;
        public int _customerCap;
        public int _animalCap;
        public List<Costumer> _costumers;
        public List<Animal> _animals;
        public List<Worker> _workers;
        public string _location;
        public DateTime _start;
        public DateTime _stop;

        public string Name { get; set; }
        public string Description { get; set; }
        public int CostumerCap { get; set; }
        public int AnimalCap { get; set; }
        public List<Costumer> Costumers { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Worker> Workers { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }


        public Event(string name, string description, int customerCap, int animalCap, List<Costumer> costumers, List<Animal> animals, List<Worker> workers, string location, DateTime start, DateTime stop)
        {
            Name = name;
            Description = description;
            CostumerCap = customerCap;
            AnimalCap = animalCap;
            Costumers = costumers;
            Animals = animals;
            Workers = workers;
            Location = location;
            Start = start;
            Stop = stop;
        }
    }
}

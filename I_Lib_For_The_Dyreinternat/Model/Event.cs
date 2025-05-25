using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public class Event
    {
        //instansvariabler
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

        //Properties
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
        public int ID { get; set; }

        //Default Construktor
        public Event() { }

        //List<Costumer> costumers, List<Animal> animals, List<Worker> workers we give ID a default value we later change
        public Event(string name, string description, int customerCap, int animalCap, string location, DateTime start, DateTime stop, List<Worker> workers, int id=0)
        {
            Name = name;
            Description = description;
            CostumerCap = customerCap;
            AnimalCap = animalCap;
            Location = location;
            Start = start;
            Stop = stop;
            Workers = workers;
            ID = id;

        }

        //Construktor Scaffolding
        public Event(string name, string description, int customerCap, int animalCap, string location, DateTime start, DateTime stop, List<Worker> workers, List<Animal> animals) : this(name, description,customerCap,animalCap,location,start,stop,workers)
        {
            Animals = animals;
        }
        public Event(string name, string description, int customerCap, int animalCap, string location, DateTime start, DateTime stop, List<Worker> workers, List<Costumer> costumers) : this(name, description, customerCap, animalCap, location, start, stop, workers)
        {
            Costumers = costumers;
        }
        public Event(string name, string description, int customerCap, int animalCap, string location, DateTime start, DateTime stop, List<Worker> workers, List<Animal> animals, List<Costumer> costumers) : this(name, description, customerCap, animalCap, location, start, stop, workers)
        {
            Animals = animals;
            Costumers = costumers;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}, Costumer Capacity: {CostumerCap}, Animal Capacity: {AnimalCap}, Location: {Location}, Start time: {Start}, End time: {Stop}, ID: {ID} Animal amount: {Animals.Count}, Worker amount: {Workers.Count}, Costumer amount: {Costumers.Count}";
        }
    }
}

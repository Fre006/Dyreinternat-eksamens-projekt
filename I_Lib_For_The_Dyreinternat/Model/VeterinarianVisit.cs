using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public enum Type { Surgery, Vacination, Put_to_sleep, Check_Up, Other }

    public class VeterinarianVisit : Event
    {
        public Type _type;
        public string _veterinarian;

        public Type Type { get; set; }
        public string Veterinarian { get; set; }

        public VeterinarianVisit(string name, string description, int customerCap, int animalCap, List<Costumer> costumers, List<Animal> animals, List<Worker> workers, string location, DateTime start, DateTime stop, Type type, string veterinarian)
        {
            Type = type;
            Veterinarian = veterinarian;
        }
    }
}

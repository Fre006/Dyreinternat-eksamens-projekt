using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    //Enum Showing the 5 different types of veterinarian types of visits
    public enum Type { Surgery, Vacination, Put_to_sleep, Check_Up, Other }

    public class VeterinarianVisit : Event
    {
        //Instansvariables
        public Type _type;
        public string _veterinarian;

        //Properties
        public Type Type { get; set; }
        public string Veterinarian { get; set; }

        //Construktor for Veterinarian events
        public VeterinarianVisit(string name, string description, int customerCap, int animalCap, List<Costumer> costumers, List<Animal> animals, List<Worker> workers, string location, DateTime start, DateTime stop, Type type, string veterinarian)
        {
            Type = type;
            Veterinarian = veterinarian;
        }
        public override string ToString()
        {
            return $"Name: {Name}  Description: {Description}  CostumerCap: {CostumerCap}  AnimalCap: {AnimalCap}  Costumers: {Costumers} Animals: {Animals} Workers: {Workers} Location: {Location} Time start: {Start} time stop: {Stop} Type: {Type} Veterinarian: {Veterinarian}";
        }
    }
}

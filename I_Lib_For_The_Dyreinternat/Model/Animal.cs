using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public enum Sizes { Big, Medium, Small }
    public class Animal
    {
        public string Name { get; set; }
        public string Characteristics { get; set; }
        public string Status { get; set; }
        public bool Male { get; set; }
        public bool Fertile { get; set; }
        public Sizes Size;

        public List<Event> Logs { get; set; }
        public string ChipID { get; set; }
        public string Description { get; set; }

        public DateTime Birthdate { get; set; }
        public List<Event> DefaultEvents = new List<Event>();
        public Animal()
        {

        }
        public Animal(string name, string characteristics, string status, bool male, bool fertile, Sizes size, string chipID, string description, DateTime birthdate, List<Event> logs)
        {
            Name = name;
            Characteristics = characteristics;
            Status = status;
            Male = male;
            Fertile = fertile;
            Size = size;
            ChipID = chipID;
            Description = description;
            Logs= logs;
            ChipID=chipID;
            Birthdate=birthdate;
        }
        public override string ToString()
        {
            string sex = "Male";
            if (Male == false)
            {
                sex = "Female";
            }
            string fertility = "Animal isn't sterilised";
            if (Fertile == false) { fertility = "Animal is sterilised"; }
      

            return $"Name: {Name}  Id: {ChipID}  Status: {Status}  Description: {Description}  Birthdate: {Birthdate} Sex: {sex} Sterilised:{fertility}";
        }




    }
}

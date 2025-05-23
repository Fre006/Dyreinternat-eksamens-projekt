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

        //default constructor
        public Animal()
        {

        }
        public Animal(string name, string characteristics, string status, bool male, bool fertile, Sizes size, List<Event> logs, string chipID, string description, DateTime birthdate)
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
            return $"Name: {Name}, Characteristics: {Characteristics}, Status: {Status}, IsMale: {Male}, Fertile: {Fertile}, Size: {Size}, ChipID: {ChipID}, Description: {Description}, Birthdate:{Birthdate}";
        }



    }
}

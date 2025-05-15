using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    enum Sizes { Big, Medium, Small }
    internal class Animal
    {
        public string Name { get; set; }
        public string Characteristics { get; set; }
        public string Status { get; set; }
        public bool Male { get; set; }
        public bool Fertile { get; set; }
        public Sizes Size;

        public List<string> Logs { get; set; }
        public string ChipID { get; set; }
        public string Description { get; set; }

        public DateTime Birthdate { get; set; }

        public Animal(string name, string characteristics, string status, bool male, bool fertile, Sizes size, List<string> logs, string chipID, string description, DateTime birthdate)
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



    }
}

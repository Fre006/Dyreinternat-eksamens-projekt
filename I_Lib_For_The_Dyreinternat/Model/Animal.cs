using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Lib_For_The_Dyreinternat.Model
{
    internal class Animal
    {
        public string Name { get; set; }
        public string Characteristics { get; set; }
        public string Status { get; set; }
        public bool Male { get; set; }
        public bool Fertile { get; set; }
        public enum Size;

        public List<string> Logs { get; set; }
        public string ChipID { get; set; }
        public string Description { get; set; }

        public DateTime birthdate { get; set; }

        public Animal(string name, string characteristics, string status, bool male, bool fertile, Enum size,   )
        {

        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Lib_For_The_Dyreinternat.Model
{
    public abstract class Person
    {

        public string Name { get; set; }
        public string Id { get; set; }
        public string Mail {  get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }


        public Person() { }

        public Person(string name, string id, string mail, string phoneNumber, DateTime birthdate)
        {
            Name = name;
            Id = id;
            Mail = mail;
            PhoneNumber = phoneNumber;
            Birthdate = birthdate;
        }
      

    }
}

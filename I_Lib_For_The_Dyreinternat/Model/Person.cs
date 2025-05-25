using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public class Person
    {
        //Just some normal properties shared by Worker and Costumer
        public string Name { get; set; }
        public int Id { get; set; }
        public string Mail {  get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }


        public Person() { }//Default Constructor

        public Person(string name, string phoneNumber, string mail, DateTime birthdate, int id = 0)
        {
            Name = name;
            Id = id;
            Mail = mail;
            PhoneNumber = phoneNumber;
            Birthdate = birthdate;
        }
      

    }
}

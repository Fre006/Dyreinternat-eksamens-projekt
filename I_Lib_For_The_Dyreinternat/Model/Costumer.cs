using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public class Costumer : Person //Costumer inherits properties from Person
    {
        
        public string CardNumber { get; set; }//Costumers only unique property

        public Costumer() //Default Constructor
        {

        }
        public Costumer(string name, string mail, string phoneNumber, DateTime birthdate, string cardNumber, int id = 0) //We set the default id to be 0
        {
            Name = name;
            Id = id;
            Mail = mail;
            PhoneNumber = phoneNumber;
            Birthdate = birthdate;
            CardNumber = cardNumber;
        }
        public override string ToString() //Simple ToString
        {
            return $"Name: {Name}  Id: {Id}  Mail: {Mail}  PhoneNumber: {PhoneNumber}  Birthdate: {Birthdate} CardNumber: {CardNumber}";
        }
    }
}

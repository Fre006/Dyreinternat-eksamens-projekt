using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public class Costumer : Person
    {
        public string _cardNumber;
        public string CardNumber { get; set; }

        public Costumer()
        {

        }
        public Costumer(string name, string mail, string phoneNumber, DateTime birthdate, string cardNumber, int id = 0)
        {
            Name = name;
            Id = id;
            Mail = mail;
            PhoneNumber = phoneNumber;
            Birthdate = birthdate;
            CardNumber = cardNumber;
        }
        public override string ToString()
        {
            return $"Name: {Name}  Id: {Id}  Mail: {Mail}  PhoneNumber: {PhoneNumber}  Birthdate: {Birthdate} CardNumber: {CardNumber}";
        }
    }
}

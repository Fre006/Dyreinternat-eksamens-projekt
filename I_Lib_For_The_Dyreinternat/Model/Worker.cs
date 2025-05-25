using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    //Creates an enum with the roles to avoid confusion about what the roles are
    public enum Roles { Admin, Leader, Grunt}
    public class Worker : Person //Inherits from person
    {

        public Roles Role {  get; set; } //Worker has one unique property, that being role

        public Worker() //Default constructor
        {
        
        }
        /*
            We then use constructor scafolding ot allow the creation of workes with 
            less data, such as no phone number, or mail or birthday
         */
        public Worker(Roles role, string name, int id = 0) :this() //We set the default id to be 0
        {
            Role = role;
            Name = name;
            Id = id;
        }
        public Worker(Roles role, string name, int id, string phoneNumber) :this(role, name, id)
        {
            PhoneNumber = phoneNumber;
        }
        public Worker(Roles role, string name, int id, string mail, DateTime birtdate) : this(role, name, id, mail)
        {

            Birthdate = birtdate;
        }
        public Worker(Roles role, string name, int id, string phoneNumber, string mail) :this(role, name, id, phoneNumber) 
        {
            Mail = mail;
        }
        public Worker(Roles role, string name, int id, string phoneNumber, string mail, DateTime birtdate) :this(role, name, id, phoneNumber, mail)
        {
            
            Birthdate = birtdate;

        }

        public override string ToString() //Simple ToString
        {
            return $"Name: {Name}  Role: {Role}  ID: {Id}  Mail: {Mail}  Birthdate: {Birthdate}";
        }

    }
}

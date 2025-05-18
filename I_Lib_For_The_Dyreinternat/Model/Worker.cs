using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public enum Roles { Admin, Leader, Grunt}
    public class Worker : Person
    {

        public Roles Role {  get; set; }

        public Worker() 
        {
        
        }
        public Worker(Roles role, string name, string id) :this()
        {
            Role = role;
            Name = name;
            Id = id;
        }
        public Worker(Roles role, string name, string id, string phoneNumber) :this(role, name, id)
        {
            PhoneNumber = phoneNumber;
        }
        public Worker(Roles role, string name, string id, string mail, DateTime birtdate) : this(role, name, id, mail)
        {

            Birthdate = birtdate;
        }
        public Worker(Roles role, string name, string id, string phoneNumber, string mail) :this(role, name, id, phoneNumber) 
        {
            Mail = mail;
        }
        public Worker(Roles role, string name, string id, string phoneNumber, string mail, DateTime birtdate) :this(role, name, id, phoneNumber, mail)
        {
            
            Birthdate = birtdate;
        }

        public override string ToString()
        {
            return $"Name: {Name}  Role: {Role}  ID: {Id}  Mail: {Mail}  Birthdate: {Birthdate}";
        }

    }
}

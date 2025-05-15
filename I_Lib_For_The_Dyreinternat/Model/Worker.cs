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


        public Worker(Roles role, string name, string id, string mail, DateTime birtdate) 
        {
            Role = role;
            Name = name;
            Id = id;
            Mail = mail;
            Birthdate = birtdate;
        }

        public override string ToString()
        {
            return $"Name: {Name}  Role: {Role}  ID: {Id}  Mail: {Mail}  Birthdate: {Birthdate}";
        }

    }
}

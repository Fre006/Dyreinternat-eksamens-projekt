using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    enum Roles { Admin, Leader, Grunt}
    internal class Worker : Person
    {

        public Roles Role {  get; set; }


        public Worker(Roles role) 
        {
            Role = role;
        }



    }
}

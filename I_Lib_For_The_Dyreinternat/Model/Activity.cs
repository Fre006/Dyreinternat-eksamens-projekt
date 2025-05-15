using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    internal class Activity : Event
    {
        public Activity(string name, string description, int customerCap, int animalCap, List<Customer> customers, List<Animal> animals, List<Worker> workers, string location, DateTime start, DateTime stop)
        {

        }
    }
}

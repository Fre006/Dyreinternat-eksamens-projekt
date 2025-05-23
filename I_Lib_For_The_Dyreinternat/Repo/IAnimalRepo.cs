using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public interface IAnimalRepo
    {
        public List<Animal> GetAll();
        public Animal GetByID(string id);
        public List<Event> GetLogs(string id);
        public void AddLog(string id, Event newentry, string path = "default");
        public void RemoveLogByID(Event theevent, string Chipid);
    }
}

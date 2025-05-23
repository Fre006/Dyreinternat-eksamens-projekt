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
        public void DeletedEvent(Event theEvent);
        public void DeleteByID(string chipID);
        public void Sterilise(string chipID, string path = "default");
        public List<Animal> AllFemales();
        public List<Animal> AllMales();
        public List<Animal> AllFertile();
        public List<Animal> AllInfertile();
    }
}

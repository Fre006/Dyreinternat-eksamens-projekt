using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public interface IEventJSONRepo
    {
        public int GiveID(int ThisID);
        public Event GetEventByID(int id);
        public void AddEventToLogViaID(int id);
        public void AddEventToLog(Event theevent);
        public List<Event> GetAll();
        public Animal GetAnimalByID(string id);
        public Costumer GetCostumerByID(int id);
        public Worker GetWorkerByID(int id);
        public void DeletedEvent(Event theevent);


    }
}

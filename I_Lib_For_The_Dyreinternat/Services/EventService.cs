using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Repo;

namespace Lib.Services
{
    public class EventService
    {
        private IEventJSONRepo _eventRepo;

        public EventService(IEventJSONRepo EventRepo)
        {
            _eventRepo = EventRepo;
        }
        public List<Event> GetAll()
        {
            return _eventRepo.GetAll();
        }
        public Event GetByID(int ID)
        {
            return _eventRepo.GetEventByID(ID);
        }
        public Animal GetAnimalByID(string id)
        {
            return _eventRepo.GetAnimalByID(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public interface IBookingJSONRepo
    {
        public List<Booking> GetAll();
        public void Add(Booking booking);
        public Booking GetByName(string name);
        public void Edit(int id, string name, string description, int customerCap, int animalCap, string location, DateTime start, DateTime stop);
        public int GetIndexById(int id);
        public void DeleteById(int id);
        public void RegAnimal(int EventId, string AnimalId);
        public void RegCostumer(int EventId, int CostumerId);
        public void RegWorker(int EventId, int WorkerId);
    }
}

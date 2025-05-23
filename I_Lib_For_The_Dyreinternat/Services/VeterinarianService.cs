using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Repo;

namespace Lib.Services
{
    public class VeterinarianService
    {
        private IVeterinarianJSONRepo _veterinarianRepo;

        public VeterinarianService(IVeterinarianJSONRepo veterinarianJSONRepo)
        {
            _veterinarianRepo = veterinarianJSONRepo;
        }
        public virtual void Add(VeterinarianVisit veterinarian)
        {
            veterinarian._costumers = new List<Costumer> { };
            _veterinarianRepo.Add(veterinarian);
        }
        public List<VeterinarianVisit> GetAll()
        {
            return (List<VeterinarianVisit>)_veterinarianRepo;
        }

        public void Edit(int id, string name, string description, int customerCap, int animalCap, string location, DateTime start, DateTime stop, string veterinarian)
        {
            _veterinarianRepo.Edit(id, name, description, customerCap, animalCap, location, start, stop, veterinarian);
        }
        public void RegWorker(int EventId, int WorkerId)
        {
            _veterinarianRepo.RegWorker(EventId, WorkerId);
        }
        public void RegAnimal(int EventId, string AnimalId)
        {
            _veterinarianRepo.RegAnimal(EventId, AnimalId);
        }
        public void DeRegAnimal(int EventId, string AnimalId)
        {
            _veterinarianRepo.DeRegAnimal(EventId, AnimalId);
        }
        public void DeRegWorker(int EventId, int WorkerId)
        {
            _veterinarianRepo.DeRegWorker(EventId, WorkerId);
        }
    }
}

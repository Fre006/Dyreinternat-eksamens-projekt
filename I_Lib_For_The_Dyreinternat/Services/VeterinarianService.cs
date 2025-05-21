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
    }
}

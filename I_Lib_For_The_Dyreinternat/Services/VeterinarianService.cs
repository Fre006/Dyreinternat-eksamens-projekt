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
        private IVeterinarianJSONRepo _veterinarianJSONRepository;

        public VeterinarianService(IVeterinarianJSONRepo veterinarianJSONRepository)
        {
            _veterinarianJSONRepository = veterinarianJSONRepository;
        }
        public virtual void Add(VeterinarianVisit veterinarian)
        {
            veterinarian._costumers = new List<Costumer> { };
            _veterinarianJSONRepository.Add(veterinarian);
        }
        public List<TheActivity> GetAll()
        {
            return (List<TheActivity>)_veterinarianJSONRepository;
        }
    }
}

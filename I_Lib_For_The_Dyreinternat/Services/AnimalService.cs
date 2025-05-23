using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Repo;

namespace Lib.Services
{
    public class AnimalService
    {
        private IAnimalRepo _animalRepo;

        public AnimalService(IAnimalRepo AnimalRepo)
        {
            _animalRepo = AnimalRepo;
        }
        public List<Animal> GetAll()
        {
            return _animalRepo.GetAll();
        }
        public Animal GetByID(string ChipID)
        {
            return _animalRepo.GetByID(ChipID);
        }
        public List<Event> GetLogs(string chipID)
        {
            return _animalRepo.GetLogs(chipID);
        }
        public void DeleteByID(string ChipID) { 
            _animalRepo.DeleteByID(ChipID);
        }
        public void Sterilise(string id)
        {
            _animalRepo.Sterilise(id);
        }
        public List<Animal> AllMales()
        {
            return _animalRepo.AllMales();
        }
        public List<Animal> AllFemales()
        {
            return _animalRepo.AllFemales();
        }
        public List<Animal> AllFertile()
        {
            return _animalRepo.AllFertile();
        }
        public List<Animal> AllInfertile()
        {
            return _animalRepo.AllInfertile();
        }

    }
}

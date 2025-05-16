using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Repo;

namespace Lib.Services
{
    internal class AnimalService
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
        public void AddLog(Event log, string chipID, string path = "default")
        {
            _animalRepo.AddLog(chipID, log, path);
        }

    }
}

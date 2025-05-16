using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Repo;

namespace Lib.Services
{
    internal class DogService
    {
        private IDogRepo _dogRepo;

        public DogService(IDogRepo DogRepo)
        {
            _dogRepo = DogRepo;
        }
        public void Add(Dog dog, string path="default")
        {
            _dogRepo.Add(dog, path);

        }
        public List<Dog> GetAll()
        {
            return _dogRepo.GetAll();
        }
        public List<Event> GetLogs(string chipID)
        {
            return _dogRepo.GetLogs(chipID);
        }
        public void AddLog(Event log, string chipID, string path = "default")
        {
            _dogRepo.AddLog(chipID, log, path);
        }
        public Dog GetByID(string ChipID)
        {
            return _dogRepo.GetByID(ChipID);
        }
        public void Sterilise(string id, string path = "default")
        {
            _dogRepo.Sterilise(id, path);
        }
        public void DeleteByID(string ChipID)
        {
            _dogRepo.DeleteByID(ChipID);
        }
    }
}

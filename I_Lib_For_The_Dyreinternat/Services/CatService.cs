using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Repo;

namespace Lib.Services
{
    internal class CatService
    {
        private ICatRepo _catRepo;

        public CatService(ICatRepo CatRepo)
        {
            _catRepo = CatRepo;
        }
        public void Add(Cat cat)
        {
            _catRepo.Add(cat);

        }
        public Cat GetByID(string ChipID)
        {
            return _catRepo.GetByID(ChipID);
        }
        public List<Cat> GetAll()
        {
            return _catRepo.GetAll();
        }
        public List<Event> GetLogs(string chipID)
        {
            return _catRepo.GetLogs(chipID);
        }
        public void AddLog(Event log, string chipID, string path="default") {
            _catRepo.AddLog(chipID, log, path);
        }
        public void Sterilise(string id, string path="default") {
            _catRepo.Sterilise(id, path);    
        }
        public string GetStatus(string id)
        {
            return _catRepo.GetStatusByID(id);
        }
        public void ChangeStatus(string id, string status, string path="default")
        {
            _catRepo.ChangeStatusByID(id, status, path);
        }
    }
}

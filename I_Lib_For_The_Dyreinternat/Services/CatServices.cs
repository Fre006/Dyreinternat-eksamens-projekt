using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Repo;

namespace Lib.Services
{
    internal class CatServices
    {
        private ICatRepo _catRepo;

        public CatServices(ICatRepo CatRepo)
        {
            _catRepo = CatRepo;
        }
        public void Add(Cat cat)
        {
            _catRepo.Add(cat);

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

    }
}

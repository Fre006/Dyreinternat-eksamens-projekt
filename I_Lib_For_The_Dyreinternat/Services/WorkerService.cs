using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Repo;
using Lib.Interface;
using Lib.Model;

namespace Lib.Services
{
    internal class WorkerService
    {
        private IWorkerJSONRepo _workerRepo;

        public void Add(Person worker)
        {
            _workerRepo.Add(worker);
        }
        

        public List<Person> GetAll()
        {
            return _workerRepo.GetAll();
        }
    }
}

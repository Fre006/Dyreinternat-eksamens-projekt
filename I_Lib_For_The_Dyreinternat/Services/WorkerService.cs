using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I_Lib_For_The_Dyreinternat.Interface;
using I_Lib_For_The_Dyreinternat.Model;
using I_Lib_For_The_Dyreinternat.Repo;

namespace I_Lib_For_The_Dyreinternat.Services
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

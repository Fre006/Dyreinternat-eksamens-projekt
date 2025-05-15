using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Repo;
using Lib.Interface;
using Lib.Model;
using System.Diagnostics;

namespace Lib.Services
{
    public class WorkerService
    {
        private IWorkerJSONRepo _workerRepo;

        public WorkerService(IWorkerJSONRepo workerJsonRepo)
        {
            _workerRepo = workerJsonRepo;
        }

        public void Add(Worker worker)
        {

            _workerRepo.Add(worker);
            Debug.WriteLine("Added worker in service");

        }


        public List<Person> GetAll()
        {
            Debug.WriteLine("Reached Service");
            return _workerRepo.GetAll();
            
        }
    }
}

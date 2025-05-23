using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Repo;
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
            //Debug.WriteLine("Added worker in service");

        }
        public void Delete(Worker worker)
        {
            _workerRepo.Delete(worker);
        }


        public List<Worker> GetAll()
        {
            //Debug.WriteLine("Reached Servic e");
            return _workerRepo.GetAll();
        }
        public Worker GetByID(int id)
        {
            return _workerRepo.GetByID(id);
            
        }
        public Worker GetByName(string name) 
        {  
            return _workerRepo.GetByName(name);
        }


    }
}

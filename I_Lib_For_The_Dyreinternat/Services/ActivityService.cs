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
    public class ActivityService
    {
        private IActivityJSONRepo _activityRepo;

        public ActivityService(IActivityJSONRepo activityJSONRepository)
        {
            _activityRepo = activityJSONRepository;
        }
        public void Add(TheActivity activity)
        {
            _activityRepo.Add(activity);
        }
        public void AddNoAnimal(TheActivity activity)
        {
            activity._animals = new List<Animal> { };
            _activityRepo.Add(activity);
        }

        public void AddNoCostumer(TheActivity activity)
        {
            activity._costumers = new List<Costumer> { };
            _activityRepo.Add(activity);
        }

        public void AddOnlyWorker(TheActivity activity)
        {
            activity._animals = new List<Animal> { };
            activity._costumers = new List<Costumer> { };
            _activityRepo.Add(activity);
        }
        public List<TheActivity> GetAll()
        {
            return (List<TheActivity>)_activityRepo;
        }
         public TheActivity GetByName(string name)
        {
            return _activityRepo.GetByName(name);
        }

        public int GetIndexById(int id)
        {
            return _activityRepo.GetIndexById(id);
        }
        public void DeleteById(int id)
        {
            _activityRepo.DeleteById(id);
        }
        public void Edit(int id, string name, string description, int customerCap, int animalCap, string location, DateTime start, DateTime stop)
        {
            _activityRepo.Edit(id, name, description, customerCap, animalCap, location, start, stop);
        }
    }
}

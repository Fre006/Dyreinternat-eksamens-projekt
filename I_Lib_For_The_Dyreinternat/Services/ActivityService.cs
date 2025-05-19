using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Repo;
using Lib.Model;
namespace Lib.Services
{
    public class ActivityService
    {
        private IActivityJSONRepo _activityJSONRepository;

        public ActivityService(IActivityJSONRepo activityJSONRepository)
        {
            _activityJSONRepository = activityJSONRepository;
        }
        public void Add(TheActivity activity)
        {
            _activityJSONRepository.Add(activity);
        }
        public void AddNoAnimal(TheActivity activity)
        {
            activity._animals = new List<Animal> { };
            _activityJSONRepository.Add(activity);
        }

        public void AddNoCostumer(TheActivity activity)
        {
            activity._costumers = new List<Costumer> { };
            _activityJSONRepository.Add(activity);
        }

        public void AddOnlyWorker(TheActivity activity)
        {
            activity._animals = new List<Animal> { };
            activity._costumers = new List<Costumer> { };
            _activityJSONRepository.Add(activity);
        }
        public List<TheActivity> GetAll()
        {
            return (List<TheActivity>)_activityJSONRepository;
        }
    }
}

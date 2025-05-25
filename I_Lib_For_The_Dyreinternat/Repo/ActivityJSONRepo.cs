using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public class ActivityJSONRepo : IActivityJSONRepo
    {
        //Instansvariables
        private IEventJSONRepo _eventRepo;
        private IVaultEventJSONRepo _vaultEventRepo;
        private List<TheActivity> _activity = new List<TheActivity>();

        //Construktor for ActivityJSONRepo
        //This forces the newest version of the JSON files to be loaded which reduces the risk problems with those files.
        //Additionally it also fills the instansvariables that are used later to access methods from some of the other Classes.
        public ActivityJSONRepo(IEventJSONRepo EventRepo, IVaultEventJSONRepo VaultEventRepo)
        {
            _eventRepo = EventRepo;
            _vaultEventRepo = VaultEventRepo;
            try
            {
                LoadFile();
            }
            catch
            {
                SaveFile();
            }
        }

        //This method runs everytime we get things from the JSON files
        private void LoadFile()
        {
            string path = "Activity.json";
            string json = File.ReadAllText(path);

            _activity = JsonSerializer.Deserialize<List<TheActivity>>(json);
        }

        //This method adds ID's to new activity objects and places them in the list of all activities.
        //Additionally it also saves an event file to the log used in Visiting logs on the Animals.
        public void Add(TheActivity activity)
        {
            int newid = _eventRepo.GiveID(activity.ID);
            activity.ID = newid;
            _activity.Add(activity);
            SaveFile();
            _eventRepo.AddEventToLogViaID(activity.ID);

        }
        /// <summary>
        /// The code bellow where thought to be needed in the earliest versions of the code but where later deemed unneeded. SImply kept for posterity.
        /// </summary>
        //public virtual void AddNoAnimal(TheActivity activity)
        //{
        //    activity._animals = new List<Animal> { };
        //    _activity.Add(activity);
        //    SaveFile();
        //}

        //public virtual void AddNoCostumer(TheActivity activity)
        //{
        //    activity._costumers = new List<Costumer> { };
        //    _activity.Add(activity);
        //    SaveFile();
        //}

        //public virtual void AddOnlyWorker(TheActivity activity)
        //{
        //    activity._animals = new List<Animal> { };
        //    activity._costumers = new List<Costumer> { };
        //    _activity.Add(activity);
        //    SaveFile();
        //

        //This method is used everytime we wish to save a new version of the activity list to the JSON files.
        private void SaveFile()
        {
            string path = "Activity.json";
            File.WriteAllText(path, JsonSerializer.Serialize(_activity));
        }

        //This Method is used to find objects in the code that have a specific name.
        //It also works as a filter showing all objects with that name 
        public TheActivity GetByName(string name)
        {
            foreach (TheActivity activity in _activity)
            {
                if (name == activity.Name )
                {
                    return activity;
                }
            }
            return null;
        }

        //This Method is used to get the specific index number from the List that corresponds to the id of a given activity.
        //it is used in many methods to make sure we only get the exact object we want and nothing else.
        public int GetIndexById(int id)
        {
            int index = 0;
            for(int i = 0; i<_activity.Count;i++)
            {
                if (_activity[i].ID == id)
                {
                    index = i;
                }
            }
            return index;
        }

        //Method for getting a List of all activity objects
        public List<TheActivity> GetAll()
        {
            return _activity;
        }

        //Method for deleting an object based on its unique ID.
        //it also updates the JSON files and adds the removed files to a dictionary where it is kept incase it is needed later.
        public void DeleteById(int id)
        {
            int index = GetIndexById(id);
            if (_activity[index].ID == id)
            {
                _vaultEventRepo.VaultEvent(_activity[index]);
                _activity.RemoveAt(index);
                SaveFile();
            }
        }

        //Method for editing the arguments of an object that are not ID or lists of objects.
        public void Edit(int id, string name, string description, int customerCap, int animalCap, string location, DateTime start, DateTime stop)
        {
            int index = GetIndexById(id);
            if (_activity[index].ID == id)
            {
                _activity[index].Name = name;
                _activity[index].Description = description;
                _activity[index].CostumerCap = customerCap;
                _activity[index].AnimalCap = animalCap;
                _activity[index].Location = location;
                _activity[index].Start = start;
                _activity[index].Stop = stop;
            }
        }

        //Method for adding Specific animal objects to the List of animals in the arguments of specific activities.
        //it also updates JSON files and adds the change to the Logs of the animal.
        //it also uses the animalCap arguments to limit the amount of animals that can be added to each activity
        public void RegAnimal(int EventId, string AnimalId)
        {
            try
            {
                int index = GetIndexById(EventId);
                Animal animal = _eventRepo.GetAnimalByID(AnimalId);
                if (_activity[index].Animals.Count < _activity[index].AnimalCap)
                {
                    _activity[index]._animals.Add(animal);
                    SaveFile();
                    _eventRepo.AddEventToLogViaID(_activity[index].ID);
                }
                else Console.WriteLine("No more animals can attend this event");
            }
            catch
            {
                Console.WriteLine("Animal or event id is incorrect");
            }
        }

        //Method for adding Specific Costumers objects to the List of animals in the arguments of specific Activities.
        //it also updates JSON files.
        //it also uses the costumerCap arguments to limit the amount of Costumers that can be added to each activity
        public void RegCostumer(int EventId, int CostumerId)
        {
            try
            {
                int index = GetIndexById(EventId);
                Costumer costumer = _eventRepo.GetCostumerByID(CostumerId);
                if (_activity[index].Costumers.Count < _activity[index].CostumerCap)
                {
                    _activity[index]._costumers.Add(costumer);
                    SaveFile();
                }
                else Console.WriteLine("No more Costumers can attend this event");
            }
            catch
            {
                Console.WriteLine("costumer or event id is incorrect");
            }
        }

        //Method for adding Specific Worker objects to the List of workers in the arguments of specific Activities.
        //it also updates JSON files.
        public void RegWorker(int EventId, int WorkerId)
        {
            try
            {
                int index = GetIndexById(EventId);
                Worker worker = _eventRepo.GetWorkerByID(WorkerId);
                _activity[index].Workers.Add(worker);
            }
            catch
            {
                Console.WriteLine("Worker or event id is incorrect");
            }
        }

        //Method for removing Specific Worker objects to the List of workers in the arguments of specific Activities.
        //it also updates JSON files.
        public void DeRegWorker(int EventId, int WorkerId)
        {
            try
            {
                int index = GetIndexById(EventId);

                if (_activity[index].ID == EventId)
                {
                    foreach (Worker theworker in _activity[index].Workers)
                    {
                        if (theworker.Id == WorkerId)
                        {
                            _activity[index].Workers.Remove(theworker);
                            SaveFile();
                        }
                    }
                }
                else Console.WriteLine("Employee is not registeret to this event");
            }
            catch
            {
                Console.WriteLine("Worker or event id is incorrect");
            }
        }

        //Method for removing Specific Animal objects to the List of workers in the arguments of specific Activities.
        //it also updates JSON files.
        public void DeRegAnimal(int EventId, string AnimalId)
        {
            try
            {
                int index = GetIndexById(EventId);
                if (_activity[index].ID == EventId)
                {
                    foreach (Animal theanimal in _activity[index].Animals)
                    {
                        if (theanimal.ChipID == AnimalId)
                        {
                            _activity[index].Animals.Remove(theanimal);
                            SaveFile();
                        }
                    }
                }
                else Console.WriteLine("Animal is not registeret to this event");
            }
            catch
            {
                Console.WriteLine("Animal or event id is incorrect");
            }
        }

        //Method for removing Specific Costumer objects to the List of workers in the arguments of specific Activities.
        //it also updates JSON files.
        public void DeRegCostumer(int EventId, int CostumerId)
        {
            try
            {
                int index = GetIndexById(EventId);

                if (_activity[index].ID == EventId)
                {
                    foreach (Costumer thecostumer in _activity[index].Costumers)
                    {
                        if (thecostumer.Id == CostumerId)
                        {
                            _activity[index].Costumers.Remove(thecostumer);
                            SaveFile();
                        }
                    }
                }
                else Console.WriteLine("Employee is not registeret to this event");
            }
            catch
            {
                Console.WriteLine("Worker or event id is incorrect");
            }
        }
    }
}

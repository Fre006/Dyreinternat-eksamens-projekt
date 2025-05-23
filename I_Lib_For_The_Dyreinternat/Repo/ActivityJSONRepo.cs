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
        private IEventJSONRepo _eventRepo;
        private IVaultEventJSONRepo _vaultEventRepo;
        private List<TheActivity> _activity = new List<TheActivity>();
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

        //denne metode skal kaldes hver gang vi gerne vil trække data fra vores JSON
        private void LoadFile()
        {
            string path = "Activity.json";
            string json = File.ReadAllText(path);

            _activity = JsonSerializer.Deserialize<List<TheActivity>>(json);
        }

        public void Add(TheActivity activity)
        {
            int newid = _eventRepo.GiveID(activity.ID);
            activity.ID = newid;
            _activity.Add(activity);
            SaveFile();
            _eventRepo.AddEventToLogViaID(activity.ID);

        }
        public virtual void AddNoAnimal(TheActivity activity)
        {
            activity._animals = new List<Animal> { };
            _activity.Add(activity);
            SaveFile();
        }

        public virtual void AddNoCostumer(TheActivity activity)
        {
            activity._costumers = new List<Costumer> { };
            _activity.Add(activity);
            SaveFile();
        }

        public virtual void AddOnlyWorker(TheActivity activity)
        {
            activity._animals = new List<Animal> { };
            activity._costumers = new List<Costumer> { };
            _activity.Add(activity);
            SaveFile();
        }

        //denne metode skal kaldes når vi vil putte data i vores JSON
        private void SaveFile()
        {
            string path = "Activity.json";
            File.WriteAllText(path, JsonSerializer.Serialize(_activity));
        }

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

        public List<TheActivity> GetAll()
        {
            return _activity;
        }

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

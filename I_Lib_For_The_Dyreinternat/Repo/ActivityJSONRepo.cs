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
        private List<TheActivity> _activity = new List<TheActivity>();
        public ActivityJSONRepo(IEventJSONRepo EventRepo)
        {
            _eventRepo = EventRepo;
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
                _activity.RemoveAt(index);
                SaveFile();
            }
        }
    }
}

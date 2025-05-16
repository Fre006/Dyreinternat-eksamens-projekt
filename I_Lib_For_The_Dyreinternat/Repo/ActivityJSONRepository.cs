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
    internal class ActivityJSONRepository : IActivityJSONRepository
    {
        public ActivityJSONRepository()
        {
            LoadFile();
        }

        //denne metode skal kaldes hver gang vi gerne vil trække data fra vores JSON
        private void LoadFile()
        {
            string path = "Activity.json";
            string json = File.ReadAllText(path);

            _activity = JsonSerializer.Deserialize<List<Activity>>(json);
        }

        public virtual void Add(Activity activity)
        {
            _activity.Add(activity);
            SaveFile();
        }
        public virtual void AddNoAnimal(Activity activity)
        {
            activity._animals = new List<Animal> { };
            _activity.Add(activity);
            SaveFile();
        }

        public virtual void AddNoCostumer(Activity activity)
        {
            activity._costumers = new List<Costumer> { };
            _activity.Add(activity);
            SaveFile();
        }

        public virtual void AddOnlyWorker(Activity activity)
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

        public List<Activity> _activity = new List<Activity>();

        public List<Activity> GetAll()
        {
            return _activity;
        }

    }
}

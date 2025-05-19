using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public class DogJSONRepo:IDogJSONRepo
    {
        private string _path = "Dog.json";
        protected List<Dog> _dogs = new List<Dog>();

        public DogJSONRepo()
        {
            try
            {
                LoadFile();
            }
            catch
            {
                SaveFile();
            }

        }
        public int GetIndexByID(string chipID)
        {
            //returns 0 if chipID isn't found
            int index = 0;
            for (int i = 0; i < _dogs.Count; i++)
            {
                if (_dogs[i].ChipID == chipID)
                {

                    index = i;

                }
            }
            return index;
        }
        public void DeleteByID(string chipID, string path="default")
        {
            int index = GetIndexByID(chipID);
            //catches if chipID doesn't match, and then will not delete
            if (_dogs[index].ChipID == chipID)
            {
                _dogs.RemoveAt(index);
                SaveFile(path);
            }
        }
        public Dog GetByID(string chipID)
        {
            Dog thedog = new Dog();
            int index = GetIndexByID(chipID);

            if (_dogs[index].ChipID == chipID)
            {
                thedog = _dogs[index];
            }
            return thedog;

        }

        public List<Event> GetLogs(string chipID)
        {
            List<Event> log = new List<Event>();
            Dog thedog=GetByID(chipID);
            return thedog.Logs; ;
        }

        public void AddLog(string chipID, Event newEntry, string path="default")
        {
            List<Event> log=new List<Event>();
            log=GetLogs(chipID);
            log.Add(newEntry);
            int index = 0;
            index = GetIndexByID(chipID);
            if (_dogs[index].ChipID == chipID)
            {
                _dogs[index].Logs= log;
                SaveFile(path);
            }


        }

        public List<Dog> GetAll()
        {
            return _dogs;
        }

        public void Add(Dog dog, string path = "default")
        {
            _dogs.Add(dog);
            SaveFile(path);
        }

        public void Sterilise(string chipID, string path = "default")
        {
            Dog thedog = new Dog();
            thedog=GetByID(chipID);
            if (thedog.ChipID == chipID) {
                thedog.Fertile = false;
                SaveFile(path);
            }
        }
        public string GetStatusByID(string chipID)
        {
            Dog thedog = GetByID(chipID);
            return thedog.Status;
        }

        public void ChangeStatusByID(string chipID, string status, string path = "default")
        {
            int index = 0;
            index = GetIndexByID(chipID);
            if (_dogs[index].ChipID == chipID)
            {
                _dogs[index].Status = status;
                SaveFile(path);
            }
        }


        //denne metode skal kaldes hver gang vi gerne vil trække data fra vores JSON
        private void LoadFile(string path = "default")
        {
            if (path == "default")
            {
                path = _path;
            }
            else
            {
                path += _path;
            }
            string json = File.ReadAllText(path);

            _dogs = JsonSerializer.Deserialize<List<Dog>>(json);
        }

        //denne metode skal kaldes når vi vil putte data i vores JSON
        private void SaveFile(string path = "default")
        {
            if (path == "default")
            {
                path = _path;
            }
            else
            {
                path += _path;
            }
            File.WriteAllText(path, JsonSerializer.Serialize(_dogs));
        }
    }
}

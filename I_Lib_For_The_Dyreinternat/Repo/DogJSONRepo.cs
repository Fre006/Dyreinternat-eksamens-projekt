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
    internal class DogJSONRepo:IDogRepo
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
        public Dog GetByID(string chipID)
        {
            Dog thedog= new Dog();
            for (int i = 0; i < _dogs.Count; i++)
            {
                if (_dogs[i].ChipID == chipID)
                {

                    thedog=_dogs[i];

                }
                
            }
            return thedog;

        }

        public List<Event> Getlogs(string chipID)
        {
            List<Event> log = new List<Event>();
            Dog thedog=GetByID(chipID);
            return thedog.Logs; ;
        }
        public void Addlog(string chipID, Event newEntry, string path="default")
        {
            Dog thedog = GetByID(chipID);
            thedog.Logs.Add(newEntry);
            SaveFile(path);
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

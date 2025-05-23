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
        //filename
        private IVaultAnimalJSONRepo _vaultAnimalEvent;
        private string _path = "Dog.json";
        protected List<Dog> _dogs = new List<Dog>();
        //tries to load Dog.json, if it doesn't exist creates it
        public DogJSONRepo(IVaultAnimalJSONRepo VaultEventRepo)
        {
            _vaultAnimalEvent = VaultEventRepo;
            try
            {
                LoadFile();
            }
            catch
            {
                SaveFile();
            }

        }
        //simply an internal method to get index by ID
        internal int GetIndexByID(string chipID)
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
        //Uses getindex by id, then if given chipid matches the dog in the index,
        //and if a log matches the event id, deletes the event from the log
        public void RemoveLogByID(int EventID, string Chipid)
        {
            int index = GetIndexByID(Chipid);
            if (_dogs[index].ChipID == Chipid)
            {
                foreach (Event theEvent in _dogs[index].Logs)
                {
                    if (theEvent.ID == EventID)
                    {

                        _dogs[index].Logs.Remove(theEvent);
                        SaveFile();
                    }
                }
            }

        }
        //Uses GetIndexByID, to get the index then checks wether the chipid's fit, if they do deletes the dog
        public void DeleteByID(string chipID, string path="default")
        {
            int index = GetIndexByID(chipID);
            //catches if chipID doesn't match, and then will not delete
            if (_dogs[index].ChipID == chipID)
            {
                _vaultAnimalEvent.VaultAnimal(_dogs[index]);
                _dogs.RemoveAt(index);
                SaveFile(path);
            }
        }
        //uses get index by Id to get the specific dog from the dog list using the id, if id isn't found returns an empty dog
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
        //makes a logs list, sends chipID to getbyID, returns the logs
        public List<Event> GetLogs(string chipID)
        {
            List<Event> log = new List<Event>();
            Dog thedog=GetByID(chipID);
            return thedog.Logs; ;
        }
        //Uses GetLogs, to get the log of the animal, adds the entry to the list, then uses GetByIndex,
        //checks if the ChipId fits, if it does saves the new logs to the dog then saves the file
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
        //simply returns all dogs
        public List<Dog> GetAll()
        {
            return _dogs;
        }
        //Adds a dog, then saves the file
        public void Add(Dog dog, string path = "default")
        {
            _dogs.Add(dog);
            SaveFile(path);
        }
        //Changes the fertile bool incase the dog gets steriliset
        public void Sterilise(string chipID, string path = "default")
        {
            Dog thedog = new Dog();
            thedog=GetByID(chipID);
            if (thedog.ChipID == chipID) {
                thedog.Fertile = false;
                SaveFile(path);
            }
        }
        //Simply uses GetByID, then returns, the status
        public string GetStatusByID(string chipID)
        {
            Dog thedog = GetByID(chipID);
            return thedog.Status;
        }
        //Uses GetIndexByID, then checks wether chipID fits, the dog in the index
        //if it does, saves the Status and saves the file
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
        internal void LoadFile(string path = "default")
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
        internal void SaveFile(string path = "default")
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

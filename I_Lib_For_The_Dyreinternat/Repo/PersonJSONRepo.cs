using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public class PersonJSONRepo : IPersonJSONRepo
    {

        private int _iD = 0;
        private string _path = "IDPerson.json";
        private List<Person> _person = new List<Person>();
        private List<Costumer> _costumer = new List<Costumer>();
        private List<Worker> _worker = new List<Worker>();
        public PersonJSONRepo()
        {

            try //This try catch tries to load the file and if it fails it will save a new empty file instead
            {
                LoadFile();
            }
            catch
            {
                SaveFile();
            }
            LoadAllPersons(); //No matter what it will load all person
        }
        private void LoadAllPersons()
        {
            try
            {
                LoadCostumer(); //Tries to load, but if it fails it wont crash the code

            }
            catch
            {
            }
            try
            {
                LoadWorker();

            }
            catch
            {
            }
            foreach (Costumer costumer in _costumer) //Adds all costumer to the person list
            {
                _person.Add(costumer);
            }
            foreach (Worker worker in _worker) //Adds all Workers to the person list
            {
                _person.Add(worker);
            }
        }
        public List<Person> GetAll()
        {
            return _person;
        }
        public int GiveID(int ThisID) //gives workers and costumers id
        {
            _iD++; 
            ThisID = _iD;
            SaveFile();
            return ThisID;
        }
        private void LoadFile(string path = "default") //Loads file with a default path
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

            _iD = JsonSerializer.Deserialize<int>(json);
        }
        private void SaveFile(string path = "default") //Saves file with a default path
        {
            if (path == "default")
            {
                path = _path;
            }
            else
            {
                path += _path;
            }
            File.WriteAllText(path, JsonSerializer.Serialize(_iD));
        }
        private void LoadCostumer() //Loads the costumer repo
        {
            string path = "Costumer.json";
            string json = File.ReadAllText(path);

            _costumer = JsonSerializer.Deserialize<List<Costumer>>(json);
        }

        private void LoadWorker() //Loads the Worker Repo
        {
            string path = "Worker.json";
            string json = File.ReadAllText(path);

            _worker = JsonSerializer.Deserialize<List<Worker>>(json);
        }
        private int GetIndexByID(int ID) //Allow you the get the index based off of the id
        {
            //returns 0 if chipID isn't found
            int index = 0;
            for (int i = 0; i < _person.Count; i++) //For loop looking through all people (workers/costumers)
            {
                if (_person[i].Id == ID)
                {

                    index = i;

                }
            }
            return index;
        }
        public Person GetByID(int ID) //Get's the worker or costumer based off of the ID
        {
            Person thePerson = new Person();
            int index = GetIndexByID(ID); //Get's the index based off id

            if (_person[index].Id == ID) //Double checks we have the correct person
            {
                thePerson = _person[index]; //Take the worker/costumer object and put it into a new object
            }
            return thePerson; //Returns this new object

        }
    }
}

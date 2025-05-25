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

            try
            {
                LoadFile();
            }
            catch
            {
                SaveFile();
            }
            LoadAllPersons();
        }
        private void LoadAllPersons()
        {
            try
            {
                LoadCostumer();

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
            foreach (Costumer costumer in _costumer)
            {
                _person.Add(costumer);
            }
            foreach (Worker worker in _worker)
            {
                _person.Add(worker);
            }
        }
        public List<Person> GetAll()
        {
            return _person;
        }
        public int GiveID(int ThisID)
        {
            _iD++;
            ThisID = _iD;
            SaveFile();
            return ThisID;
        }
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

            _iD = JsonSerializer.Deserialize<int>(json);
        }
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
            File.WriteAllText(path, JsonSerializer.Serialize(_iD));
        }
        private void LoadCostumer()
        {
            string path = "Costumer.json";
            string json = File.ReadAllText(path);

            _costumer = JsonSerializer.Deserialize<List<Costumer>>(json);
        }

        private void LoadWorker()
        {
            string path = "Worker.json";
            string json = File.ReadAllText(path);

            _worker = JsonSerializer.Deserialize<List<Worker>>(json);
        }
        private int GetIndexByID(int ID)
        {
            //returns 0 if chipID isn't found
            int index = 0;
            for (int i = 0; i < _person.Count; i++)
            {
                if (_person[i].Id == ID)
                {

                    index = i;

                }
            }
            return index;
        }


        public Person GetByID(int ID)
        {
            Person thePerson = new Person();
            int index = GetIndexByID(ID);

            if (_person[index].Id == ID)
            {
                thePerson = _person[index];
            }
            return thePerson;

        }
    }
}

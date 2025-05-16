using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal class CatJSONRepo: ICatRepo
    {
        private string _path="Cat.json";
        protected List<Cat> _cats = new List<Cat>();

        public CatJSONRepo()
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
        public Cat GetByID(string chipID)
        {
            Cat thecat = new Cat();
            for (int i = 0; i < _cats.Count; i++)
            {
                if (_cats[i].ChipID == chipID)
                {

                    thecat = _cats[i];

                }

            }
            return thecat;

        }

        public List<Event> GetLogs(string chipID)
        {
            List<Event> log = new List<Event>();
            Cat thecat = GetByID(chipID);
            return thecat.Logs; ;
        }
        public void AddLog(string chipID, Event newEntry, string path = "default")
        {
            GetLogs(chipID).Add(newEntry);
            SaveFile(path);
        }

        public List<Cat> GetAll()
        {
            return _cats;
        }

        public void Add(Cat cat,string path="default")
        {
            _cats.Add(cat);
            SaveFile(path);
        }


        //denne metode skal kaldes hver gang vi gerne vil trække data fra vores JSON
        private void LoadFile(string path="default")
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

            _cats = JsonSerializer.Deserialize<List<Cat>>(json);
        }

        //denne metode skal kaldes når vi vil putte data i vores JSON
        private void SaveFile(string path="default")
        {
            if (path == "default") { 
            path= _path;
            }
            else
            {
                path += _path;
            }
            File.WriteAllText(path, JsonSerializer.Serialize(_cats));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
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
        public int GetIndexByID(string chipID)
        {
            //returns 0 if chipID isn't found
            int index= 0;
            for (int i = 0; i < _cats.Count; i++)
            {
                if (_cats[i].ChipID == chipID)
                {

                    index=i;

                }
            }   
            return index;
        }
        public void DeleteByID(string chipID, string path="default")
        {
            int index=GetIndexByID(chipID);
            //catches if chipID doesn't match, and then will not delete
            if (_cats[index].ChipID == chipID) { 
            _cats.RemoveAt(index);
            SaveFile(path);
            }
        }
        public Cat GetByID(string chipID)
        {
            Cat thecat = new Cat();
            int index=GetIndexByID(chipID);

            if (_cats[index].ChipID == chipID)
            {
                thecat = _cats[index];
            }
            return thecat;

        }


        public List<Event> GetLogs(string chipID)
        {
            Cat thecat = GetByID(chipID);
            return thecat.Logs; ;
        }
        public void AddLog(string chipID, Event newEntry, string path = "default")
        {
            List<Event> log = new List<Event>();
            log = GetLogs(chipID);
            log.Add(newEntry);
            int index = 0;
            index = GetIndexByID(chipID);
            if (_cats[index].ChipID == chipID)
            {
                _cats[index].Logs = log;
                SaveFile(path);
            }


        }


        public string GetStatusByID(string chipID)
        {
            Cat thecat = GetByID(chipID);
            return thecat.Status;
        }
        
        public void ChangeStatusByID(string chipID, string status, string path = "default")
        {
            int index = 0;
            index = GetIndexByID(chipID);
            if (_cats[index].ChipID == chipID)
            {
                _cats[index].Status = status;
                SaveFile(path);
            }
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
        public void Sterilise(string chipID, string path="default")
        {
            Cat thecat = new Cat();
            thecat = GetByID(chipID);
            if (thecat.ChipID == chipID)
            {
                thecat.Fertile = false;
                SaveFile(path);
            }

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

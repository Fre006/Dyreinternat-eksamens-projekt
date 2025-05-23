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
    public class CatJSONRepo: ICatJSONRepo
    {
        //_path is the file name
        private string _path="Cat.json";
        protected List<Cat> _cats = new List<Cat>();
        //tries to load Cat.json, if it doesn't exist then it creates it
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
        //simply an internal method to find the cats index in the _cats list,
        //in case it can't find the id in the list returns the 0'th index
        internal int GetIndexByID(string chipID)
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
        //Uses getindex by id, then if given chipid matches the cat in the index,
        //and if a log matches the event id, deletes the event from the log
        public void RemoveLogByID(int EventID, string Chipid)
        {
            int index=GetIndexByID(Chipid);
            if (_cats[index].ChipID==Chipid)
            {
                foreach (Event theEvent in _cats[index].Logs)
                {
                    if (theEvent.ID == EventID)
                    {
                        _cats[index].Logs.Remove(theEvent);
                        SaveFile();
                    }
                }
            }

        }

        //gets the cats index in _cats using the chipID, then checks if the cat is right,
        //in case it couldn't find the cat, if it is right, deletes the cat, then saves the cats file, if it isn't does nothing
        public void DeleteByID(string chipID, string path="default")
        {
            int index=GetIndexByID(chipID);
            //catches if chipID doesn't match, and then will not delete
            if (_cats[index].ChipID == chipID) { 
            _cats.RemoveAt(index);
            SaveFile(path);
            }
        }
        //Finds, the cat using GetIndexByID, then returns that cat, in case it can't find the cat, returns a null cat
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
        //Finds the cat using GetByID, then returns it's log
        public List<Event> GetLogs(string chipID)
        {
            Cat thecat = GetByID(chipID);
            return thecat.Logs; ;
        }
        //uses GetLogs, to get the log, then adds the new entry event,
        //checks, gets the indexbyid, checks wether the chipid fits the index,
        //if it oes saves the new log to the cat then saves the file
        public void AddLog(string chipID, Event newEntry, string path = "default")
        {
            List<Event> log = new List<Event>();
            log = GetLogs(chipID);
            log.Add(newEntry);
            int index=0;
            index = GetIndexByID(chipID);
            if (_cats[index].ChipID == chipID)
            {
                _cats[index].Logs = log;
                SaveFile(path);
            }


        }

        //uses getbyID, then returns that cats status
        public string GetStatusByID(string chipID)
        {
            Cat thecat = GetByID(chipID);
            return thecat.Status;
        }
        //uses GetIndexByID, then checks wether the chipid fits,
        //if it does saves that cats status to the cat then saves the cats file 
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

        //simply returns all cats
        public List<Cat> GetAll()
        {
            return _cats;
        }
        //simply adds a cat
        public void Add(Cat cat,string path="default")
        {
            _cats.Add(cat);
            SaveFile(path);
        }
        //changes the fertile statys of the cat to false, in case you sterilise the cat
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

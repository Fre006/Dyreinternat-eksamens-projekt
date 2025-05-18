using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;


namespace Lib.Repo
{
    public class WorkerJSONRepo : IWorkerJSONRepo
    {
        List<Worker> _workers = new List<Worker>();

        public WorkerJSONRepo()
        {
            try
            {
                LoadFile();
                Debug.WriteLine("Successfully loaded Worker Json File");
            }
            catch
            {
                Debug.WriteLine("Failed to load Worker Json file");
                //SaveFile();
            }
        }

        private string _path = @"worker.json";
        private void LoadFile()
        {
            string json = File.ReadAllText(_path);
            _workers = JsonSerializer.Deserialize<List<Worker>>(json);

        }
        private void SaveFile()
        {
            File.WriteAllText(_path, JsonSerializer.Serialize(_workers));
            Debug.WriteLine("saved file");
        }
       
        public void Add(Worker worker)
        {
            _workers.Add(worker);
            Debug.WriteLine("Successfully added worker");
            SaveFile();
        }
        public void Delete(Worker worker)
        {
            _workers.Remove(worker);
            Debug.WriteLine("Successfully removed worker");
            SaveFile();
        }
        public List<Worker> GetAll() 
        {
            return _workers; 
        }
        public Worker GetByID(string id)
        {
            foreach (Worker worker in _workers) 
            {
                if (worker.Id == id)
                {
                    return worker;
                }
            }
            return null;

        }

        public void Edit(string name, Worker worker1)
        {
            foreach (Worker worker in _workers)
            {
                if (worker.Name == name)
                {
                    worker.Role = worker1.Role;
                    worker.PhoneNumber = worker1.PhoneNumber;
                    worker.Birthdate = worker1.Birthdate;
                }                    
                SaveFile();
            }
        }
    }
       
}


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
        private IPersonJSONRepo _personRepo;
        List<Worker> _workers = new List<Worker>();

        public WorkerJSONRepo(IPersonJSONRepo PersonRepo)
        {
            _personRepo = PersonRepo;
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

        private string _path = "Worker.json";
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
            int newid = _personRepo.GiveID(worker.Id);
            worker.Id = newid;
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
        public Worker GetByID(int id)
        {
            Worker theworker=new Worker();
            foreach (Worker worker in _workers) 
            {
                if (worker.Id == id)
                {
                    theworker=worker;
                    
                }
            }
            return theworker;

        }
        public Worker GetByName(string name)
        {
            foreach (Worker worker in _workers) 
            {
                if (worker.Name == name)
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
                    SaveFile();
                }                    
            }
        }
    }
       
}


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
    public class WorkerJSONRepo : IWorkerJSONRepo //Implements the WorkerJSONRepo interface
    {
        private IPersonJSONRepo _personRepo;
        List<Worker> _workers = new List<Worker>();

        public WorkerJSONRepo(IPersonJSONRepo PersonRepo)
        {
            _personRepo = PersonRepo; //Gives us access to the PersonRepo
            try         //This try catch tries to load the file and if it fails it will save a new empty file instead
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
        //This method loads the file based off of the given path and puts into our private _costumer list
        private void LoadFile()
        {
            string json = File.ReadAllText(_path);
            _workers = JsonSerializer.Deserialize<List<Worker>>(json);

        }
        //Saves our list in a json file
        private void SaveFile()
        {
            File.WriteAllText(_path, JsonSerializer.Serialize(_workers));
            Debug.WriteLine("saved file");
        }
       
        public void Add(Worker worker) //Add method
        {
            int newid = _personRepo.GiveID(worker.Id);  //Creates a new ID
            worker.Id = newid;                          //Gives the costumer object this new ID
            _workers.Add(worker);                       //Adds the Costumer to the list
            Debug.WriteLine("Successfully added worker");
            SaveFile();     //Saves the list
        }
        public void Delete(Worker worker)
        { 
            _workers.Remove(worker); //removes the worker you chose from the list
            //Debug.WriteLine("Successfully removed worker");
            SaveFile(); //Saves the file
        }
        public List<Worker> GetAll() //Get's all workers
        {
            return _workers; //Returns the full Worker list
        }
        public Worker GetByID(int id)
        {
            Worker theworker=new Worker(); //creates a new empty worker
            foreach (Worker worker in _workers) //Looks through each worker
            {
                if (worker.Id == id) //Checks if the IDs match
                {
                    theworker=worker; //Puts the worker into a new object
                }
            }
            return theworker; //Return the new object

        }
        public Worker GetByName(string name) 
        {
            foreach (Worker worker in _workers) //Loops through each worker in the list
            {
                if (worker.Name == name) //Checks if the name matches the one you sent
                {
                    return worker; //Returns the worker
                }
            }
            return null;

        }

        public void Edit(string name, Worker worker1) //You give the name of the worker you want to edit, and a worker object with all the properties
        {
            foreach (Worker worker in _workers) //Loops through all workers
            {
                if (worker.Name == name) //If the current worker is the same as the name you sent
                {
                    worker.Role = worker1.Role; //Changes all the properties one by one
                    worker.PhoneNumber = worker1.PhoneNumber;
                    worker.Birthdate = worker1.Birthdate;
                    SaveFile(); //Saves the file
                }                    
            }
        }
    }
       
}


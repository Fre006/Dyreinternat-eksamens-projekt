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
        List<Worker> workers = new List<Worker>();

        public WorkerJSONRepo()
        {
            try
            {
                LoadFile();
            }
            catch 
            {
                Console.WriteLine("Failed to Load File");
                SaveFile();
            }
        }

        private string _path = "Worker.json";
        private void LoadFile()
        {
            string json = File.ReadAllText(_path);
            workers = JsonSerializer.Deserialize<List<Worker>>(json);

        }
        private void SaveFile()
        {
            File.WriteAllText(_path, JsonSerializer.Serialize(workers));
        }
       
        public void Add(Worker worker)
        {
            workers.Add(worker);
            Debug.WriteLine("Successfully added worker");
            SaveFile();
        }
        public List<Worker> GetAll() 
        {
            return workers; 
        }
        
       
    }

}

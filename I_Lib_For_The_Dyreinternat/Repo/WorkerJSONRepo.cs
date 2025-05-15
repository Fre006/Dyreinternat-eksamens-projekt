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
                Debug.WriteLine("Failed to Load File");
            }
        }

        private void LoadFile()
        {
            string path = @"Worker.json";
            string json = File.ReadAllText(path);
            workers = JsonSerializer.Deserialize<List<Worker>>(json);

        }
        private void SaveFile()
        {
            string path = @"Worker.json";
            File.WriteAllText(path, JsonSerializer.Serialize(workers));
        }
       
        public  void Add(Worker worker)
        {
            workers.Add(worker);
            Debug.WriteLine("Successfully added worker");
            SaveFile();
        }
        public  List<Worker> GetAll() 
        {
            return workers; 
        }
        
       
    }

}

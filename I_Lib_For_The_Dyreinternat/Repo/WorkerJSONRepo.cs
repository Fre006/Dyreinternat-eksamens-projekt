using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Interface;
using Lib.Model;

namespace Lib.Repo
{
    internal class WorkerJSONRepo : IWorkerJSONRepo
    {
        List<Person> workers = new List<Person>();

        public WorkerJSONRepo()
        {
            //LoadFile();
        }

        private void LoadFile()
        {
            string path = @"..\..\..\JSON\Worker.json";
            string json = File.ReadAllText(path);
            workers = JsonSerializer.Deserialize<List<Person>>(json);

        }
        private void SaveFile()
        {
            string path = @"..\..\..\JSON\Worker.json";
            File.WriteAllText(path, JsonSerializer.Serialize(workers));
        }
        public string ToString()
        {
            return "fish";
        }

        public  void Add(Person worker)
        {
            workers.Add(worker);
            //SaveFile();
        }
        public  List<Person> GetAll() 
        {
            return workers; 
        }
        
        
    }

}

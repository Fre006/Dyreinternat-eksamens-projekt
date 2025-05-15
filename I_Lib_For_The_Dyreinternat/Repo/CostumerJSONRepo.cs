using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal class CostumerJSONRepository : ICostumerJSONRepo
    {
        public List<Costumer> _costumer = new List<Costumer>();

        public CostumerJSONRepository()
        {
            LoadFile();
        }

        //denne metode skal kaldes hver gang vi gerne vil trække data fra vores JSON
        private void LoadFile()
        {
            string path = "Costumer.json";
            string json = File.ReadAllText(path);

            _costumer = JsonSerializer.Deserialize<List<Costumer>>(json);
        }

        public virtual void Add(Costumer costumer)
        {
            _costumer.Add(costumer);
            SaveFile();
        }

        //denne metode skal kaldes når vi vil putte data i vores JSON
        private void SaveFile()
        {
            string path = "Costumer.json";
            File.WriteAllText(path, JsonSerializer.Serialize(_costumer));
        }

        public List<Costumer> GetAll()
        {
            return _costumer;
        }
    }
}

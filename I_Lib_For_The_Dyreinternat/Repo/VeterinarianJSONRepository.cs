using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal class VeterinarianJSONRepository : IVeterinarianJSONRepository
    {
        public VeterinarianJSONRepository()
        {
            LoadFile();
        }

        //denne metode skal kaldes hver gang vi gerne vil trække data fra vores JSON
        private void LoadFile()
        {
            string path = "Veterinarian.json";
            string json = File.ReadAllText(path);

            _veterinarian = JsonSerializer.Deserialize<List<VeterinarianVisit>>(json);
        }

        public virtual void Add(VeterinarianVisit veterinarian)
        {
            _veterinarian.Add(veterinarian);
            SaveFile();
        }

        //denne metode skal kaldes når vi vil putte data i vores JSON
        private void SaveFile()
        {
            string path = "Veterinarian.json";
            File.WriteAllText(path, JsonSerializer.Serialize(_veterinarian));
        }

        public List<VeterinarianVisit> _veterinarian = new List<VeterinarianVisit>();

        public List<VeterinarianVisit> GetAll()
        {
            return _veterinarian;
        }
    }
}

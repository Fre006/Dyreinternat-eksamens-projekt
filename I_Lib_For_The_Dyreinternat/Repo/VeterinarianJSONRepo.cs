using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public class VeterinarianJSONRepo : IVeterinarianJSONRepo
    {
        private IEventJSONRepo _eventRepo;
        public VeterinarianJSONRepo(IEventJSONRepo EventRepo)
        {
            _eventRepo = EventRepo;
            try
            {
                LoadFile();
            }
            catch
            { 
                SaveFile();
            }
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
            veterinarian._costumers = new List<Costumer> { };
            int newid = _eventRepo.GiveID(veterinarian.ID);
            veterinarian.ID = newid;
            _veterinarian.Add(veterinarian);
            SaveFile();
            _eventRepo.AddEventToLogViaID(veterinarian.ID);

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

        public VeterinarianVisit GetByName(string name)
        {
            foreach (VeterinarianVisit veterinarian in _veterinarian)
            {
                if (name == veterinarian.Name)
                {
                    return veterinarian;
                }
            }
            return null;
        }
        public int GetIndexById(int id)
        {
            int index = 0;
            for (int i = 0; i < _veterinarian.Count; i++)
            {
                if (_veterinarian[i].ID == id)
                {
                    index = i;
                }
            }
            return index;
        }
        public void DeleteById(int id)
        {
            int index = GetIndexById(id);
            if (_veterinarian[index].ID == id)
            {
                _veterinarian.RemoveAt(index);
                SaveFile();
            }
        }
    }
}

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
        private IVaultEventJSONRepo _vaultEventRepo;
        private IEventJSONRepo _eventRepo;
        public VeterinarianJSONRepo(IEventJSONRepo EventRepo, IVaultEventJSONRepo VaultEventRepo)
        {
            _eventRepo = EventRepo;
            _vaultEventRepo = VaultEventRepo;
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
                _vaultEventRepo.VaultEvent(_veterinarian[index]);
                _veterinarian.RemoveAt(index);
                SaveFile();
            }
        }
        public void Edit(int id, string name, string description, int customerCap, int animalCap, string location, DateTime start, DateTime stop, string veterinarian)
        {
            int index = GetIndexById(id);
            if (_veterinarian[index].ID == id)
            {
                _veterinarian[index].Name = name;
                _veterinarian[index].Description = description;
                _veterinarian[index].CostumerCap = customerCap;
                _veterinarian[index].AnimalCap = animalCap;
                _veterinarian[index].Location = location;
                _veterinarian[index].Start = start;
                _veterinarian[index].Stop = stop;
                _veterinarian[index].Veterinarian = veterinarian;
            }
        }
        public void RegAnimal(int EventId, string AnimalId)
        {
            try
            {
                int index = GetIndexById(EventId);
                Animal animal = _eventRepo.GetAnimalByID(AnimalId);
                _veterinarian[index]._animals.Add(animal);
            }
            catch
            {
                Console.WriteLine("Animal or event id is incorrect");
            }
        }
        public void RegWorker(int EventId, int WorkerId)
        {
            try
            {
                int index = GetIndexById(EventId);
                Worker worker = _eventRepo.GetWorkerByID(WorkerId);
                _veterinarian[index].Workers.Add(worker);
            }
            catch
            {
                Console.WriteLine("Worker or event id is incorrect");
            }
        }
        public void DeRegWorker(int EventId, int WorkerId)
        {
            try
            {
                int index = GetIndexById(EventId);

                if (_veterinarian[index].ID == EventId)
                {
                    foreach (Worker theworker in _veterinarian[index].Workers)
                    {
                        if (theworker.Id == WorkerId)
                        {
                            _veterinarian[index].Workers.Remove(theworker);
                            SaveFile();
                        }
                    }
                }
                else Console.WriteLine("Employee is not registeret to this event");
            }
            catch
            {
                Console.WriteLine("Worker or event id is incorrect");
            }
        }
        public void DeRegAnimal(int EventId, string AnimalId)
        {
            try
            {
                int index = GetIndexById(EventId);
                if (_veterinarian[index].ID == EventId)
                {
                    foreach (Animal theanimal in _veterinarian[index].Animals)
                    {
                        if (theanimal.ChipID == AnimalId)
                        {
                            _veterinarian[index].Animals.Remove(theanimal);
                            SaveFile();
                        }
                    }
                }
                else Console.WriteLine("Animal is not registeret to this event");
            }
            catch
            {
                Console.WriteLine("Animal or event id is incorrect");
            }
        }
    }
}

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
        //instansvariabler
        private IVaultEventJSONRepo _vaultEventRepo;
        private IEventJSONRepo _eventRepo;
        private List<VeterinarianVisit> _veterinarian = new List<VeterinarianVisit>();

        //Construktor for VeterinarianJSONRepo
        //This forces the newest version of the JSON files to be loaded which reduces the risk problems with those files.
        //Additionally it also fills the instansvariables that are used later to access methods from some of the other Classes.
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

        //This method runs everytime we get things from the JSON files
        private void LoadFile()
        {
            string path = "Veterinarian.json";
            string json = File.ReadAllText(path);

            _veterinarian = JsonSerializer.Deserialize<List<VeterinarianVisit>>(json);
        }

        //This method adds ID's to new Booking objects and places them in the list of all Booking.
        //Additionally it also saves an event file to the log used in Visiting logs on the Animals.
        public void Add(VeterinarianVisit veterinarian)
        {
            veterinarian._costumers = new List<Costumer> { };
            int newid = _eventRepo.GiveID(veterinarian.ID);
            veterinarian.ID = newid;
            _veterinarian.Add(veterinarian);
            SaveFile();
            _eventRepo.AddEventToLogViaID(veterinarian.ID);

        }
        //This method is used everytime we wish to save a new version of the activity list to the JSON files.
        private void SaveFile()
        {
            string path = "Veterinarian.json";
            File.WriteAllText(path, JsonSerializer.Serialize(_veterinarian));
        }

        //Method for getting a List of all VeterinarianVisit objects
        public List<VeterinarianVisit> GetAll()
        {
            return _veterinarian;
        }

        //This Method is used to find objects in the code that have a specific name.
        //It also works as a filter showing all objects with that name 
        public List<VeterinarianVisit> GetByName(string name)
        {
                List<VeterinarianVisit> FilteredList = new();
                foreach (VeterinarianVisit veterinarian in _veterinarian)
                {
                    if (name == veterinarian.Name)
                    {
                        FilteredList.Add(veterinarian);
                    }
                }
                return FilteredList;
        }

        //This Method is used to get the specific index number from the List that corresponds to the id of a given VeterinarianVisit.
        //it is used in many methods to make sure we only get the exact object we want and nothing else.
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

        //Method for deleting an object based on its unique ID.
        //it also updates the JSON files and adds the removed files to a dictionary where it is kept incase it is needed later.
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

        //Method for editing the arguments of an object that are not ID or lists of objects.
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

        //Method for adding Specific animal objects to the List of animals in the arguments of specific VeterinarianVisit.
        //it also updates JSON files and adds the change to the Logs of the animal.
        //it also uses the animalCap arguments to limit the amount of animals that can be added to each VeterinarianVisit.
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

        //Method for adding Specific Worker objects to the List of workers in the arguments of specific Activities.
        //it also updates JSON files.
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

        //Method for removing Specific Worker objects to the List of workers in the arguments of specific Activities.
        //it also updates JSON files.
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

        //Method for removing Specific Animal objects to the List of workers in the arguments of specific Activities.
        //it also updates JSON files.
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

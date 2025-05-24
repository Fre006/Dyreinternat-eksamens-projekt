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
    public class BookingJSONRepo : IBookingJSONRepo
    {
        //Instansvariables
        private IEventJSONRepo _eventRepo;
        private IVaultEventJSONRepo _vaultEventRepo;
        private List<Booking> _booking = new List<Booking>();

        //Construktor for BookingJSONRepo
        //This forces the newest version of the JSON files to be loaded which reduces the risk problems with those files.
        //Additionally it also fills the instansvariables that are used later to access methods from some of the other Classes.
        public BookingJSONRepo(IEventJSONRepo bookingRepo, IVaultEventJSONRepo VaultEventRepo)
        {
            _eventRepo = bookingRepo;
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
            string path = "Booking.json";
            string json = File.ReadAllText(path);

            _booking = JsonSerializer.Deserialize<List<Booking>>(json);
        }

        //This method adds ID's to new activity objects and places them in the list of all activities.
        //Additionally it also saves an event file to the log used in Visiting logs on the Animals.
        public virtual void Add(Booking booking)
        {
            int newid=_eventRepo.GiveID(booking.ID);
            booking.ID = newid;
            _booking.Add(booking);
            SaveFile();
            _eventRepo.AddEventToLogViaID(booking.ID);

        }

        //This method is used everytime we wish to save a new version of the activity list to the JSON files.
        private void SaveFile()
        {
            string path = "Booking.json";
            File.WriteAllText(path, JsonSerializer.Serialize(_booking));
        }

        //This Method is used to find objects in the code that have a specific name.
        //It also works as a filter showing all objects with that name 
        public Booking GetByName(string name)
        {
            foreach (Booking booking in _booking)
            {
                if (name == booking.Name)
                {
                    return booking;
                }
            }
            return null;
        }

        //This Method is used to get the specific index number from the List that corresponds to the id of a given Booking.
        //it is used in many methods to make sure we only get the exact object we want and nothing else.
        public int GetIndexById(int id)
        {
            int index = 0;
            for (int i = 0; i < _booking.Count; i++)
            {
                if (_booking[i].ID == id)
                {
                    index = i;
                }
            }
            return index;
        }

        //Method for getting a List of all Booking objects
        public List<Booking> GetAll()
        {
            return _booking;
        }

        //Method for deleting an object based on its unique ID.
        //it also updates the JSON files and adds the removed files to a dictionary where it is kept incase it is needed later.
        public void DeleteById(int id)
        {
            int index = GetIndexById(id);
            if (_booking[index].ID == id)
            {
                _vaultEventRepo.VaultEvent(_booking[index]);
                _booking.RemoveAt(index);
                SaveFile();
            }
        }

        //Method for editing the arguments of an object that are not ID or lists of objects.
        public void Edit(int id, string name, string description, int customerCap, int animalCap, string location, DateTime start, DateTime stop)
        {
            int index = GetIndexById(id);
            if (_booking[index].ID == id)
            {
                _booking[index].Name = name;
                _booking[index].Description = description;
                _booking[index].CostumerCap = customerCap;
                _booking[index].AnimalCap = animalCap;
                _booking[index].Location = location;
                _booking[index].Start = start;
                _booking[index].Stop = stop;
            }
        }

        //Method for adding Specific animal objects to the List of animals in the arguments of specific Bookings.
        //it also updates JSON files and adds the change to the Logs of the animal.
        //it also uses the animalCap arguments to limit the amount of animals that can be added to each Booking
        public void RegAnimal(int EventId, string AnimalId)
        {
            try
            {
                int index = GetIndexById(EventId);
                Animal animal = _eventRepo.GetAnimalByID(AnimalId);
                if (_booking[index].Animals.Count < _booking[index].AnimalCap)
                {
                    _booking[index]._animals.Add(animal);
                }
                else Console.WriteLine("No more animals can attend this event");
            }
            catch
            {
                Console.WriteLine("Animal or event id is incorrect");
            }
        }

        //Method for adding Specific Costumers objects to the List of animals in the arguments of specific Bookings.
        //it also updates JSON files.
        //it also uses the costumerCap arguments to limit the amount of Costumers that can be added to each Booking
        public void RegCostumer(int EventId, int CostumerId)
        {
            try
            {
                int index = GetIndexById(EventId);
                Costumer costumer = _eventRepo.GetCostumerByID(CostumerId);
                if (_booking[index].Costumers.Count < _booking[index].CostumerCap)
                {
                    _booking[index]._costumers.Add(costumer);
                }
                else Console.WriteLine("No more Costumers can attend this event");
            }
            catch
            {
                Console.WriteLine("costumer or event id is incorrect");
            }
        }

        //Method for adding Specific Worker objects to the List of workers in the arguments of specific Booking.
        //it also updates JSON files.
        public void RegWorker(int EventId, int WorkerId)
        {
            try
            {
                int index = GetIndexById(EventId);
                Worker worker = _eventRepo.GetWorkerByID(WorkerId);
                _booking[index].Workers.Add(worker);
            }
            catch
            {
                Console.WriteLine("Worker or event id is incorrect");
            }
        }

        //Method for removing Specific Worker objects to the List of workers in the arguments of specific Booking.
        //it also updates JSON files.
        public void DeRegWorker(int EventId, int WorkerId)
        {
            try
            {
                int index = GetIndexById(EventId);
                
                if (_booking[index].ID == EventId)
                {
                    foreach (Worker theworker in _booking[index].Workers)
                    {
                        if (theworker.Id == WorkerId)
                        {
                            _booking[index].Workers.Remove(theworker);
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

        //Method for removing Specific Animal objects to the List of workers in the arguments of specific Booking.
        //it also updates JSON files.
        public void DeRegAnimal(int EventId, string AnimalId)
        {
            try
            {
                int index = GetIndexById(EventId);
                if (_booking[index].ID == EventId)
                {
                    foreach (Animal theanimal in _booking[index].Animals)
                    {
                        if (theanimal.ChipID == AnimalId)
                        {
                            _booking[index].Animals.Remove(theanimal);
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

        //Method for removing Specific Costumer objects to the List of workers in the arguments of specific Booking.
        //it also updates JSON files.
        public void DeRegCostumer(int EventId, int CostumerId)
        {
            try
            {
                int index = GetIndexById(EventId);

                if (_booking[index].ID == EventId)
                {
                    foreach (Costumer thecostumer in _booking[index].Costumers)
                    {
                        if (thecostumer.Id == CostumerId)
                        {
                            _booking[index].Costumers.Remove(thecostumer);
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
    }
}

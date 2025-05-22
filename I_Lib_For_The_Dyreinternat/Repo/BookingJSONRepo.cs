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
        private IEventJSONRepo _eventRepo;
        public List<Booking> _booking = new List<Booking>();
        public BookingJSONRepo(IEventJSONRepo bookingRepo)
        {
            _eventRepo = bookingRepo;
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
            string path = "Booking.json";
            string json = File.ReadAllText(path);

            _booking = JsonSerializer.Deserialize<List<Booking>>(json);
        }

        public virtual void Add(Booking booking)
        {
            int newid=_eventRepo.GiveID(booking.ID);
            booking.ID = newid;
            _booking.Add(booking);
            SaveFile();
            _eventRepo.AddEventToLogViaID(booking.ID);

        }

        //denne metode skal kaldes når vi vil putte data i vores JSON
        private void SaveFile()
        {
            string path = "Booking.json";
            File.WriteAllText(path, JsonSerializer.Serialize(_booking));
        }
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

        public List<Booking> GetAll()
        {
            return _booking;
        }

        public void DeleteById(int id)
        {
            int index = GetIndexById(id);
            if (_booking[index].ID == id)
            {
                _booking.RemoveAt(index);
                SaveFile();
            }
        }
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
        public void DeRegWorker(int EventId, int WorkerId)
        {
            try
            {
                int index = GetIndexById(EventId);
                if (_booking[index].ID == WorkerId)
                {
                    int remove = _booking[index].ID;
                    _booking[index].Workers.RemoveAt(remove);
                }
                else Console.WriteLine("Employee is not registeret to this event");
            }
            catch
            {
                Console.WriteLine("Worker or event id is incorrect");
            }
        }
        public void DeRegAnimal(int EventId, int AnimalId)
        {
            try
            {
                int index = GetIndexById(EventId);
                if (_booking[index].ID == AnimalId)
                {
                    int remove = _booking[index].ID;
                    _booking[index].Workers.RemoveAt(remove);
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Repo;
using Lib.Services;
using System.Diagnostics;

namespace Lib.Repo
{
    public class EventJSONRepo:IEventJSONRepo
    {

        private string _path = "ID.json";
        private List<Event> _events=new List<Event>();
        private List<Booking> _bookings=new List<Booking>();
        private List<VeterinarianVisit> _vets=new List<VeterinarianVisit>();
        private List<TheActivity> _activities=new List<TheActivity>();
        private int _iD = 0;
        private IAnimalRepo _animalRepo;
        public EventJSONRepo(IAnimalRepo AnimalRepo)
        {

            try
            {
                LoadFile();
            }
            catch
            {
                SaveFile();
            }
            _animalRepo = AnimalRepo;
            LoadAllEvents();
        }

        private void LoadAllEvents()
        {
            _events = new List<Event>();
            try
            {
                LoadActivities();

            }
            catch
            {
            }
            try
            {
                LoadBookings();

            }
            catch
            {
            }
            try
            {
                LoadVets();

            }
            catch
            {
            }
            foreach (VeterinarianVisit vet in _vets)
            {
                _events.Add(vet);
            }
            foreach (Booking booking in _bookings)
            {
                _events.Add(booking);
            }
            foreach (TheActivity activity in _activities)
            {
                _events.Add(activity);
            }

        }


        public void AddEventToLog(Event theevent)
        {

            Debug.WriteLine("amount of events:"+_events.Count);
            foreach (Animal animal in theevent.Animals)
            {
                _animalRepo.AddLog(animal.ChipID, theevent);
            }
        }

        public Event GetEventByID(int id)
        {
            Event Event=new Event();
            foreach(Event theevent in _events)
            {
                if (theevent.ID == id)
                {
                    Event = theevent;
                }
            }
            return Event;
        }
        public List<Event> GetAll()
        {
            return _events;
        }

        public void AddEventToLogViaID(int id)
        {
            LoadAllEvents();
            Event Event=GetEventByID(id);
            AddEventToLog(Event);


        }


        public int GiveID(int ThisID)
        {
            _iD++;
            ThisID = _iD;
            SaveFile();
            return ThisID;
        }


        private void LoadFile(string path = "default")
        {
            if (path == "default")
            {
                path = _path;
            }
            else
            {
                path += _path;
            }
            string json = File.ReadAllText(path);

            _iD = JsonSerializer.Deserialize<int>(json);
        }
        private void SaveFile(string path = "default")
        {
            if (path == "default")
            {
                path = _path;
            }
            else
            {
                path += _path;
            }
            File.WriteAllText(path, JsonSerializer.Serialize(_iD));
        }

        private void LoadActivities()
        {
            string path = "Activity.json";
            string json = File.ReadAllText(path);

            _activities = JsonSerializer.Deserialize<List<TheActivity>>(json);
        }

        private void LoadBookings()
        {
            string path = "Booking.json";
            string json = File.ReadAllText(path);

            _bookings = JsonSerializer.Deserialize<List<Booking>>(json);
        }

        private void LoadVets()
        {
            string path = "Veterinarian.json";
            string json = File.ReadAllText(path);

            _vets = JsonSerializer.Deserialize<List<VeterinarianVisit>>(json);
        }
    }
}

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
        //_path is the file name
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
        //Loads all events into the _events lists, if no events makes an empty _events list
        internal void LoadAllEvents()
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

        //Looks at all animals in the Event and sends the event and animal id and the event to AddLog to animal repos
        public void AddEventToLog(Event theevent)
        {

            foreach (Animal animal in theevent.Animals)
            {
                _animalRepo.AddLog(animal.ChipID, theevent);
            }
        }
        //Updates _events list and checks all events for their id and
        //if they match the given id returns that event if not returns an empty event
        public Event GetEventByID(int id)
        {
            LoadAllEvents();
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
        //gets all events
        public List<Event> GetAll()
        {
            return _events;
        }
        //Gets event via id of event and adds to logs of animals
        public void AddEventToLogViaID(int id)
        {
            LoadAllEvents();
            Event Event=GetEventByID(id);
            AddEventToLog(Event);


        }

        //takes the the id from somewhere and returns _iD++ for a unique identifier for the Event.
        public int GiveID(int ThisID)
        {
            _iD++;
            ThisID = _iD;
            SaveFile();
            return ThisID;
        } 

        //Loads id-file into _iD
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

        //Saves _iD into ID.json
        internal void SaveFile(string path = "default")
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
        //Loads all activities from Activity.json file into _activities list
        internal void LoadActivities()
        {
            string path = "Activity.json";
            string json = File.ReadAllText(path);

            _activities = JsonSerializer.Deserialize<List<TheActivity>>(json);
        }
        //Loads all bookings from Booking.json file into _bookings list
        internal void LoadBookings()
        {
            string path = "Booking.json";
            string json = File.ReadAllText(path);

            _bookings = JsonSerializer.Deserialize<List<Booking>>(json);
        }
        //Loads all veterinarian visits from Veterinarian.json file into _vets list
        internal void LoadVets()
        {
            string path = "Veterinarian.json";
            string json = File.ReadAllText(path);

            _vets = JsonSerializer.Deserialize<List<VeterinarianVisit>>(json);
        }
        
        public Animal GetAnimalByID(string id)
        {
            Animal animal = _animalRepo.GetByID(id);

            return animal;
        }
        //public Animal GetCostumerByID(string id)
        //{
        //    Costumer costumer = _costumerRepo.GetByID(id);

        //    return costumer;
        //}
    }
}

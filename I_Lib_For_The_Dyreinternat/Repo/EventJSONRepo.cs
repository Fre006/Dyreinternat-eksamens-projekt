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

namespace Lib.Repo
{
    internal class EventJSONRepo:IEventJSONRepo
    {

        private string _path = "ID.json";
        private List<Event> _events=new List<Event>();
        private List<Booking> _bookings=new List<Booking>();
        private List<VeterinarianVisit> _vets=new List<VeterinarianVisit>();
        private List<Activity> _activities=new List<Activity>();
        private int _iD = 0;

        private IBookingJSONRepository _bookingRepo;
        private IActivityJSONRepository _activityRepo;
        private IVeterinarianJSONRepository _vetRepo;
        private IAnimalRepo _animalRepo;
        public EventJSONRepo(IBookingJSONRepository BookingRepo, IActivityJSONRepository ActivityRepo, IVeterinarianJSONRepository VetRepo, IAnimalRepo AnimalRepo)
        {

            try
            {
                LoadFile();
            }
            catch
            {
                SaveFile();
            }
            _bookingRepo = BookingRepo;
            _bookings = _bookingRepo.GetAll();
            _activityRepo = ActivityRepo;
            _activities = _activityRepo.GetAll();
            _vetRepo = VetRepo;
            _animalRepo = AnimalRepo;
            _vets = _vetRepo.GetAll();
            foreach (VeterinarianVisit vet in _vets)
            {
                _events.Add(vet);
            }
            foreach (Booking booking in _bookings)
            {
                _events.Add(booking);
            }
            foreach (Activity activity in _activities)
            {
                _events.Add(activity);
            }

        }

        public void AddEventToLog(Event theevent)
        {
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

        public void AddEventToLogViaID(int id)
        {
            Event Event=GetEventByID(id);
            if (Event.ID == id)
            {
                AddEventToLog(Event);
            }

        }


        public int GiveID(int ThisID)
        {
            ThisID = _iD;
            _iD++;
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
    }
}

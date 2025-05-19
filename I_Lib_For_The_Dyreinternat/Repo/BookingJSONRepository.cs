using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal class BookingJSONRepository : IBookingJSONRepository
    {
        private IEventJSONRepo _eventRepo;
        public BookingJSONRepository(IEventJSONRepo EventRepo)
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

        public List<Booking> _booking = new List<Booking>();

        public List<Booking> GetAll()
        {
            return _booking;
        }
    }
}

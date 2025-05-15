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
        public BookingJSONRepository()
        {
            LoadFile();
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
            _booking.Add(booking);
            SaveFile();
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

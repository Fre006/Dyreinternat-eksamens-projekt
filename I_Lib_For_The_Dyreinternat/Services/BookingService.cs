using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Repo;

namespace Lib.Services
{
    public class BookingService
    {
        private IBookingJSONRepo _bookingJSONRepo;

        public BookingService(IBookingJSONRepo bookingJSONRepo)
        {
            _bookingJSONRepo = bookingJSONRepo;
        }
        public virtual void Add(Booking booking)
        {
            _bookingJSONRepo.Add(booking);
        }
        public List<Booking> GetAll()
        {
            return (List<Booking>)_bookingJSONRepo;
        }
        public Booking GetByName(string name)
        {
            return _bookingJSONRepo.GetByName(name);
        }

        public int GetIndexById(int id)
        {
            return _bookingJSONRepo.GetIndexById(id);
        }
        public void DeleteById(int id)
        {
            _bookingJSONRepo.DeleteById(id);
        }
        public void Edit(int id, string name, string description, int customerCap, int animalCap, string location, DateTime start, DateTime stop)
        {
            _bookingJSONRepo.Edit(id, name, description, customerCap, animalCap, location, start, stop);
        }
    }
}

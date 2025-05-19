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
        private IBookingJSONRepo _bookingJSONRepository;

        public BookingService(IBookingJSONRepo bookingJSONRepository)
        {
            _bookingJSONRepository = bookingJSONRepository;
        }
        public virtual void Add(Booking booking)
        {
            _bookingJSONRepository.Add(booking);
        }
        public List<Booking> GetAll()
        {
            return (List<Booking>)_bookingJSONRepository;
        }
    }
}

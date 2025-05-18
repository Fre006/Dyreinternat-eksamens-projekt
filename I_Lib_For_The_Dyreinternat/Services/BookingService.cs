using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Repo;

namespace Lib.Services
{
    internal class BookingService
    {
        private IBookingJSONRepository _bookingJSONRepository;

        public BookingService(IBookingJSONRepository bookingJSONRepository)
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

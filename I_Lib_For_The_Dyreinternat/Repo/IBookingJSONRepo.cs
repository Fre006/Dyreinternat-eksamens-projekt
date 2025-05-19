using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public interface IBookingJSONRepo
    {
        public List<Booking> GetAll();
        public void Add(Booking booking);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public interface IVeterinarianJSONRepo
    {
        public List<VeterinarianVisit> GetAll();
        public void Add(VeterinarianVisit veterinarian);
    }
}

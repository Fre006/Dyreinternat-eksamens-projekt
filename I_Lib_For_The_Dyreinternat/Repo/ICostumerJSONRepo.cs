using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public interface ICostumerJSONRepo
    {
        public List<Costumer> GetAll();
        public void Add(Costumer costumer);
    }
}

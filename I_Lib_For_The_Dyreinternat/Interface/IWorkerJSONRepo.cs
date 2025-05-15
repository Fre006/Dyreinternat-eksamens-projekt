using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Interface
{
    public interface IWorkerJSONRepo
    {
        public void Add(Person worker);

        public List<Person> GetAll();
    }
}

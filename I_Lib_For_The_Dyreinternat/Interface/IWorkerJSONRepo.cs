using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I_Lib_For_The_Dyreinternat.Model;

namespace I_Lib_For_The_Dyreinternat.Interface
{
    public interface IWorkerJSONRepo
    {
        public void Add(Person worker);

        public List<Person> GetAll();
    }
}

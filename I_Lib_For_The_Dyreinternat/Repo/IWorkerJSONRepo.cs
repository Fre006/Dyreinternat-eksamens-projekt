using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public interface IWorkerJSONRepo
    {
        public void Add(Worker worker);
        public void Delete(Worker worker);

        public List<Worker> GetAll();

        public Worker GetByID(int id);
        public Worker GetByName(string name);

    }
}

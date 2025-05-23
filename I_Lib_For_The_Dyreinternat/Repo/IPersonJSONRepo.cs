using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public interface IPersonJSONRepo
    {
        public List<Person> GetAll();
        public int GiveID(int ThisID);
        public Person GetByID(int ID);

    }
}

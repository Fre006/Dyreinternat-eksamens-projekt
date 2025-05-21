using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public interface IActivityJSONRepo
    {
        public List<TheActivity> GetAll();
        public void Add(TheActivity activity);
        public void AddNoCostumer(TheActivity activity);
        public void AddNoAnimal(TheActivity activity);
        public void AddOnlyWorker(TheActivity activity);
        public TheActivity GetByName(string name);
        public int GetIndexById(int id);
        public void DeleteById(int id);
        public void Edit(int id, string name, string description, int customerCap, int animalCap, string location, DateTime start, DateTime stop);
    }
}

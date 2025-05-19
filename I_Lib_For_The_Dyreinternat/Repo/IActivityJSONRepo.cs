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
    }
}

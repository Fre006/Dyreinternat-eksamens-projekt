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
        public List<Activity> GetAll();
        public void Add(Activity activity);
        //public void AddNoCostumer(Activity activity);
        //public void AddNoAnimal(Activity activity);
        //public void AddOnlyWorker(Activity activity);
    }
}

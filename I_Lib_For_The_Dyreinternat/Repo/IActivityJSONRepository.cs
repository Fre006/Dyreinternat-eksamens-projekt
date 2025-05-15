using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal interface IActivityJSONRepository
    {
        public List<Activity> GetAll();
        public void Add(Activity activity);
    }
}

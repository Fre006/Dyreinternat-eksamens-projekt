using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal interface IDogRepo
    {
        public List<Dog> GetAll();
        public void Add(Dog dog, string path);
    }
}

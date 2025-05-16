using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal interface ICatRepo
    {
        public List<Cat> GetAll();
        public void Add(Cat cat, string path="default");
        public Cat GetByID(string id);

        public List<Event> GetLogs(string id);
        public void AddLog(string id, Event newentry, string path = "default");
    }
}
